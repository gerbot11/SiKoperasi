using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;

namespace SiKoperasi.Web.Controllers
{
    public class LoanController : BaseController<LoanController>
    {
        private readonly ILoanService loanService;
        private readonly IInstalmentService instalmentService;
        public LoanController(ILogger<LoanController> logger, ILoanService loanService, IInstalmentService instalmentService) : base(logger)
        {
            this.loanService = loanService;
            this.instalmentService = instalmentService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewLoan(LoanCreateDto dto)
        {
            var data = await loanService.CreateLoanAsync(dto);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetListLoan([FromQuery] QueryParamDto queryParam)
        {
            var data = await loanService.GetLoanPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpPost("[action]/{loanid}")]
        public async Task<IActionResult> CalculateInstalment(string loanid)
        {
            var data = await loanService.CalculateLoanInstSchdl(loanid);
            return Ok(data);
        }
    }
}
