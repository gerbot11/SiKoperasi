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

        public string MemberId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CutAmount { get; set; }
        public string RefSavingTypeId { get; set; }

        public virtual Member Member { get; set; }
        public virtual RefSavingType RefSavingType { get; set; }
        public ICollection<SavingTransaction> SavingTransactions { get; set; }
    }
}
