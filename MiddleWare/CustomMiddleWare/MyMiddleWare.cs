
using System.Runtime.CompilerServices;

namespace MiddleWare.CustomMiddleWare
{
    public class MyMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom MiddleWare Has Runned.\n");
            await next(context);
        }
    }
    public static class CustomMiddleWareExtension
    {
        public static IApplicationBuilder MyMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleWare>();
        }
    }
}
