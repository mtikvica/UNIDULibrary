using Library.Data.Context;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Data.Repositories;
public class BookRepository(UNIDULibraryDbContext context) : Repository<Book>(context), IBookRepository
{
}
