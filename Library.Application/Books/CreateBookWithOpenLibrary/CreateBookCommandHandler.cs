using Library.Application.Abstractions.Messaging;
using Library.Application.Abstractions.OpenLibrary;
using Library.Domain.Abstractions;
using Library.Domain.AuthorBooks;
using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Publishers;

namespace Library.Application.Books.CreateBookWithOpenLibrary;
internal sealed class CreateBookCommandHandler(
    IOpenLibraryService openLibraryService,
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork,
    IPublisherRepository publisherRepository,
    IAuthorRepository authorRepository,
    IAuthorBookRepository authorBookRepository) : ICommandHandler<CreateBookCommand, Guid>
{
    private readonly IOpenLibraryService _openLibraryService = openLibraryService;
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPublisherRepository _publisherRepository = publisherRepository;
    private readonly IAuthorRepository _authorRepository = authorRepository;
    private readonly IAuthorBookRepository _authorBookReposiotry = authorBookRepository;

    public async Task<Result<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var existingBook = await _bookRepository.GetByIsbn(request.Isbn, cancellationToken);

        if (existingBook is not null)
        {
            return Result.Failure<Guid>(BookErrors.AlreadyExist);
        }

        var openLibraryBookResponse = await _openLibraryService.GetBookDetailsAsync(request.Isbn);
        if (openLibraryBookResponse is null)
        {
            return Result.Failure<Guid>(BookErrors.NotFound);
        }
        var publisherResponseName = openLibraryBookResponse.Publishers.FirstOrDefault();

        if (string.IsNullOrEmpty(publisherResponseName))
        {
            return Result.Failure<Guid>(PublisherErrors.OpenLibraryNotFound);
        }

        var publisher = await _publisherRepository.GetPublisherByName(publisherResponseName, cancellationToken);

        if (publisher is null)
        {
            publisher = Publisher.Create(publisherResponseName);
            _publisherRepository.Add(publisher);
        }

        var isbn = openLibraryBookResponse.Isbn10.FirstOrDefault() ?? request.Isbn;
        var publishDate = openLibraryBookResponse.PublishDate?.Substring(openLibraryBookResponse.PublishDate.Length - 4);

        var book = Book.CreateFromOpenLibrary(openLibraryBookResponse.Title, isbn, publishDate,
            openLibraryBookResponse.NumberOfPages, publisher.Id);


        foreach (var authorCode in openLibraryBookResponse.Authors)
        {
            var author = await _authorRepository.GetByOpenLibraryCode(authorCode.Key, cancellationToken);

            if (author is null)
            {
                var authorResponse = await _openLibraryService.GetAuthorAsync(authorCode.Key);
                author = Author.Create(authorResponse.Name, authorCode.Key);
                _authorRepository.Add(author);
            }

            _authorBookReposiotry.Add(AuthorBook.Create(author.Id, book.Id));
        }


        _bookRepository.Add(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(book.Id);
    }
}
