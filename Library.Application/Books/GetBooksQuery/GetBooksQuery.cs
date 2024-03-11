using Library.Application.Abstractions.Messaging;
using Library.Application.Books.GetBookQuery;
using Library.Application.Shared;

namespace Library.Application.Books.GetBooksQuery;
public sealed record GetBooksQuery(int Page, int PageSize) : IQuery<PaginatedResponse<BookResponse>>;