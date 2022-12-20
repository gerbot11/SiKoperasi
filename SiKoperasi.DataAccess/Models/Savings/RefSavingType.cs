using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Savings
{
    public class RefSavingType : BaseModel
    {
        public string SavingName { get; set; }
        public decimal MinimalAmountDeposit { get; set; }
        public decimal? CutAmount { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Saving> Savings { get; set; }
    }
}
