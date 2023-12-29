using Library.Data.Context;
using Library.Data.Entities;

namespace Library.Data.Repositories;
public class StudentRepository(UNIDULibraryDbContext context) : Repository<Student>(context), IStudentRepository
{
}
