using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class InstalmentSchedule : BaseModel
    {
        public string LoanId { get; set; }
        public int SeqNo { get; set; }
        public DateTime InstDate { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal InstAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsInterestAmount { get; set; }
        public decimal? LateChargeAmount { get; set; }

        public Loan Loan { get; set; }
    }
}
