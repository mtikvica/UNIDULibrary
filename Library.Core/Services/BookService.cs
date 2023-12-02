using Library.Core.Services.Interfaces;

namespace Library.Core.Services;

public class BookService
{
    private readonly IOpenLibraryService _openLibraryService;

    public BookService(IOpenLibraryService openLibraryService)
    {
        _openLibraryService = openLibraryService;
    }
}
