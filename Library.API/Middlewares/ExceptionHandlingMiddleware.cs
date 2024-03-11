using System.Net;

namespace Library.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private record ExceptionResponse(int StatusCode, string Message, string? InnerExceptionMessage = null);

    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = exception switch
        {
            ApplicationException _ => new ExceptionResponse((int)HttpStatusCode.BadRequest, exception.Message),
            _ => new ExceptionResponse((int)HttpStatusCode.InternalServerError, exception.Message, exception.InnerException?.Message),
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode;

        await context.Response.WriteAsJsonAsync(response);
    }
}
