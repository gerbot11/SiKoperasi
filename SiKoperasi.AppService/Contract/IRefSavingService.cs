using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface IRefSavingService
    {
        Task<RefSavingTypeDto> CreateSavingTypeAsync(RefSavingTypeCreateDto payload);
        Task DeleteSavingTypeAsync(string id);
        Task<RefSavingTypeDto> EditSavingTypeAsync(RefSavingTypeEditDto payload);
        Task<RefSavingTypeDto> GetSavingTypeById(string id);
        Task<PagingModel<RefSavingTypeDto>> GetSavingTypePagingAsync(QueryParamDto queryParam);
    }
}
