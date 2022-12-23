namespace SiKoperasi.AppService.Contract
{
    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(string userid, string username);
    }
}
