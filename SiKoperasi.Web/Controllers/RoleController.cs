using Microsoft.AspNetCore.Mvc;
using SiKoperasi.Auth.Contract;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    //[ServiceFilter(typeof(PermissionFilterAttribute))]
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

        [HttpPut]
        public async Task<IActionResult> Edit(RoleEditDto dto)
        {
            LoggingPayload(dto);
            var data = await roleService.EditRoleAsync(dto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await roleService.DeleteRoleAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaging([FromQuery] QueryParamDto queryParam)
        {
            var data = await roleService.GetPagingRoleAsync(queryParam);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var data = await roleService.GetRoleByIdAsync(id);
            return Ok(data);
        }
    }
}
