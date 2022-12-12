namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanEditDto
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string LoanNo { get; set; }
        public DateTime LoanDate { get; set; }
        public int? CurrentDueNum { get; set; }
        public int? NextDueNum { get; set; }
        public string LoanSchemeId { get; set; }
        public decimal LoanAmount { get; set; }
    }
}
