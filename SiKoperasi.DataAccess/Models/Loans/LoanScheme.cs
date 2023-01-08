using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class LoanScheme : BaseModel
    {
        public string LoanSchemeName { get; set; } = null!;
        public decimal PlafondAmount { get; set; }
        public int DueNum { get; set; }
        public decimal Rate { get; set; }
        //public decimal LateChargeRate { get; set; }
        public bool IsUseGuarantee { get; set; }
        public string ApprovalSchemeCode { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
