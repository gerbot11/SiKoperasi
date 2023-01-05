using Microsoft.AspNetCore.Mvc.Filters;
using SiKoperasi.Auth.Contract;
using System.Net;

namespace SiKoperasi.Web.FilterAttribute
{
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        private readonly IRoleService roleService;
        public PermissionFilterAttribute(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool isPermited = await roleService.IsUserHasPermission(context.HttpContext);
            if (!isPermited)
                await HandleResponse(context.HttpContext);
            else
                await next();
        }

        private static Task HandleResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return context.Response.WriteAsync("Unauthorized Permission");
        }
    }
}
