using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiKoperasi.Web.Controllers
{
    public class PermissionController : BaseController<PermissionController>
    {
        public PermissionController(ILogger<PermissionController> logger) : base(logger)
        {
        }
    }
}
