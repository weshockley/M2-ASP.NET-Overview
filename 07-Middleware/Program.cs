using Middleware;

var builder = WebApplication.CreateBuilder(args);

// HACK Middleware: We configured here the ASP.NET Logging to log to debug (Output Window)
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddDebug();

var app = builder.Build();

// HACK Middleware: Uncomment the statement below.
// Inline middleware implementation below
app.Use(async (context, next) =>
{
    app.Logger.LogInformation($"Handling request: {context.Request.Path}/{context.Request.Query}");


    await next.Invoke();
    app.Logger.LogInformation("Finished handling request.");
});

app.UseRequestLogger();

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from app.Run()");
//});

app.Run();
