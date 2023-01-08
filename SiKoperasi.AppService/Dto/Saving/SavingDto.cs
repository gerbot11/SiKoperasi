namespace SiKoperasi.AppService.Dto.Saving
{
    public record SavingDto
    {
        public string Id { get; init; } = null!;
        public decimal TotalAmount { get; init; }
        public decimal CutAmount { get; init; }
        public string SavingType { get; init; } = null!;
        public bool IsWithdrawal { get; init; }
    }

    public record SavingMinimalDto
    {
        public string MemberId { get; init; } = null!;
        public string MemberNo { get; init; } = null!;
        public string MemberName { get; init; } = null!;
        public string EmployeeNo { get; init; } = null!;
        public decimal TotalAmount { get; init; }
    }

    public record SavingTransactionCreateDto
    (
        string SavingId,
        DateTime TrxValueDate,
        decimal Amount,
        string TrxMethod,
        string CashBankAccountId,
        string TrxType,
        string? Notes
    );

    public record SavingTransactionDto
    (
        string Id,
        string TrxNo,
        string SavingId,
        DateTime TrxValueDate,
        decimal Amount,
        string TrxMethod,
        char TrxType,
        string? Notes
    );

    public record RefSavingTypeDto 
    {
        public string Id { get; init; } = null!;
        public string SavingName { get; init; } = null!;
        public decimal MinimalAmountDeposit { get; init; }
        public decimal? CutAmount { get; init; }
        public bool IsMandatory { get; init; }
        public bool IsActive { get; init; }
        public decimal SavingRate { get; init; }
        public bool IsWithdrawal { get; init; }
    }

    public record RefSavingTypeCreateDto(string SavingName, decimal MinimalAmountDeposit, decimal? CutAmount, bool IsMandatory, decimal SavingRate, bool IsWithdrawal);
    public record RefSavingTypeEditDto(string Id, string SavingName, decimal MinimalAmountDeposit, decimal? CutAmount, bool IsMandatory, decimal SavingRate, bool IsWithdrawal);
}
