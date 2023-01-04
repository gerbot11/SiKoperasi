using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dao;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using System.Text.RegularExpressions;
using static SiKoperasi.Auth.Commons.Constant;

namespace SiKoperasi.Auth.Services
{
    public class UserService : BaseCrudService<User, UserCreateDto, UserEditDto, UserDto, AuthDbContext>, IUserService
    {
        private readonly IRegisterService registerService;
        public UserService(AuthDbContext dbContext, IMapper mapper, IRegisterService registerService) : base(dbContext, mapper)
        {
            this.registerService = registerService;
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto payload) => await BaseCreateAsync(payload);
        public async Task<UserDto> EditUserAsync(UserEditDto payload) => await BaseEditAsync(payload.Id, payload);
        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var userdto = await dbContext.Users.Where(a => a.Id == id)
                .AsSplitQuery()
                .Include(a => a.UserRoles).ThenInclude(a => a.Role)
                .Select(a => new UserDto
                {
                    Email = a.Email,
                    FullName = a.FullName,
                    Id = a.Id,
                    Password = "******",
                    Phone = a.Phone,
                    Username = a.Username,
                    Roles = a.UserRoles.Where(x => x.UserId == id)
                        .Select(x => new RoleDto
                        {
                            Code = x.Role.Code,
                            Description = x.Role.Description,
                            Id = x.Role.Id,
                            Name = x.Role.Name
                        }).ToList()
                }).SingleOrDefaultAsync();

            if (userdto is null)
                throw new Exception("User Not Found");

            return userdto;
        }

        public async Task<PagingModel<UserDto>> GetUserPagingAsync(QueryParamDto queryParam)
        {
            var query = from a in dbContext.Users
                        select new User
                        {
                            Email = a.Email,
                            FullName = a.FullName,
                            Id = a.Id,
                            Password = "*********",
                            Phone = a.Phone,
                            Username = a.Username
                        };

            return await BaseGetPagingDataDtoAsync(queryParam, query);
        }

        private void RegisterValidationAsync(User user)
        {
            if (!Regex.IsMatch(user.Email, REGEX_EMAIL))
                throw new Exception(REGISTER_ERR_EMAIL_INVALID);

            //if (!Regex.IsMatch(user.Phone, REGEX_MOBILE_PHONE))
            //    throw new Exception(REGISTER_ERR_PHONE_INVALID);

            if (!user.UserRoles.Any())
                throw new Exception(REGISTER_ERR_NO_ROLE);

            if (dbContext.Users.Any(a => a.Username == user.Username))
                throw new Exception(REGISTER_ERR_DUPLICATE_USERNAME);

            if (dbContext.Users.Any(a => a.Email == user.Email))
                throw new Exception(REGISTER_ERR_DUPLICATE_EMAIL);

            if (dbContext.Users.Any(a => a.Phone == user.Phone))
                throw new Exception(REGISTER_ERR_DUPLICATE_PHONENUMBER);
        }

        private static string TransformPhoneNumber(string phoneNumber)
        {
            if (phoneNumber != null && phoneNumber.StartsWith("0"))
            {
                var newPhone = Regex.Replace(phoneNumber, "^0", INDONESIA_PHONE_PREFIX);
                return newPhone;
            }

            return phoneNumber ?? string.Empty;
        }

        protected override User CreateNewModel(UserCreateDto payload)
        {
            User user = mapper.Map<User>(payload);
            user.Phone = TransformPhoneNumber(payload.Phone);
            user.Password = registerService.EncryptPassword(payload.Password);
            foreach (var item in payload.Roles)
            {
                UserRole ur = new()
                {
                    User = user,
                    RoleId = item
                };
                user.UserRoles.Add(ur);
            }
            return user;
        }

        protected override DbSet<User> GetAppDbSet()
        {
            return dbContext.Users;
        }

        protected override UserDto MappingToResultCrud(User model)
        {
            return base.MappingToResult(model);
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(User.Username);
        }

        protected override void SetModelValue(User model, UserEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<User> SetQueryable()
        {
            return GetAppDbSet()
                .Include(a => a.UserRoles).ThenInclude(a => a.Role).AsNoTracking().AsSplitQuery();
        }

        protected override void ValidateCreate(User model)
        {
            RegisterValidationAsync(model);
        }

        protected override void ValidateDelete(User model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(User model)
        {
            throw new NotImplementedException();
        }
    }
}
