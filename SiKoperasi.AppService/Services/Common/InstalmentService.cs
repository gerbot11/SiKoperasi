using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Services.Common
{
    public class InstalmentService : BaseSimpleService<AppDbContext>, IInstalmentService
    {
        public InstalmentService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<InstSchdlDto>> GetLoanInstSchdlsAsync(string loanid)
        {
            var instSchdls = await (from a in dbContext.InstalmentSchedules
                                    where a.LoanId == loanid
                                    select new InstSchdlDto
                                    {
                                        LoanId = a.LoanId,
                                        InstAmount = a.InstAmount,
                                        InstDate = a.InstDate,
                                        InterestAmount = a.InterestAmount,
                                        LateChargeAmount = a.LateChargeAmount,
                                        OsInterestAmount = a.OsInterestAmount,
                                        OsPrincipalAmount = a.OsPrincipalAmount,
                                        PayAmount = a.PayAmount,
                                        PayDate = a.PayDate,
                                        PrincipalAmount = a.PrincipalAmount,
                                        SeqNo = a.SeqNo,
                                    }).ToListAsync();

            return instSchdls;
        }

        public List<InstalmentSchedule> CalculateInstalmentSchdl(Loan loan)
        {
            int payFreq = 1;
            int tenor = loan.LoanDueNum;
            DateTime effDate = loan.EffectiveDate;

            decimal ratePerInst = (loan.LoanScheme.Rate / 100) / 12;

            double presentValue = Convert.ToDouble(loan.LoanAmount * -1);
            double instAmtPerMonth = Financial.Pmt(Convert.ToDouble(ratePerInst), tenor, presentValue);

            decimal osPrincipal = loan.LoanAmount;
            decimal instAmtPerMonthRounded = Math.Round(Convert.ToDecimal(instAmtPerMonth), 0);
            decimal totInterest = 0;

            List<InstalmentSchedule> instalmentSchedules = new();
            for (int i = 1; i <= loan.LoanDueNum; i++)
            {
                InstalmentSchedule inst = new()
                {
                    SeqNo = i,
                    InstDate = effDate.AddMonths(i),
                    InterestAmount = Math.Round(Convert.ToDecimal(osPrincipal * ratePerInst), 2),
                    InstAmount = instAmtPerMonthRounded
                };
                inst.PrincipalAmount = Math.Round(instAmtPerMonthRounded - inst.InterestAmount, 2);

                osPrincipal -= inst.PrincipalAmount;
                totInterest += inst.InterestAmount;

                inst.OsPrincipalAmount = Math.Round(Convert.ToDecimal(osPrincipal), 2);

                if (i == loan.LoanDueNum)
                    inst.OsPrincipalAmount = 0;

                instalmentSchedules.Add(inst);
            }

            for (int i = 0; i < instalmentSchedules.Count; i++)
            {
                if (i == instalmentSchedules.Count - 1)
                {
                    instalmentSchedules[i].OsInterestAmount = 0;
                    break;
                }

                instalmentSchedules[i].OsInterestAmount = totInterest - instalmentSchedules[i].InterestAmount;
                totInterest = instalmentSchedules[i].OsInterestAmount;
            }

            return instalmentSchedules;
        }
    }
}
