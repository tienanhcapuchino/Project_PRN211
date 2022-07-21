using Project_PRN211.Models;
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
            return context.Employees.Where(x => x.Username.Equals(username)  && x.Password.Equals(password) || x.Email.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
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
        public Guest getGuest(int room)
        {
            return context.Guests.FirstOrDefault(x => x.RoomNo == room);
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

        public bool checkPhone(string s)
        {
            if (s.StartsWith("0") && s.Length == 10)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public void UpdateStatusRom(int room)
        {
            short ro = (short)room;
            Room ro1 = context.Rooms.FirstOrDefault(x => x.RoomNo == ro);
            ro1.Status = 1;
            context.SaveChanges();
        }
        public void deactivateRom(int room)
        {
            short ro = (short)room;
            Room ro1 = context.Rooms.FirstOrDefault(x => x.RoomNo == ro);
            ro1.Status = 0;
            context.SaveChanges();
        }
        public void addGuest(Guest gu, int roomID)
        {
            gu.RoomNo = short.Parse(roomID + "");
            gu.Status = 1;
            context.Guests.Add(gu);
            context.SaveChanges();
        }
        public List<RoomTY> searchStatus(int status)
        {
            return ManageDAO.searchByStatus(status);
        }

        public int countDays(DateTime from, DateTime to)
        {
            int n = 0;
            while (from.CompareTo(to) <= 0)
            {
                from = from.AddDays(1);
                n++;
            }
            return n;
        }

        public void UpdateGuest(Guest gu)
        {
            Guest g = context.Guests.FirstOrDefault(x => x.GuestId == gu.GuestId);
            g.FullName = gu.FullName;
            g.Dob = gu.Dob;
            g.Gender = gu.Gender;
            g.PhoneNo = gu.PhoneNo;
            g.Address = gu.Address;
            g.ArrivalDate = gu.ArrivalDate;
            g.DepartureDate = gu.DepartureDate;
            g.Email = gu.Email;
            g.Status = 1;
            context.SaveChanges();    
        }

        public List<int?> getAllRoom()
        {
            List<int?> lst = new List<int?>();
            lst = context.RoomTypes.Select(x => x.NumberOfPersons).ToList();
            return lst;
        }
        public void updateBill(Bill b)
        {
            Bill bi = context.Bills.FirstOrDefault(x => x.GuestId == b.GuestId);
            bi.PaymentDate = DateTime.Now;
            bi.ExpiredDate = DateTime.Now.AddDays(1);
            bi.PaymentMode = b.PaymentMode;
            bi.Status = 1;
            bi.Note = b.Note;
            context.SaveChanges();
        }
    }
}
