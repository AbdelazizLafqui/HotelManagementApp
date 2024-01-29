namespace HotelManagementApp.Contracts.Room
{
    public record RoomResponse(
        Guid Id,
        int RoomNumber,
        int FloorNumber,
        string RoomType,
        string Bed,
        int Capacity,
        string Amenities,
        double Price);
}
