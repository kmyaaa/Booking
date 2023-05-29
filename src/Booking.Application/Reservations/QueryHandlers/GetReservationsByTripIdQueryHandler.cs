using Booking.Application.Abstractions;
using Booking.Application.Reservations.Queries;
using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.QueryHandlers
{
    public class GetReservationsByTripIdQueryHandler : IRequestHandler<GetReservationsByTripIdQuery, IEnumerable<Reservation>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsByTripIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> Handle(GetReservationsByTripIdQuery query, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetReservationsByTripIdAsync(query.TripId);
        }
    }
}
