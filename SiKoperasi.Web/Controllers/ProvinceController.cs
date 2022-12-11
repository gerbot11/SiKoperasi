using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Province;

namespace SiKoperasi.Web.Controllers
{
    public class ProvinceController : BaseController<ProvinceController>
    {
        private readonly IProvinceService provinceService;
        public ProvinceController(ILogger<ProvinceController> logger, IProvinceService provinceService) : base(logger)
        {
            this.provinceService = provinceService;
        }

        [HttpGet("province")]
        public async Task<IActionResult> GetProvince([FromQuery] QueryParamDto dto)
        {
            var result = await provinceService.GetProvincePagingAsync(dto);
            return Ok(result);
        }

        [HttpGet("province/{id}")]
        public async Task<IActionResult> GetProvinceById(string id)
        {
            var result = await provinceService.GetProvinceAsync(id);
            return Ok(result);
        }

        [HttpPost("newprovince")]
        public async Task<IActionResult> NewProvince(ProvinceCreateDto dto)
        {
            await provinceService.CreateProvinceAsync(dto);
            return Ok(dto);
        }

        [HttpPut("editprovince")]
        public async Task<IActionResult> EditProvince(ProvinceEditDto dto)
        {
            await provinceService.EditProvinceAsync(dto);
            return Ok();
        }

        [HttpDelete("deleteprovince/{id}")]
        public async Task<IActionResult> DeleteProvince(string id)
        {
            await provinceService.DeleteProvinceAsync(id);
            return Ok();
        }
    }
}
