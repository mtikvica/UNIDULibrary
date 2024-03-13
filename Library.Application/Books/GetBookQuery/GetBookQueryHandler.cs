using Dapper;
using Library.Application.Abstractions.Data;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.Books;

namespace Library.Application.Books.GetBookQuery;
internal sealed class GetBookQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetBookQuery, BookResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<BookResponse>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

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
                 WHERE b.[Id] = @BookId
            """;

        var books = await connection.QueryAsync<BookResponse, AuthorResponse, BookResponse>(sql, (book, author) =>
        {

            book.Authors.Add(author);
            return book;
        },
        new { request.BookId },
        splitOn: "AuthorName");

        if (!books.Any())
        {
            return Result.Failure<BookResponse>(BookErrors.NotFound);
        }


        return books.GroupBy(b => b.Id).Select(group =>
        {
            var book = group.First();
            book.Authors = group.SelectMany(b => b.Authors).Distinct().ToList();
            return book;
        }).First();
    }
}
