using Library.Domain.Abstractions;
using Library.Domain.Books;
using Library.Domain.Students;

namespace Library.Domain.Departments;

public sealed class Department : Entity
{
    public string DepartmentName { get; } = null!;

    public IEnumerable<Book> Books { get; } = new List<Book>();

    public IEnumerable<Student> Students { get; } = new List<Student>();
}