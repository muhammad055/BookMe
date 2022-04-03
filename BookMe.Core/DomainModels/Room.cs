using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Room
    {
        public Room()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public int? RoomNumber { get; set; }
        public int? HotelId { get; set; }
        public int? FloorNo { get; set; }
        public int? People { get; set; }
        public int? Rating { get; set; }
        public bool? IsAvailable { get; set; }
        public int? RoomTypeId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
