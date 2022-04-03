using System;
using System.Collections.Generic;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class Rent
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsActive { get; set; }
        public int? RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
