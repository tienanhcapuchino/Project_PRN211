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
            int price = 0;
            double totalPrice = 0;
          
            Bill b = new Bill();
            Guest g = new Guest();
            using (var context = new SE1619_Project_HotelContext())
            {
                context.RoomTypes.ToList();
                g = context.Guests.FirstOrDefault(x => x.GuestId == para1);
                g.DepartureDate = DateTime.Now;
                b = context.Bills.FirstOrDefault(x => x.GuestId == g.GuestId);
                Room ro = context.Rooms.FirstOrDefault(x => x.RoomNo == para1);
                int? priceRoom = ro.RoomType.RoomPrice;
                price = Int32.Parse(priceRoom+"");
                try
                {
                    b.Note = b.Note.Trim();
                }
                catch (Exception)
                {

                }
                context.SaveChanges();
            }
            int days = Convert.ToInt32(g.DepartureDate - g.ArrivalDate);
            totalPrice = days * price;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.GuestName = g.FullName;
            return View(b);
        }
        public IActionResult CheckOut(int para1)
        {
            return View();
        }
    }
}
