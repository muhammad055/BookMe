using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rents = new HashSet<Rent>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
