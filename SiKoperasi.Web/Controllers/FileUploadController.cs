using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiKoperasi.Web.Controllers
{
    public class FileUploadController : BaseController<FileUploadController>
    {
        private const string UPL_FOLDER = "FileUpload";
        private readonly IWebHostEnvironment env;
        private readonly IFileUploadExtService fileUploadExtService;
        public FileUploadController(ILogger<FileUploadController> logger, IWebHostEnvironment env, IFileUploadExtService fileUploadExtService) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            return Ok();
        }
    }
}
