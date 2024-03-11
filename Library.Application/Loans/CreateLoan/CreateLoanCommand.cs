using Library.Application.Abstractions.Messaging;

namespace Library.Application.Loans.CreateLoan;
public sealed record CreateLoanCommand(Guid BookId, Guid StudentId) : ICommand<Guid>;
