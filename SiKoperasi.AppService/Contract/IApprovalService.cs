using SiKoperasi.AppService.Dto.Approval;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface IApprovalService
    {
        Task<ApprovalLoanDetailDto> ClaimApprovalTaskAsync(ApprovalDto payload, string currentUser);
        Task CreateNewApvRequestAsync(ApprovalReqDto reqDto);
        Task<PagingModel<ApprovalDto>> GetApprovalReqPagingAsync(QueryParamDto queryParam);
        Task ProcessApprovalAsync(ApprovalProcessDto payload);
    }
}
