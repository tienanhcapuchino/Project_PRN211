using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Models;
using Project_PRN211.Logic;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Project_PRN211.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpdateProfile(int para1)
        {
            Employee em;
            UserManager use = new UserManager();
            string jsonstr = HttpContext.Session.GetString("user");
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
                //return "login";
            }
            else
            {
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                para1 = em.Id;
                ViewBag.users = em;
                return View(use.GetEmployee(para1));
            }
            //return $"{e.Id} - {e.FullName} - {e.DateBirth} - {e.Username}";
        }

        public IActionResult listRoom()
        {
            List<Room> lstro = new List<Room>();
            using (var context = new SE1619_Project_HotelContext())
            {
                //lstro = context.Rooms.Select(x => new
                //{
                //    x.RoomNo,
                //    x.RoomType.RoomPrice,
                //    x.RoomType.NumberOfPersons.ToString(),
                //    x.Status
                //}).ToList();
            }
            return View();
        }

        public IActionResult DoUpdateProfile(Employee e)
        {
            string jsonstr = HttpContext.Session.GetString("user");
            Employee em;
            if (jsonstr is null)
            {
                return View("/Views/Home/Login.cshtml");
                //return "login";
            }
            else
            {
                UserManager use = new UserManager();
                em = JsonConvert.DeserializeObject<Employee>(jsonstr);
                using (var context = new SE1619_Project_HotelContext())
                {
                    em = context.Employees.FirstOrDefault(x => x.Id == em.Id);
                }
                
                use.EditProfile(e);
                ViewBag.Users = e.FullName;
                return RedirectToAction("UpdateProfile");
                //return $"{em.FullName} - {e.FullName} - {em.Id} - {e.Id}";
            }
        }
        public IActionResult changePass()
        {
            string jsonstr = HttpContext.Session.GetString("user");
            Employee em;
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
    }
}