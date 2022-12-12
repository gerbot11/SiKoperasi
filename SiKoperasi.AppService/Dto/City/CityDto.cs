using System.Text.Json.Serialization;

namespace SiKoperasi.AppService.Dto.City
{
    public class CityDto
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [JsonPropertyName("province_id")]
        public string ProvinceId { get; set; }
    }
}
