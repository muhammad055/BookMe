using System;
using System.Collections.Generic;
using System.Text;

namespace BookMe.Contract.Dtos
{
    public class BookingRequestDto
    {
        public BookingRequestDto()
        {
            RoomRent = new List<RoomRentDto>();
        }
        public int BookerId { get; set; }
        public int RoomTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<RoomRentDto> RoomRent { get; set; }
        

    }

}
