using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Payments;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Services.Savings
{
    public class SavingTransactionService : BaseService<SavingTransaction, SavingTransactionDto, AppDbContext>, ISavingTransactionService
    {
        private readonly IMasterSequenceService masterSequenceService;
        private readonly ICashBankService cashBankService;
        public SavingTransactionService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, ICashBankService cashBankService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
            this.cashBankService = cashBankService;
        }

        public async Task<PagingModel<SavingTransactionDto>> GetPagingModelAsync(QueryParamDto queryParam, string savingId)
        {
            var query = GetAppDbSet().Where(a => a.SavingId == savingId);
            return await GetPagingDataDtoAsync(queryParam, query);
        }

        public async Task<SavingTransactionDto> CreateSavingTransactionAsync(SavingTransactionCreateDto payload)
        {
            Saving? saving = await dbContext.Savings.FindAsync(payload.SavingId);
            if (saving is null)
                throw new Exception("Saving Data Is Not Exist");

            SavingTransaction savingTransaction = new()
            {
                Amount = payload.Amount,
                Notes = payload.Notes,
                TrxValueDate = payload.TrxValueDate,
                TrxDate = DateTime.Now,
                TrxType = payload.TrxType,
                TrxMethod = payload.TrxMethod,
                TrxNo = masterSequenceService.GenerateNo(SavingTransaction.SAVING_TRX_CODE)
            };

            saving.SavingTransactions.Add(savingTransaction);
            saving.TotalAmount += payload.Amount;

            PayHistH payHist = await CreateSavingPayHistory(savingTransaction);

            dbContext.Savings.Update(saving);
            await dbContext.SaveChangesAsync();
            await cashBankService.CreateCashBankTrxAsync(payHist, string.Empty);

            return mapper.Map<SavingTransactionDto>(savingTransaction);
        }

        private async Task<PayHistH> CreateSavingPayHistory(SavingTransaction savingTransaction)
        {
            PayHistH ph = new()
            {
                Amount = savingTransaction.Amount,
                TrxCode = SavingTransaction.SAVING_TRX_CODE,
                TrxDate = DateTime.Now.Date,
                ValueDate = savingTransaction.TrxValueDate,
                TrxNo = savingTransaction.TrxNo,
                IsReverse = false
            };

            PayHistD pd = new()
            {
                Descr = "Saving Deposit",
                InAmount = savingTransaction.TrxType == 'C' ? savingTransaction.Amount : 0,
                OutAmount = savingTransaction.TrxType == 'D' ? savingTransaction.Amount : 0,
                PayHistSeqNo = 1
            };

            ph.PayHistDs.Add(pd);
            await dbContext.AddAsync(ph);
            return ph;
        }

        protected override DbSet<SavingTransaction> GetAppDbSet()
        {
            return dbContext.SavingTransactions;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(SavingTransaction.DtmUpd);
        }

        protected override IQueryable<SavingTransaction> SetQueryable()
        {
            return GetAppDbSet();
        }
    }
}
