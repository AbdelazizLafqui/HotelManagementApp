namespace HotelManagementApp.Application.DTOs
{
    public record RoomDto(Guid Id,
        int RoomNumber,
        int FloorNumber,
        string RoomType,
        string Bed,
        int Capacity,
        string Amenities,
        double Price);
}
