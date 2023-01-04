using SiKoperasi.Auth.Dto;
using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Contract
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto payload);
        Task<UserDto> EditUserAsync(UserEditDto payload);
        Task<UserDto> GetUserByIdAsync(string id);
        Task<PagingModel<UserDto>> GetUserPagingAsync(QueryParamDto queryParam);
    }
}
