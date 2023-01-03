using System.ComponentModel.DataAnnotations;

namespace SiKoperasi.AppService.Dto.Member
{
    public record MemberDto
    (
        string Id,
        string MemberNo,
        string Name,
        string IdNo,
        string IdType,
        string Gender,
        DateTime BirthDate,
        string BirthPlace,
        DateTime RegistrationDate,
        string PhoneNumber,
        string? NpwpNo,
        string MartialStat,
        string EmployeeNo,
        AddressDto Address,
        JobDto Job
    );

    public record MemberMinimalDto
    {
        public string Id { get; init; } = null!;
        public string MemberNo { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string IdNo { get; init; } = null!;
        public string IdType { get; init; } = null!;
        public string PhoneNumber { get; init; } = null!;
        public string EmployeeNo { get; init; } = null!;
    }

    public record MemberCreateDto
    (
        [Required]
        string Name,
        [Required]
        [MaxLength(25)]
        string IdNo,
        [Required]
        string IdType,
        [Required]
        string Gender,
        [Required]
        DateTime BirthDate,
        [Required]
        string BirthPlace,
        [Required]
        DateTime RegistrationDate,
        [Required]
        string PhoneNumber,
        string? NpwpNo,
        string MartialStat,
        string EmployeeNo,
        [Required]
        AddressCreateDto Address,
        [Required]
        JobCreateDto Job
    );

    public record MemberEditDto
    (
        string Id,
        string Name,
        string IdNo,
        string IdType,
        string Gender,
        DateTime BirthDate,
        string BirthPlace,
        DateTime RegistrationDate,
        string PhoneNumber,
        string? NpwpNo,
        string MartialStat,
        string EmployeeNo,
        AddressEditDto Address,
        JobEditDto Job
    );
}
