using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Shu
{
    public class ShuAllocationTrxDist : BaseModel
    {
        public ShuAllocationTrxDist()
        {
            ShuAllocationMembers = new HashSet<ShuAllocationMember>();
        }

        public string ShuAllocationTrxId { get; set; } = null!;
        public string ShuAllocationId { get; set; } = null!;
        public decimal AllocationAmt { get; set; }
        public decimal AllocationPrcnt { get; set; }

        public virtual ShuAllocationTrx ShuAllocationTrx { get; set; } = null!;
        public virtual ShuAllocation ShuAllocation { get; set; } = null!;
        public ICollection<ShuAllocationMember> ShuAllocationMembers { get; set; } = null!;
    }
}
