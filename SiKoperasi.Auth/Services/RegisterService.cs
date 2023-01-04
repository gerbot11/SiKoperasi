using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dao;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;
using SiKoperasi.Core.Common;
using static SiKoperasi.Auth.Commons.Constant;

namespace SiKoperasi.Auth.Services
{
    public class RegisterService : BaseSimpleService<AuthDbContext>, IRegisterService
    {
        private readonly IPasswordHasher<User> passwordHasher;
        public RegisterService(AuthDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher) : base(dbContext, mapper)
        {
            this.passwordHasher = passwordHasher;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            await RegisterValidationAsync(registerDto);
            User user = new()
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = EncryptPassword(registerDto.Password),
                FullName = registerDto.FullName,
                Phone = registerDto.PhoneNumber
            };

            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

            RegisterResponseDto response = new(user.Id, user.Username, null, null);
            return response;
        }

        public string EncryptPassword(string password)
        {
            User user = new();
            string enct = passwordHasher.HashPassword(user, password);
            return enct;
        }

        private async Task RegisterValidationAsync(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.PasswordConfirm)
                throw new Exception(REGISTER_ERR_UNMATCH_PASSWORD);

            if (await dbContext.Users.AnyAsync(a => a.Username == registerDto.Username))
                throw new Exception(REGISTER_ERR_DUPLICATE_USERNAME);

            if (await dbContext.Users.AnyAsync(a => a.Email == registerDto.Email))
                throw new Exception(REGISTER_ERR_DUPLICATE_EMAIL);

            if (await dbContext.Users.AnyAsync(a => a.Phone == registerDto.PhoneNumber))
                throw new Exception(REGISTER_ERR_DUPLICATE_PHONENUMBER);
        }
    }
}
