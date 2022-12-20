using SiKoperasi.AppService.Dto.Saving;

namespace SiKoperasi.AppService.Dto.Member
{
    public class MemberSavingDto
    {
        public MemberDto Member { get; set; }
        public IEnumerable<SavingDto> Savings { get; set; }
    }
}
