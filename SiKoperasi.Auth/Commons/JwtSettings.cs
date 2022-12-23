namespace SiKoperasi.Auth.Commons
{
    public class JwtSettings
    {
        public string Secret { get; init; }
        public int ExpiredTime { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }

        public const string SECTION_NAME = "JwtSettings";
    }
}
