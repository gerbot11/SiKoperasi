using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface IMemberService
    {
        Task<MemberDto> CreateMemberAsync(MemberCreateDto payload);
        Task DeleteMember(string id);
        Task<MemberDto> EditMemberAsync(MemberEditDto payload);
        Task<MemberDto> GetMemberAsync(string id);
        Task<PagingModel<MemberDto>> GetMemberPagingAsync(QueryParamDto queryParam);
    }
}
