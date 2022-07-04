using Project_PRN211.Models;
using System;
using System.Linq;

namespace Project_PRN211.Logic
{
    public class UserManager
    {
        SE1619_Project_HotelContext context;
        public UserManager()
        {
            context = new SE1619_Project_HotelContext();
        }
        public Employee logged(string username, string password)
        {
            return context.Employees.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
        }
        public void AddGuest(short room, string fullname, string phone, DateTime arrDate, DateTime depDate)
        {
            Guest guest = new Guest(room, fullname, phone, arrDate, depDate);
            context.Add(guest);
            context.SaveChanges();
        }
    }
}
