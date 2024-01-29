using HotelManagementApp.Domain.Common;

namespace HotelManagementApp.Domain.Entities
{
    public class User : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
