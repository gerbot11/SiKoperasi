namespace SiKoperasi.AppService.Dto.Loan
{
    public class InstSchdlMinimalDto
    {
        public string LoanId { get; set; }
        public int SeqNo { get; set; }
        public DateTime InstDate { get; set; }
        public decimal InstAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
    }
}
