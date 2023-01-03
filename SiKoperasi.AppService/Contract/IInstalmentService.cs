using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Contract
{
    public interface IInstalmentService
    {
        List<InstSchdlMinimalDto> CalculateInstalmentSchdl(InstSchdlCalculationDto dto);
        List<InstalmentSchedule> CalculateInstalmentSchdl(int tenor, decimal loanAmount, DateTime effDate, LoanScheme loanScheme);
        Task<IEnumerable<InstSchdlDto>> GetLoanInstSchdlsAsync(string loanid);
    }
}
