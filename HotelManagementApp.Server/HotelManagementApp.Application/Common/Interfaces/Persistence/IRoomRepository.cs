using  HotelManagementApp.Domain;

namespace HotelManagementApp.Application.Common.Interfaces.Persistence
{
    public interface IRoomRepository
    {
        List<Domain.Entities.Room> GetRooms();
        void AddRoom(Domain.Entities.Room room);
        void Remove(Guid id);

    }
}
