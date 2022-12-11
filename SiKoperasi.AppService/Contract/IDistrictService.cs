using SiKoperasi.AppService.Dto.District;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface IDistrictService
    {
        Task CreateDistrictAsync(DistrictCreateDto dto);
        District GetDistrictModel(string id);
    }
}
