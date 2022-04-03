using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class HotelFacility
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? FacilityId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
