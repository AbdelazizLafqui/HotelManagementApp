using ErrorOr;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ErrorOr<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ErrorOr<ReservationDto>> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservationsAsync();
            var duplicateReservation = reservations.FirstOrDefault(x => x.RoomId == command.RoomId);

            if (duplicateReservation != null && command.CheckInDate >= duplicateReservation.CheckInDate
                && command.CheckInDate <= duplicateReservation.CheckOutDate)
            {
                return Domain.Common.Errors.CommonErrors.Reservation.BookedRoom;

            }

            var newReservation = new Domain.Entities.Reservation
            {
                GuestName = command.GuestName,
                MobileNumber = command.MobileNumber,
                Email = command.Email,
                RoomId = command.RoomId,
                CheckInDate = command.CheckInDate,
                CheckOutDate = command.CheckOutDate,
                Amount = command.Amount,
            };

            await _reservationRepository.AddReservationAsync(newReservation);

            var resDto = newReservation.Adapt<ReservationDto>();

            return resDto;
        }
    }
}
