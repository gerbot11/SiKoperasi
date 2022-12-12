using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface ILoanService
    {
        Task<LoanDto> CreateLoanAsync(LoanCreateDto payload);
        Task<LoanDto> GetLoanAsync(string id);
        Task<PagingModel<LoanDto>> GetLoanPagingAsync(QueryParamDto queryParam);
    }
}
