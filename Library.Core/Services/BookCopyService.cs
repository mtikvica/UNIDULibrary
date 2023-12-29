using AutoMapper;
using Library.Core.Dtos;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class BookCopyService(IBookCopyRepository bookCopyRepository, IBookRepository bookRepository, IMapper mapper) : IBookCopyService
{
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IMapper _mapper = mapper;

    public async Task AddBookCopyAsync(Guid bookId, int ammount)
    {
        var book = await _bookRepository.GetBy(x => x.BookId == bookId).FirstOrDefaultAsync() ?? throw new NotFoundException($"Book with id: {bookId} was not found!");

        await AddBookCopies(book.BookId, ammount);
    }
    public async Task AddBookCopyAsync(string isbn, int ammount)
    {
        var book = await _bookRepository.GetBy(x => x.Isbn == isbn).FirstOrDefaultAsync() ?? throw new NotFoundException($"Book with isbn: {isbn} was not found!");

        await AddBookCopies(book.BookId, ammount);
    }

    private async Task AddBookCopies(Guid bookId, int ammount)
    {
        for (var i = 0; i < ammount; i++)
        {
            var bookCopyDto = new BookCopyDto(bookId);

            await _bookCopyRepository.AddAsync(_mapper.Map<BookCopy>(bookCopyDto));
        }
    }

    public async Task<IEnumerable<BookCopy>> GetBookCopiesAsync(Guid bookId)
    {
        var bookCopies = await _bookCopyRepository.GetBy(x => x.BookId == bookId).ToListAsync();
        return bookCopies;
    }

    public async Task<IEnumerable<BookCopy>> GetBookCopiesAsync(string isbn)
    {
        var bookCopies = await _bookCopyRepository.GetBy(x => x.Book.Isbn == isbn).ToListAsync();
        return bookCopies;
    }


    public async Task<BookCopy> GetBookCopyByIdAsync(Guid id)
    {
        var bookCopy = await _bookCopyRepository.GetBy(x => x.CopyId == id).FirstOrDefaultAsync() ?? throw new NotFoundException($"BookCopy with id: {id} was not found!");

        return bookCopy;
    }

    public async Task DeleteBookCopyAsync(Guid id)
    {
        var bookCopy = await _bookCopyRepository.GetBy(x => x.CopyId == id).FirstOrDefaultAsync() ?? throw new NotFoundException($"BookCopy with id: {id} was not found!");

        await _bookCopyRepository.DeleteAsync(bookCopy);
    }
}
