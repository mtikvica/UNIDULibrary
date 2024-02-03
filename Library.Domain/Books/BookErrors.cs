using Library.Domain.Abstractions;

namespace Library.Domain.Books;
public static class BookErrors
{
    public static Error NotFound = new(
        "Book.NotFound",
        "Book is not found!");

}
