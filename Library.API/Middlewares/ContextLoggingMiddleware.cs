using Serilog.Context;

namespace Library.API.Middlewares;

public class ContextLoggingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext httpContext)
    {
        var correlationId = httpContext.Request.Headers["X-Correlation-ID"].FirstOrDefault() ?? httpContext.TraceIdentifier;
        using (LogContext.PushProperty("CorrelationId", correlationId))
        {
            await _next(httpContext);
        }
    }
}
