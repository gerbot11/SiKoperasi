using Microsoft.AspNetCore.Http;

namespace SiKoperasi.ExternalService.Contract
{
    public interface IGoogleDriveService
    {
        Task DeleteFileAsync(string fileid);
        Task<string> GoogleDriveCreateParentFolder(string folderName);
        Task<string> GoogleDriveUploadFile(string parentFolderId, string foldername, IFormFile file);
    }
}
