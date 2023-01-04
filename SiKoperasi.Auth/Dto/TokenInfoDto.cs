namespace SiKoperasi.Auth.Dto
{
    public record TokenInfoDto(string Token, DateTime ValidFrom, DateTime ValidUntil);
}
