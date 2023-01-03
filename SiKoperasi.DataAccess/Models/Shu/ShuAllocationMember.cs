using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.Shu
{
    public class ShuAllocationMember : BaseModel
    {
        public string ShuAllocationTrxDistId { get; set; } = null!;
        public string MemberId { get; set; } = null!;
        public decimal AllocationAmount { get; set; }
        public decimal AllocationPrcnt { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ShuAllocationTrxDist ShuAllocationTrxDist { get; set; } = null!;
    }
}
