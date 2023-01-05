using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Approvals
{
    public class ApvReqTask : BaseModel
    {
        public string ApvReqId { get; set; } = null!;
        public string? UserId { get; set; }
        public bool IsDone { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool IsFinal { get; set; }
        public int ApvSeq { get; set; }
        public bool IsClaimed { get; set; }
        public string ApvSchemeNodeId { get; set; } = null!;
        public string? ResultNotes { get; set; }
        public DateTime? ApproveDate { get; set; }

        public virtual ApvReq ApvReq { get; set; } = null!;
        public virtual ApvSchemeNode ApvSchemeNode { get; set; } = null!;
    }
}
