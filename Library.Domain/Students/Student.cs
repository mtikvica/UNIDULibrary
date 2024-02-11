using Library.Domain.Shared;
using Library.Domain.Users;

namespace Library.Domain.Students;

public sealed class Student : User
{
    private Student(Name firstName, Name lastName, Email email, Password password, AcademicYear academicYear, Guid departmentId) : base(firstName, lastName, email, password)
    {
        AcademicYear = academicYear;
        DepartmentId = departmentId;
    }

    private Student() { }

    public AcademicYear AcademicYear { get; }
    public Guid DepartmentId { get; }

    public static Student Create(Name firstName, Name lastName, Email email, Password password, AcademicYear academicYear, Guid departmentId)
    {
        return new Student(firstName, lastName, email, password, academicYear, departmentId);
    }

    public static Student Create(Name name1, Name name2, Email email, Password password)
    {
        throw new NotImplementedException();
    }
}