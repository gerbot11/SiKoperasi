using System.ComponentModel.DataAnnotations;

namespace SiKoperasi.AppService.Dto.Member
{
    public class MemberCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string IdNo { get; set; }
        [Required]
        public string IdType { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? NpwpNo { get; set; }

        [Required]
        public AddressCreateDto Address { get; set; }
        [Required]
        public JobCreateDto Job { get; set; }
    }
}
