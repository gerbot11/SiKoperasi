using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.AppService.Dto.Saving
{
    public class SavingDto
    {
        public string Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CutAmount { get; set; }
        public string SavingType { get; set; }

        
    }
}
