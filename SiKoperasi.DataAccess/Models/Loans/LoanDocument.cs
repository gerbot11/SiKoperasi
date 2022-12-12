using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanDocument : BaseModel
    {
        public string LoanId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentExt { get; set; }
        public string FileUrl { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
