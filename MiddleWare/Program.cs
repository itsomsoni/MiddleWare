using MiddleWare.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyMiddleWare>();

var app = builder.Build();

app.UseRouting();

app.Use(async (context, next) =>
{
    Endpoint? endpoint = context.GetEndpoint();
    if (endpoint != null)
        await context.Response.WriteAsync(endpoint.DisplayName + Environment.NewLine);
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapGet("/Product/{id:int}", async (context) =>
    {
        int Id = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (Id != 0)
            await context.Response.WriteAsync($"This is product with ID: {Id}");
        else
            await context.Response.WriteAsync($"Wrong Request Fired.");
    });

    _ = endpoints.MapGet("/books/author/{authorname:alpha:length(6)}/{bookid:int?}", async (context) =>
    {
        var BookId = (context.Request.RouteValues["bookid"]);
        var AuthorName = (context.Request.RouteValues["authorname"]);

        if (BookId != null)
        {
            await context.Response.WriteAsync($"Author Name: {AuthorName} & BookId: {BookId}");
        }
        else
        {
            await context.Response.WriteAsync($"Following Are the book by Author Name: {AuthorName}.");
        }
    });
});

/*app.UseEndpoints(endpoints =>
{
    _ = endpoints.Map("/Home", async (context) =>
    {
        await context.Response.WriteAsync("You Are In Home Page.");
    });

    _ = endpoints.MapGet("/Product", async (context) =>
    {
        await context.Response.WriteAsync("You Are In Product Page With Get Method.");
    });
    _ = endpoints.MapPost("/Product", async (context) =>
    {
        await context.Response.WriteAsync("You Are In Product Page With Post Method.");
    });
});*/

app.Run(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Requested Page Not Found.");
});

/*//app.MapGet("/", () => "Hello World!");

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome To ASP.NET Core App. Also MiddleWare First.\n");
    await next(context);
});
//custom middleware
//app.UseMiddleware<MyMiddleWare>();
//app.MyMiddleWare();
//app.UseAnotherCustomMiddleware();

app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized")
&& Convert.ToBoolean(context.Request.Query["IsAuthorized"]) == true,
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Conditional MiddleWare Called.\n\n");
            await next(context);
        });
    });

app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized") &&
Convert.ToBoolean(context.Request.Query["IsAuthorized"]) == true, app =>
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("This Is UseWhen Conditon Called.\n");
        await next(context);
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This Is MiddleWare - 3\n");
});*/

app.Run();
