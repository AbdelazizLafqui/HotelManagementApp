using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Domain.Entities;
using HotelManagementApp.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApp.Infrastructure.Users.Persistence
{
    internal class UserRepository : IUserRepository
    {
        private readonly HotelManagementDbContext _hotelManagementDbContext;

        public UserRepository(HotelManagementDbContext hotelManagementDbContext)
        {
            this._hotelManagementDbContext = hotelManagementDbContext;
        }

        public void AddUser(User user)
        {
            _hotelManagementDbContext.Users.Add(user);
            _hotelManagementDbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _hotelManagementDbContext.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
