namespace SiKoperasi.AppService.Dto.Loan
{
    public class InstSchdlDto
    {
        public string LoanId { get; set; }
        public int SeqNo { get; set; }
        public DateTime InstDate { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal? PayAmount { get; set; }
        public decimal InstAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsInterestAmount { get; set; }
        public decimal? LateChargeAmount { get; set; }
    }
}
