using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Approvals
{
    public class ApvReq : BaseModel
    {
        public ApvReq()
        {
            ApvReqTasks = new HashSet<ApvReqTask>();
        }

        public string TrxNo { get; set; } = null!;
        public string ApvSchemeId { get; set; } = null!;
        public string RequestBy { get; set; } = null!;
        public DateTime RequestDate { get; set; }
        public string? Notes { get; set; }
        public string ApvStatus { get; set; } = null!;
        public DateTime? FinishDate { get; set; }

        public virtual ApvScheme ApvScheme { get; set; } = null!;
        public ICollection<ApvReqTask> ApvReqTasks { get; set; } = null!;
    }
}
