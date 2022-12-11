using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class City : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
