namespace HotelManagementApp.Contracts.Reservation
{
    public record CreateReservationRequest(
        string GuestName,
        string MobileNumber,
        string Email,
        Guid RoomId,
        DateTime CheckInDate,
        DateTime CheckOutDate,
        double Amount);

}
