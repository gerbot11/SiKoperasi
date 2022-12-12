using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Services.Loans
{
    public class LoanService : BaseCrudService<Loan, LoanCreateDto, LoanEditDto, LoanDto, AppDbContext>, ILoanService
    {
        private readonly IMasterSequenceService masterSequenceService;
        public LoanService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
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

        #region Override Base Method
        protected override async Task<PagingModel<LoanDto>> GetPagingDataDtoAsync(IQueryParam queryParam)
        {
            IQueryable<LoanDto> query = from a in dbContext.Loans
                                        join b in dbContext.Members on a.MemberId equals b.Id
                                        let c = dbContext.Addresses.FirstOrDefault(a => a.AddressType.ToLower() == "legal" && a.MemberId == b.Id)
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
                                            MemberAddress = c.Description
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
            throw new NotImplementedException();
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
            return;
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
