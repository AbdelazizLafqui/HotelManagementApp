using ErrorOr;
using MediatR;

namespace HotelManagementApp.Application.Reservation.Commands.DeleteReservation
{
    public record DeleteReservationCommand(Guid Id) : IRequest<ErrorOr<Success>>;
}
