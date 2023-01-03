using Microsoft.AspNetCore.Http;

namespace SiKoperasi.AppService.Dto.Loan
{
    public record LoanDocumentDto
    {
        public string LoanId { get; init; } = null!;
        public List<LoanDoucmentFileDto> DocumentFiles { get; init; } = null!;
    }

    public record LoanDoucmentFileDto
    {
        public string RefLoanDocumentId { get; init; } = null!;
        public IFormFile DocumentFiles { get; init; } = null!;
    }

    public record LoanDocumentViewDto
    {
        public string Id { get; init; } = null!;
        public string RefLoanDocumentName { get; init; } = null!;
        public string FilePreviewUrl { get; init; } = null!;
    }

    public record LoanDocumentEditDto(
        string Id,
        LoanDoucmentFileDto DocumentFile);
}
