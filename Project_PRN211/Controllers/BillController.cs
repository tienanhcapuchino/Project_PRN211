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
    public class BillController : Controller
    {
        public IActionResult ViewBill(short para1)
        {
            Employee em;
            int price = 0;
            UserManager use = new UserManager();
            double totalPrice = 0;

            Bill b = new Bill();
            Guest g = new Guest();
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
                    context.RoomTypes.ToList();
                    g = context.Guests.FirstOrDefault(x => x.GuestId == para1);
                    g.DepartureDate = DateTime.Now;
                    b = context.Bills.FirstOrDefault(x => x.GuestId == g.GuestId);
                    Room ro = context.Rooms.FirstOrDefault(x => x.RoomNo == para1);
                    int? priceRoom = ro.RoomType.RoomPrice;
                    price = Int32.Parse(priceRoom + "");
                    try
                    {
                        b.Note = b.Note.Trim();
                    }
                    catch (Exception)
                    {

                    }
                    context.SaveChanges();
                }
                DateTime from = Convert.ToDateTime(g.ArrivalDate);
                DateTime to = DateTime.Now;
                int days = use.countDays(from, to);
                totalPrice = days * price;
                ViewBag.TotalPrice = totalPrice;
                ViewBag.GuestName = g.FullName;
                ViewBag.GuestId = g.GuestId;
                ViewBag.Days = days;
                ViewBag.RomNO = para1;
                ViewBag.users = em;
                //return $"Total day+s are: {days} and DepartureDate: {g.DepartureDate}";
                return View(b);
            }

        }
        public IActionResult CheckOut(Bill b, int para1)
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
                us.updateBill(b);
                ViewBag.users = em;
                ViewBag.ok = 1;
                return View("/Views/Bill/ViewBill.cshtml");
            }
        }
    }
}
