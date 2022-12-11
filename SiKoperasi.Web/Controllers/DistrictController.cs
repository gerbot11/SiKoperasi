using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
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

        [HttpPost("newdistrict")]
        public async Task<IActionResult> CreateDistrict(DistrictCreateDto dto)
        {
            await districtService.CreateDistrictAsync(dto);
            return Ok(dto);
        }
    }
}
