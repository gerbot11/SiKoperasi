using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class Permission : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
