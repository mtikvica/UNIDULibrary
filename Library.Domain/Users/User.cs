using Library.Domain.Abstractions;
using Library.Domain.Shared;

namespace Library.Domain.Users;
public class User : Entity
{
    protected User(Name firstName, Name lastName, Email email, Password password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    protected User() { }

    public Name FirstName { get; }
    public Name LastName { get; }
    public Email Email { get; }
    public Password Password { get; }
}
