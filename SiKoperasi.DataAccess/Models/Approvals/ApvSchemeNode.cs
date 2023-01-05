using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Approvals
{
    public class ApvSchemeNode : BaseModel
    {
        public ApvSchemeNode()
        {
            ApvReqTasks = new HashSet<ApvReqTask>();
        }

        public string ApvSchemeId { get; set; } = null!;
        public string UserRoleCode { get; set; } = null!;
        public int Level { get; set; }

        public virtual ApvScheme ApvScheme { get; set; } = null!;
        public ICollection<ApvReqTask> ApvReqTasks { get; set; } = null!;
    }
}
