using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class MenuPermission : BaseModel
    {
        public string MenuId { get; set; } = null!;
        public string PermissionId { get; set; } = null!;

        public virtual Menu Menu { get; set; } = null!;
        public virtual Permission Permission { get; set; } = null!;
    }
}
