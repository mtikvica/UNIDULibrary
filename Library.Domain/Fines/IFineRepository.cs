namespace Library.Domain.Fines;
public interface IFineRepository
{
    Task<Fine?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Fine fine);
    void Update(Fine fine);
    void Delete(Fine fine);
}
