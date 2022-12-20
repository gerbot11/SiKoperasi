using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Payments
{
    public class RefPaymentAlloc : BaseModel
    {
        public string PayAllocCode { get; set; }
        public string PayAllocName { get; set;}
        public bool IsActive { get; set; }

        public ICollection<PayHistD> PayHistDs { get; set; }
    }
}
