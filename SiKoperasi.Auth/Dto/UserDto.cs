using SiKoperasi.Auth.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiKoperasi.Auth.Dto
{
    public record UserDto
    {
        public string Id { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string FullName { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Phone { get; init; } = null!;
        public List<RoleDto>? Roles { get; init; }
    }

    public record UserCreateDto {
        public string Username { get; init; } = null!;
        public string FullName { get; init; } = null!;
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; init; } = null!;
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirm { get; init; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; } = null!;
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; init; } = null!;
        public List<string> Roles { get; init; } = null!;
    }

    public record UserEditDto(string Id, string Username, string FullName, string Password, string PasswordConfirm, string Email, string Phone, List<RoleDto> Roles);
}
