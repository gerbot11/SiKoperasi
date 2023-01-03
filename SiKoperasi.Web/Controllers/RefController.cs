using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;

namespace SiKoperasi.Web.Controllers
{
    [Route("api/mdata")]
    public class RefController : BaseController<RefController>
    {
        private readonly IRefService refService;
        public RefController(ILogger<RefController> logger, IRefService refService) : base(logger)
        {
            this.refService = refService;
        }

        #region Ref Loan Document
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRefLoanDoc(RefLoanDocCreateDto dto)
        {
            var data = await refService.CreateRefLoanDocAsync(dto);
            return Ok(data);
        }
        #endregion

        #region Ref Master
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListRefMaster([FromQuery] QueryParamDto queryParam)
        {
            var data = await refService.GetListRefMasterAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRefMaster(string code)
        {
            var data = await refService.GetRefMasterValueByCodeAsync(code);
            return Ok(data);
        }
        #endregion
    }
}
