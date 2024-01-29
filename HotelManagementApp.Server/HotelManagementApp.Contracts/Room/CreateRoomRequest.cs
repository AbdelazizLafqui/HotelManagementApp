namespace HotelManagementApp.Contracts.Room
{
    public record CreateRoomRequest(
        int RoomNumber,
        int FloorNumber,
        string RoomType,
        string Bed,
        int Capacity,
        string Amenities,
        double Price);
}
