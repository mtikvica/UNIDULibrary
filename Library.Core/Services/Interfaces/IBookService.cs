using Library.Core.Requests;
using Library.Core.Responses.PaginatedResponses;
using Library.Data.Entities;

namespace Library.Core.Services;
public interface IBookService
{
    Task<Book> AddBookWithDetailsByIsbnAsync(string isbn);
    Task<PaginatedResponse> GetAllBooks(PageRequest request);
    Task<Book> GetBookByIsbnAsync(string isbn);
    Task<Book> AddBookAsync(Book book);
    Task<Book> UpdateBookAsync(Book book);
    Task<Book> GetBookAsync(Guid id);
    Task<Book> GetBookByTitleAsync(string title);
    Task<Book> GetBookByAuthorAsync(string author);
    Task DeleteBookAsync(Guid id);
}