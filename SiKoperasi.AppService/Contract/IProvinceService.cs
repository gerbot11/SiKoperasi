using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface IProvinceService
    {
        Task CreateProvinceAsync(ProvinceCreateDto payload);
        Task DeleteProvinceAsync(string id);
        Task EditProvinceAsync(ProvinceEditDto payload);
        Task<ProvinceDto> GetProvinceAsync(string id);
        Province GetProvinceModel(string id);
        Task<PagingModel<Province>> GetProvincePagingAsync(QueryParamDto dto);
    }
}
