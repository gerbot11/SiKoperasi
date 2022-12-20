using Microsoft.AspNetCore.Http;

namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanDocumentDto
    {
        public string RefLoanDocumentId { get; set; }
        public IFormFile DocumentFiles { get; set; }
    }
}
