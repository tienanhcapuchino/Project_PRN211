using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Logic;
using Project_PRN211.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Project_PRN211.DataAccess;

namespace Project_PRN211.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UserManager us = new UserManager();

            return View(us.getAllRoom());
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult loginAd(string para1, string para2)
        {
            UserManager user = new UserManager();
            Employee e1 = user.logged(para1, para2);
            string jsonStr = JsonConvert.SerializeObject(e1);
            HttpContext.Session.SetString("user", jsonStr);
            if (e1 != null)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Error = "Login Failed! Please check your username and password!";
                return View("/Views/Home/Login.cshtml");
            }
        }
        public IActionResult Admin()
        {
            string jsonStr = HttpContext.Session.GetString("user");
            Employee e;
            if (jsonStr is null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<RoomTY> lstro = ManageDAO.listAllRoom();
                e = JsonConvert.DeserializeObject<Employee>(jsonStr);
                ViewBag.Users = e;
                return View(lstro);
            }
        }

        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult searchStatus(int para1)
        {
            UserManager us = new UserManager();
            string jsonStr = HttpContext.Session.GetString("user");
            Employee e;
            if (jsonStr is null)
            {
                return RedirectToAction("Login");
            }
            else
            {

                List<RoomTY> lstro = new List<RoomTY>();
                if (para1 == 2)
                {
                    lstro = ManageDAO.listAllRoom();
                } else
                {
                    lstro = us.searchStatus(para1);
                }
                e = JsonConvert.DeserializeObject<Employee>(jsonStr);
                ViewBag.Users = e;
                //ViewBag.ListSearch = lstro;
                ViewBag.Sta = para1;
                return View("/Views/Home/Admin.cshtml", lstro);
            }
        }
    }
}
