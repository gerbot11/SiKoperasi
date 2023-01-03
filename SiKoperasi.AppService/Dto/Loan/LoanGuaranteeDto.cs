using Microsoft.AspNetCore.Http;

namespace SiKoperasi.AppService.Dto.Loan
{
    public record LoanGuaranteeDto
    {
        public string Id { get; init; } = null!;
        public string LoanId { get; init; } = null!;
        public string GuaranteeName { get; init; } = null!;
        public string GuaranteeType { get; init; } = null!;
        public string? LetterNo { get; init; }
        public string? OwnerName { get; init; }
        public DateTime? LetterDate { get; init; }
        public DateTime? LetterExpDate { get; init; }
    }

    public record LoanGuaranteeCreateDto
    (
        string LoanId,
        List<LoanGuaranteeFileDto> LoanGuaranteeFiles
    );

    public record LoanGuaranteeFileDto(
        string GuaranteeName,
        string GuaranteeType,
        string? LetterNo,
        string? OwnerName,
        DateTime? LetterDate,
        DateTime? LetterExpDate,
        IFormFile File
        );
}
