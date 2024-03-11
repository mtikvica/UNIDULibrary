namespace Library.Application.Students;
public sealed class StudentResponse
{
    public Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public int AcademicYear { get; init; }
    public required string DepartmentName { get; init; }
}
