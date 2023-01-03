namespace SiKoperasi.AppService.Dto.City
{
    public record CityDto(
        string Id,
        string Name, 
        string Code, 
        string ProvinceId
    );

    public record CityCreateDto(
        string Name, 
        string Code, 
        string ProvinceId
    );

    public record CityEditDto(
        string Id,
        string Name,
        string Code,
        string ProvinceId
    );
}
