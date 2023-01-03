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
                                    orderby a.SeqNo
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

        public List<InstalmentSchedule> CalculateInstalmentSchdl(int tenor, decimal loanAmount, DateTime effDate, LoanScheme loanScheme)
        {
            if (effDate <= DateTime.Now)
                throw new Exception($"Invalid Effective Date ({effDate})! Must > Current Date");

            decimal ratePerInst = (loanScheme.Rate / 100) / 12;

            double presentValue = Convert.ToDouble(loanAmount * -1);
            double instAmtPerMonth = Financial.Pmt(Convert.ToDouble(ratePerInst), tenor, presentValue);

            decimal osPrincipal = loanAmount;
            decimal instAmtPerMonthRounded = Math.Round(Convert.ToDecimal(instAmtPerMonth), 0);
            decimal totInterest = 0;

            List<InstalmentSchedule> instalmentSchedules = new();
            for (int i = 1; i <= tenor; i++)
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

                if (i == tenor)
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

        public List<InstSchdlMinimalDto> CalculateInstalmentSchdl(InstSchdlCalculationDto dto)
        {
            LoanScheme scheme = dbContext.LoanSchemes.Single(a => a.Id == dto.LoanSchemeId);
            if (scheme.DueNum < dto.LoanDueNum)
                throw new Exception($"Invalid Tenor! Cannot be More than Tenor settings is {dto.LoanDueNum}");

            return mapper.Map<List<InstalmentSchedule>, List<InstSchdlMinimalDto>>(CalculateInstalmentSchdl(dto.LoanDueNum, dto.LoanAmount, dto.EffectiveDate, scheme));
        }
    }
}
