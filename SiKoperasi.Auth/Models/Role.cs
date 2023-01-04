using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class Role : BaseModel
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<UserRole>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;

        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
