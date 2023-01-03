namespace SiKoperasi.AppService.Dto.Loan
{
    public record InstSchdlDto
    {
        public string LoanId { get; init; }
        public int SeqNo { get; init; }
        public DateTime InstDate { get; init; }
        public DateTime? PayDate { get; init; }
        public decimal? PayAmount { get; init; }
        public decimal InstAmount { get; init; }
        public decimal PrincipalAmount { get; init; }
        public decimal InterestAmount { get; init; }
        public decimal OsPrincipalAmount { get; init; }
        public decimal OsInterestAmount { get; init; }
        public decimal? LateChargeAmount { get; init; }
    }

    public record InstSchdlMinimalDto
    {
        public string LoanId { get; init; }
        public int SeqNo { get; init; }
        public DateTime InstDate { get; init; }
        public decimal InstAmount { get; init; }
        public decimal PrincipalAmount { get; init; }
        public decimal InterestAmount { get; init; }
        public decimal OsPrincipalAmount { get; init; }
        public decimal OsInterestAmount { get; init; }
    }

    public record InstSchdlCalculationDto(
        string LoanSchemeId,
        int LoanDueNum,
        DateTime EffectiveDate,
        decimal LoanAmount);
}
