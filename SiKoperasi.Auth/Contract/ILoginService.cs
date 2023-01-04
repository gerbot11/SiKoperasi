using SiKoperasi.Auth.Commons;
using SiKoperasi.Auth.Dto;

namespace SiKoperasi.Auth.Contract
{
    public interface ILoginService
    {
        Task<LoginResponseDto> LoginProcess(LoginDto payload);
    }
}
