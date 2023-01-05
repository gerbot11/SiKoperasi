using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Shu;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    [ServiceFilter(typeof(PermissionFilterAttribute))]
    public class ShuController : BaseController<ShuController>
    {
        private readonly IShuService shuService;
        private readonly IShuTrxService shuTrxService;
        public ShuController(ILogger<ShuController> logger, IShuService shuService, IShuTrxService shuTrxService) : base(logger)
        {
            this.shuService = shuService;
            this.shuTrxService = shuTrxService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShu(string id)
        {
            var data = await shuService.GetShuByIdAsync(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagingShu([FromQuery] QueryParamDto queryParam)
        {
            var data = await shuService.GetShuPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShuCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await shuService.CreateShuAsync(dto);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ShuEditDto dto)
        {
            LoggingPayload(dto);
            var data = await shuService.EditShuAsync(dto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await shuService.DeleteShuAsync(id);
            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> TestShuCalc()
        {
            await shuTrxService.CalculateShuDistAsync();
            return Ok();
        }
    }
}
