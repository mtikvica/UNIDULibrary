using Library.Domain.Loans;

namespace Library.Infrastructure.Repositories;
internal class LoanRepository(LibraryDbContext dbContext) : Repository<Loan>(dbContext), ILoanRepository
{
}
