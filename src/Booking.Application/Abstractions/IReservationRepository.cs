using Booking.Domain.Entities;

namespace Booking.Application.Abstractions
{
    public interface IReservationRepository
    {
        // Basic CRUD operations
        Task<Reservation> GetReservationByIdAsync(int reservationId);
        Task AddReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationByIdAsync(int reservationId);

        // Querying and filtering
        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(int userId);
        Task<IEnumerable<Reservation>> GetReservationsByTripIdAsync(int tripId);
    }
}
