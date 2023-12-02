using Library.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("[controller]")]
[ApiController]
public class OpenLibraryController : ControllerBase
{
    private readonly IOpenLibraryService _openLibraryService;

    public OpenLibraryController(IOpenLibraryService openLibraryService)
    {
        _openLibraryService = openLibraryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOpenLibraryBookISBN(string isbn)
    {
        var book = await _openLibraryService.GetBookDetailsAsync(isbn);
        return Ok(book);
    }
}