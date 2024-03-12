using Dapper;
using Library.Application.Abstractions.Data;
using Library.Application.Abstractions.Messaging;
using Library.Application.Books.GetBookQuery;
using Library.Application.Shared;
using Library.Domain.Abstractions;

namespace Library.Application.Books.GetBooksQuery;
internal sealed class GetBooksQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetBooksQuery, PaginatedResponse<BookResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<PaginatedResponse<BookResponse>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var offset = (request.Page - 1) * request.PageSize;
        var limit = request.PageSize;

        var bookDictionary = new Dictionary<Guid, BookResponse>();
        var authorDictionary = new Dictionary<string, AuthorResponse>();

        const string sql = """
            SELECT
                 b.[Id],
                 b.[Title],
                 b.[NumberOfPages],
                 p.[PublisherName],
                 b.[PublicationYear],
                 b.[ISBN],
                 a.[FirstName] + ' ' + a.[LastName] AS 'AuthorName'
                 FROM [Book] AS b
                 INNER JOIN [AuthorBook] AS ab ON ab.[BookId] = b.[Id]
                 JOIN [Author] AS a ON a.[Id] = ab.[AuthorId]
            	 JOIN [Publisher] as p ON b.PublisherId = p.Id
                 ORDER BY b.[Id]
                 OFFSET @Offset ROWS
                 FETCH NEXT @Limit ROWS ONLY
            """;


        var books = await connection.QueryAsync<BookResponse, AuthorResponse, BookResponse>(sql, (book, author) =>
        {

            book.Authors.Add(author);
            return book;
        },
        new { Offset = offset, Limit = limit },
        splitOn: "AuthorName");

        var result = books.GroupBy(b => b.Id).Select(group =>
        {
            var book = group.First();
            book.Authors = group.SelectMany(b => b.Authors).Distinct().ToList();
            return book;
        });

        return Result.Success(new PaginatedResponse<BookResponse>(result, request.Page, request.PageSize));
    }
}
