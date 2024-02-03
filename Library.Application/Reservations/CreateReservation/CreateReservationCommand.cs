using Library.Application.Abstractions.Messaging;

namespace Library.Application.Reservations.CreateReservation;
internal record CreateReservationCommand(Guid StudentId, Guid BookId) : ICommand<Guid>;
