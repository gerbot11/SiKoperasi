using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Savings
{
    public class SavingTransaction : BaseModel
    {
        public string SavingId { get; set; }
        public string TrNo { get; set; }
        public DateTime TrDate { get; set; }
        public decimal Amount { get; set; }
        public string TrMethod { get; set; }
        public string? Notes { get; set; }

        public virtual Saving Saving { get; set; }
    }
}
