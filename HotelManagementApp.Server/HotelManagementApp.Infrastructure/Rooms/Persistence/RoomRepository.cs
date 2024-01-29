using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Domain.Entities;
using HotelManagementApp.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.Infrastructure.Rooms.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelManagementDbContext _hotelManagementDbContext;

        public RoomRepository(HotelManagementDbContext hotelManagementDbContext)
        {
            _hotelManagementDbContext = hotelManagementDbContext;
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _hotelManagementDbContext.Rooms.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _hotelManagementDbContext.Rooms.AsNoTracking().ToListAsync();
        }

        public async Task AddRoomAsync(Room room)
        {
            _hotelManagementDbContext.Rooms.Add(room);
            await _hotelManagementDbContext.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            var room = _hotelManagementDbContext.Rooms.Single(x => x.Id == id);
            _hotelManagementDbContext.Rooms.Remove(room);
            await _hotelManagementDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsRoomExistAsync(int floorNumber, int roomNumber)
        {
            return await _hotelManagementDbContext.Rooms.
                AnyAsync(u => u.FloorNumber == floorNumber
                                    && u.RoomNumber == roomNumber);
        }

    }
}
