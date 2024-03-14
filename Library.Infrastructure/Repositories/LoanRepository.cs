using Dapper;
using Library.Application.Abstractions.Data;
using Library.Domain.Loans;

namespace Library.Infrastructure.Repositories;
internal class LoanRepository(LibraryDbContext dbContext, ISqlConnectionFactory sqlConnectionFactory) : Repository<Loan>(dbContext), ILoanRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Loan?> GetActiveLoanOnBookAsync(Guid studentId, Guid bookId)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                l.[Id],
                l.[StudentId],
                l.[BookCopyId],
                l.[LoanedDate],
                l.[DueDate]
            FROM [Loan] AS l
            JOIN [BookCopy] AS bc ON l.[BookCopyId] = bc.[Id]
            WHERE l.[StudentId] = @studentId
                AND bc.[BookId] = @bookId
                AND l.[ReturnedDate] IS NULL
            """;

        return await connection.QueryFirstOrDefaultAsync<Loan>(sql, new { studentId, bookId });
    }
}
