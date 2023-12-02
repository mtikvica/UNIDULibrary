using Library.Core.Responses.OpenLibraryModels;

namespace Library.Core.Services.Interfaces;
public interface IOpenLibraryService
{
    Task<OpenLibraryBookResponse> GetBookDetailsAsync(string isbn);
}