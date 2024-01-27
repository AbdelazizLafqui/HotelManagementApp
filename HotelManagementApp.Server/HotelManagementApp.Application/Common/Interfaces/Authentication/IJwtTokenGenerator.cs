using HotelManagementApp.Domain.Entities;

namespace HotelManagementApp.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
