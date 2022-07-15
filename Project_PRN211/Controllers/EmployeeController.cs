using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_PRN211.Models;
using Project_PRN211.Logic;
using System;
using System.Linq;
using System.Collections.Generic;
using Project_PRN211.DataAccess;

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
                List<Employee> lstEM = new List<Employee>();
                using (var context = new SE1619_Project_HotelContext())
                {
                    em = context.Employees.FirstOrDefault(x => x.Id == em.Id);
                    lstEM = context.Employees.Where(x => x.Id != e.Id).ToList();
                }
                if (!e.Email.Contains("@")){
                    ViewBag.Err = "Email is invalid!";
                    return RedirectToAction("UpdateProfile");
                }
                foreach (Employee emp in lstEM)
                {
                    if (e.Email.Equals(emp.Email))
                    {
                        ViewBag.Err = "Email is already exists!";
                        return RedirectToAction("UpdateProfile");
                    }
                }
                if (e.PhoneNumber.Length == 10 && e.PhoneNumber.StartsWith("0"))
                {

                } else
                {
                    ViewBag.Err = "Phone number must have 10 numbers and start with 0!";
                    return RedirectToAction("UpdateProfile");
                }
                use.EditProfile(e);
                ViewBag.Users = e.FullName;
                return RedirectToAction("UpdateProfile");
                //return $"{em.FullName} - {e.FullName} - {em.Id} - {e.Id}";
            }
        }
        public IActionResult ChangePass()
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
        public IActionResult DoChangePass(Employee e)
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
                using (var context = new SE1619_Project_HotelContext())
                {
                    em = context.Employees.FirstOrDefault(x => x.Id == em.Id);
                    em.Password = e.Password;
                    context.SaveChanges();
                }
                return RedirectToAction("ChangePass");
            }
        }
    }
}