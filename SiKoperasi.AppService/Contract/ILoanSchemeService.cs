using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface ILoanSchemeService
    {
        Task<LoanSchemeDto> CreateLoanSchemeAsync(LoanSchemeCreateDto payload);
        Task DeleteLoanSchemeAsync(string id);
        Task<LoanSchemeDto> EditLoanSchemeAsync(LoanSchemeEditDto payload);
        Task<LoanSchemeDto> GetLoanSchemeByIdAsync(string id);
        Task<PagingModel<LoanSchemeDto>> GetLoanSchemeListAsync(QueryParamDto queryParam);
    }
}
