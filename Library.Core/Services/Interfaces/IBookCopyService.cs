using Library.Data.Entities;

namespace Library.Core.Services;
public interface IBookCopyService
{
    Task AddBookCopyAsync(Guid bookId, int ammount);
    Task AddBookCopyAsync(string isbn, int ammount);
    Task DeleteBookCopyAsync(Guid id);
    Task<BookCopy> GetBookCopyByIdAsync(Guid id);
    Task<IEnumerable<BookCopy>> GetBookCopiesAsync(Guid bookId);
    Task<IEnumerable<BookCopy>> GetBookCopiesAsync(string isbn);
    Task UpdateBookCopyAsync(BookCopy bookCopy);
}