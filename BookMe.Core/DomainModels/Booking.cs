using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Booking
    {
        public Booking()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public int? BookerId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }

        public virtual Booker Booker { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
