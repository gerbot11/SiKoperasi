using SiKoperasi.Auth.Commons;

namespace SiKoperasi.Auth.Dto
{
    public record LoginDto(string Username, string Password);
    public record LoginResponseDto(string Id, string Username, string Token, DateTime ValidUntil, List<RoleDto> Roles);
}
