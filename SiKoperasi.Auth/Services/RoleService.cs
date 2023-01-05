using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dao;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using System.Security.Claims;

namespace SiKoperasi.Auth.Services
{
    public class RoleService : BaseCrudService<Role, RoleCreateDto, RoleEditDto, RoleDto, AuthDbContext>, IRoleService
    {
        public RoleService(AuthDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<RoleDto> CreateRoleAsync(RoleCreateDto payload) => await BaseCreateAsync(payload);
        public async Task<RoleDto> EditRoleAsync(RoleEditDto payload) => await BaseEditAsync(payload.Id, payload);
        public async Task<PagingModel<RoleDto>> GetPagingRoleAsync(QueryParamDto queryParam) => await BaseGetPagingDataDtoAsync(queryParam);
        public async Task<RoleDto> GetRoleByIdAsync(string id) => await BaseGetByIdAsync(id);
        public async Task DeleteRoleAsync(string id) => await BaseDeleteAsync(id);

        public async Task<bool> IsUserHasPermission(HttpContext context)
        {
            if (context.Request.Method != HttpMethod.Get.Method)
            {
                string? claimContext = context.User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault();
                if (claimContext is null)
                    return true;

                string[] reqPathArr = context.Request.Path.Value.Split('/').ToArray();
                string reqPath = $"/{reqPathArr[1]}/{reqPathArr[2]}";

                bool queryCheck = await (from a in dbContext.UserRoles
                                         join b in dbContext.RolePermissions on a.RoleId equals b.RoleId
                                         join c in dbContext.MenuPermissions on b.PermissionId equals c.PermissionId
                                         join d in dbContext.Menus on c.MenuId equals d.Id
                                         where a.UserId == claimContext && d.Url.Contains(reqPath)
                                         select a).AnyAsync();

                return queryCheck;
            }

            return true;
        }

        protected override Role CreateNewModel(RoleCreateDto payload)
        {
            return mapper.Map<Role>(payload);
        }

        protected override DbSet<Role> GetAppDbSet()
        {
            return dbContext.Roles;
        }

        protected override RoleDto MappingToResultCrud(Role model)
        {
            return base.MappingToResult(model);
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Role.Name);
        }

        protected override void SetModelValue(Role model, RoleEditDto payload)
        {
            model.Name = payload.Name;
            model.Description = payload.Description;
            model.Code = payload.Code;
        }

        protected override IQueryable<Role> SetQueryable()
        {
            return GetAppDbSet();
        }

        protected override void ValidateCreate(Role model)
        {
            if (dbContext.Roles.Any(a => a.Code == model.Code))
                throw new Exception($"Duplicate Role Code: {model.Code}");
        }

        protected override void ValidateDelete(Role model)
        {
            var userRole = dbContext.UserRoles.Where(a => a.RoleId == model.Id);
            foreach (var item in userRole)
            {
                dbContext.UserRoles.Remove(item);
            }

            var permissionRole = dbContext.RolePermissions.Where(a => a.RoleId == model.Id);
            foreach (var item in permissionRole)
            {
                dbContext.RolePermissions.Remove(item);
            }
        }

        protected override void ValidateEdit(Role model)
        {
            if (dbContext.Roles.Any(a => a.Code == model.Code && a.Id != model.Id))
                throw new Exception($"Duplicate Role Code: {model.Code}");
        }
    }
}
