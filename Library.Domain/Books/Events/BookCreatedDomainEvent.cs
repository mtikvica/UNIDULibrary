using Library.Domain.Abstractions;

namespace Library.Domain.Books.Events;
public sealed record BookCreatedDomainEvent(Guid BookId) : IDomainEvent;
