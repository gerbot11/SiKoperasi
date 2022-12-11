using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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
    }
}
