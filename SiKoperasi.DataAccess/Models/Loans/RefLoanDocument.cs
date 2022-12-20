using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class RefLoanDocument : BaseModel
    {
        public string DocumentName { get; set; }
        public string FileType { get; set; }
        public string AcceptedFileExt { get; set; }
        public int MaxFileSize { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsActive { get; set; }

        public ICollection<LoanDocument> Documents { get; set; }
    }
}
