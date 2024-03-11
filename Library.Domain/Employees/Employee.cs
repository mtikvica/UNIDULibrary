using Library.Domain.Shared;
using Library.Domain.Users;

namespace Library.Domain.Employees;

public sealed class Employee : User
{
    private Employee(Name firstName, Name lastName, Email email, Password password, Guid locationId)
        : base(firstName, lastName, email, password)
    {
        LocationId = locationId;
    }

    private Employee() { }

    public Guid LocationId { get; set; }

    public static Employee Create(Name firstName, Name lastName, Email email, Password password, Guid locationId)
    {
        return new Employee(firstName, lastName, email, password, locationId);
    }
}