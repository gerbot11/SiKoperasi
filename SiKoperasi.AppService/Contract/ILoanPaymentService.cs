using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface ILoanPaymentService
    {
        Task<LoanPaymentDto> CreateLoanPaymentAsync(LoanPaymentCreateDto payload);
        Task<PagingModel<LoanToBePaidDto>> GetPagingLoanToBePaidAsync(QueryParamDto queryParam);
    }
}
