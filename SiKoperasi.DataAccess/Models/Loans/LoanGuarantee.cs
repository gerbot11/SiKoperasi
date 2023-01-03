using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanGuarantee : BaseModel
    {
        public string LoanId { get; set; } = null!;
        public string GuaranteeName { get; set; } = null!;
        public string GuaranteeType { get; set; } = null!;
        public string? LetterNo { get; set; }
        public string? OwnerName { get; set; }
        public DateTime? LetterDate { get; set; }
        public DateTime? LetterExpDate { get; set; }
        public string FileUrl { get; set; } = null!;

        public virtual Loan Loan { get; set; } = null!;
    }
}
