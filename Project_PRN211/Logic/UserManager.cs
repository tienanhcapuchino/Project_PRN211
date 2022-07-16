﻿using Project_PRN211.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Project_PRN211.DataAccess;

namespace Project_PRN211.Logic
{
    public class UserManager
    {
        SE1619_Project_HotelContext context;
        public UserManager()
        {
            context = new SE1619_Project_HotelContext();
        }
        public Employee logged(string username, string password)
        {
            return context.Employees.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
        }
        //public void AddGuest(short room, string fullname, string phone, DateTime arrDate, DateTime depDate)
        //{
        //    Guest guest = new Guest(room, fullname, phone, arrDate, depDate);
        //    context.Add(guest);
        //    context.SaveChanges();
        //}
        //public void updateGuest(short GuestId, short? RoomNo, DateTime? ArrivalDate, DateTime? DepartureDate)
        //{
        //    Guest gg = new Guest(GuestId, RoomNo, ArrivalDate, DepartureDate);
        //    context.Update(gg);
        //    context.SaveChanges();
        //}
        public Employee GetEmployee(int id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }
        public List<int> getAllRoomNo()
        {
            return ManageDAO.getAllRoom();
        }
        public void EditProfile(Employee e)
        {
            Employee em = context.Employees.FirstOrDefault(x => x.Id == e.Id);
            em.FullName = e.FullName;
            em.DateBirth = e.DateBirth;
            em.Gender = e.Gender;
            em.PhoneNumber = e.PhoneNumber;
            em.Email = e.Email;
            context.SaveChanges();
        }
        public List<RoomTY> searchStatus(int status)
        {
            return ManageDAO.searchByStatus(status);
        }
        public List<int?> getAllRoom()
        {
            List<int?> lst = new List<int?>();
            lst = context.RoomTypes.Select(x => x.NumberOfPersons).ToList();
            return lst;
        }
    }
}
