namespace SiKoperasi.AppService.Dto.Loan
{
    public record LoanPaymentDto
    {
        public string Id { get; init; } = null!;
        public decimal Amount { get; init; }
        public int InstSeqNo { get; init; }
        public DateTime PaymentDate { get; init; }
        public string Wop { get; init; } = null!;
        public string CashBankAccId { get; init; } = null!;
        public string LoanId { get; init; } = null!;
    }

    public record LoanPaymentCreateDto
    (
        decimal Amount,
        int InstSeqNo,
        DateTime PaymentDate,
        string Wop,
        string CashBankAccId,
        string LoanId
    );
}
