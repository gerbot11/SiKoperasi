using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanDocument : BaseModel
    {
        public string LoanId { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string? FileExt { get; set; } = null!;
        public int? FileSize { get; set; }
        public string? FileUrl { get; set; }
        public string RefLoanDocumentId { get; set; } = null!;

        public virtual Loan Loan { get; set; } = null!;
        public virtual RefLoanDocument RefLoanDocument { get; set; } = null!;
    }
}
