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
            List<Guest> lstGu = new List<Guest>();
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
                    context.Guests.ToList();
                    lstGu = context.Guests.Where(x => x.RoomNo == para1).ToList();
                }
                foreach (Guest gu1 in lstGu)
                {
                    if (gu1.Status == 1)
                    {
                        gu = gu1;
                        break;
                    }
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
                    context.Guests.ToList();
                    lstGu = context.Guests.Where(x => x.GuestId != g.GuestId).ToList();
                }
                //foreach (Guest g2 in lstGu)
                //{
                //    if (gu.Email.Equals(g2.Email))
                //    {
                //        ViewBag.err = "Email is already exists!";
                //        return View("Views/Guest/InfoGuest.cshtml", gu);
                //    }
                //}
                if (use.checkPhone(gu.PhoneNo))
                {
                    
                } else
                {
                    ViewBag.err = "Phone number must be 10 numbers and starts with 0!";
                    ViewBag.users = em;
                    return View("Views/Guest/InfoGuest.cshtml", gu);
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
                ViewBag.Rom = para1;
                ViewBag.users = em;
                return View(new Guest());
            }
        }
        public IActionResult DoAddGuest(Guest gu, string para1)
        {
            string ro = Request.Form["roomNo"];
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
                int ro1 = Int32.Parse(ro);
                g = use.getGuest(ro1);
                if (use.checkPhone(gu.PhoneNo))
                {

                }
                else
                {
                    ViewBag.Err = "Phone number must be 10 numbers and starts with 0!";
                    ViewBag.Rom = ro1;
                    ViewBag.users = em;
                    return View("Views/Guest/AddGuest.cshtml", gu);
                }
                Bill b = new Bill();
                use.addGuest(gu, ro1);
                using (var context = new SE1619_Project_HotelContext())
                {
                    b.GuestId = gu.GuestId;
                    b.Status = 0;
                    b.PaymentMode = "Cash";
                    context.Bills.Add(b);
                    context.SaveChanges();
                }
                use.UpdateStatusRom(ro1);
                ViewBag.users = em;
                ViewBag.ok = 1;
                ViewBag.Rom = ro1;
                return View("Views/Guest/AddGuest.cshtml", gu);
            }
            
        }
    }
}
