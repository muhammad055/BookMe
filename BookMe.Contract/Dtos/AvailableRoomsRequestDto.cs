using System;
using System.Collections.Generic;
using System.Text;

namespace BookMe.Contract.Dtos
{
    public class AvailableRoomsRequestDto
    {
        public int HotelId { get; set; }
        public DateTime? CheckInDate { get; set; }
    }
}
