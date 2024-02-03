using Library.Application.Abstractions.Messaging;

namespace Library.Application.Loans.CreateLoan;
internal record CreateLoanCommand(Guid BookId, Guid StudentId) : ICommand<Guid>;
