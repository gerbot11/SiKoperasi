namespace SiKoperasi.AppService.Dto.Loan
{
    public record RefLoanDocDto
    {
        public string Id { get; init; } = null!;
        public string DocumentName { get; init; } = null!;
        public string FileType { get; init; } = null!;
        public string AcceptedFileExt { get; init; } = null!;
        public int MaxFileSize { get; init; }
        public bool IsMandatory { get; init; }
        public bool IsActive { get; init; }
    }

    public record RefLoanDocCreateDto
    (
        string DocumentName ,
        string FileType,
        string AcceptedFileExt,
        int MaxFileSize,
        bool IsMandatory,
        bool IsActive
    );
}
