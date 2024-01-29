using ErrorOr;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using Mapster;
using MediatR;

namespace HotelManagementApp.Application.Room.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, ErrorOr<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ErrorOr<RoomDto>> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
        {
            var hasRoom = await _roomRepository.IsRoomExistAsync(command.FloorNumber, command.RoomNumber);
            if (hasRoom)
            {
                return Domain.Common.Errors.CommonErrors.Room.ExistingRoom;
            }

            var newRoom = new Domain.Entities.Room
            {
                FloorNumber = command.FloorNumber,
                RoomNumber = command.RoomNumber,
                RoomType = command.RoomType,
                Bed = command.Bed,
                Capacity = command.Capacity,
                Amenities = command.Amenities,
                Price = command.Price,
            };

            await _roomRepository.AddRoomAsync(newRoom);

            var roomDto = newRoom.Adapt<RoomDto>();

            return roomDto;
        }
    }
}
