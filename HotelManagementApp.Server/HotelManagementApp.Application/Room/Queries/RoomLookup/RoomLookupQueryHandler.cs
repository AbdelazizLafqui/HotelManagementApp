using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Room.Queries
{
    internal class RoomLookupQueryHandler : IRequestHandler<RoomLookupQuery, List<RoomLookupDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public RoomLookupQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomLookupDto>> Handle(RoomLookupQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRoomsAsync();
            var roomsLookup = rooms.Select(x => new RoomLookupDto(x.Id,$"FN :{x.FloorNumber}, RN :{x.RoomNumber}")).ToList();

            var roomsDto = rooms.Adapt<List<RoomLookupDto>>();
            return roomsDto;
        }

    }
}
