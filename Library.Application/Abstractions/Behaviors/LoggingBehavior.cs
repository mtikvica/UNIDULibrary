﻿using Library.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Abstractions.Behaviors;
public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing command {Command}", name);

            var result = await next();

            _logger.LogInformation("Command {Command} executed successfully!", name);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Command {Command} failed!", name);

            throw;
        }
    }
}