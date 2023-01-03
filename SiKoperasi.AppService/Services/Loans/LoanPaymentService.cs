using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.Payments;
using static SiKoperasi.AppService.Util.Constant;

namespace SiKoperasi.AppService.Services.Loans
{
    public class LoanPaymentService : BaseService<LoanPayment, LoanPaymentDto, AppDbContext>, ILoanPaymentService
    {
        private readonly IMasterSequenceService masterSequenceService;
        private readonly ICashBankService cashBankService;
        public LoanPaymentService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, ICashBankService cashBankService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
            this.cashBankService = cashBankService;
        }

        public async Task<LoanPaymentDto> CreateLoanPaymentAsync(LoanPaymentCreateDto payload)
        {
            Loan? loan = await dbContext.Loans.FindAsync(payload.LoanId);
            if (loan is null)
                throw new Exception("Loan Data is Not Found");

            InstalmentSchedule? instalment = dbContext.InstalmentSchedules
                .Where(a => a.PayDate == null || a.PayAmount < a.InstAmount && a.LoanId == loan.Id)
                .OrderBy(a => a.SeqNo)
                .FirstOrDefault();

            if (instalment is null)
                throw new Exception("There is no Due instalment");

            LoanPayment loanPayment = mapper.Map<LoanPayment>(payload);
            loanPayment.PaymentNo = masterSequenceService.GenerateNo(LoanPayment.LOAN_PAYMENT_SEQ_CODE);
            loanPayment.IsValid = true;
            loanPayment.InstSeqNo = instalment.SeqNo;

            instalment.PayAmount = loanPayment.Amount;
            instalment.PayDate = DateTime.Now.Date;

            PayHistH payHist = await CreateLoanPayHistory(loanPayment);

            InstalmentSchedule? nextInst = dbContext.InstalmentSchedules.Where(a => a.LoanId == loan.Id && a.SeqNo == loan.NextDueNum).FirstOrDefault();
            if (nextInst is not null)
            {
                loan.CurrentDueNum = nextInst.SeqNo;
                loan.NextDueNum = nextInst.SeqNo + 1;
                loan.NextDueDate = nextInst.InstDate;
            }
            else //kalau lunas
            {
                loan.Status = LOAN_STATUS_RELEASE_DOC;
                loan.CurrentDueNum = 9999;
                loan.NextDueNum = 9999;
                loan.NextDueDate = new DateTime(9999, 1, 1);
            }

            dbContext.Add(loanPayment);
            dbContext.Update(instalment);

            await dbContext.SaveChangesAsync();
            await cashBankService.CreateCashBankTrxAsync(payHist, payload.CashBankAccId);

            return mapper.Map<LoanPaymentDto>(loanPayment);
        }

        public async Task<PagingModel<LoanToBePaidDto>> GetPagingLoanToBePaidAsync(QueryParamDto queryParam)
        {
            var query = from a in dbContext.Loans
                        join b in dbContext.Members on a.MemberId equals b.Id
                        where a.Status == LOAN_STATUS_LIVE
                        select new LoanToBePaidDto
                        {
                            LoanId = a.Id,
                            MemberName = b.Name,
                            LoanNo = a.LoanNo,
                            OverDueDays = a.NextDueDate < DateTime.Now.Date ? (DateTime.Now.Date - a.NextDueDate).Value.Days : 0,
                            InstSchdl = dbContext.InstalmentSchedules
                                .Where(x => x.PayDate == null || x.PayAmount < x.InstAmount)
                                .OrderBy(a => a.SeqNo)
                                .Select(x => new InstSchdlMinimalDto
                                {
                                    InstAmount = x.InstAmount,
                                    InstDate = x.InstDate,
                                    InterestAmount = x.InterestAmount,
                                    PrincipalAmount = x.PrincipalAmount,
                                    SeqNo = x.SeqNo,
                                    LoanId = x.LoanId,
                                    OsInterestAmount = x.OsInterestAmount,
                                    OsPrincipalAmount = x.OsPrincipalAmount
                                }).Where(c => c.LoanId == a.Id).FirstOrDefault()
                        };

            queryParam.OrderBy ??= nameof(LoanToBePaidDto.MemberName);
            queryParam.OrderBehavior ??= Core.Enums.OrderBehaviour.Asc;

            return await PagingModel<LoanToBePaidDto>.CreateAsync(query, queryParam);
        }

        private async Task<PayHistH> CreateLoanPayHistory(LoanPayment loanPayment)
        {
            PayHistH ph = new()
            {
                Amount = loanPayment.Amount,
                TrxCode = LoanPayment.LOAN_PAYMENT_SEQ_CODE,
                TrxDate = DateTime.Now.Date,
                ValueDate = loanPayment.PaymentDate,
                TrxNo = loanPayment.PaymentNo,
                IsReverse = false
            };

            PayHistD pd = new()
            {
                Descr = $"Inst Payment for seq no {loanPayment.InstSeqNo}",
                InstSeqNo = loanPayment.InstSeqNo,
                InAmount = loanPayment.Amount,
                OutAmount = 0,
                PayHistSeqNo = 1
            };

            ph.PayHistDs.Add(pd);
            await dbContext.AddAsync(ph);
            return ph;
        }

        protected override DbSet<LoanPayment> GetAppDbSet()
        {
            return dbContext.LoanPayments;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(LoanPayment.InstSeqNo);
        }

        protected override IQueryable<LoanPayment> SetQueryable()
        {
            return dbContext.LoanPayments
                .Include(a => a.Loan);
        }
    }
}
