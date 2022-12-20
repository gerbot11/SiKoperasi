using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Contract
{
    public interface IInstalmentService
    {
        List<InstalmentSchedule> CalculateInstalmentSchdl(Loan loan);
        Task<IEnumerable<InstSchdlDto>> GetLoanInstSchdlsAsync(string loanid);
    }
}
