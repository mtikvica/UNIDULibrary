using FluentValidation;

namespace Library.Application.Reservations.CreateReservation;
internal class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.StudentId).NotEmpty();
        RuleFor(x => x.BookId).NotEmpty();
    }
}
