using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dto;

namespace SiKoperasi.Web.Controllers
{
    public class AuthController : BaseController<AuthController>
    {
        private readonly ILoginService loginService;
        private readonly IRegisterService registerService;
        public AuthController(ILogger<AuthController> logger, ILoginService loginService, IRegisterService registerService) : base(logger)
        {
            this.registerService = registerService;
            this.loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var data = await loginService.LoginProcess(dto);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var data = await registerService.RegisterAsync(dto);
            return Ok(data);
        }
    }
}
