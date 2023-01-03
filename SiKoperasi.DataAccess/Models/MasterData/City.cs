using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class City : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string ProvinceId { get; set; } = null!;

        public virtual Province Province { get; set; } = null!;
        public ICollection<District> Districts { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
