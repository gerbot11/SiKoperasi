using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Payments
{
    public class CashBankTrx : BaseModel
    {
        public string CashBankId { get; set; } = null!;
        public decimal InAmount { get; set; }
        public decimal OutAmount { get; set; }
        public string TrxNo { get; set; } = null!;
        public string? Description { get; set; }

        public virtual CashBank CashBank { get; set; } = null!;
    }
}
