using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("newcity")]
        public async Task<IActionResult> CreateCity(CityCreateDto dto)
        {
            LoggingPayload(dto);
            await cityService.CreateCityAsync(dto);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(string id)
        {
            var data = await cityService.GetCityAsync(id);
            return Ok(data);
        }

        [HttpGet()]
        public async Task<IActionResult> GetCityPaging([FromQuery] QueryParamDto dto)
        {
            LoggingPayload(dto);
            var data = await cityService.GetCityPagingAsync(dto);
            return Ok(data);
        }
    }
}
