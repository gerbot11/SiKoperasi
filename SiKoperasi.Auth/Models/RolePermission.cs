using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class RolePermission : BaseModel
    {
        public string RoleId { get; set; } = null!;
        public string PermissionId { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual Permission Permission { get; set; } = null!;
    }
}
