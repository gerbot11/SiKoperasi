namespace SiKoperasi.Auth.Commons
{
    public class JwtSettings
    {
        public string Secret { get; init; } = null!;
        public int ExpiredTime { get; init; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;

        public const string SECTION_NAME = "JwtSettings";
    }
}
