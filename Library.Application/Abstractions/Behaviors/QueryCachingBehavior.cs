using Library.Application.Abstractions.Caching;
using Library.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Abstractions.Behaviors;
internal sealed class QueryCachingBehavior<TRequest, TReponse>
    (ICacheService cacheService, ILogger<QueryCachingBehavior<TRequest, TReponse>> logger)
    : IPipelineBehavior<TRequest, TReponse>
    where TRequest : ICachedQuery
    where TReponse : Result
{
    private readonly ICacheService _cacheService = cacheService;
    private readonly ILogger<QueryCachingBehavior<TRequest, TReponse>> _logger = logger;

    public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
    {
        var cachedResult = await _cacheService.GetAsync<TReponse>(
            request.CacheKey,
            cancellationToken
            );

        var name = typeof(TRequest).Name;

        if (cachedResult is not null)
        {
            _logger.LogInformation("Cache hit for query {Query}", name);

            return cachedResult;
        }

        _logger.LogInformation("Cache miss for query {Query}", name);

        var result = await next();

        if (result.IsSuccess)
        {
            await _cacheService.SetAsync(request.CacheKey, result, request.Expiration, cancellationToken);
        }

        return result;
    }
}
