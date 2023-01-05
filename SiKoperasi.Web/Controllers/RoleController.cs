using Microsoft.AspNetCore.Mvc;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    [ServiceFilter(typeof(PermissionFilterAttribute))]
    public class RoleController : BaseController<RoleController>
    {
        private readonly IRoleService roleService;
        public RoleController(ILogger<RoleController> logger, IRoleService roleService) : base(logger)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await roleService.CreateRoleAsync(dto);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaging([FromQuery] QueryParamDto queryParam)
        {
            var data = await roleService.GetPagingRoleAsync(queryParam);
            return Ok(data);
        }
    }
}
