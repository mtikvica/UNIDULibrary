using Library.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Library.Application.Abstractions.Behaviors;
public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
    where TResponse : Result
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing request {Request}", name);

            var result = await next();

            if (result.IsSuccess)
            {
                _logger.LogInformation("Request {Request} executed successfully!", name);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                    _logger.LogError("Request {Request} processed with error", name);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request {Request} failed!", name);

            throw;
        }
    }
}
