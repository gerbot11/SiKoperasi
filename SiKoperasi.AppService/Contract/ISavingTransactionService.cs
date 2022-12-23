using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Data;

namespace SiKoperasi.AppService.Contract
{
    public interface ISavingTransactionService
    {
        Task<SavingTransactionDto> CreateSavingTransactionAsync(SavingTransactionCreateDto payload);
        Task<PagingModel<SavingTransactionDto>> GetPagingModelAsync(QueryParamDto queryParam, string savingId);
    }
}
