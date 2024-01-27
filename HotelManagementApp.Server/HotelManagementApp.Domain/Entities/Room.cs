namespace HotelManagementApp.Domain.Entities
{
    public class Room
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string RoomType { get; set; }
        public string Bed { get; set; }
        public int Capacity { get; set; }
        public string Amenities { get; set; }
        public double Amount { get; set; }


    }
}
