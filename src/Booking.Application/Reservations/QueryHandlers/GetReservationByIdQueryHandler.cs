using Booking.Application.Abstractions;
using Booking.Application.Reservations.Queries;
using Booking.Common.Exceptions;
using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.QueryHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Reservation>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> Handle(GetReservationByIdQuery query, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(query.ReservationId);

            if (reservation == null)
            {
                throw new NotFoundException($"Reservation with ID {query.ReservationId} not found.");
            }

            return reservation;
        }
    }
}
