using Library.Data.Context;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Data.Repositories;
public class BookCopyRepository(UNIDULibraryDbContext context) : Repository<BookCopy>(context), IBookCopyRepository
{
}
