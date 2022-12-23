namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanToBePaidDto
    {
        public string LoanId { get; set; }
        public string LoanNo { get; set; }
        public string MemberName { get; set; }
        public InstSchdlMinimalDto? InstSchdl { get; set; }
    }
}
