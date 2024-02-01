using Library.Domain.Abstractions;
using Library.Domain.Authors;
using Library.Domain.Books.Events;

namespace Library.Domain.Books;

public sealed class Book : Entity
{
    private Book(string title, string isbn, int? publicationYear, int? numberOfPages, IEnumerable<Author> authors)
    {
        Title = title;
        Isbn = isbn;
        PublicationYear = publicationYear;
        NumberOfPages = numberOfPages;
        Authors = authors;
    }

    public string Title { get; }

    public string Isbn { get; }

    public int? NumberOfPages { get; private set; }

    public Guid? DepartmentId { get; private set; }

    public Guid? PublisherId { get; private set; }

    public Guid? LocationId { get; private set; }

    public int? PublicationYear { get; private set; }

    public IEnumerable<Author> Authors { get; } = new List<Author>();

    public static Book Create(string title, string isbn, int? publicationYear, int? numberOfPages, IEnumerable<Author> authors)
    {
        var book = new Book(title, isbn, publicationYear, numberOfPages, authors);

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