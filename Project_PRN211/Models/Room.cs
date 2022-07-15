using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Room
    {
        public Room()
        {
            Guests = new HashSet<Guest>();
        }

        public short RoomNo { get; set; }
        public short? RoomTypeId { get; set; }
        public string Renter { get; set; }
        public int? Status { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
