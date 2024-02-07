using Library.Domain.Abstractions;

namespace Library.Domain.Fines;
public interface IFineRepository
{
    Task<IEnumerable<Fine>> GetFinesForStudent(Guid studentId, CancellationToken cancellationToken);
    Task<Fine> GetFine(Guid fineId);
    Task AddFine(Fine fine);
    Task UpdateFine(Fine fine);
    Task DeleteFine(Guid fineId);
}
