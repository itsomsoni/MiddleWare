using MiddleWare.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyMiddleWare>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome To ASP.NET Core App. Also MiddleWare First.\n");
    await next(context);
});
//custom middleware
//app.UseMiddleware<MyMiddleWare>();
app.MyMiddleWare();
app.UseAnotherCustomMiddleware();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This Is" +
        " MiddleWare - 3\n");
});

app.Run();
