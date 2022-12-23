namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanPaymentCreateDto
    {
        public decimal Amount { get; set; }
        public int InstSeqNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Wop { get; set; }
        public string CashBankAccId { get; set; }
        public string LoanId { get; set; }
    }
}
