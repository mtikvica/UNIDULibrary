namespace Library.Domain.Abstractions;
public abstract class Entity
{
    protected Entity() { }

    private readonly List<IDomainEvent> _domainEvents = [];

    public Guid Id { get; init; } = Guid.NewGuid();

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
