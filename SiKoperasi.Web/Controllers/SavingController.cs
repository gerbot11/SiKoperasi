using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;

namespace SiKoperasi.Web.Controllers
{
    public class SavingController : BaseController<SavingController>
    {
        private readonly ISavingService savingService;
        private readonly ISavingTransactionService savingTransactionService;
        public SavingController(ILogger<SavingController> logger, ISavingService savingService, ISavingTransactionService savingTransactionService) : base(logger)
        {
            this.savingService = savingService;
            this.savingTransactionService = savingTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberSavingsList([FromQuery] QueryParamDto queryParam)
        {
            var data = await savingService.GetSavingPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("[action]/{memberid}")]
        public async Task<IActionResult> GetMemberSavings(string memberid)
        {
            var data = await savingService.GetMemberSavingAsync(memberid);
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSavingTransaction(string savingid, [FromQuery] QueryParamDto queryParam)
        {
            var data = await savingTransactionService.GetPagingModelAsync(queryParam, savingid);
            return Ok(data);
        }
    }
}
