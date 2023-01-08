using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    //[ServiceFilter(typeof(PermissionFilterAttribute))]
    public class SavingController : BaseController<SavingController>
    {
        private readonly ISavingService savingService;
        private readonly ISavingTransactionService savingTransactionService;
        private readonly IRefSavingService refSavingService;
        public SavingController(ILogger<SavingController> logger, ISavingService savingService, ISavingTransactionService savingTransactionService, IRefSavingService refSavingService) : base(logger)
        {
            this.savingService = savingService;
            this.savingTransactionService = savingTransactionService;
            this.refSavingService = refSavingService;
        }

        [HttpGet("membersaving")]
        public async Task<IActionResult> GetMemberSavingsList([FromQuery] QueryParamDto queryParam)
        {
            var data = await savingService.GetSavingPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("membersaving/{memberid}")]
        public async Task<IActionResult> GetMemberSavings(string memberid)
        {
            var data = await savingService.GetMemberSavingAsync(memberid);
            return Ok(data);
        }

        [HttpGet("membersaving/transaction")]
        public async Task<IActionResult> GetSavingTransaction(string savingid, [FromQuery] QueryParamDto queryParam)
        {
            var data = await savingTransactionService.GetPagingModelAsync(queryParam, savingid);
            return Ok(data);
        }

        #region SAVING TYPE
        [HttpGet("savingtype")]
        public async Task<IActionResult> GetListSavingType([FromQuery] QueryParamDto queryParam)
        {
            var data = await refSavingService.GetSavingTypePagingAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("savingtype/{id}")]
        public async Task<IActionResult> GetSavingType(string id)
        {
            var data = await refSavingService.GetSavingTypeById(id);
            return Ok(data);
        }

        [HttpPost("savingtype")]
        public async Task<IActionResult> CreateSavingType(RefSavingTypeCreateDto dto)
        {
            var data = await refSavingService.CreateSavingTypeAsync(dto);
            return Ok(data);
        }

        [HttpPut("savingtype")]
        public async Task<IActionResult> EditSavingType(RefSavingTypeEditDto dto)
        {
            var data = await refSavingService.EditSavingTypeAsync(dto);
            return Ok(data);
        }

        [HttpDelete("savingtype/{id}")]
        public async Task<IActionResult> DeleteSavingType(string id)
        {
            await refSavingService.DeleteSavingTypeAsync(id);
            return NoContent();
        }
        #endregion
    }
}
