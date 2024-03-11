using Library.Application.Abstractions.Messaging;

namespace Library.Application.Students.GetStudentQuery;
public sealed record GetStudentQuery(Guid Id) : IQuery<StudentResponse>;