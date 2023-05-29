using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<Reservation>>
    {
        public int UserId { get; set; }
    }
}
