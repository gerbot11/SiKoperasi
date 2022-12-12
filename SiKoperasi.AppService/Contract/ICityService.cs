using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface ICityService
    {
        Task CreateCityAsync(CityCreateDto payload);
        City GetCity(string id);
        Task<CityDto> GetCityAsync(string id);
        Task<PagingModel<CityDto>> GetCityPagingAsync(QueryParamDto queryParam);
    }
}
