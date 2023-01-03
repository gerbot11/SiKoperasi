using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Shu
{
    public class ShuAllocation : BaseModel
    {
        public string ShuName { get; set; } = null!;
        public string? Descr { get; set; }
        public decimal AllocationAmt { get; set; }
        public bool IsExpense { get; set; }
        public bool IsActive { get; set; }
    }
}
