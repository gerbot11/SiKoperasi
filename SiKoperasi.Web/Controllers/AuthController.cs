using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.Auth.Dto;

namespace SiKoperasi.Web.Controllers
{
    public class AuthController : BaseController<AuthController>
    {
        private readonly IJwtTokenGeneratorService jwtTokenGeneratorService;
        private readonly ILoginService loginService;

        public AuthController(ILogger<AuthController> logger, IJwtTokenGeneratorService jwtTokenGeneratorService, ILoginService loginService) : base(logger)
        {
            this.jwtTokenGeneratorService = jwtTokenGeneratorService;
            this.loginService = loginService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = jwtTokenGeneratorService.GenerateToken(Guid.NewGuid().ToString(), dto.Username);
            string pass = loginService.EncryptPassword(dto.Password);
            bool isValid = loginService.PasswordVerification("$2a$12$Ts8gzsP1dSheOHMYLKqe..PVgw7AyKf.17LgnBZIPkJ98bVJDYo/.", dto.Password);
            return Ok(pass);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            return Ok();
        }
    }
}
