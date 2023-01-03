using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Shu;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Shu;
using static SiKoperasi.AppService.Util.Constant;

namespace SiKoperasi.AppService.Services.Shu
{
    public class ShuTrxService : BaseService<ShuAllocationTrx, ShuTrxDto, AppDbContext>, IShuTrxService
    {
        private readonly IMasterSequenceService masterSequenceService;
        public ShuTrxService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
        }

        public async Task CalculateShuDistAsync()
        {
            DateTime dtCurrent = new DateTime(2022, 12, 31);
            int yearPeriod;

            ShuAllocationTrx? lastShuTrx = await dbContext.ShuAllocationTrxes.OrderByDescending(a => a.TrxDate).FirstOrDefaultAsync();
            if (lastShuTrx is null)
                yearPeriod = dtCurrent.Year;
            else
                yearPeriod = lastShuTrx.YearPeriod + 1;

            decimal shuAmount = await CalculateTotalShuAsync(yearPeriod);
            decimal shuAfterExpense = shuAmount;
            if (shuAmount <= 0)
                throw new Exception("Insufficient Amount to Process");

            List<ShuAllocation> listAlloc = await dbContext.ShuAllocations.Where(a => a.IsActive).ToListAsync();

            ShuAllocationTrx newTrx = new()
            {
                TrxDate = dtCurrent,
                TrxNo = masterSequenceService.GenerateNo(SHU_TRX_SEQ_CODE),
                TotalAllocation = shuAmount,
                YearPeriod = yearPeriod
            };

            foreach (ShuAllocation item in listAlloc.Where(a => a.IsExpense))
            {
                ShuAllocationTrxDist dist = new()
                {
                    AllocationAmt = item.AllocationAmt,
                    ShuAllocation = item,
                    AllocationPrcnt = item.AllocationAmt / shuAmount * 100
                };

                shuAfterExpense -= item.AllocationAmt;
                newTrx.ShuAllocationTrxDists.Add(dist);
            }

            if (shuAfterExpense <= 0)
                throw new Exception($"Cannot Distribute More, because SHU After Expense is Insufficient. Current Amount After Expense: {shuAfterExpense}");

            foreach (ShuAllocation item in listAlloc.Where(a => !a.IsExpense))
            {
                ShuAllocationTrxDist dist = new()
                {
                    AllocationAmt = shuAfterExpense,
                    ShuAllocation = item,
                    AllocationPrcnt = shuAfterExpense / shuAmount * 100
                };

                var loanData = (from a in dbContext.Loans
                                join b in dbContext.InstalmentSchedules on a.Id equals b.LoanId
                                where a.GoLiveDate.Value.Year == yearPeriod && (a.Status == LOAN_STATUS_LIVE || a.Status == LOAN_STATUS_EXPIRED)
                                group b by new { a.MemberId } into grp
                                select new
                                {
                                    grp.Key.MemberId,
                                    InstAmt = grp.Sum(a => a.InstAmount)
                                }).AsEnumerable();

                foreach (var loan in loanData)
                {
                    ShuAllocationMember shuLoan = new()
                    {
                        MemberId = loan.MemberId,
                        AllocationPrcnt = loan.InstAmt / shuAmount * 100
                    };
                    shuLoan.AllocationAmount = shuLoan.AllocationPrcnt / 100 * shuAfterExpense;
                    dist.ShuAllocationMembers.Add(shuLoan);
                }

                newTrx.ShuAllocationTrxDists.Add(dist);
            }

            dbContext.ShuAllocationTrxes.Add(newTrx);
            await dbContext.SaveChangesAsync();
        }

        private async Task<decimal> CalculateTotalShuAsync(int yearperiod)
        {
            decimal totalShu = await dbContext.Loans
                .Where(a => a.GoLiveDate.Value.Year == yearperiod && (a.Status == LOAN_STATUS_LIVE || a.Status == LOAN_STATUS_EXPIRED))
                .Join(dbContext.InstalmentSchedules,
                    a => a.Id,
                    b => b.LoanId,
                    (a, b) => new { b.InstAmount })
                .SumAsync(a => a.InstAmount);

            return totalShu;
        }

        protected override DbSet<ShuAllocationTrx> GetAppDbSet()
        {
            return dbContext.ShuAllocationTrxes;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(ShuAllocationTrx.TrxDate);
        }

        protected override IQueryable<ShuAllocationTrx> SetQueryable()
        {
            return GetAppDbSet();
        }
    }
}
