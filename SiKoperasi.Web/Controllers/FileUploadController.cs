using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiKoperasi.Web.Controllers
{
    public class FileUploadController : BaseController<FileUploadController>
    {
        public FileUploadController(ILogger<FileUploadController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            return Ok();
        }
    }
}
