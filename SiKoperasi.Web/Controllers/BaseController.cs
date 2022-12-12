using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SiKoperasi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TController> : ControllerBase
    {
        protected ILogger<TController> logger;
        public BaseController(ILogger<TController> logger)
        {
            this.logger = logger;
        }

        protected void LoggingPayload<TPayload>(TPayload payload) where TPayload : class
        {
            logger.LogInformation(typeof(TPayload).Name + "\n" + JsonConvert.SerializeObject(payload, Formatting.Indented));
        }
    }
}
