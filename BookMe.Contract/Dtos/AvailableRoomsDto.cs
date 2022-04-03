using System;
using System.Collections.Generic;
using System.Text;

namespace BookMe.Contract.Dtos
{
    public class AvailableRoomsDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int? RoomNumber { get; set; }
        public int RoomId { get; set; }
        public string Type { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
    }
}
