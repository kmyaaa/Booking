using Booking.Application.Abstractions;
using Booking.Application.Reservations.Queries;
using Booking.Domain.Entities;
using MediatR;

namespace Booking.Application.Reservations.QueryHandlers
{
    public class GetReservationsByUserIdQueryHandler : IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<Reservation>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsByUserIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> Handle(GetReservationsByUserIdQuery query, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetReservationsByUserIdAsync(query.UserId);
        }
    }
}
