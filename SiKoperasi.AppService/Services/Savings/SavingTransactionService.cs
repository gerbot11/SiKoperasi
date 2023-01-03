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
using static SiKoperasi.AppService.Util.Constant;

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
            if (string.IsNullOrEmpty(queryParam.OrderBy))
            {
                queryParam.OrderBy = nameof(SavingTransaction.TrxDate);
                queryParam.OrderBehavior = Core.Enums.OrderBehaviour.Desc;
            }

            return await GetPagingDataDtoAsync(queryParam, query);
        }

        public async Task<SavingTransactionDto> CreateSavingTransactionAsync(SavingTransactionCreateDto payload)
        {
            Saving? saving = await dbContext.Savings.FindAsync(payload.SavingId);
            if (saving is null)
                throw new Exception("Saving Data Is Not Exist");

            await SavingTrxValidation(payload, saving);
            SavingTransaction savingTransaction = new()
            {
                Amount = payload.Amount,
                Notes = payload.Notes,
                TrxValueDate = payload.TrxValueDate,
                TrxDate = DateTime.Now,
                TrxType = payload.TrxType,
                TrxMethod = payload.TrxMethod,
                TrxNo = masterSequenceService.GenerateNo(SAVING_TRX_SEQ_CODE)
            };

            saving.SavingTransactions.Add(savingTransaction);
            saving.TotalAmount = payload.TrxType == 'C' ? saving.TotalAmount + payload.Amount : saving.TotalAmount - payload.Amount;

            PayHistH payHist = await CreateSavingPayHistory(savingTransaction);

            dbContext.Savings.Update(saving);
            await dbContext.SaveChangesAsync();
            await cashBankService.CreateCashBankTrxAsync(payHist, payload.CashBankAccountId);

            return mapper.Map<SavingTransactionDto>(savingTransaction);
        }

        private async Task<PayHistH> CreateSavingPayHistory(SavingTransaction savingTransaction)
        {
            PayHistH ph = new()
            {
                Amount = savingTransaction.Amount,
                TrxCode = SAVING_TRX_SEQ_CODE,
                TrxDate = DateTime.Now.Date,
                ValueDate = savingTransaction.TrxValueDate,
                TrxNo = savingTransaction.TrxNo,
                IsReverse = false
            };

            PayHistD pd = new()
            {
                Descr = savingTransaction.TrxType == 'C' ? "Saving Deposit" : "Saving Withdrawal",
                InAmount = savingTransaction.TrxType == 'C' ? savingTransaction.Amount : 0,
                OutAmount = savingTransaction.TrxType == 'D' ? savingTransaction.Amount : 0,
                PayHistSeqNo = 1
            };

            ph.PayHistDs.Add(pd);
            await dbContext.AddAsync(ph);
            return ph;
        }

        private async Task SavingTrxValidation(SavingTransactionCreateDto payload, Saving saving)
        {
            if (payload.TrxType != 'C' || payload.TrxType != 'D')
                throw new Exception($"Invalid TrxType ({payload.TrxType}). Should Be 'C' or 'D'");

            RefSavingType savingType = await dbContext.RefSavingTypes.SingleAsync(a => a.Id == saving.RefSavingTypeId);
            if (!savingType.IsWithdrawal && payload.TrxType == 'D')
                throw new Exception($"Cannot Withdraw From this type of Saving ({savingType.SavingName})");

            if (payload.TrxType == 'D' && saving.TotalAmount < payload.Amount)
                throw new Exception($"Insufficient Saving Balance. Your Balance: {saving.TotalAmount}");

            if (payload.Amount < savingType.MinimalAmountDeposit && payload.TrxType == 'C')
                throw new Exception($"{savingType.SavingName} minimal deposit({savingType.MinimalAmountDeposit}) is lower than Amount Receive ({payload.Amount})");
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
