using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class UserRole : BaseModel
    {
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
