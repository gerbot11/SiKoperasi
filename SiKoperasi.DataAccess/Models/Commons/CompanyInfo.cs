using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Commons
{
    public class CompanyInfo : BaseModel
    {
        public string CompanyName { get; set; } = null!;
        public string CompanyShortName { get; set; } = null!;
        public string? CompanyDescription { get; set; }
        public string Address { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
    }
}
