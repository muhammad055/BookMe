using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Rating
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public decimal? Rating1 { get; set; }
        public int? HotelId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
