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

        [HttpPost("newdistrict")]
        public async Task<IActionResult> CreateDistrict(DistrictCreateDto dto)
        {
            LoggingPayload(dto);
            await districtService.CreateDistrictAsync(dto);
            return Ok(dto);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditDistrict(DistrictEditDto dto)
        {
            LoggingPayload(dto);
            await districtService.EditDistrictAsync(dto);
            return Ok(dto);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteDistrict(string id)
        {
            await districtService.DeleteDistrictAsync(id);
            return NoContent();
        }
    }
}
