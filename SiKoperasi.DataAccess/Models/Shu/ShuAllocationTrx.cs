using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Shu
{
    public class ShuAllocationTrx : BaseModel
    {
        public ShuAllocationTrx()
        {
            ShuAllocationTrxDists = new HashSet<ShuAllocationTrxDist>();
        }

        public string TrxNo { get; set; } = null!;
        public DateTime TrxDate { get; set; }
        public int YearPeriod { get; set; }
        public decimal TotalAllocation { get; set; }

        public ICollection<ShuAllocationTrxDist> ShuAllocationTrxDists { get; set; } = null!;
    }
}
