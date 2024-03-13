using Library.Application.Abstractions.Caching;

namespace Library.Application.Books.GetBookQuery;
public sealed record GetBookQuery(Guid BookId) : ICachedQuery<BookResponse>
{
    public string CacheKey => $"book-{BookId}";

    public TimeSpan? Expiration => null;
}
