﻿namespace SiKoperasi.AppService.Dto.Loan
{
    public class LoanCreateDto
    {
        public string MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string LoanSchemeId { get; set; }
        public decimal LoanAmount { get; set; }
    }
}