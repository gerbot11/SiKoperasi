namespace SiKoperasi.Auth.Dto
{
    public record RegisterDto(string Username, string Password, string PasswordConfirm, string Email, string PhoneNumber, string FullName);
    public record RegisterResponseDto(string Id, string Username, string? Role, List<string>? Permission);
}
