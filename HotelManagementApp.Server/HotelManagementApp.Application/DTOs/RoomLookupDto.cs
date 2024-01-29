using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Application.DTOs
{
    public record RoomLookupDto(
        Guid Id,
        string DisplayValue);
}
