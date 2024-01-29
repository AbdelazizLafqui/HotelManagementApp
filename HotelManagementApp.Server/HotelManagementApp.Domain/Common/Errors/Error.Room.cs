using ErrorOr;

namespace HotelManagementApp.Domain.Common.Errors
{
    public static partial class CommonErrors
    {
        public static class Room
        {
            public static Error ExistingRoom => Error.Conflict(
                code: "Room.ExistingRoom",
                description: "Room already exists.");
        }
    }
}