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
            LoggingPayload(dto);
            var data = await loanService.CreateLoanAsync(dto);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetListLoan([FromQuery] QueryParamDto queryParam)
        {
            var data = await loanService.GetLoanPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoan(string id)
        {
            var data = await loanService.GetLoanAsync(id);
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListLoanSchemes([FromQuery] QueryParamDto queryParam)
        {
            var data = await loanService.GetLoanSchemeListAsync(queryParam);
            return Ok(data);
        }

        //Installment
        [HttpGet("[action]")]
        public IActionResult CalculateInstalment([FromQuery]InstSchdlCalculationDto dto)
        {
            LoggingPayload(dto);
            var data = instalmentService.CalculateInstalmentSchdl(dto);
            return Ok(data);
        }

        [HttpGet("[action]/{loanid}")]
        public async Task<IActionResult> GetLoanInstalment(string loanid)
        {
            var data = await instalmentService.GetLoanInstSchdlsAsync(loanid);
            return Ok(data);
        }

        //Loan Document
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLoanDocument([FromForm] LoanDocumentDto dto)
        {
            LoggingPayload(dto);
            if (!dto.DocumentFiles.Any())
                return BadRequest("No File Provided!");

            await loanService.CreateListLoanDocumentAsync(dto);
            return Ok();
        }

        [HttpGet("[action]/{loanid}")]
        public async Task<IActionResult> GetLoanDocument(string loanid)
        {
            var data = await loanService.GetLoanDocumentAsync(loanid);
            return Ok(data);
        }

        //Loan Guarantee
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLoanGuarantee([FromForm] LoanGuaranteeCreateDto dto)
        {
            LoggingPayload(dto);
            await loanService.CreateLoanGuaranteAsync(dto);
            return Ok();
        }
    }
}
