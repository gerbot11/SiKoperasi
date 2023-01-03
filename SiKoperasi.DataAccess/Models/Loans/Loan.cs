using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;
using SiKoperasi.DataAccess.Models.Shu;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class Loan : BaseModel
    {
        public Loan() 
        {
            InstalmentSchedules = new HashSet<InstalmentSchedule>();
            LoanDocuments = new HashSet<LoanDocument>();
            LoanPayments = new HashSet<LoanPayment>();
            LoanGuarantees = new HashSet<LoanGuarantee>();
        }

        public string MemberId { get; set; }
        public string LoanNo { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int? CurrentDueNum { get; set; }
        public int? NextDueNum { get; set; }
        public int LoanDueNum { get; set; }
        public string LoanSchemeId { get; set; }
        public decimal LoanAmount { get; set; }
        public string Status { get; set; }
        public string? LoanPurpose { get; set; }
        public DateTime? GoLiveDate { get; set; }
        public DateTime? NextDueDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual LoanScheme LoanScheme { get; set; }
        public ICollection<InstalmentSchedule> InstalmentSchedules { get; set; }
        public ICollection<LoanDocument> LoanDocuments { get; set; }
        public ICollection<LoanPayment> LoanPayments { get; set; }
        public ICollection<LoanGuarantee> LoanGuarantees { get; set; }
    }
}
