using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Contract
{
    public interface ISavingService
    {
        List<Saving> CreateSaving();
        Task<MemberSavingDto> GetMemberSavingAsync(string memberid);
        Task<PagingModel<SavingMinimalDto>> GetSavingPagingAsync(QueryParamDto queryParam);
    }
}
