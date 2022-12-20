using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Services.Savings
{
    public class SavingTransactionService : BaseService<SavingTransaction, SavingTransactionDto, AppDbContext>
    {
        private readonly IMasterSequenceService masterSequenceService;
        public SavingTransactionService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
        }

        public async Task<SavingTransactionDto> CreateSavingTransaction(SavingTransactionCreateDto payload)
        {
            Saving? saving = await dbContext.Savings.FindAsync(payload.SavingId);
            if (saving is null)
                throw new Exception("Saving Data Is Not Exist");

            SavingTransaction savingTransaction = new()
            {
                Amount = payload.Amount,
                Notes = payload.Notes,
                TrxDate = payload.TrDate,
                TrxNo = masterSequenceService.GenerateNo("")
            };

            saving.SavingTransactions.Add(savingTransaction);
            saving.TotalAmount += payload.Amount;

            dbContext.Savings.Update(saving);
            await dbContext.SaveChangesAsync();

            return mapper.Map<SavingTransactionDto>(savingTransaction);
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
