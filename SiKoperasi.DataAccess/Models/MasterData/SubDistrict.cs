using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class SubDistrict : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string PostalCode { get; set; }
        public string DistrictId { get; set; }

        public virtual District District { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
