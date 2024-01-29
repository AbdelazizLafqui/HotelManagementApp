using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Room.Queries.RoomSummary
{
    internal class RoomSummaryQueryHandler : IRequestHandler<RoomSummaryQuery, List<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public RoomSummaryQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomDto>> Handle(RoomSummaryQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRoomsAsync();

            var roomsDto = rooms.Adapt<List<RoomDto>>();
            return roomsDto;
        }

    }
}
