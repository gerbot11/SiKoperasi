namespace SiKoperasi.AppService.Dto.SubDistrict
{
    public record SubDistrictDto
    {
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Code { get; init; } = null!;
        public string PostalCode { get; init; } = null!;
        public string DistrictId { get; init; } = null!;
    }

    public record SubDistrictCreateDto
    {
        public string Name { get; init; } = null!;
        public string Code { get; init; } = null!;
        public string PostalCode { get; init; } = null!;
        public string DistrictId { get; init; } = null!; 
    }

    public record SubDistrictEditDto
    {
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Code { get; init; } = null!;
        public string PostalCode { get; init; } = null!;
        public string DistrictId { get; init; } = null!; 
    }
}
