namespace SiKoperasi.AppService.Dto.Saving
{
    public class SavingTransactionCreateDto
    {
        public string SavingId { get; set; }
        public DateTime TrxValueDate { get; set; }
        public decimal Amount { get; set; }
        public string TrxMethod { get; set; }
        public char TrxType { get; set; }
        public string? Notes { get; set; }
    }
}
