using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Services.Common
{
    public class RefService : BaseSimpleService<AppDbContext>, IRefService
    {
        public RefService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        #region Ref Loan Doc
        public async Task<RefLoanDocDto> CreateRefLoanDocAsync(RefLoanDocCreateDto payload)
        {
            if (await dbContext.RefLoanDocuments.AnyAsync(a => a.DocumentName.ToLower() == payload.DocumentName.ToLower()))
                throw new Exception("Duplicate Document Name");

            RefLoanDocument refLoanDocument = mapper.Map<RefLoanDocument>(payload);

            dbContext.Add(refLoanDocument);
            await dbContext.SaveChangesAsync();

            return mapper.Map<RefLoanDocDto>(refLoanDocument);
        }
        #endregion
    }
}
