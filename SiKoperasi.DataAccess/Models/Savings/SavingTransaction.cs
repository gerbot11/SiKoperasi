using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Savings
{
    public class SavingTransaction : BaseModel
    {
        public string SavingId { get; set; }
        public string TrxNo { get; set; }
        public DateTime TrxDate { get; set; }
        public DateTime TrxValueDate { get; set; }
        public decimal Amount { get; set; }
        public string TrxMethod { get; set; }
        public char TrxType { get; set; }
        public string? Notes { get; set; }

        public virtual Saving Saving { get; set; }

        public const string SAVING_TRX_CODE = "SVT";
    }
}
