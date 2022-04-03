using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Booker
    {
        public Booker()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
