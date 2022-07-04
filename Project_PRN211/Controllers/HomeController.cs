using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Logic;
using Project_PRN211.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project_PRN211.Controllers
{
    public class HomeController : Controller
    {
        public string setCookie()
        {
            CookieOptions option = new CookieOptions();
            option.Expires = System.DateTimeOffset.Now.AddSeconds(30);
            Response.Cookies.Append("SE1619-NET", "TienAnh", option);
            return $"set cookie oke";
        }
        public string showCookie()
        {
            string cook = Request.Cookies["SE1619-NET"];
            return cook;
        }
        public string setSession()
        {
            HttpContext.Session.SetInt32("Id", 12);
            HttpContext.Session.SetString("user", "tienanh");
            Employee em = new Employee();
            em.FullName = "Tien Anh";
            em.Salary = 2005;
            Dictionary<int, int> cart = new Dictionary<int, int>();
            cart.Add(1, 2);
            cart.Add(2, 4);
            cart.Add(3, 2);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            string jConstr = JsonConvert.SerializeObject(em);
            HttpContext.Session.SetString("employ", jConstr);
            return $"";
        }
        public string showSession()
        {
            int? id = HttpContext.Session.GetInt32("Id");
            string? user = HttpContext.Session.GetString("user");
            string jconstr = HttpContext.Session.GetString("employ");
            Employee e;
            if (jconstr is null) e = new Employee();
            else e = JsonConvert.DeserializeObject<Employee>(jconstr);

            Employee e1;
            string cat = HttpContext.Session.GetString("cart");
            if (string.IsNullOrEmpty(cat)) e1 = new Employee();
            return $"ID: {id} - user: {user}";
        }
        public IActionResult Index()
        {
            return View();
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
            if (e1 is not null)
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
                ViewBag.Error = "Login Failed! Please check your username and password!";
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                e = JsonConvert.DeserializeObject<Employee>(jsonStr);
                ViewBag.Users = e;
                return View();
            }
        }
        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult bookRoom(short para1, string para2, string para3, DateTime para4, DateTime para5)
        {
            UserManager us = new UserManager();
            us.AddGuest(para1, para2, para3, para4, para5);
            
            return RedirectToAction("Index");
        }
    }
}
