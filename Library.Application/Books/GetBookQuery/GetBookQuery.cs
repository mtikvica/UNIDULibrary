using Library.Application.Abstractions.Messaging;

namespace Library.Application.Books.GetBookQuery;
public sealed record GetBookQuery(Guid BookId) : IQuery<BookResponse>;