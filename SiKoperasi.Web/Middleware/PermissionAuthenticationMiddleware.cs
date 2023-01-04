using SiKoperasi.Auth.Contract;
using System.Net;

namespace SiKoperasi.Web.Middleware
{
    public class PermissionAuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IRoleService roleService;
        public PermissionAuthenticationMiddleware(RequestDelegate next, IRoleService roleService)
        {
            this.next = next;
            this.roleService = roleService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool isPermited = await roleService.IsUserHasPermission(context);
            if (!isPermited)
            {
                await HandleResponse(context);
            }else
                await next(context);
        }

        private static Task HandleResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return context.Response.WriteAsync("Unauthorized Permission");
        }
    }
}
