using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Facility
    {
        public Facility()
        {
            HotelFacilities = new HashSet<HotelFacility>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HotelFacility> HotelFacilities { get; set; }
    }
}
