using SiKoperasi.AppService.Dto.Saving;

namespace SiKoperasi.AppService.Dto.Member
{
    public record MemberSavingDto
    (
        MemberDto Member,
        IEnumerable<SavingDto> Savings
    );
}
