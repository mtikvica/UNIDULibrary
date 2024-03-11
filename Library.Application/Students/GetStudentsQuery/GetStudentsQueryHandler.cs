using Dapper;
using Library.Application.Abstractions.Data;
using Library.Application.Abstractions.Messaging;
using Library.Application.Shared;
using Library.Domain.Abstractions;

namespace Library.Application.Students.GetStudentsQuery;
internal class GetStudentsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<GetStudentsQuery, PaginatedResponse<StudentResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<PaginatedResponse<StudentResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();

        var offset = (request.Page - 1) * request.PageSize;
        var limit = request.PageSize;

        const string sql = """"
            SELECT
                s.[Id],
                s.[FirstName],
                s.[LastName],
                s.[Email],
                s.[AcademicYear],
                d.[Name] AS DepartmentName
                FROM Student s
                JOIN Department d ON s.DepartmentId = d.Id
                ORDER BY s.[Id]
                OFFSET @Offset ROWS
                FETCH NEXT @Limit ROWS ONLY
            """";

        var students = await connection.QueryAsync<StudentResponse>(sql, new { Offset = offset, Limit = limit });

        return Result.Success(new PaginatedResponse<StudentResponse>(students, request.Page, request.PageSize));
    }
}
