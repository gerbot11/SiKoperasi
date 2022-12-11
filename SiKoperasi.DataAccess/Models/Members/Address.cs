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
        public District District { get; set; }
        public SubDistrict SubDistrict { get; set; }
        public City City { get; set; }
        public Province Province { get; set; }

        public virtual Member Member { get; set; }
    }
}
