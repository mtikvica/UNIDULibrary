using Library.Domain.Abstractions;

namespace Library.Domain.Departments;

public sealed class Department : Entity
{
    private Department(string departmentName)
    {
        Name = departmentName;
    }

    private Department() { }

    public string Name { get; }
    public Guid LocationId { get; set; }

    public static Department Create(string departmentName)
    {
        return new Department(departmentName);
    }
}