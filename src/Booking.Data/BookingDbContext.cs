using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
            .HasKey(r => r.Id);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.ReservedById)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Trip)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TripId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
             new User { Id = 1, Email = "user1@example.com", Password = "password1" },
             new User { Id = 2, Email = "user2@example.com", Password = "password2" }
            );

            modelBuilder.Entity<Trip>().HasData(
                new Trip { Id = 1, Name = "Trip 1", CityName = "City 1", Price = 100, ImageUrl = "https://example.com/image1.jpg", Content = "<p>Content 1</p>", CreationDate = DateTime.Now },
                new Trip { Id = 2, Name = "Trip 2", CityName = "City 2", Price = 200, ImageUrl = "https://example.com/image2.jpg", Content = "<p>Content 2</p>", CreationDate = DateTime.Now }
            );
        }
    }
}
