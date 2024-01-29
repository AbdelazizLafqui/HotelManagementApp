using HotelManagementApp.Application.DTOs;
using MediatR;

namespace HotelManagementApp.Application.Room.Queries.RoomSummary
{
    public class RoomSummaryQuery : IRequest<List<RoomDto>>
    {
    }
}
