using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dao;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;
using SiKoperasi.Core.Common;
using System.Security.Authentication;
using static SiKoperasi.Auth.Commons.Constant;

namespace SiKoperasi.Auth.Services
{
    public class LoginService : BaseService<User, LoginDto, AuthDbContext>, ILoginService
    {
        private readonly IJwtTokenGeneratorService jwtTokenGeneratorService;
        
        public LoginService(AuthDbContext dbContext, IMapper mapper, IJwtTokenGeneratorService jwtTokenGeneratorService) : base(dbContext, mapper)
        {
            this.jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public async Task<LoginResponseDto> LoginProcess(LoginDto payload)
        {
            User? user = await dbContext.Users.SingleOrDefaultAsync(a => a.Username == payload.Username && a.IsActive);
            if (user is null)
            {
                await InsertLoginAttempt(LOGIN_ERR_USER_NOT_EXIST, false);
                throw new AuthenticationException(LOGIN_ERR_USER_NOT_EXIST);
            }

            bool isPasswordMatch = PasswordVerification(user.Password, payload.Password);
            if (!isPasswordMatch)
            {
                await InsertLoginAttempt(LOGIN_ERR_INVALID_PASSWORD, false, username: user.Username);
                throw new AuthenticationException(LOGIN_ERR_INVALID_PASSWORD);
            }

            user.UserRoles = dbContext.UserRoles.Where(a => a.UserId == user.Id).Include(a => a.Role).ToList();
            List<RoleDto> roles = new();
            foreach (var item in user.UserRoles)
            {
                List<PermissionDto> permissions = dbContext.RolePermissions
                    .Where(a => a.RoleId == item.RoleId)
                    .Include(a => a.Permission)
                    .Select(a => new PermissionDto
                    {
                        Code = a.Permission.Code,
                        Name = a.Permission.Name,
                        Description = a.Permission.Description,
                        Id = a.Permission.Id
                    }).ToList();

                RoleDto roleDto = new()
                {
                    Id = item.RoleId,
                    Code = item.Role.Code,
                    Description = item.Role.Description,
                    Name = item.Role.Name,
                    Permissions = permissions
                };

                roles.Add(roleDto);
            }

            TokenInfoDto tokenDto = jwtTokenGeneratorService.GenerateToken(user);
            LoginResponseDto loginResponse = new(user.Id, user.Username, tokenDto.Token, tokenDto.ValidUntil, roles);
            await InsertLoginAttempt("Login Success", true, loginResponse.Token, user.Username, loginResponse.ValidUntil);
            return loginResponse;
        }

        private static bool PasswordVerification(string hashedPassword, string providedPassword)
        {
            bool isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            return isValid;
        }

        private async Task InsertLoginAttempt(string message, bool isSuccess, string? token = null, string? username = null, DateTime? tokenLifetime = null)
        {
            LoginAttempt loginAttempt = new()
            {
                Username = username ?? "Unknown User",
                FailReason = message,
                Token = token, 
                LoginTime = DateTime.Now,
                IsSuccess = isSuccess,
                ValidUntil = tokenLifetime
            };

            dbContext.Add(loginAttempt);
            await dbContext.SaveChangesAsync();
        }

        protected override DbSet<User> GetAppDbSet()
        {
            return dbContext.Users;
        }

        protected override IQueryable<User> SetQueryable()
        {
            return GetAppDbSet();
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(User.Username);
        }
    }
}
