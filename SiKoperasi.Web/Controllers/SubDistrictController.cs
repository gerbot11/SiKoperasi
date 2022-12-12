using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.SubDistrict;

namespace SiKoperasi.Web.Controllers
{
    public class SubDistrictController : BaseController<SubDistrictController>
    {
        private readonly ISubDistrictService subDistrictService;
        public SubDistrictController(ILogger<SubDistrictController> logger, ISubDistrictService subDistrictService) : base(logger)
        {
            this.subDistrictService = subDistrictService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(SubDistrictCreateDto dto)
        {
            LoggingPayload(dto);
            await subDistrictService.CreateSubDistrictAsync(dto);
            return Ok(dto);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(SubDistrictEditDto dto)
        {
            LoggingPayload(dto);
            await subDistrictService.EditSubDistrictAsync(dto);
            return Ok(dto);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await subDistrictService.DeleteSubDistrictAsync(id);
            return NoContent();
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
