using HotelManagementApp.Domain.Entities;

namespace HotelManagementApp.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);

    }
}
