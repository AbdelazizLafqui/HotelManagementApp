using ErrorOr;
using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Room.Commands.CreateRoom
{
    public record CreateRoomCommand(
        int RoomNumber,
        int FloorNumber,
        string RoomType,
        string Bed,
        int Capacity,
        string Amenities,
        double Price) : IRequest<ErrorOr<RoomDto>>;

}
