using Library.Application.Abstractions.OpenLibrary.Responses;

namespace Library.Application.Abstractions.OpenLibrary;
public interface IOpenLibraryService
{
    Task<OpenLibraryBookResponse> GetBookDetailsAsync(string isbn);
    Task<OpenLibraryAuthorResponse> GetAuthorAsync(string authorOLCode);
}