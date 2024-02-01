using Library.Domain.Abstractions;
using Library.Domain.Loans;

namespace Library.Domain.BookCopies;

public sealed class BookCopy : Entity
{
    private BookCopy(Guid bookId)
    {
        BookId = bookId;
    }

    public Guid BookId { get; }
    public bool IsAvailable { get; private set; } = true;
    public bool IsReserved { get; private set; }
    public ICollection<Loan> Loans { get; } = new List<Loan>();

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
        if (IsAvailable)
        {
            IsAvailable = false;
        }
        IsAvailable = true;
    }

    public static BookCopy Create(Guid bookId)
    {
        return new BookCopy(bookId);
    }
}