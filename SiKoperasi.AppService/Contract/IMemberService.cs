using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Contract
{
    public interface IMemberService
    {
        Task<MemberDto> CreateMemberAsync(MemberCreateDto payload);
        Task DeleteMember(string id);
        Task<MemberDto> EditMemberAsync(MemberEditDto payload);
        Task<MemberDto> GetMemberAsync(string id);
        Task<Member> GetMemberModelAsync(string id);
        Task<PagingModel<MemberMinimalDto>> GetMemberPagingAsync(QueryParamDto queryParam);
    }
}
