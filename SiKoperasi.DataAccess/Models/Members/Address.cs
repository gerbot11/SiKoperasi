using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.DataAccess.Models.Members
{
    public class Address : BaseModel
    {
        public string MemberId { get; set; }
        public string AddressType { get; set; }
        public string Description { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string SubDistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual SubDistrict SubDistrict { get; set; }
        public virtual City City { get; set; }
        public virtual Province Province { get; set; }
        public virtual Member Member { get; set; }
    }
}
