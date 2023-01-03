using Microsoft.AspNetCore.Mvc;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;

namespace SiKoperasi.Web.Controllers
{
    public class FileUploadController : BaseController<FileUploadController>
    {
        private const string BASE_LOAN_FOLDER_ID = "1QbB7kQ7jQaSf4ouU_OfOheiOmthpOUcn";
        private const string BASE_LOAN_FOLDER_NAME = "LOAN";

        private readonly IWebHostEnvironment env;

        public FileUploadController(ILogger<FileUploadController> logger, IWebHostEnvironment env) : base(logger)
        {
            this.env = env;
        }

        [HttpPost("[action]")]
        public async Task<FileUploadDto> UploadFile(IFormFile file, string folderId, string parentFolder)
        {
            FileUploadDto dto = new()
            {
                FileName = file.FileName,
                FullPath = "Not Available",
                Status  = 200
            };

            return dto;
        }
    }
}
