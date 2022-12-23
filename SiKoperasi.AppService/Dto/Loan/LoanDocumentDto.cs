using Microsoft.AspNetCore.Http;

namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanDocumentDto
    {
        public string LoanId { get; set; }
        public string RefLoanDocumentId { get; set; }
        public IFormFile DocumentFiles { get; set; }
    }
}
