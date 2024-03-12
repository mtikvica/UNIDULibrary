using Library.Application.Abstractions.Messaging;
using Library.Application.Shared;

namespace Library.Application.Students.GetStudentsQuery;
public sealed record GetStudentsQuery(int Page, int PageSize) : IQuery<PaginatedResponse<StudentResponse>>;
