using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class Loan : BaseModel
    {
        public Loan() 
        {
            InstalmentSchedules = new HashSet<InstalmentSchedule>();
            LoanDocuments= new HashSet<LoanDocument>();
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
        //public string TypeOfPay { get; set; }

        public virtual Member Member { get; set; }
        public virtual LoanScheme LoanScheme { get; set; }
        public ICollection<InstalmentSchedule> InstalmentSchedules { get; set; }
        public ICollection<LoanDocument> LoanDocuments { get; set; }

        public const string LOAN_STATUS_NEW = "NEW";
        public const string LOAN_STATUS_ONCHECK = "CHK";
        public const string LOAN_STATUS_LIVE = "LIV";
        public const string LOAN_STATUS_RETURN = "RET";

        public const string LOAN_SEQ_CODE = "LOS";
    }
}
