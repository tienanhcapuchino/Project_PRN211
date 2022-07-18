using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Logic;
using Project_PRN211.Models;
using System;
using System.Linq;

namespace Project_PRN211.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InfoGuest(short? para1)
        {
            Employee em;
            Guest gu = new Guest();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                using (var context = new SE1619_Project_HotelContext())
                {
                    gu = context.Guests.FirstOrDefault(x => x.RoomNo == para1);
                }
                ViewBag.users = em;
                return View(gu);
            }
        }
        public IActionResult UpdateGuest()
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
                return View("InfoGuest");
            }
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
