using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiKoperasi.Web.Common;
using System.Net;

namespace SiKoperasi.Web.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            ErrorModel errorModel = new()
            {
                ErrorMessage = ex.InnerException is null ? ex.Message : ex.InnerException.Message,
                Status = (int) code
            };

            var result = JsonConvert.SerializeObject(errorModel);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
