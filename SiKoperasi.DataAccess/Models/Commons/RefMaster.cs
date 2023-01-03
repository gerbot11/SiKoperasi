using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Commons
{
    public class RefMaster : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Code { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
