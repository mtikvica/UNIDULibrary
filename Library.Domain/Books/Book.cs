using Library.Domain.Abstractions;
using Library.Domain.Books.Events;

namespace Library.Domain.Books;

public sealed class Book : Entity
{
    private Book(string title, string isbn, int? publicationYear, int? numberOfPages)
    {
        Title = title;
        Isbn = isbn;
        PublicationYear = publicationYear;
        NumberOfPages = numberOfPages;
    }

    private Book() { }

    public string Title { get; }

    public string Isbn { get; }

    public int? NumberOfPages { get; private set; }

    public Guid? DepartmentId { get; private set; }

    public Guid? PublisherId { get; private set; }

    public Guid? LocationId { get; private set; }

    public int? PublicationYear { get; private set; }

    public static Book Create(string title, string isbn, int? publicationYear, int? numberOfPages)
    {
        var book = new Book(title, isbn, publicationYear, numberOfPages);

        book.RaiseDomainEvent(new BookCreatedDomainEvent(book.Id));

        return book;
    }

    public Book UpdateWithMissingProperties(int numberOfPages, Guid departmentId, Guid publisherId, Guid locationId)
    {
        NumberOfPages = numberOfPages;
        DepartmentId = departmentId;
        PublisherId = publisherId;
        LocationId = locationId;

        return this;
    }
}