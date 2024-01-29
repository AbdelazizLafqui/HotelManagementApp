using ErrorOr;
using MediatR;

namespace HotelManagementApp.Application.Room.Commands.DeleteRoom
{
    public record DeleteRoomCommand(Guid Id) : IRequest<ErrorOr<Success>>;
}
