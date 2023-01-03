using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.AppService.Dto.Loan
{
    public record LoanDto
    {
        public string Id { get; init; } = null!;
        public string LoanNo { get; init; } = null!;
        public DateTime LoanDate { get; init; }
        public int? CurrentDueNum { get; init; }
        public int? NextDueNum { get; init; }
        public int LoanDueNum { get; init; }
        public DateTime EffectiveDate { get; init; }
        public decimal LoanAmount { get; init; }
        public string Status { get; init; } = null!;
        public MemberMinimalDto Member { get; init; } = null!;
        public LoanSchemeDto LoanScheme { get; init; } = null!;
    }

    public record LoanEditDto
    (
        string Id,
        string MemberId,
        DateTime LoanDate,
        string LoanSchemeId,
        decimal LoanAmount,
        int LoanDueNum,
        string? LoanPurpose,
        DateTime EffectiveDate
    );

    public record LoanCreateDto
    (
        string MemberId,
        DateTime LoanDate,
        DateTime EffectiveDate,
        string LoanSchemeId,
        decimal LoanAmount,
        int LoanDueNum,
        string? LoanPurpose
    );
}
