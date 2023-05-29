using Booking.Application.Abstractions;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data.Repositories
{

    public class ReservationRepository : IReservationRepository
    {
        private readonly BookingDbContext _context;

        public ReservationRepository(BookingDbContext context)
        {
            _context = context;
        }

        // Basic CRUD operations
        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                reservation.Trip = await _context.Trips.FindAsync(reservationId);
                reservation.User = await _context.Users.FindAsync(reservationId);

            }

            return reservation;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        // Querying and filtering
        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(int userId)
        {
            var reservations = await _context.Reservations.Where(r => r.ReservedById == userId).ToListAsync();

            return reservations;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByTripIdAsync(int tripId)
        {
            var reservations = await _context.Reservations.Where(r => r.TripId == tripId).ToListAsync();


            return reservations;
        }

    }
}
