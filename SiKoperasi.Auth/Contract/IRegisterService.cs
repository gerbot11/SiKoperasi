using SiKoperasi.Auth.Dto;

namespace SiKoperasi.Auth.Contract
{
    public interface IRegisterService
    {
        string EncryptPassword(string password);
        Task<RegisterResponseDto> RegisterAsync(RegisterDto registerDto);
    }
}
