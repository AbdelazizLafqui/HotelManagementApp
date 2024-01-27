using ErrorOr;

namespace HotelManagementApp.Domain.Common.Errors
{
    public static partial class CommonErrors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCredentials",
                description: "Invalid credentials.");
        }
    }
}