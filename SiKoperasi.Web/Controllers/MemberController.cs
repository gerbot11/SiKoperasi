using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Web.FilterAttribute;

namespace SiKoperasi.Web.Controllers
{
    [ServiceFilter(typeof(PermissionFilterAttribute))]
    public class MemberController : BaseController<MemberController>
    {
        private readonly IMemberService memberService;
        private readonly IJobService jobService;
        private readonly IAddressService addressService;

        public MemberController(ILogger<MemberController> logger, IMemberService memberService, IJobService jobService, IAddressService addressService) : base(logger)
        {
            this.memberService = memberService;
            this.jobService = jobService;
            this.addressService = addressService;
        }

        #region Member
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMember(MemberCreateDto dto)
        {
            LoggingPayload(dto);
            var data = await memberService.CreateMemberAsync(dto);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetListMember([FromQuery] QueryParamDto queryparam)
        {
            var data = await memberService.GetMemberPagingAsync(queryparam);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(string id)
        {
            var data = await memberService.GetMemberAsync(id);
            return Ok(data);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditMember(MemberEditDto dto)
        {
            LoggingPayload(dto);
            var data = await memberService.EditMemberAsync(dto);
            return Ok(data);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteMember(string id)
        {
            await memberService.DeleteMember(id);
            return NoContent();
        }
        #endregion

        //#region Job
        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateJob(JobCreateDto dto)
        //{
        //    LoggingPayload(dto);
        //    await jobService.CreateJobAsync(dto);
        //    return Ok(dto);
        //}

        //[HttpPut("[action]")]
        //public async Task<IActionResult> EditJob(JobEditDto dto)
        //{
        //    LoggingPayload(dto);
        //    await jobService.EditJobAsync(dto);
        //    return Ok(dto);
        //}

        //[HttpGet("[action]/{memberid}")]
        //public IActionResult GetJob(string memberid)
        //{
        //    var data = jobService.GetJobByMember(memberid);
        //    return Ok(data);
        //}
        //#endregion

        //#region Address
        //[HttpGet("[action]/{memberid}")]
        //public async Task<IActionResult> GetListAddress(string memberid)
        //{
        //    var data = await addressService.GetAddressDtoByMemberAsync(memberid);
        //    return Ok(data);
        //}

        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> GetAddress(string id)
        //{
        //    var data = await addressService.GetAddressAsync(id);
        //    return Ok(data);
        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateAddress(AddressCreateDto dto)
        //{
        //    LoggingPayload(dto);
        //    await addressService.CreateAddressAsync(dto);
        //    return Ok(dto);
        //}

        //[HttpPut("[action]")]
        //public async Task<IActionResult> EditAddress(AddressEditDto dto)
        //{
        //    LoggingPayload(dto);
        //    await addressService.EditAddressAsync(dto);
        //    return Ok(dto);
        //}

        //[HttpDelete("[action]/{id}")]
        //public async Task<IActionResult> DeleteAddress(string id)
        //{
        //    await addressService.DeleteAddressAsync(id);
        //    return NoContent();
        //}
        //#endregion
    }
}
