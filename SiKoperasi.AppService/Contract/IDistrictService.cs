using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface IDistrictService
    {
        Task<DistrictDto> GetDistrictAsync(string id);
        Task<PagingModel<DistrictDto>> GetDistrictPagingAsync(QueryParamDto queryParam);
    }
}
