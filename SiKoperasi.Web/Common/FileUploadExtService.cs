using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Options;
using static Google.Apis.Drive.v3.DriveService;

namespace SiKoperasi.Web.Common
{
    public class FileUploadExtService : IFileUploadExtService
    {
        private readonly GoogleDriveSetting googleDriveSetting;
        public FileUploadExtService(IOptions<GoogleDriveSetting> googleDriveSetting)
        {
            this.googleDriveSetting = googleDriveSetting.Value;
        }

        public async Task<string> GoogleDriveUpload(string parentFolderId, string parentFolderName, string foldername, IFormFile file)
        {
            string fileId;
            string? existFolder = await CheckExistFolder(foldername, parentFolderId);
            if (!string.IsNullOrEmpty(existFolder))
            {
                fileId = await CreateFile(existFolder, file);
            }
            else
            {
                string folderIdcreated = await CreateFolder(parentFolderId, foldername);
                fileId = await CreateFile(folderIdcreated, file);
            }

            return fileId;
        }

        private async Task<string> CreateFolder(string parent, string folderName)
        {
            var service = GetService();
            var driveFolder = new Google.Apis.Drive.v3.Data.File
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                Parents = new string[] { parent }
            };

            var command = service.Files.Create(driveFolder);
            var file = await command.ExecuteAsync();
            return file.Id;
        }

        private async Task<string> CreateFile(string folder, IFormFile file)
        {
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File
            {
                Name = file.FileName,
                MimeType = file.ContentType,
                Parents = new string[] { folder }
            };

            var request = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
            request.Fields = "id";

            var response = await request.UploadAsync();
            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                throw response.Exception;

            return request.ResponseBody.Id;
        }

        private async Task<string?> CheckExistFolder(string folderName, string parentFolder)
        {
            DriveService service = GetService();
            var fileList = service.Files.List();
            fileList.Q = $"mimeType='application/vnd.google-apps.folder' and parents='{parentFolder}'";
            fileList.Fields = "nextPageToken, files(id, name)";
            fileList.Spaces = "drive";

            var result = new List<Google.Apis.Drive.v3.Data.File>();
            string? pageToken = null;
            do
            {
                fileList.PageToken = pageToken;

                var filesResult = await fileList.ExecuteAsync();
                var files = filesResult.Files.Where(a => a.Name == folderName);
                pageToken = filesResult.NextPageToken;

                result.AddRange(files);
            } while (pageToken != null);

            return result.Select(a => a.Id).FirstOrDefault();
        }

        public bool GetFolder(string folder)
        {
            DriveService service = GetService();
            var fileList = service.Files.List();
            fileList.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folder}'";
            fileList.Fields = "nextPageToken, files(id, name)";
            fileList.Spaces = "drive";

            var result = new List<Google.Apis.Drive.v3.Data.File>();
            string? pageToken = null;
            do
            {
                
                fileList.PageToken = pageToken;

                var filesResult = fileList.Execute();
                var files = filesResult.Files;

                pageToken = filesResult.NextPageToken;
                result.AddRange(files);
            } while (pageToken != null);

            return result.Any();
        }

        private DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = googleDriveSetting.AccessToken, 
                RefreshToken = googleDriveSetting.RefreshToken
            };


            var applicationName = googleDriveSetting.AppName; 
            var username = googleDriveSetting.Username;


            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = googleDriveSetting.ClientId,
                    ClientSecret = googleDriveSetting.ClientSecret
                },
                Scopes = new[] { Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            });


            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);


            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            return service;
        }
    }
}
