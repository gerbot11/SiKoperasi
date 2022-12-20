using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Payments
{
    public class PayHistD : BaseModel
    {
        public string PayHistHId { get; set; }
        public int PayHistSeqNo { get; set; }
        public int? InstSeqNo { get; set; }
        public decimal InAmount { get; set; }
        public decimal OutAmount { get; set; }
        public string RefPaymentAllocId { get; set; }

        public virtual PayHistH PayHistH { get; set; }
        public virtual RefPaymentAlloc RefPaymentAlloc { get; set; }
    }
}
