using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Logging;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SiKoperasi.ExternalService.Contract;
using SiKoperasi.ExternalService.Utilities;
using static Google.Apis.Drive.v3.DriveService;

namespace SiKoperasi.ExternalService.Services
{
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly GoogleDriveSetting googleDriveSetting;
        private readonly ILogger<GoogleDriveService> logger;
        public GoogleDriveService(IOptions<GoogleDriveSetting> googleDriveSetting, ILogger<GoogleDriveService> logger)
        {
            this.googleDriveSetting = googleDriveSetting.Value;
            this.logger = logger;
        }

        public async Task<string> GoogleDriveUploadFile(string parentFolderId, string foldername, IFormFile file)
        {
            string fileId;
            logger.LogInformation("Starting Upload File to Google Drive...");
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

        public async Task<string> GoogleDriveCreateParentFolder(string folderName)
        {
            var service = GetService();
            logger.LogInformation($"Creating Parent Folder with Name: {folderName}");
            var driveFolder = new Google.Apis.Drive.v3.Data.File
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
            };

            var command = service.Files.Create(driveFolder);
            var file = await command.ExecuteAsync();
            return file.Id;
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
            logger.LogInformation($"Start Create Drive Files to Folder: {folder}");
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

        public async Task DeleteFileAsync(string fileid)
        {
            logger.LogInformation($"Start Delete File with ID: {fileid}");
            DriveService service = GetService();
            var cmd = service.Files.Delete(fileid);
            var result = await cmd.ExecuteAsync();
            logger.LogInformation($"Result: {result}");
        }

        private async Task<string?> CheckExistFolder(string folderName, string parentFolder)
        {
            DriveService service = GetService();
            logger.LogInformation("Validation Existing Folder");
            var fileList = service.Files.List();
            fileList.Q = $"mimeType='application/vnd.google-apps.folder' and parents='{parentFolder}'";
            fileList.Fields = "nextPageToken, files(id, name)";
            fileList.Spaces = "drive";
            logger.LogInformation($"Q : {fileList.Q}");

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

            logger.LogInformation($"File Result Count: {result.Count}");
            return result.Select(a => a.Id).FirstOrDefault();
        }

        private DriveService GetService()
        {
            logger.LogInformation("Create Drive Services..");
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
