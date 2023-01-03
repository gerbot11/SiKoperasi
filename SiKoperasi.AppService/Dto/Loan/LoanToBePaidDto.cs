namespace SiKoperasi.AppService.Dto.Loan
{
    public record LoanToBePaidDto
    {
        public string LoanId { get; init; } = null!;
        public string LoanNo { get; init; } = null!;
        public string MemberName { get; init; } = null!;
        public int OverDueDays { get; init; }
        public InstSchdlMinimalDto? InstSchdl { get; init; }
    }
}
