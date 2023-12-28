using Library.Core.Requests;
using Library.Core.Responses.PaginatedResponses;
using Library.Data.Entities;

namespace Library.Core.Services;
public interface IBookService
{
    Task<Book> AddBookWithDetailsByIsbnAsync(string isbn);
    Task<PaginatedResponse> GetAllBooks(PageRequest request);
    Task<Book> GetBookByIsbnAsync(string isbn);
    Task<Book> AddBookAsync(Book bookDto);
}