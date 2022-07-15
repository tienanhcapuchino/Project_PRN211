using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public short RoomTypeId { get; set; }
        public int? RoomPrice { get; set; }
        public string RoomImg { get; set; }
        public int? NumberOfPersons { get; set; }
        public int? NumberOfRooms { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
