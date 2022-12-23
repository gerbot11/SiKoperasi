using Microsoft.AspNetCore.Identity;
using SiKoperasi.AppService.Contract;
using SiKoperasi.Auth.Models;

namespace SiKoperasi.Auth.Services
{
    public class LoginService : ILoginService
    {
        private readonly IPasswordHasher<User> passwordHasher;

        public LoginService(IPasswordHasher<User> passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }

        public string EncryptPassword(string password)
        {
            User user = new();
            string enct = passwordHasher.HashPassword(user, password);
            return enct;
        }

        public bool PasswordVerification(string hashedPassword, string providedPassword)
        {
            bool isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            return isValid;
        }
    }
}
