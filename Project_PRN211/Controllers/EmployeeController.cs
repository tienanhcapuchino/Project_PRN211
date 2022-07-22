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
                    ViewBag.users = em;
                    return View("/Views/Employee/UpdateProfile.cshtml", use.GetEmployee(em.Id));
                }
                foreach (Employee emp in lstEM)
                {
                    if (e.Email.Equals(emp.Email))
                    {
                        ViewBag.Err = "Email is already exists!";
                        ViewBag.users = em;
                        return View("/Views/Employee/UpdateProfile.cshtml", use.GetEmployee(em.Id));
                    }
                    if (e.PhoneNumber.Equals(emp.PhoneNumber))
                    {
                        ViewBag.Err = "Phone number is already exists!";
                        ViewBag.users = em;
                        return View("/Views/Employee/UpdateProfile.cshtml", use.GetEmployee(em.Id));
                    }
                }
                if (e.PhoneNumber.Length == 10 && e.PhoneNumber.StartsWith("0"))
                {

                } else
                {
                    ViewBag.Err = "Phone number must have 10 numbers and start with 0!";
                    ViewBag.users = em;
                    return View("/Views/Employee/UpdateProfile.cshtml", use.GetEmployee(em.Id));
                }
                use.EditProfile(e);
                ViewBag.Users = e.FullName;
                ViewBag.ok = 1;
                return View("/Views/Employee/UpdateProfile.cshtml", use.GetEmployee(em.Id));
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
        public IActionResult DoChangePass()
        {
            string oldPass = Request.Form["PassNow"];
            string newPass = Request.Form["passNew"];
            string repass = Request.Form["re_pass"];
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
                    
                    if (!oldPass.Equals(em.Password))
                    {
                        ViewBag.err = "Old password is not correct!";
                        ViewBag.oldPa = oldPass;
                        ViewBag.newPa = newPass;
                        ViewBag.rePa = repass;
                        ViewBag.users = em;
                        return View("/Views/Employee/ChangePass.cshtml");
                    }
                    if (!newPass.Equals(repass))
                    {
                        ViewBag.err = "Re-password is not match with new password!";
                        ViewBag.oldPa = oldPass;
                        ViewBag.newPa = newPass;
                        ViewBag.rePa = repass;
                        ViewBag.users = em;
                        return View("/Views/Employee/ChangePass.cshtml");
                    }
                    em.Password = newPass;
                    context.Update(em);
                    context.SaveChanges();
                }
                //return $"{oldPass} - {newPass} - {repass}";
                HttpContext.Session.Remove("user");
                return View("/Views/Home/Login.cshtml");
            }
        }
    }
}