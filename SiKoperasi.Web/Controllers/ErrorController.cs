using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SiKoperasi.Web.Controllers
{
    [Route("error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception is null) 
                return NoContent();

            string title = exception.Message;
            string innerMsg = exception.InnerException != null ? exception.InnerException.Message : exception.Message;

            return Problem(title:title, detail:innerMsg);
        }
    }
}
