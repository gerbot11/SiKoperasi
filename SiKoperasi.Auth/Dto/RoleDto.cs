namespace SiKoperasi.Auth.Dto
{
    public record RoleDto
    {
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Code { get; init; } = null!;
        public List<PermissionDto> Permissions { get; init; } = null!;
    }

    public record RoleCreateDto(string Name, string Description, string Code, List<string> PermissionIds);
    public record RoleEditDto(string Id, string Name, string Description, string Code, List<string> PermissionIds);
}
