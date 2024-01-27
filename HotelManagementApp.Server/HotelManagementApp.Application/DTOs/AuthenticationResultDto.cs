
namespace HotelManagementApp.Application.DTOs
{
    public record AuthenticationResultDto(
        UserDto User,
        string Token);
}