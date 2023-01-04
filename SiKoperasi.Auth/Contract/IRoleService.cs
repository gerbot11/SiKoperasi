using Microsoft.AspNetCore.Http;
using SiKoperasi.Auth.Commons;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Contract
{
    public interface IRoleService
    {
        Task<RoleDto> CreateRoleAsync(RoleCreateDto payload);
        Task DeleteRoleAsync(string id);
        Task<RoleDto> EditRoleAsync(RoleEditDto payload);
        Task<PagingModel<RoleDto>> GetPagingRoleAsync(QueryParamDto queryParam);
        Task<RoleDto> GetRoleByIdAsync(string id);
        Task<bool> IsUserHasPermission(HttpContext context);
    }
}
