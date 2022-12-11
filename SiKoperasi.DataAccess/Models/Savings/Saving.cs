using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.DataAccess.Models.Savings
{
    public class Saving : BaseModel
    {
        public string MemberId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string SavingType { get; set; }
        public string TransactionType { get; set; }

        public virtual Member Member { get; set; }
    }
}
