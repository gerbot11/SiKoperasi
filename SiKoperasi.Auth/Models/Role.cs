using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class Role : BaseModel
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
