using SiKoperasi.AppService.Dto.SubDistrict;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface ISubDistrictService
    {
        Task CreateSubDistrictAsync(SubDistrictCreateDto payload);
        SubDistrict GetSubDistrictModel(string id);
    }
}
