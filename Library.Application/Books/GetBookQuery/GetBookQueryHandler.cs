using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.Books;

namespace Library.Application.Books.GetBookQuery;
internal sealed class GetBookQueryHandler : IQueryHandler<GetBookQuery, BookResponse>
{
    private readonly IBookRepository _bookRepository;

    public async Task<Result<BookResponse>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId, cancellationToken);
        if (book is null)
        {
            return Result.Failure<BookResponse>(BookErrors.NotFound);
        }

        var response = BookResponse.Create(book);

        return Result.Success(response);
    }
}
