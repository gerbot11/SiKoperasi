using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.Web.Controllers
{
    public class MemberController : BaseController<MemberController>
    {
        public MemberController(ILogger<MemberController> logger) : base(logger)
        {

        }

        [HttpPost("newmember")]
        public async Task<IActionResult> CreateMember(MemberCreateDto dto)
        {
            return Ok(dto);
        }
    }
}
