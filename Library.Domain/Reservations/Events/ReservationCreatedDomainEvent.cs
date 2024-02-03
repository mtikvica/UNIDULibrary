using Library.Domain.Abstractions;

namespace Library.Domain.Reservations.Events;
public sealed record ReservationCreatedDomainEvent(Guid BookCopyId) : IDomainEvent;