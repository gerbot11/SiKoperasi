using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Approval;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Auth.Services;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    [ServiceFilter(typeof(PermissionFilterAttribute))]
    public class ApprovalController : BaseController<ApprovalController>
    {
        private readonly IApprovalService approvalService;
        private readonly ILoanService loanService;
        private readonly UserResolverService userResolverService;
        public ApprovalController(ILogger<ApprovalController> logger, IApprovalService approvalService, ILoanService loanService, UserResolverService userResolverService) : base(logger)
        {
            this.approvalService = approvalService;
            this.userResolverService = userResolverService;
            this.loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApprovalList([FromQuery] QueryParamDto queryParam)
        {
            var data = await approvalService.GetApprovalReqPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ClaimApproval(ApprovalDto dto)
        {
            var currUser = userResolverService.GetCurrentUser();
            if (string.IsNullOrEmpty(currUser.Username))
                return BadRequest("No Active User");

            var data = await approvalService.ClaimApprovalTaskAsync(dto, currUser.Username);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Approve(ApprovalProcessDto dto)
        {
            await approvalService.ProcessApprovalAsync(dto);
            await loanService.UpdateLoanAfterApproveAsync(dto.TrxNo, dto.ApvStat);
            return Ok();
        }
    }
}
