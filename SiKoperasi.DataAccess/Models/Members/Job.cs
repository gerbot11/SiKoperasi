using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Members
{
    public class Job : BaseModel
    {
        public string MemberId { get; set; }
        public string JobName { get; set; }
        public string? JobPosition { get; set; }
        public string? JobDescription { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Member Member { get; set; }
    }
}
