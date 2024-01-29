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

        public async Task AddUserAsync(User user)
        {
            _hotelManagementDbContext.Users.Add(user);
            await _hotelManagementDbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _hotelManagementDbContext.Users.AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email); ;
        }
    }
}
