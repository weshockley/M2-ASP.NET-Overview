namespace Middleware;

public class RequestLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation($">[RequestLoggerMiddleware] Handling request: {context.Request.Path}/{context.Request.Query}");
        await _next.Invoke(context);
        _logger.LogInformation(">[RequestLoggerMiddleware] Finished handling request.");
    }
}
