namespace SiKoperasi.AppService.Dto.CashBank
{
    public record CashBankAccDto
    {
        public string Id { get; init; } = null!;
        public string BankName { get; init; } = null!;
        public string AccountNo { get; init; } = null!;
        public decimal Balance { get; init; }
        public bool IsDefault { get; init; }
        public bool IsActive { get; init; }
        public bool IsSavingDefault { get; init; }
    }

    public record CashBankAccCreateDto
    (
        string BankName,
        string AccountNo,
        decimal Balance,
        bool IsDefault,
        bool IsActive,
        bool IsSavingDefault
    );
}
