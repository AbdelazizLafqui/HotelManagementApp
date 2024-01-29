using ErrorOr;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using MediatR;

namespace HotelManagementApp.Application.Room.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, ErrorOr<Success>>
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ErrorOr<Success>> Handle(DeleteRoomCommand command, CancellationToken cancellationToken)
        {
            var room = _roomRepository.GetByIdAsync(command.Id);

            if (room is null)
            {
                return Error.NotFound(description: "Room not found");
            }
            await _roomRepository.DeleteRoomAsync(command.Id);

            return Result.Success;
        }
    }
}
