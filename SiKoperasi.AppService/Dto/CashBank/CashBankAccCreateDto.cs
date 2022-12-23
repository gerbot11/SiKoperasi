namespace SiKoperasi.AppService.Dto.CashBank
{
    public class CashBankAccCreateDto
    {
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
