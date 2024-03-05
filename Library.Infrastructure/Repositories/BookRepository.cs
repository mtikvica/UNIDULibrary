using Library.Domain.Books;

namespace Library.Infrastructure.Repositories;
internal class BookRepository(LibraryDbContext dbContext) : Repository<Book>(dbContext), IBookRepository
{
}
