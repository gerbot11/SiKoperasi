using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Loans
{
    public class RefLoanDocument : BaseModel
    {
        public string DocumentName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public string AcceptedFileExt { get; set; } = null!;
        public int MaxFileSize { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsActive { get; set; }

        public ICollection<LoanDocument> Documents { get; set; }
    }
}
