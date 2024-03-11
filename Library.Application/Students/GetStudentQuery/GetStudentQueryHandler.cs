using Dapper;
using Library.Application.Abstractions.Data;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;

namespace Library.Application.Students.GetStudentQuery;
internal class GetStudentQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetStudentQuery, StudentResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<StudentResponse>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """

            SELECT
                s.[Id],
                s.[FirstName],
                s.[LastName],
                s.[Email],
                s.[AcademicYear],
                d.[Name] AS DepartmentName
                FROM Student s
                JOIN Department d ON s.DepartmentId = d.Id
                WHERE s.Id = @Id
            """;

        return await connection.QuerySingleOrDefaultAsync<StudentResponse>(sql, new { request.Id });
    }
}
