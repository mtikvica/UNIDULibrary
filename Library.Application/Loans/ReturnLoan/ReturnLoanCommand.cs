
using Library.Application.Abstractions.Messaging;

namespace Library.Application.Loans.ReturnLoan;
public sealed record ReturnLoanCommand(Guid LoanId) : ICommand<string>;
