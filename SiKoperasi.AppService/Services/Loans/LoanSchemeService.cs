using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Services.Loans
{
    public class LoanSchemeService : BaseCrudService<LoanScheme, LoanSchemeCreateDto, LoanSchemeEditDto, LoanSchemeDto, AppDbContext>, ILoanSchemeService
    {
        public LoanSchemeService(AppDbContext dbContext, IMapper mapper, ILogger<LoanScheme> logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<PagingModel<LoanSchemeDto>> GetLoanSchemeListAsync(QueryParamDto queryParam)
        {
            IQueryable<LoanSchemeDto> query = dbContext.LoanSchemes.OrderBy(a => a.LoanSchemeName).Select(a => mapper.Map<LoanSchemeDto>(a));
            return await BaseGetPagingCustomResultAsync(queryParam, query);
        }

        public async Task<LoanSchemeDto> GetLoanSchemeByIdAsync(string id) => await BaseGetByIdAsync(id);
        public async Task<LoanSchemeDto> CreateLoanSchemeAsync(LoanSchemeCreateDto payload) => await BaseCreateAsync(payload);
        public async Task<LoanSchemeDto> EditLoanSchemeAsync(LoanSchemeEditDto payload) => await BaseEditAsync(payload.Id, payload);
        public async Task DeleteLoanSchemeAsync(string id) => await BaseSafeDeleteAsync(id);

        protected override LoanScheme CreateNewModel(LoanSchemeCreateDto payload)
        {
            LoanScheme loanScheme = mapper.Map<LoanScheme>(payload);
            loanScheme.IsActive = true;
            return loanScheme;
        }

        protected override DbSet<LoanScheme> GetAppDbSet()
        {
            return dbContext.LoanSchemes;
        }

        protected override LoanSchemeDto MappingToResultCrud(LoanScheme model)
        {
            return base.MappingToResult(model);
        }

        protected override string SetDefaultOrderField()
        {
            throw new NotImplementedException();
        }

        protected override void SetModelValue(LoanScheme model, LoanSchemeEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<LoanScheme> SetQueryable()
        {
            return GetAppDbSet().Where(a => a.IsActive);
        }

        protected override void ValidateCreate(LoanScheme model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateDelete(LoanScheme model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(LoanScheme model)
        {
            throw new NotImplementedException();
        }
    }
}
