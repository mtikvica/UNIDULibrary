using Library.Domain.AuthorBooks;

namespace Library.Infrastructure.Repositories;
internal class AuthorBookRepository(LibraryDbContext dbContext) : Repository<AuthorBook>(dbContext), IAuthorBookRepository;
