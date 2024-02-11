using Library.Application.Abstractions.Messaging;

namespace Library.Application.Reservations.CreateReservation;
public sealed record CreateReservationCommand(Guid StudentId, Guid BookId) : ICommand<Guid>;
