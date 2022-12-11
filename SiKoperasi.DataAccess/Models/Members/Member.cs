using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.DataAccess.Models.Members
{
    public class Member : BaseModel
    {
        public string Name { get; set; }
        public string MemberNo { get; set; }
        public string IdNo { get; set; }
        public string IdType { get; set; }
        public bool IsIdVerified { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? NpwpNo { get; set; }
        public bool IsActive { get; set; }

        public virtual Job Job { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Saving> Savings { get; set; }
    }
}
