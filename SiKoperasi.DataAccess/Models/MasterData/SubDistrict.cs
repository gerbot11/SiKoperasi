using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class SubDistrict : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? PostalCode { get; set; } 
        public string DistrictId { get; set; } = null!;

        public virtual District District { get; set; } = null!; 
        public ICollection<Address> Addresses { get; set; }
    }
}
