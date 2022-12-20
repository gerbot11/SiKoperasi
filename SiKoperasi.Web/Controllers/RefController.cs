using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Loan;

namespace SiKoperasi.Web.Controllers
{
    public class RefController : BaseController<RefController>
    {
        private readonly IRefService refService;
        public RefController(ILogger<RefController> logger, IRefService refService) : base(logger)
        {
            this.refService = refService;
        }

        #region Ref Loan Document
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRefLoanDoc(RefLoanDocCreateDto dto)
        {
            var data = await refService.CreateRefLoanDocAsync(dto);
            return Ok(data);
        }
        #endregion
    }
}
