using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.Web.Controllers
{
    public class MemberController : BaseController<MemberController>
    {
        private readonly IMemberService memberService;
        public MemberController(ILogger<MemberController> logger, IMemberService memberService) : base(logger)
        {
            this.memberService = memberService;
        }

        [HttpPost("newmember")]
        public async Task<IActionResult> CreateMember(MemberCreateDto dto)
        {
            await memberService.CreateMemberAsync(dto);
            return Ok(dto);
        }
    }
}
