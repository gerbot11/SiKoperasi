using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class District : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CityId { get; set; }

        public virtual City City { get; set; }
        public ICollection<SubDistrict> SubDistricts { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
