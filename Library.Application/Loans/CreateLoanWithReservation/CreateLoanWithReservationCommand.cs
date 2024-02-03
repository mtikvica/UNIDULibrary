using Library.Application.Abstractions.Messaging;

namespace Library.Application.Loans.CreateLoanReservation;
internal record CreateLoanWithReservationCommand(Guid ReservationId) : ICommand<Guid>;