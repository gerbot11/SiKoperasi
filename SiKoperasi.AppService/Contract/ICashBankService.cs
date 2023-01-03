using SiKoperasi.AppService.Dto.CashBank;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Payments;

namespace SiKoperasi.AppService.Contract
{
    public interface ICashBankService
    {
        Task<CashBankAccDto> CreateCashBankAccAsync(CashBankAccCreateDto payload);
        Task CreateCashBankTrxAsync(PayHistH payHistH, string bankAccId);
        Task<CashBankAccDto> EditCashBankAccAsync(CashBankAccDto payload);
        Task<CashBankAccDto> GetCashBankByIdAsync(string id);
        Task<PagingModel<CashBankAccDto>> GetPagingModelAsync(QueryParamDto queryParam);
    }
}
