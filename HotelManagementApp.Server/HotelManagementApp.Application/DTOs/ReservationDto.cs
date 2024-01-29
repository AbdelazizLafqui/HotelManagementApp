namespace HotelManagementApp.Application.DTOs
{
    public record ReservationDto(Guid Id,
                                 string GuestName,
                                 string MobileNumber,
                                 string Email,
                                 Guid RoomId,
                                 DateTime CheckInDate,
                                 DateTime CheckOutDate,
                                 double Amount);
}
