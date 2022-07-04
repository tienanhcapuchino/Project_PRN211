using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Role
    {
        public Role()
        {
            Guests = new HashSet<Guest>();
        }

        public short RoleId { get; set; }
        public string RoleTitle { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
