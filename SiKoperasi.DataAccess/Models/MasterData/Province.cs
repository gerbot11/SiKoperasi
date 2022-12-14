using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class Province : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string TimeZone { get; set; } = null!;

        public ICollection<City> Cities { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
