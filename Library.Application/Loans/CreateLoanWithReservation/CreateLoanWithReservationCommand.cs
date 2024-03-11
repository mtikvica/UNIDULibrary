using Library.Application.Abstractions.Messaging;

namespace Library.Application.Loans.CreateLoanReservation;
public sealed record CreateLoanWithReservationCommand(Guid ReservationId) : ICommand<Guid>;