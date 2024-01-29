using HotelManagementApp.Application.Room.Commands.CreateRoom;
using HotelManagementApp.Contracts.Room;
using Mapster;

namespace HotelManagementApp.Api.Common.Mapping
{
    public class RoomMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateRoomRequest, CreateRoomCommand>();
        }

    }
}
