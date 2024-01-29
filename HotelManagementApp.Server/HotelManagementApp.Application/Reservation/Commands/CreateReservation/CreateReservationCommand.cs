using ErrorOr;
using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Reservation.Commands.CreateReservation
{
    public record CreateReservationCommand(
        string GuestName,
        string MobileNumber,
        string Email,
        Guid RoomId,
        DateTime CheckInDate,
        DateTime CheckOutDate,
        double Amount) : IRequest<ErrorOr<ReservationDto>>;

}
