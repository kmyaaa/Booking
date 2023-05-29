namespace Booking.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ReservedById { get; set; }
        public string CustomerName { get; set; }
        public int TripId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public virtual User User { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
