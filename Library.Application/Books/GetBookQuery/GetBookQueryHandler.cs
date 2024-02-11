using Dapper;
using Library.Application.Abstractions.Data;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;

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
                b.[Pages],
                b.[Publisher],
                b.[PublicationYear],
                b.[ISBN],
                a.[Id],
                a.[FirstName],
                a.[LastName]
                FROM [Book] AS b
                INNER JOIN [BookAuthor] AS ba ON ba.[BookId] = b.[Id]
                JOIN [Author] AS a ON a.[Id] = ba.[AuthorId]
                WHERE b.[Id] = @BookId
            """;

        return await connection.QuerySingleOrDefaultAsync<BookResponse>(sql,
                new { request.BookId });
    }
}
