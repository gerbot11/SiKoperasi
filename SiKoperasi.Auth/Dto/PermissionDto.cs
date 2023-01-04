namespace SiKoperasi.Auth.Dto
{
    public record PermissionDto
    {
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Code { get; init; } = null!;
    }
}
