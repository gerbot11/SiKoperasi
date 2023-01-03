using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;

namespace SiKoperasi.Web.Controllers
{
    public class SubDistrictController : BaseController<SubDistrictController>
    {
        private readonly ISubDistrictService subDistrictService;
        public SubDistrictController(ILogger<SubDistrictController> logger, ISubDistrictService subDistrictService) : base(logger)
        {
            this.subDistrictService = subDistrictService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var data = await subDistrictService.GetSubDistrictAsync(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaging([FromQuery] QueryParamDto queryParam)
        {
            LoggingPayload(queryParam);
            var data = await subDistrictService.GetSubDistrictPagingAsync(queryParam);
            return Ok(data);
        }
    }
}
