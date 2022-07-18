using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Logic;
using Project_PRN211.Models;
using System;
using System.Collections.Generic;
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
        public IActionResult UpdateGuest(Guest gu, short para1)
        {
            UserManager use = new UserManager();
            Employee em;
            Guest g = use.getGuest(para1); ;
            //short? para1 = short.Parse(Request.Form["roomNO"]);
            List<Guest> lstGu = new List<Guest>();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
                //return "login";
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                using (var context = new SE1619_Project_HotelContext())
                {
                    lstGu = context.Guests.Where(x => x.GuestId != g.GuestId).ToList();
                }
                foreach (Guest g2 in lstGu)
                {
                    if (gu.Email.Equals(g2.Email))
                    {
                        ViewBag.err = "Email is already exists!";
                        return View("Views/Guest/InfoGuest.cshtml", gu);
                    }
                }
                use.UpdateGuest(gu);
                ViewBag.ok = 1;
                //ViewBag.roomno = g.RoomNo;
                ViewBag.users = em;
                return View("Views/Guest/InfoGuest.cshtml", gu);
                //return $"{g}";
            }
        }
        public IActionResult AddGuest(short para1)
        {
            Employee em;
            UserManager us = new UserManager();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                ViewBag.users = em;
                return View(us.getGuest(para1));
            }
        }
        public IActionResult DoAddGuest(Guest gu, short para1)
        {
            Employee em;
            Guest g;
            UserManager use = new UserManager();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                use.addGuest(gu, para1);
                ViewBag.users = em;
                ViewBag.ok = 1;
                return View("Views/Guest/AddGuest.cshtml", gu);
            }
        }
    }
}
