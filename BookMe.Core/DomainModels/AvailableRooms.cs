using System;
using System.Collections.Generic;
using System.Text;

namespace BookMe.Core.DomainModels
{
    public class AvailableRooms
    {
        public int HotelId { get; set; }
        public string  Name { get; set; }
        public int? RoomNumber { get; set; }
        public int RoomId { get; set; }
        public string Type { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal? Amount { get; set; }

    }
}
