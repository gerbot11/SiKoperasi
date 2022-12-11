using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanScheme : BaseModel
    {
        public string LoanSchemeName { get; set; }
        public decimal PlafondAmount { get; set; }
        public int DueNum { get; set; }
        public decimal Rate { get; set; }
    }
}
