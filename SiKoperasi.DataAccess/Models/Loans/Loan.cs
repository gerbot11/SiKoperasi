using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class Loan : BaseModel
    {
        public string MemberId { get; set; }
        public string LoanNo { get; set; }
        public DateTime LoanDate { get; set; }
        public int? CurrentDueNum { get; set; }
        public int? NextDueNum { get; set; }
        public string LoanSchemeId { get; set; }
        public decimal LoanAmount { get; set; }

        public Member Member { get; set; }
        public LoanScheme LoanScheme { get; set; }
        public ICollection<InstalmentSchedule> InstalmentSchedules { get; set; }
    }
}
