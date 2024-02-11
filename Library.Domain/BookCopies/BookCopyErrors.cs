using Library.Domain.Abstractions;

namespace Library.Domain.BookCopies;
public static class BookCopyErrors
{
    public static Error NotAvailableForReservation = new(
               "BookCopy.NotAvailableForReservation",
                      "Book copy is not available for reservation!"
               );

    public static Error NotAvailableForLoan = new(
               "BookCopy.NotAvailableForLoan",
                      "Book copy is not available for loan!"
               );

    public static Error NotFound = new(
                      "BookCopy.NotFound",
                        "Book copy not found!"
                      );
}
