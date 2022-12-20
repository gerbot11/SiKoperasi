using SiKoperasi.AppService.Dto.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiKoperasi.AppService.Contract
{
    public interface IRefService
    {
        Task<RefLoanDocDto> CreateRefLoanDocAsync(RefLoanDocCreateDto payload);
    }
}
