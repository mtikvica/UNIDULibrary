namespace Library.Domain.Publishers;
public interface IPublisherRepository
{
    Task<Publisher?> GetPublisherByName(string name, CancellationToken cancellationToken = default);
    void Add(Publisher book);
}
