using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.Savings;
using SiKoperasi.DataAccess.Models.Shu;

namespace SiKoperasi.DataAccess.Models.Members
{
    public class Member : BaseModel
    {
        public Member()
        {
            Savings = new HashSet<Saving>();
            Loans = new HashSet<Loan>();
            ShuAllocationMembers = new HashSet<ShuAllocationMember>();
        }

        public string Name { get; set; } = null!;
        public string MemberNo { get; set; } = null!;
        public string IdNo { get; set; } = null!;
        public string IdType { get; set; } = null!;
        public bool IsIdVerified { get; set; }
        public string Gender { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? NpwpNo { get; set; }
        public bool IsActive { get; set; }
        public string MartialStat { get; set; } = null!;
        public string EmployeeNo { get; set; } = null!;
        public string? PhotoUrl { get; set; }

        public virtual Job Job { get; set; }
        public virtual Address Address { get; set; }

        public ICollection<Loan> Loans { get; set; }
        public ICollection<Saving> Savings { get; set; }
        public ICollection<ShuAllocationMember> ShuAllocationMembers { get; set; }
    }
}
