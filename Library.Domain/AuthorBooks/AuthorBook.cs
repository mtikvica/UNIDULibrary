namespace Library.Domain.AuthorBooks;
public sealed class AuthorBook
{
    private AuthorBook(Guid authorId, Guid bookId)
    {
        AuthorId = authorId;
        BookId = bookId;
    }

    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public static AuthorBook Create(Guid authorId, Guid bookId)
    {
        return new AuthorBook(authorId, bookId);
    }
}
