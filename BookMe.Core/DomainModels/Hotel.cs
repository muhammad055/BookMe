using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelFacilities = new HashSet<HotelFacility>();
            InverseParent = new HashSet<Hotel>();
            Ratings = new HashSet<Rating>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public int? ParentId { get; set; }

        public virtual Hotel Parent { get; set; }
        public virtual ICollection<HotelFacility> HotelFacilities { get; set; }
        public virtual ICollection<Hotel> InverseParent { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
