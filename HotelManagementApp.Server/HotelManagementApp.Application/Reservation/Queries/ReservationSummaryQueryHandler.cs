using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Reservation.Queries
{
    internal class ReservationSummaryQueryHandler : IRequestHandler<ReservationSummaryQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationSummaryQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<ReservationDto>> Handle(ReservationSummaryQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservationsAsync();

            var resDtos = reservations.Adapt<List<ReservationDto>>();
            return resDtos;
        }

    }
}
