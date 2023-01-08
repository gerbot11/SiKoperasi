using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    [ServiceFilter(typeof(PermissionFilterAttribute))]
    public class LoanController : BaseController<LoanController>
    {
        private readonly ILoanService loanService;
        private readonly IInstalmentService instalmentService;
        private readonly IUserResolverService userResolverService;
        private readonly ILoanSchemeService loanSchemeService;

        private const string REST_DOCUMENT = "document";
        private const string REST_SCHEME = "scheme";
        private const string REST_GUARANTEE = "guarantee";
        public LoanController(ILogger<LoanController> logger, ILoanService loanService, IInstalmentService instalmentService, IUserResolverService userResolverService, ILoanSchemeService loanSchemeService) : base(logger)
        {
            this.loanService = loanService;
            this.instalmentService = instalmentService;
            this.userResolverService = userResolverService;
            this.loanSchemeService = loanSchemeService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewLoan(LoanCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await loanService.CreateLoanAsync(dto);
            return Ok(data);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditLoan(LoanEditDto dto)
        {
            LoggingPayload(dto);
            var data = await loanService.EditLoanAsync(dto);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SubmitLoan(string id)
        {
            var currUser = userResolverService.GetCurrentUser();
            if (string.IsNullOrEmpty(currUser.Username))
                return BadRequest("No Active User");

            await loanService.SubmitFinalLoanAsync(id, currUser.Username);
            return Ok();
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

        [HttpGet(REST_DOCUMENT + "/{loanid}")]
        public async Task<IActionResult> GetLoanDocument(string loanid)
        {
            var data = await loanService.GetLoanDocumentAsync(loanid);
            return Ok(data);
        }

        [HttpPut(REST_DOCUMENT)]
        public async Task<IActionResult> EditLoanDocument([FromForm] LoanDocumentEditDto dto)
        {
            LoggingPayload(dto);
            await loanService.EditLoanDocumentAsync(dto);
            return Ok();
        }

        //Loan Guarantee
        [HttpPost(REST_GUARANTEE)]
        public async Task<IActionResult> CreateLoanGuarantee([FromForm] LoanGuaranteeCreateDto dto)
        {
            LoggingPayload(dto);
            await loanService.CreateLoanGuaranteAsync(dto);
            return Ok();
        }

        #region Loan Scheme
        [HttpPost(REST_SCHEME)]
        public async Task<IActionResult> CreateLoanScheme(LoanSchemeCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await loanSchemeService.CreateLoanSchemeAsync(dto);
            return Ok(data);
        }

        [HttpPut(REST_SCHEME)]
        public async Task<IActionResult> EditLoanScheme(LoanSchemeEditDto dto)
        {
            LoggingPayload(dto);
            var data = await loanSchemeService.EditLoanSchemeAsync(dto);
            return Ok(data);
        }

        [HttpDelete(REST_SCHEME + "/{id}")]
        public async Task<IActionResult> DeleteLoanScheme(string id)
        {
            await loanSchemeService.DeleteLoanSchemeAsync(id);
            return NoContent();
        }

        [HttpGet(REST_SCHEME + "/{id}")]
        public async Task<IActionResult> GetLoanScheme(string id)
        {
            var data = await loanSchemeService.GetLoanSchemeByIdAsync(id);
            return Ok(data);
        }

        [HttpGet(REST_SCHEME)]
        public async Task<IActionResult> GetListLoanSchemes([FromQuery] QueryParamDto queryParam)
        {
            var data = await loanSchemeService.GetLoanSchemeListAsync(queryParam);
            return Ok(data);
        }
        #endregion
    }
}
