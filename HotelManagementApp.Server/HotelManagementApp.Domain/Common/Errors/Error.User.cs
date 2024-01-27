using ErrorOr;

namespace HotelManagementApp.Domain.Common.Errors
{
    public static partial class CommonErrors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already in use.");
        }
    }
}