
namespace Library.Domain.Loans;
public interface ILoanRepository
{
    Task<Loan?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Loan?> GetActiveLoanOnBookAsync(Guid studentId, Guid bookId);
    void Add(Loan loan);
    void Update(Loan loan);
}
