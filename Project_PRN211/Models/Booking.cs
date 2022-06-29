using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Bills = new HashSet<Bill>();
        }

        public short BookingId { get; set; }
        public short GuestId { get; set; }
        public short RoomNo { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? Checkout { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual Room RoomNoNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
