using Library.Domain.Abstractions;
using Library.Domain.Roles;

namespace Library.Domain.Users;
public class User(FirstName firstName, LastName lastName, Email email, Password password, Guid roleId) : Entity
{
    public FirstName FirstName { get; } = firstName;
    public LastName LastName { get; } = lastName;
    public Email Email { get; } = email;
    public Password Password { get; } = password;
    public Guid RoleId { get; } = roleId;
    public Role Role { get; } = new();
}
