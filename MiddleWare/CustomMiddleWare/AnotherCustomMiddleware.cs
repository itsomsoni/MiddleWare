using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare.CustomMiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnotherCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public AnotherCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Another Custom MiddleWare Called.\n\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Another Custom MiddleWare Finished\n\n.");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnotherCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnotherCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherCustomMiddleware>();
        }
    }
}
