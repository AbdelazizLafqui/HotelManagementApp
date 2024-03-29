﻿using HotelManagementApp.Domain.Common;

namespace HotelManagementApp.Domain.Entities
{
    public class Reservation : Entity
    {
        public string GuestName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double Amount { get; set; }

    }
}
