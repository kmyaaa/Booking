using Booking.Application.Abstractions;
using Booking.Application.Reservations.Commands;
using Booking.Common.Exceptions;
using MediatR;

namespace Booking.Application.Reservations.CommandHandlers
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(command.ReservationId);

            if (reservation == null)
            {
                throw new NotFoundException($"Reservation with ID {command.ReservationId} not found.");
            }

            await _reservationRepository.DeleteReservationByIdAsync(command.ReservationId);
            return Unit.Value;
        }
    }
}
