using Booking.Application.Abstractions;
using Booking.Application.Reservations.Commands;
using Booking.Common.Exceptions;
using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.CommandHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Reservation>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepo)
        {
            _reservationRepository = reservationRepo;
        }

        public async Task<Reservation> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(request.ReservationId);

            if (reservation == null)
            {
                throw new NotFoundException($"Reservation with ID {request.ReservationId} not found.");
            }

            reservation.CustomerName = request.CustomerName;
            reservation.TripId = request.TripId;
            reservation.ReservationDate = request.ReservationDate;
            reservation.Notes = request.Notes;

            await _reservationRepository.UpdateReservationAsync(reservation);

            return reservation;

        }
    }
}
