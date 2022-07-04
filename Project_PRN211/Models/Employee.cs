using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Employee
    {
        public short Id { get; set; }
        public string FullName { get; set; }
        public DateTime? DateBirth { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Salary { get; set; }

        public override string ToString()
        {
            return $"{FullName}";
        }
    }
}
