namespace SiKoperasi.AppService.Dto.Province
{
    public record ProvinceCreateDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string TimeZone { get; set; }
    }
}
