using Project_PRN211.Models;
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
    }
}
