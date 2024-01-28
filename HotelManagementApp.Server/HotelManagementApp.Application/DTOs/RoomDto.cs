using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Application.DTOs
{
    public record RoomDto (Guid Id,
        int RoomNumber,
        int FloorNumber,
        string RoomType,
        string Bed,
        int Capacity,
        string Amenities,
        double Amount);
}
