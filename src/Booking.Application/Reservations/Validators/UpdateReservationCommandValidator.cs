using Booking.Application.Reservations.Commands;
using FluentValidation;

namespace Booking.Application.Reservations.Validators
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ReservationDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.TripId)
                .NotEmpty();

        }
    }
}
