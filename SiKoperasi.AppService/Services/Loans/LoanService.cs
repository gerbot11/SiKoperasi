using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Services.Loans
{
    public class LoanService : BaseCrudService<Loan, LoanCreateDto, LoanEditDto, LoanDto, AppDbContext>, ILoanService
    {
        private readonly IMasterSequenceService masterSequenceService;
        private readonly IInstalmentService instalmentService;
        public LoanService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, IInstalmentService instalmentService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
            this.instalmentService = instalmentService;
        }

        public async Task<LoanDto> GetLoanAsync(string id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<PagingModel<LoanDto>> GetLoanPagingAsync(QueryParamDto queryParam)
        {
            return await GetPagingDataDtoAsync(queryParam);
        }

        public async Task<LoanDto> CreateLoanAsync(LoanCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task<List<InstSchdlDto>> CalculateLoanInstSchdl(string loanid)
        {
            Loan? loan = await dbContext.Loans.FindAsync(loanid);
            if (loan is null)
            {
                throw new Exception("Loan Data Is Not Found");
            }

            List<InstalmentSchedule> oldInstSchdl = dbContext.InstalmentSchedules.Where(a => a.LoanId == loanid).ToList();
            if (oldInstSchdl.Any())
            {
                for (int i = 0; i < oldInstSchdl.Count; i++)
                {
                    dbContext.InstalmentSchedules.Remove(oldInstSchdl[i]);
                }
            }

            loan.LoanScheme = dbContext.LoanSchemes.First(a => a.Id == loan.LoanSchemeId);
            var listInstSchdl = instalmentService.CalculateInstalmentSchdl(loan);

            loan.InstalmentSchedules = listInstSchdl;
            dbContext.Loans.Update(loan);
            await dbContext.SaveChangesAsync();

            var listDto = (from a in listInstSchdl
                           select new InstSchdlDto
                           {
                               InstAmount = a.InstAmount,
                               InstDate = a.InstDate,
                               InterestAmount = a.InterestAmount,
                               PrincipalAmount = a.PrincipalAmount,
                               OsInterestAmount = a.OsInterestAmount,
                               OsPrincipalAmount = a.OsPrincipalAmount,
                               SeqNo = a.SeqNo
                           }).ToList();

            return listDto;
        }

        #region Override Base Method
        protected override async Task<PagingModel<LoanDto>> GetPagingDataDtoAsync(IQueryParam queryParam)
        {
            IQueryable<LoanDto> query = from a in dbContext.Loans
                                        join b in dbContext.Members on a.MemberId equals b.Id
                                        let c = dbContext.Addresses.FirstOrDefault(a => a.AddressType.ToLower() == "legal" && a.MemberId == b.Id)
                                        where a.Status == Loan.LOAN_STATUS_NEW || a.Status == Loan.LOAN_STATUS_RETURN
                                        select new LoanDto
                                        {
                                            Id = a.Id,
                                            CurrentDueNum = a.CurrentDueNum,
                                            LoanAmount = a.LoanAmount,
                                            LoanDate = a.LoanDate,
                                            LoanNo = a.LoanNo,
                                            LoanSchemeId = a.LoanSchemeId,
                                            NextDueNum = a.NextDueNum,
                                            MemberId = a.MemberId,
                                            MemberName = b.Name,
                                            MemberAddress = c.Description,
                                            EffectiveDate = a.EffectiveDate,
                                            Status = a.Status
                                        };

            return await PagingModel<LoanDto>.CreateAsync(query, queryParam);
        }
        #endregion

        #region Abstract Impl
        protected override Loan CreateNewModel(LoanCreateDto payload)
        {
            Loan loan = mapper.Map<Loan>(payload);
            loan.LoanNo = masterSequenceService.GenerateNo(Loan.LOAN_SEQ_CODE);
            loan.Status = Loan.LOAN_STATUS_NEW;

            return loan;
        }

        protected override DbSet<Loan> GetAppDbSet()
        {
            return dbContext.Loans;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Loan.DtmUpd);
        }

        protected override void SetModelValue(Loan model, LoanEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Loan> SetQueryable()
        {
            return dbContext.Loans;
        }

        protected override void ValidateCreate(Loan model)
        {
            LoanScheme? loanScheme = dbContext.LoanSchemes.FirstOrDefault(a => a.Id == model.LoanSchemeId);
            if (loanScheme is null)
                throw new Exception("Loan Scheme Not Exist");

            if (model.LoanAmount > loanScheme.PlafondAmount)
                throw new Exception($"Jumlah pinjaman melebihi Palfond : {loanScheme.PlafondAmount}");

            if (model.LoanDueNum > loanScheme.DueNum)
                throw new Exception("Jumlah Angsuran pinjaman melebihi Scheme");

            bool member = dbContext.Members.Any(a => a.Id == model.MemberId);
            if (!member)
                throw new Exception("Member Not Exist");
        }

        protected override void ValidateDelete(Loan model)
        {
            return;
        }

        protected override void ValidateEdit(Loan model)
        {
            return;
        }
        #endregion
    }
}
