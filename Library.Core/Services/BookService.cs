using AutoMapper;
using Library.Core.Extensions;
using Library.Core.Requests;
using Library.Core.Responses.PaginatedResponses;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Core.Services;

public class BookService(IBookRepository bookRepository, IOpenLibraryService openLibraryService, IMapper mapper) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IOpenLibraryService _openLibraryService = openLibraryService;
    private readonly IMapper _mapper = mapper;

    public async Task<Book> AddBookWithDetailsByIsbnAsync(string isbn)
    {
        var openLibraryBookResponse = await _openLibraryService.GetBookDetailsAsync(isbn);

        var authors = new List<Author>();

        var publisher = new Publisher() { PublisherName = openLibraryBookResponse.Publishers.FirstOrDefault() };

        foreach (var authorCode in openLibraryBookResponse.Authors)
        {
            var openLibraryReposne = await _openLibraryService.GetAuthorAsync(authorCode.Key);
            var author = new Author()
            {
                AuthorName = openLibraryReposne.Name,
                AuthorOpenLibraryKey = authorCode.Key
            };
            authors.Add(author);
        }

        var publishDate = openLibraryBookResponse.PublishDate.Substring(openLibraryBookResponse.PublishDate.Length - 4);

        var book = new Book()
        {
            Title = openLibraryBookResponse.Title,
            Publisher = publisher,
            Authors = authors,
            PublicationYear = int.TryParse(publishDate, out var publicationYear) ? publicationYear : null,
            NumberOfPages = openLibraryBookResponse.NumberOfPages,
            Isbn = openLibraryBookResponse.Isbn10.FirstOrDefault()
        };

        var bookResponse = await _bookRepository.AddAsync(book);

        return bookResponse;
    }

    public async Task<PaginatedResponse> GetAllBooks(PageRequest request)
    {
        var includes = new Expression<Func<Book, object>>[]
        {
            x => x.Authors,
            x => x.Publisher
        };


        var books = await _bookRepository.GetAllWithIncludesAsync(includes).Paginate(request.PageNumber, request.PageSize).ToListAsync();
        return new PaginatedResponse
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = (int)Math.Ceiling(books.Count() / (double)request.PageSize),
            Records = books.Select(x => _mapper.Map<Book>(x))
        };
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var includes = new Expression<Func<Book, object>>[]
        {
            x => x.Authors,
            x => x.Publisher
        };

        var book = await _bookRepository.GetAllWithIncludesAsync(x => x.Isbn == isbn, includes).FirstOrDefaultAsync() ?? throw new NotFoundException($"Book with {isbn} is not found!");
        return book;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        var response = await _bookRepository.AddAsync(book);
        return response;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        var response = await _bookRepository.UpdateAsync(book);
        return response;
    }

    public async Task<Book> GetBookAsync(Guid id)
    {
        var book = await _bookRepository.GetBy(x => x.BookId == id).FirstOrDefaultAsync() ?? throw new NotFoundException($"Book with {id} is not found!");
        return book;
    }

    public async Task<Book> GetBookByTitleAsync(string title)
    {
        var includes = new Expression<Func<Book, object>>[]
        {
            x => x.Authors,
            x => x.Publisher
        };

        var book = await _bookRepository.GetAllWithIncludesAsync(x => x.Title == title, includes).FirstOrDefaultAsync() ?? throw new NotFoundException($"Book with {title} is not found!");
        return book;
    }

    public async Task<Book> GetBookByAuthorAsync(string author)
    {
        var includes = new Expression<Func<Book, object>>[]
        {
            x => x.Authors,
            x => x.Publisher
        };

        var book = await _bookRepository.GetAllWithIncludesAsync(x => x.Authors.Any(x => x.AuthorName == author), includes).FirstOrDefaultAsync() ?? throw new NotFoundException($"Book with {author} is not found!");
        return book;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        await _bookRepository.DeleteAsync(id);
    }
}
