using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.DataAccess.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiKoperasi.AppService.Contract
{
    public interface IRefService
    {
        Task CreateDriveFolderMapping(string folderName, string folderId);
        Task<RefLoanDocDto> CreateRefLoanDocAsync(RefLoanDocCreateDto payload);
        Task<DriveFolderMap>? GetDriveByNameAsync(string name);
    }
}
