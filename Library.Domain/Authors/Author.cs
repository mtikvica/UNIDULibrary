using Library.Domain.Abstractions;
using Library.Domain.Shared;

namespace Library.Domain.Authors;

public sealed class Author : Entity
{
    private Author(string firstName, string lastName, string? middleName)
    {
        FirstName = Name.Create(firstName);
        LastName = Name.Create(lastName);
        MiddleName = middleName is not null ? Name.Create(middleName) : null;
    }

    private Author() { }

    public Name FirstName { get; }
    public Name? MiddleName { get; }
    public Name LastName { get; }

    public static Author Create(string authorName)
    {
        var authorNameParts = authorName.Split(' ');

        if (authorNameParts.Length == 3)
        {
            return new Author(authorNameParts[0], authorNameParts[2], authorNameParts[1]);
        }

        return new Author(authorNameParts[0], authorNameParts[1], null);
    }
}