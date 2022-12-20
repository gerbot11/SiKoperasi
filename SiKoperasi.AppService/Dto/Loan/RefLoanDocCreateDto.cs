namespace SiKoperasi.AppService.Dto.Loan
{
    public class RefLoanDocCreateDto
    {
        public string DocumentName { get; set; }
        public string FileType { get; set; }
        public string AcceptedFileExt { get; set; }
        public int MaxFileSize { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsActive { get; set; }
    }
}
