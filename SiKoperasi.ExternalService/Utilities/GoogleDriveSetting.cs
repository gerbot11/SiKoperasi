namespace SiKoperasi.ExternalService.Utilities
{
    public class GoogleDriveSetting
    {
        public string AccessToken { get; init; } = null!;
        public string RefreshToken { get; init; } = null!;
        public string ClientId { get; init; } = null!;
        public string ClientSecret { get; init; } = null!;
        public string AppName { get; init; } = null!;
        public string Username { get; init; } = null!;

        public const string SECTION_NAME = "GoogleDriveSettings";
    }
}
