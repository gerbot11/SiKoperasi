using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.DataAccess.Models.Members
{
    public class Address : BaseModel
    {
        public string MemberId { get; set; } = null!;
        public string AddressType { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Rt { get; set; } = null!;
        public string Rw { get; set; } = null!;
        public string ProvinceId { get; set; } = null!;
        public string CityId { get; set; } = null!;
        public string DistrictId { get; set; } = null!;
        public string SubDistrictId { get; set; } = null!;

        public virtual District District { get; set; } = null!;
        public virtual SubDistrict SubDistrict { get; set; } = null!;
        public virtual City City { get; set; } = null!; 
        public virtual Province Province { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
