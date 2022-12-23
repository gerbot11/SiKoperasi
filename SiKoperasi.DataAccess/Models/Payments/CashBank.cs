using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Payments
{
    public class CashBank : BaseModel
    {
        public CashBank()
        {
            CashBankTrxes = new HashSet<CashBankTrx>();
        }

        public string CashBankAccountId { get; set; }
        public DateTime TrxDate { get; set; }
        public decimal BeginBalance { get; set; }
        public decimal EndBalance { get; set; }

        public virtual CashBankAccount CashBankAccount { get; set; }
        public ICollection<CashBankTrx> CashBankTrxes { get; set; }
    }
}
