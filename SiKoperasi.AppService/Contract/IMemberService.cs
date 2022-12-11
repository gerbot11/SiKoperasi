using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.AppService.Contract
{
    public interface IMemberService
    {
        Task CreateMemberAsync(MemberCreateDto payload);
    }
}
