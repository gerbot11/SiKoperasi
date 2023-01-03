using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanPayment : BaseModel
    {
        public string PaymentNo { get; set; } = null!;
        public decimal Amount { get; set; }
        public int InstSeqNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsValid { get; set; }
        public string Wop { get; set; } = null!;
        public string LoanId { get; set; } = null!;

        public virtual Loan Loan { get; set; } = null!;

        public const string LOAN_PAYMENT_SEQ_CODE = "LPY";
    }
}
