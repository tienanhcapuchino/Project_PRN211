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
            List<Guest> listGu = new List<Guest>();
            List<Bill> lstBill = new List<Bill>();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
                //return "abc";
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                using (var context = new SE1619_Project_HotelContext())
                {
                    context.RoomTypes.ToList();
                    context.Guests.ToList();
                    listGu = context.Guests.Where(x => x.RoomNo == para1).ToList();
                    foreach (Guest guest in listGu)
                    {
                        if (guest.Status == 1)
                        {
                            g = guest;
                            break;
                        }
                    }
                    lstBill = context.Bills.Where(x => x.GuestId == g.GuestId).ToList();
                    foreach(Bill bill in lstBill)
                    {
                        if (bill.Status == 0)
                        {
                            b = bill;
                            break;
                        }
                    }
                    Room ro = context.Rooms.FirstOrDefault(x => x.RoomNo == para1);
                    int? priceRoom = ro.RoomType.RoomPrice;
                    price = Int32.Parse(priceRoom + "");
                    //try
                    //{
                    //    b.Note = b.Note.Trim();
                    //}
                    //catch (Exception)
                    //{

                    //}
                    context.SaveChanges();
                }
                
                using (var conte = new SE1619_Project_HotelContext())
                {
                    g.DepartureDate = DateTime.Now;
                    conte.Guests.Update(g);
                    conte.SaveChanges();
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
                //return $"Total days are: {days} and DepartureDate: {g.DepartureDate}";
                return View(b);
                //return $"{b.ToString()}";
            }
        }
        public IActionResult CheckOut(Bill b, int para1)
        {
            int price = 0;
            double totalPrice = 0;
            Employee em;
            Room ro = new Room();
            Guest gu = new Guest();
            Bill b1 = new Bill();
            UserManager us = new UserManager();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
                //return "abcde";
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                using (var context = new SE1619_Project_HotelContext())
                {
                    context.RoomTypes.ToList();
                    gu = context.Guests.FirstOrDefault(x => x.RoomNo == para1 && x.Status == 1);
                    b1 = context.Bills.FirstOrDefault(x => x.GuestId == gu.GuestId);
                    ro = context.Rooms.FirstOrDefault(x => x.RoomNo == para1);
                    int? priceRoom = ro.RoomType.RoomPrice;
                    price = Int32.Parse(priceRoom + "");
                    //try
                    //{
                    //    b.Note = b.Note.Trim();
                    //}
                    //catch (Exception)
                    //{

                    //}
                    context.SaveChanges();
                }
                us.updateBill(b);
                us.deactivateRom(para1);
                using (var conten = new SE1619_Project_HotelContext())
                {
                    gu.Status = 0;
                    ro.Status = 0;
                    b.Status = 1;
                    conten.Rooms.Update(ro);
                    conten.Guests.Update(gu);
                    conten.Bills.Update(b);
                    conten.SaveChanges();
                }

                DateTime from = Convert.ToDateTime(gu.ArrivalDate);
                DateTime to = DateTime.Now;
                int days = us.countDays(from, to);
                totalPrice = days * price;
                ViewBag.TotalPrice = totalPrice;
                ViewBag.GuestName = gu.FullName;
                ViewBag.GuestId = gu.GuestId;
                ViewBag.Days = days;
                ViewBag.RomNO = para1;
                ViewBag.users = em;
                ViewBag.ok = 1;
                return View("/Views/Bill/ViewBill.cshtml", b1);
                //return gu.Status + "" + "  " + gu.GuestId + "";
            }
        }
    }
}
