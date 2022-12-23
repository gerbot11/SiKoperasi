using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class UserRole : BaseModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
