namespace Library.Domain.BookCopies;
public interface IBookCopyRepository
{
    Task<BookCopy?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<BookCopy?> GetAvailableBookCopyForReservationAsync(Guid bookId, CancellationToken cancellationToken = default);
    Task<BookCopy?> GetAvailableBookCopyForLoanAsync(Guid bookId, CancellationToken cancellationToken = default);
    void Add(BookCopy bookCopy);
    void Update(BookCopy bookCopy);
    void Delete(BookCopy bookCopy);
}
