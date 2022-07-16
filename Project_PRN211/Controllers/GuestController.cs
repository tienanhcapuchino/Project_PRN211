using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Logic;
using Project_PRN211.Models;

namespace Project_PRN211.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InfoGuest(int para1)
        {
            Employee em;
            UserManager use = new UserManager();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                ViewBag.users = em;
                return View();
            }
        }
        public IActionResult UpdateGuest()
        {

            return View("InfoGuest");
        }
        public IActionResult AddGuest(int para1)
        {
            Employee em;
            UserManager use = new UserManager();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                ViewBag.users = em;
                return View();
            }
        }
        public IActionResult DoAddGuest()
        {
            return View("AddGuest");
        }
    }
}
