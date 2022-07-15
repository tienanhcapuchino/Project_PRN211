using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Guest
    {
        public Guest()
        {
            Bills = new HashSet<Bill>();
        }

        public short GuestId { get; set; }
        public short? RoomNo { get; set; }
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? Status { get; set; }

        public virtual Room RoomNoNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
