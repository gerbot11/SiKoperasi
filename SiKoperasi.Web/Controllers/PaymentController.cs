using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.AppService.Dto.Saving;

namespace SiKoperasi.Web.Controllers
{
    public class PaymentController : BaseController<PaymentController>
    {
        private readonly ILoanPaymentService loanPaymentService;
        private readonly ISavingTransactionService savingTransactionService;
        public PaymentController(ILogger<PaymentController> logger, ILoanPaymentService loanPaymentService, ISavingTransactionService savingTransactionService) : base(logger)
        {
            this.loanPaymentService = loanPaymentService;
            this.savingTransactionService = savingTransactionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLoanToBePaid([FromQuery] QueryParamDto queryParam)
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

        [HttpPost("[action]")]
        public async Task<IActionResult> SavingTransaction(SavingTransactionCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await savingTransactionService.CreateSavingTransactionAsync(dto);
            return Ok(data);
        }
    }
}
