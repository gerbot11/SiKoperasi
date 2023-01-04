using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;

namespace SiKoperasi.Auth.Contract
{
    public interface IJwtTokenGeneratorService
    {
        TokenInfoDto GenerateToken(User user);
    }
}
