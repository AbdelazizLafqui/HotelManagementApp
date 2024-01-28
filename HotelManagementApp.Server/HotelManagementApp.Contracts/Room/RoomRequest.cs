using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Contracts.Room
{
    public record RoomRequest(
        Guid Id, 
        int RoomNumber, 
        int FloorNumber,
        string RoomType,
        string Bed,
        int Capacity,
        string Amenities,
        double Amount);
}
