using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Savings
{
    public class SavingTransaction : BaseModel
    {
        public string SavingId { get; set; } = null!;
        public string TrxNo { get; set; } = null!;
        public DateTime TrxDate { get; set; }
        public DateTime TrxValueDate { get; set; }
        public decimal Amount { get; set; }
        public string TrxMethod { get; set; } = null!;
        public char TrxType { get; set; }
        public string? Notes { get; set; }

        public virtual Saving Saving { get; set; } = null!;
    }
}
