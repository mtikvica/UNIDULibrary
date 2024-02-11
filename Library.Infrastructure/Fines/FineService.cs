using Dapper;
using Library.Application.Abstractions.Data;
using Library.Application.Shared.Fines;

namespace Library.Infrastructure.Fines;
internal sealed class FineService(ISqlConnectionFactory sqlConnectionFactory) : IFineService
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<IReadOnlyList<FineResponse>> GetUnpaidFinesByStundet(Guid studentId)
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

        var fines = await connection.QueryAsync<FineResponse>(sql, new { studentId });

        return fines.ToList();
    }
}
