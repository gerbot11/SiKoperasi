using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface IDistrictService
    {
        Task CreateDistrictAsync(DistrictCreateDto dto);
        Task DeleteDistrictAsync(string id);
        Task EditDistrictAsync(DistrictEditDto dto);
        Task<DistrictDto> GetDistrictAsync(string id);
        District GetDistrictModel(string id);
        Task<PagingModel<DistrictDto>> GetDistrictPagingAsync(QueryParamDto queryParam);
    }
}
