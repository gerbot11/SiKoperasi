using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;

namespace SiKoperasi.Web.Controllers
{
    public class ProvinceController : BaseController<ProvinceController>
    {
        private readonly IProvinceService provinceService;
        public ProvinceController(ILogger<ProvinceController> logger, IProvinceService provinceService) : base(logger)
        {
            this.provinceService = provinceService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProvince([FromQuery] QueryParamDto dto)
        {
            LoggingPayload(dto);
            var result = await provinceService.GetProvincePagingAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvinceById(string id)
        {
            var result = await provinceService.GetProvinceAsync(id);
            return Ok(result);
        }
    }
}
