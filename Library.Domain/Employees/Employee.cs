using Library.Domain.Users;

namespace Library.Domain.Employees;

public sealed class Employee : User
{
    private Employee(FirstName firstName, LastName lastName, Email email, Password password, Guid roleId) : base(firstName, lastName, email, password, roleId)
    {
    }

    public static Employee Create(FirstName firstName, LastName lastName, Email email, Password password, Guid roleId)
    {
        return new Employee(firstName, lastName, email, password, roleId);
    }
}