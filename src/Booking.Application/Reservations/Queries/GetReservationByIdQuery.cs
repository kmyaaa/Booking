using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.Queries
{
    public class GetReservationByIdQuery : IRequest<Reservation>
    {
        public int ReservationId { get; set; }
    }
}
