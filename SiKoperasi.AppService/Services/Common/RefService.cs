using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Commons;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Services.Common
{
    public class RefService : BaseSimpleService<AppDbContext>, IRefService
    {
        public RefService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<DriveFolderMap>? GetDriveByNameAsync(string name)
        {
            return await dbContext.DriveFolderMaps.FirstOrDefaultAsync(a => a.FolderName == name);
        }

        public async Task CreateDriveFolderMapping(string folderName, string folderId)
        {
            DriveFolderMap folderMap = new()
            {
                FolderName = folderName,
                FolderId = folderId
            };

            dbContext.Add(folderMap);
            await dbContext.SaveChangesAsync();
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
