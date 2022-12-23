namespace SiKoperasi.Web.Common
{
    public interface IFileUploadExtService
    {
        bool GetFolder(string folder);
        Task<string> GoogleDriveUpload(string parentFolderId, string parentFolderName, string foldername, IFormFile file);
    }
}
