namespace HotelManagementApp.Contracts.Reservation
{
    public record ReservationResponse(
        Guid Id,
        string GuestName,
        string MobileNumber,
        string Email,
        Guid RoomId,
        DateTime CheckInDate,
        DateTime CheckOutDate,
        double Amount);

}
