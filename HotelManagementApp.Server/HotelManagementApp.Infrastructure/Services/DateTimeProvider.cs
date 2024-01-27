using HotelManagementApp.Application.Common.Interfaces.Services;

namespace HotelManagementApp.Infrastructure.Serivces
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}