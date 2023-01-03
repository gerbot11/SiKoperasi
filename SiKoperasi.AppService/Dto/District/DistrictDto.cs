namespace SiKoperasi.AppService.Dto.District
{
    public record DistrictDto
    (
        string Id,
        string Name,
        string Code
    );

    public record DistrictCreateDto
    (
        string Name,
        string Code,
        string CityId
    );

    public record DistrictEditDto
    (
        string Id,
        string Name,
        string Code,
        string CityId
    );
}
