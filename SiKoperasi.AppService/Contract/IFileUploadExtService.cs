using Microsoft.AspNetCore.Http;

namespace SiKoperasi.AppService.Contract
{
    public interface IFileUploadExtService
    {
        Task<string> CreateParentFolder(string folderName);
        Task<string> GoogleDriveUpload(string parentFolderId, string foldername, IFormFile file);
    }
}
