using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanDto
    {
        public string Id { get; set; }
        public string LoanNo { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberAddress { get; set; }
        public DateTime LoanDate { get; set; }
        public int? CurrentDueNum { get; set; }
        public int? NextDueNum { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string LoanSchemeId { get; set; }
        public decimal LoanAmount { get; set; }
        public string Status { get; set;}
    }
}
