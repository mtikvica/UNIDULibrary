using Library.Domain.Loans;

namespace Library.Infrastructure.Repositories;
internal class LoanRepository : Repository<Loan>, ILoanRepository
{
    public LoanRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}
