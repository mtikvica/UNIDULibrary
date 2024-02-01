using Library.Domain.Abstractions;
using Library.Domain.Employees;
using Library.Domain.Students;

namespace Library.Domain.Roles;

public sealed class Role : Entity
{
    public string RoleName { get; } = null!;
    public ICollection<Employee> Employee { get; } = new List<Employee>();
    public ICollection<Student> Students { get; } = new List<Student>();
}