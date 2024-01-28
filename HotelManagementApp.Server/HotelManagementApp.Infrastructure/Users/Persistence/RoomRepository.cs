using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Domain.Entities;
using HotelManagementApp.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Infrastructure.Users.Persistence
{
    internal class RoomRepository : IRoomRepository
    {
        private readonly HotelManagementDbContext _hotelManagementDbContext;

        public RoomRepository(HotelManagementDbContext hotelManagementDbContext)
        {
            _hotelManagementDbContext = hotelManagementDbContext;
        }

        public void AddRoom(Room room)
        {
            _hotelManagementDbContext.Rooms.Add(room);
            _hotelManagementDbContext.SaveChanges();
        }

        public List<Room> GetRooms()
        {
            return _hotelManagementDbContext.Rooms.ToList();
        }

        public void Remove(Guid id)
        {
            var room = _hotelManagementDbContext.Rooms.Single(x => x.Id == id);
            _hotelManagementDbContext.Rooms.Remove(room);
            _hotelManagementDbContext.SaveChanges();

        }
    }
}
