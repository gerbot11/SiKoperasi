using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.Common;

namespace SiKoperasi.Web.Controllers
{
    public class CityController : BaseController<CityController>
    {
        private readonly ICityService cityService;
        public CityController(ILogger<CityController> logger, ICityService cityService) : base(logger)
        {
            this.cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(string id)
        {
            var data = await cityService.GetCityAsync(id);
            return Ok(data);
        }

        [HttpGet("[action]/{provinceid}")]
        public async Task<IActionResult> GetCityByProvince(string provinceid, [FromQuery] QueryParamDto queryParam)
        {
            var data = await cityService.GetListCityByProvinceAsync(provinceid, queryParam);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCityPaging([FromQuery] QueryParamDto dto)
        {
            LoggingPayload(dto);
            var data = await cityService.GetCityPagingAsync(dto);
            return Ok(data);
        }
    }
}
