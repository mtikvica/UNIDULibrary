using Dapper;
using Library.Application.Abstractions.Data;
using Library.Domain.Fines;

namespace Library.Infrastructure.Repositories;
internal class FineRepository(LibraryDbContext dbContext, ISqlConnectionFactory sqlConnectionFactory)
    : Repository<Fine>(dbContext), IFineRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<IEnumerable<Fine>> GetUnpaidFinesByStundet(Guid studentId, CancellationToken cancellationToken = default)
    {
        var connection = _sqlConnectionFactory.CreateConnection();

        connection.Open();

        const string sql = """
            SELECT
                f.[Id],
                f.[Amount],
                f.[DueDate],
                f.[IsPaid]
                FROM [Fine] AS f
                JOIN [Loan] AS l ON l.[Id] = f.[LoanId]
                WHERE l.[StudentId] = @studentId
                AND f.[IsPaid] = 0
            """;

        return await connection.QueryAsync<Fine>(sql, new { studentId });
    }
}
