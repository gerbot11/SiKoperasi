using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Commons;

namespace SiKoperasi.AppService.Contract
{
    public interface IRefService
    {
        Task CreateDriveFolderMapping(string folderName, string folderId);
        Task<RefLoanDocDto> CreateRefLoanDocAsync(RefLoanDocCreateDto payload);
        Task<DriveFolderMap?> GetDriveByNameAsync(string name);
        Task<PagingModel<RefMasterDto>> GetListRefMasterAsync(QueryParamDto queryParam);
        Task<List<string>> GetRefMasterValueByCodeAsync(string code);
    }
}
