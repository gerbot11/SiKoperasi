using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.CashBank;
using SiKoperasi.AppService.Dto.Common;

namespace SiKoperasi.Web.Controllers
{
    public class CashBankController : BaseController<CashBankController>
    {
        private readonly ICashBankService cashBankService;
        public CashBankController(ILogger<CashBankController> logger, ICashBankService cashBankService) : base(logger)
        {
            this.cashBankService = cashBankService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListCashBankAcc([FromQuery] QueryParamDto queryParam)
        {
            var data = await cashBankService.GetPagingModelAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCashBankAcc(string id)
        {
            var data = await cashBankService.GetCashBankByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCashBank(CashBankAccCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await cashBankService.CreateCashBankAccAsync(dto);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> EditCashBank(CashBankAccDto dto)
        {
            LoggingPayload(dto);
            var data = await cashBankService.EditCashBankAccAsync(dto);
            return Ok(data);
        }
    }
}
