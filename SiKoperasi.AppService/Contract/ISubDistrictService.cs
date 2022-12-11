using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface ISubDistrictService
    {
        SubDistrict GetSubDistrictModel(string id);
    }
}
