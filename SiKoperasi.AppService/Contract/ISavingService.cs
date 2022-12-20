using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Contract
{
    public interface ISavingService
    {
        List<Saving> CreateSaving();
        Task<MemberSavingDto> GetMemberSavingAsync(string memberid);
    }
}
