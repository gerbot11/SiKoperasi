using SiKoperasi.AppService.Dto.City;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface ICityService
    {
        Task CreateCityAsync(CityCreateDto payload);
        City GetCity(string id);
        Task<City> GetCityAsync(string id);
    }
}
