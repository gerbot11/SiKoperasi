using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using static Google.Apis.Drive.v3.DriveService;

namespace SiKoperasi.Web.Common
{
    public class FileUploadExtService : IFileUploadExtService
    {

        public string GoogleDriveUpload(string folder)
        {

            return CreateFolder(folder, "Test SI Koperasi");
        }

        private static DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = "ya29.a0AX9GBdVm33kR1t_I-lyuJK7_4Sgsm81-O_bqFDyeWOoC9MbOxOidERt3qCTsQyWAdfHUrFxGZBLec6VOI6g3FCyU7Iqa6nS5xxQzwtCwPZewIb2CiIXc6X2tj6DFwlZhSCcROWOWzzjfSCXifF8nBPOHhbc1aCgYKAZoSARASFQHUCsbCxTbNpBJ2GfzPQkv4BswEdA0163",
                RefreshToken = "1//04M1RAs5e1waoCgYIARAAGAQSNwF-L9IrIDCvCgg-2M77Z_JjmKq85Qk4DI5jDb-6okWqMThC__q6QaDvs-rbwtoP8tUybyN7sQE",
            };


            var applicationName = "SI Koperasi"; // Use the name of the project in Google Cloud
            var username = "dj.gerbot.music@gmail.com"; // Use your email


            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "88113512789-bmdbn6krrhihh2faqdfc2tfng0ttjj0s.apps.googleusercontent.com",
                    ClientSecret = "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"
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

        public string CreateFolder(string parent, string folderName)
        {
            var service = GetService();
            var driveFolder = new Google.Apis.Drive.v3.Data.File
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                Parents = new string[] { parent }
            };

            var command = service.Files.Create(driveFolder);
            var file = command.Execute();
            return file.Id;
        }
    }
}
