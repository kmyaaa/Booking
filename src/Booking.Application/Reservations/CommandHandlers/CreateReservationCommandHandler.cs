using Booking.Application.Abstractions;
using Booking.Application.Reservations.Commands;
using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.CommandHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(IReservationRepository reservationRepo)
        {
            _reservationRepository = reservationRepo;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                ReservedById = request.ReservedByUserId,
                TripId = request.TripId,
                ReservationDate = request.ReservationDate,
                CustomerName = request.CustomerName,
                Notes = request.Notes,
                CreationDate = DateTime.Now,
            };

            await _reservationRepository.AddReservationAsync(reservation);

            return reservation.Id;
        }
    }
}
