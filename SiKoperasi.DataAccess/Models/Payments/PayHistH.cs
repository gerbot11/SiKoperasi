using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Payments
{
    public class PayHistH : BaseModel
    {
        public PayHistH()
        {
            PayHistDs = new HashSet<PayHistD>();
        }

        public DateTime TrxDate { get; set; }
        public DateTime ValueDate { get; set; }
        public string TrxCode { get; set; }
        public string TrxNo { get; set; }
        public decimal Amount { get; set; }
        public bool IsReverse { get; set; }
        public string? ReverseNotes { get; set; }
        
        public ICollection<PayHistD> PayHistDs { get; set; }
    }
}
