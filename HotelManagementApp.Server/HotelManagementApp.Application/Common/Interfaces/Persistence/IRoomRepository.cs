namespace HotelManagementApp.Application.Common.Interfaces.Persistence
{
    public interface IRoomRepository
    {
        Task<Domain.Entities.Room?> GetByIdAsync(Guid id);
        Task<List<Domain.Entities.Room>> GetRoomsAsync();
        Task AddRoomAsync(Domain.Entities.Room room);
        Task DeleteRoomAsync(Guid id);
        Task<bool> IsRoomExistAsync(int floorNumber, int roomNumber);

    }
}
