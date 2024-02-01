using Library.Domain.Loans;
using Library.Domain.Reservations;
using Library.Domain.Users;

namespace Library.Domain.Students;

public sealed class Student : User
{
    private Student(FirstName firstName, LastName lastName, Email email, Password password, Guid roleId, AcademicYear academicYear, Guid departmentId) : base(firstName, lastName, email, password, roleId)
    {
        AcademicYear = academicYear;
        DepartmentId = departmentId;
    }

    public AcademicYear AcademicYear { get; private set; }
    public Guid DepartmentId { get; }
    public IEnumerable<Reservation> Reservation { get; } = new List<Reservation>();
    public IEnumerable<Loan> Loan { get; } = new List<Loan>();

    public static Student Create(FirstName firstName, LastName lastName, Email email, Password password, Guid roleId, AcademicYear academicYear, Guid departmentId)
    {
        return new Student(firstName, lastName, email, password, roleId, academicYear, departmentId);
    }

    public Student NewAcademicYear()
    {
        AcademicYear = AcademicYear.Create(AcademicYear.Value + 1);
        return this;
    }
}