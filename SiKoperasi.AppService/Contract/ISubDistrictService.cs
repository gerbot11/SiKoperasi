using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.SubDistrict;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Contract
{
    public interface ISubDistrictService
    {
        Task CreateSubDistrictAsync(SubDistrictCreateDto payload);
        Task DeleteSubDistrictAsync(string id);
        Task EditSubDistrictAsync(SubDistrictEditDto payload);
        Task<SubDistrictDto> GetSubDistrictAsync(string id);
        SubDistrict GetSubDistrictModel(string id);
        Task<PagingModel<SubDistrictDto>> GetSubDistrictPagingAsync(QueryParamDto queryParam);
    }
}
