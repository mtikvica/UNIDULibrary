using Library.Domain.Fines;

namespace Library.Infrastructure.Repositories;
public class FineRepository(LibraryDbContext dbContext)
    : Repository<Fine>(dbContext), IFineRepository;
