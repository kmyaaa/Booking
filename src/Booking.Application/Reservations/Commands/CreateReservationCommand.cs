using MediatR;

namespace Booking.Application.Reservations.Commands
{
    public class CreateReservationCommand : IRequest<int>
    {
        public int ReservedByUserId { get; set; }
        public int TripId { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Notes { get; set; }
    }
}
