using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.District;

namespace SiKoperasi.Web.Controllers
{
    public class DistrictController : BaseController<DistrictController>
    {
        private readonly IDistrictService districtService;
        public DistrictController(ILogger<DistrictController> logger, IDistrictService districtService) : base(logger)
        {
            this.districtService = districtService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistrict(string id)
        {
            var data = await districtService.GetDistrictAsync(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDistrictPaging([FromQuery] QueryParamDto queryParam)
        {
            LoggingPayload(queryParam);
            var data = await districtService.GetDistrictPagingAsync(queryParam);
            return Ok(data);
        }
    }
}
