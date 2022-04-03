using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class RoomBooking
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int? RoomId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Room Room { get; set; }
    }
}
