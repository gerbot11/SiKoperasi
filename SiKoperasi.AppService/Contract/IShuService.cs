using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Shu;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface IShuService
    {
        Task<ShuDto> CreateShuAsync(ShuCreateDto payload);
        Task DeleteShuAsync(string id);
        Task<ShuDto> EditShuAsync(ShuEditDto payload);
        Task<ShuDto> GetShuByIdAsync(string id);
        Task<PagingModel<ShuDto>> GetShuPagingAsync(QueryParamDto queryParam);
    }
}
