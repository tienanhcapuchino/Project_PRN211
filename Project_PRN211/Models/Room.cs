using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            Employees = new HashSet<Employee>();
        }

        public short RoomNo { get; set; }
        public short? RoomType { get; set; }
        public string Renter { get; set; }
        public int? Status { get; set; }

        public virtual RoomType RoomTypeNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
