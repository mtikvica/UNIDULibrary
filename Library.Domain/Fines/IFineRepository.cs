namespace Library.Domain.Fines;
public interface IFineRepository
{
    Task<IEnumerable<Fine>> GetUnpaidFinesByStundet(Guid studentId, CancellationToken cancellationToken = default);
    Task<Fine?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Fine fine);
    void Update(Fine fine);
    void Delete(Fine fine);
}
