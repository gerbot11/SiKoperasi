namespace SiKoperasi.AppService.Dto.Member
{
    public class MemberEditDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdNo { get; set; }
        public string IdType { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? NpwpNo { get; set; }

        public AddressEditDto Address { get; set; }
        public JobEditDto Job { get; set; }
    }
}
