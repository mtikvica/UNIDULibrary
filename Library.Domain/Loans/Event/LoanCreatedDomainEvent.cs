using Library.Domain.Abstractions;

namespace Library.Domain.Loans.Event;
public sealed record LoanCreatedDomainEvent(Guid BookCopyId) : IDomainEvent;