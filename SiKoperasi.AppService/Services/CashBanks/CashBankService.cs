using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.CashBank;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Payments;

namespace SiKoperasi.AppService.Services.CashBanks
{
    public class CashBankService : BaseCrudService<CashBankAccount, CashBankAccCreateDto, CashBankAccDto, CashBankAccDto, AppDbContext>, ICashBankService
    {
        public CashBankService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<CashBankAccDto> CreateCashBankAccAsync(CashBankAccCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task<CashBankAccDto> EditCashBankAccAsync(CashBankAccDto payload)
        {
            return await BaseEditAsync(payload.Id, payload);
        }

        public async Task<PagingModel<CashBankAccDto>> GetPagingModelAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        public async Task CreateCashBankTrxAsync(PayHistH payHistH, string bankAccId)
        {
            CashBank? cashBank = dbContext.CashBanks.Where(a => a.CashBankAccountId == bankAccId && a.TrxDate == DateTime.Now.Date).FirstOrDefault();
            cashBank ??= await CreateCashBank(bankAccId);

            CashBankTrx trx = new()
            {
                CashBank = cashBank,
                InAmount = payHistH.PayHistDs.Sum(a => a.InAmount),
                OutAmount = payHistH.PayHistDs.Sum(a => a.OutAmount),
                TrxDate = cashBank.TrxDate
            };

            dbContext.Add(trx);
            await dbContext.SaveChangesAsync();
        }

        private async Task<CashBank> CreateCashBank(string bankAccId)
        {
            CashBank? prevTrx = dbContext.CashBanks.FirstOrDefault(a => a.TrxDate == DateTime.Now.Date.AddDays(-1));
            if (prevTrx is null)
            {
                prevTrx = new()
                {
                    TrxDate= DateTime.Now.Date,
                    BeginBalance= 0,
                    EndBalance = 0,
                    CashBankAccountId = bankAccId
                };

                dbContext.Add(prevTrx);
                await dbContext.SaveChangesAsync();
                return prevTrx;
            }
            else
            {
                CashBank newCashBank = new()
                {
                    TrxDate = DateTime.Now.Date,
                    BeginBalance = prevTrx.EndBalance,
                    EndBalance = prevTrx.EndBalance,
                };

                dbContext.Add(newCashBank);
                await dbContext.SaveChangesAsync();
                return newCashBank;
            }
        }

        protected override CashBankAccount CreateNewModel(CashBankAccCreateDto payload)
        {
            return mapper.Map<CashBankAccount>(payload);
        }

        protected override DbSet<CashBankAccount> GetAppDbSet()
        {
            return dbContext.CashBankAccounts;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(CashBankAccount.BankName);
        }

        protected override void SetModelValue(CashBankAccount model, CashBankAccDto payload)
        {
            model.AccountNo = payload.AccountNo;
            model.BankName = payload.BankName;
            model.IsActive = payload.IsActive;
            model.IsDefault = payload.IsDefault;
            model.Balance = payload.Balance;
        }

        protected override IQueryable<CashBankAccount> SetQueryable()
        {
            return GetAppDbSet().Where(a => a.IsActive);
        }

        protected override void ValidateCreate(CashBankAccount model)
        {
            if (dbContext.CashBankAccounts.Any(a => a.AccountNo == model.AccountNo))
                throw new Exception("Duplicate Account No");
        }

        protected override void ValidateDelete(CashBankAccount model)
        {
            return;
        }

        protected override void ValidateEdit(CashBankAccount model)
        {
            if (dbContext.CashBankAccounts.Any(a => a.AccountNo == model.AccountNo && a.Id != model.Id))
                throw new Exception("Duplicate Account No");
        }
    }
}
