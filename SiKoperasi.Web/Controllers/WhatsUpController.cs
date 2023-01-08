using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using static SiKoperasi.AppService.Util.Constant;

namespace SiKoperasi.Web.Controllers
{
    public class WhatsUpController : BaseController<WhatsUpController>
    {
        private readonly IRefService refService;
        public WhatsUpController(ILogger<WhatsUpController> logger, IRefService refService) : base(logger)
        {
            this.refService = refService;
        }

        [HttpGet(REST_WA_CALLBACK)]
        public async Task<IActionResult> WebhookVerification(
                [FromQuery(Name = "hub.mode")] string hubMode,
                [FromQuery(Name = "hub.challenge")] int hubChallenge,
                [FromQuery(Name = "hub.verify_token")] string hubVerifyToken)
        {
            logger.LogInformation("Recieve verification call from WhatsApp API");
            logger.LogInformation($"mode : {hubMode}");
            logger.LogInformation($"challenge : {hubChallenge}");
            logger.LogInformation($"verify_token : {hubVerifyToken}");

            List<string> verificationCode = await refService.GetRefMasterValueByCodeAsync(REF_WA_VERIFICATION_CODE);
            if (hubVerifyToken != verificationCode.First())
                return BadRequest("Invalid Verification Token");

            return Ok(hubChallenge);
        }
    }
}
