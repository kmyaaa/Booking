using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.Commands
{
    public class UpdateReservationCommand : IRequest<Reservation>
    {
        public int ReservationId { get; set; }
        public int TripId { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Notes { get; set; }
    }
}
