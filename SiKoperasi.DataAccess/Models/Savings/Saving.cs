using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.Savings
{
    public class Saving : BaseModel
    {
        public Saving()
        {
            SavingTransactions = new HashSet<SavingTransaction>();
        }

        public string MemberId { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public decimal CutAmount { get; set; }
        public string RefSavingTypeId { get; set; } = null!;
        public decimal MonthlyDepositAmount { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual RefSavingType RefSavingType { get; set; } = null!;
        public ICollection<SavingTransaction> SavingTransactions { get; set; }
    }
}
