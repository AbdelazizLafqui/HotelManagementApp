using ErrorOr;

namespace HotelManagementApp.Domain.Common.Errors
{
    public static partial class CommonErrors
    {
        public static class Reservation
        {
            public static Error BookedRoom => Error.Conflict(
                code: "Reservation.BookedRoom",
                description: "Room already booked.");

        }
    }
}