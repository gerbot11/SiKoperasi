using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.City;

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
            await cityService.CreateCityAsync(dto);
            return Ok(dto);
        }
    }
}
