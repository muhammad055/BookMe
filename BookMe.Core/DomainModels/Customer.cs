using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
