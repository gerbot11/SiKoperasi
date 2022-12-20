using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Web.Common;

namespace SiKoperasi.Web.Controllers
{
    public class FileUploadController : BaseController<FileUploadController>
    {
        private const string UPL_FOLDER = "FileUpload";
        private readonly IWebHostEnvironment env;
        private readonly IFileUploadExtService fileUploadExtService;
        public FileUploadController(ILogger<FileUploadController> logger, IWebHostEnvironment env, IFileUploadExtService fileUploadExtService) : base(logger)
        {
            this.env = env;
            this.fileUploadExtService = fileUploadExtService;
        }

        [HttpPost("[action]")]
        public async Task<FileUploadDto> UploadFile(IFormFileCollection formFiles, string code)
        {
            string finalPath = string.Empty;
            string baseLoc = env.ContentRootPath+ "/" + code;

            var file = fileUploadExtService.GoogleDriveUpload(code);
            FileUploadDto dto = new()
            {
                FileName = "Test",
                FullPath = file
            };

            return dto;
        }
    }
}
