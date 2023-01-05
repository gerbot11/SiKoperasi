using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Approvals
{
    public class ApvScheme : BaseModel
    {
        public ApvScheme()
        {
            ApvSchemeNodes= new HashSet<ApvSchemeNode>();
            ApvReqs = new HashSet<ApvReq>();
        }

        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string ApvType { get; set; } = null!;
        public string? Desc { get; set; }

        public ICollection<ApvSchemeNode> ApvSchemeNodes { get; set; } = null!;
        public ICollection<ApvReq> ApvReqs { get; set; } = null!;
    }
}
