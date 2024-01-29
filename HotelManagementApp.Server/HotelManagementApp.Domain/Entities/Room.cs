using HotelManagementApp.Domain.Common;

namespace HotelManagementApp.Domain.Entities
{
    public class Room : Entity
    {
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string RoomType { get; set; }
        public string Bed { get; set; }
        public int Capacity { get; set; }
        public string Amenities { get; set; }
        public double Price { get; set; }


    }
}
