using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Room.Queries
{
    public class RoomLookupQuery : IRequest<List<RoomLookupDto>>
    {
    }
}
