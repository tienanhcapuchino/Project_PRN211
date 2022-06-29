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
            Bookings = new HashSet<Booking>();
        }

        public short GuestId { get; set; }
        public short BookingId { get; set; }
        public short RoleId { get; set; }
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
