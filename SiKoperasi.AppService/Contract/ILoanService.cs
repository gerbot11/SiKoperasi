using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface ILoanService
    {
        Task CheckOnDueLoanAsync();
        Task CreateListLoanDocumentAsync(LoanDocumentDto payloads);
        Task<LoanDto> CreateLoanAsync(LoanCreateDto payload);
        //Task CreateLoanDocumentAsync(LoanDocumentDto payload, string loanid);
        Task CreateLoanGuaranteAsync(LoanGuaranteeCreateDto payload);
        Task<LoanDto> EditLoanAsync(LoanEditDto payload);
        Task EditLoanDocumentAsync(LoanDocumentEditDto payload);
        Task<LoanDto> GetLoanAsync(string id);
        Task<IEnumerable<LoanDocumentViewDto>> GetLoanDocumentAsync(string loanid);
        Task<PagingModel<LoanDto>> GetLoanPagingAsync(QueryParamDto queryParam);
        Task SubmitFinalLoanAsync(string id, string currUser);
        Task UpdateLoanAfterApproveAsync(string loanNo, string apvStat);
    }
}
