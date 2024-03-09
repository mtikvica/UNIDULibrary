using Library.Domain.Abstractions;

namespace Library.Domain.BookCopies;

public sealed class BookCopy : Entity
{
    private BookCopy(Guid bookId)
    {
        BookId = bookId;
    }

    private BookCopy() { }

    public Guid BookId { get; }
    public bool IsAvailable { get; private set; } = true;
    public bool IsReserved { get; private set; }

    public void ProcessReservation()
    {
        if (IsReserved)
        {
            IsReserved = false;
        }
        IsReserved = true;
    }

    public void ProcessLoan()
    {
        IsAvailable = !IsAvailable;
    }

    public static BookCopy Create(Guid bookId)
    {
        return new BookCopy(bookId);
    }
}