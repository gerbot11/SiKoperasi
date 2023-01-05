using Microsoft.AspNetCore.Mvc;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    [ServiceFilter(typeof(PermissionFilterAttribute))]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService userService;
        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPaging([FromQuery] QueryParamDto queryParam)
        {
            var data = await userService.GetUserPagingAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var data = await userService.GetUserByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var data = await userService.CreateUserAsync(dto);
            return Ok(data);
        }
    }
}
