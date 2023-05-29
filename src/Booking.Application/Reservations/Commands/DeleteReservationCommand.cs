using MediatR;

namespace Booking.Application.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest
    {
        public int ReservationId { get; set; }
    }
}
