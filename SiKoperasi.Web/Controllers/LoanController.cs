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
        private readonly FileUploadController fileUploadController;
        
        public LoanController(ILogger<LoanController> logger, ILoanService loanService, IInstalmentService instalmentService, FileUploadController fileUploadController, IFileUploadExtService fileUploadExtService) : base(logger)
        {
            this.loanService = loanService;
            this.instalmentService = instalmentService;
            this.fileUploadController = fileUploadController;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoan(string id)
        {
            var data = await loanService.GetLoanAsync(id);
            return Ok(data);
        }

        //Installment
        [HttpPost("[action]/{loanid}")]
        public async Task<IActionResult> CalculateInstalment(string loanid)
        {
            var data = await loanService.CalculateLoanInstSchdl(loanid);
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
        public async Task<IActionResult> CreateLoanDocument([FromForm]LoanDocumentDto dto)
        {
            await loanService.CreateLoanDocumentAsync(dto, dto.LoanId);
            return Ok();
        }

        private string BaseUrl()
        {
            var uriBuilder = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}
