namespace SiKoperasi.AppService.Dto.Member
{
    public class AddressCreateDto
    {
        public string MemberId { get; set; }
        public string AddressType { get; set; }
        public string Description { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string SubDistrictId { get; set; }
    }
}
