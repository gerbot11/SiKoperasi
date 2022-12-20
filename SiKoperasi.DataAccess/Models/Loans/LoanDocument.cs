using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanDocument : BaseModel
    {
        public string LoanId { get; set; }
        public string FileName { get; set; }
        public string? FileExt { get; set; }
        public int? FileSize { get; set; }
        public string? FileUrl { get; set; }
        public string RefLoanDocumentId { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual RefLoanDocument RefLoanDocument { get; set; }
    }
}
