namespace SiKoperasi.AppService.Dto.Loan
{
    public record LoanSchemeDto
    {
        public string Id { get; init; } = null!;
        public string LoanSchemeName { get; init; } = null!;
        public decimal PlafondAmount { get; init; }
        public int DueNum { get; init; }
        public decimal Rate { get; init; }
        public bool IsUseGuarantee { get; init; }
    }
}
