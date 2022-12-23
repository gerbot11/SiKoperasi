using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class RolePermission : BaseModel
    {
        public string RoleId { get; set; }
        public string PermissionId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
