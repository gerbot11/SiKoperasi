using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Contract
{
    public interface IInstalmentService
    {
        List<InstalmentSchedule> CalculateInstalmentSchdl(Loan loan);
    }
}
