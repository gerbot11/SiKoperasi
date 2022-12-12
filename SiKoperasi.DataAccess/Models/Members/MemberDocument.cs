using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Members
{
    public class MemberDocument : BaseModel
    {
        public string MemberId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentExt { get; set; }
        public string FileUrl { get; set; }

        public virtual Member Member { get; set; }
    }
}
