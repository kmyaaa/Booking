namespace Booking.Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CityName { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }

}
