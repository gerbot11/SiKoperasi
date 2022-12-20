namespace SiKoperasi.AppService.Dto.Saving
{
    public class SavingTransactionCreateDto
    {
        public string SavingId { get; set; }
        public DateTime TrDate { get; set; }
        public decimal Amount { get; set; }
        public string TrMethod { get; set; }
        public string? Notes { get; set; }
    }
}
