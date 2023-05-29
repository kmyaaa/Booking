using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.Queries
{
    public class GetReservationsByTripIdQuery : IRequest<IEnumerable<Reservation>>
    {
        public int TripId { get; set; }
    }
}
