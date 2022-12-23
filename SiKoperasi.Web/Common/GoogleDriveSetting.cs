namespace SiKoperasi.Web.Common
{
    public class GoogleDriveSetting
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; }
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string AppName { get; init; }
        public string Username { get; init; }

        public const string SECTION_NAME = "GoogleDriveSettings";
    }
}
