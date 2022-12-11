using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
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

        [HttpPost("newsubdistrict")]
        public async Task<IActionResult> CreateSubDistrict(SubDistrictCreateDto dto)
        {
            await subDistrictService.CreateSubDistrictAsync(dto);
            return Ok(dto);
        }
    }
}
