using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class Permission : BaseModel
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
            MenuPermissions = new HashSet<MenuPermission>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;

        public ICollection<RolePermission> RolePermissions { get; set; } = null!;
        public ICollection<MenuPermission> MenuPermissions { get; set; } = null!;
    }
}
