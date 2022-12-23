using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;

namespace SiKoperasi.Web.Controllers
{
    public class PaymentController : BaseController<PaymentController>
    {
        private readonly ILoanPaymentService loanPaymentService;
        public PaymentController(ILogger<PaymentController> logger, ILoanPaymentService loanPaymentService) : base(logger)
        {
            this.loanPaymentService = loanPaymentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUnpaymentLoan([FromQuery] QueryParamDto queryParam)
        {
            LoggingPayload(queryParam);
            var data = await loanPaymentService.GetPagingLoanToBePaidAsync(queryParam);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoanPayment(LoanPaymentCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await loanPaymentService.CreateLoanPaymentAsync(dto);
            return Ok(data);
        }
    }
}
