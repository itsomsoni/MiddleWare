
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
}
