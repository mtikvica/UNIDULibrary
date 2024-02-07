using Library.Domain.Abstractions;

namespace Library.Domain.Users;
public class User(FirstName firstName, LastName lastName, Email email, Password password) : Entity
{
    public FirstName FirstName { get; } = firstName;
    public LastName LastName { get; } = lastName;
    public Email Email { get; } = email;
    public Password Password { get; } = password;
}
