using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Payments
{
    public class CashBankAccount : BaseModel
    {
        public CashBankAccount()
        {
            CashBanks = new HashSet<CashBank>();
        }

        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public bool IsDefault { get; set;}
        public bool IsActive { get; set;}
        public bool IsSavingDefault { get; set; }

        public ICollection<CashBank> CashBanks { get; set; }
    }
}
