using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class GuestsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        private readonly HelperClass aHelperClass = new HelperClass();
        

        public List<Guests> SelectAll()
        {
            var dt = new DataTable();
            try
            {
                return aDatabaseDA.Guests.ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
         
        }

        public string AddNewGuest(string name, int type, string nation, string info)
        {
            string result = "";
            try
            {
                var guest = new Guests() {Name = name, Type = type, Nationality = nation, GroupName = "", Info = info};
                aDatabaseDA.Guests.Add(guest);
                aDatabaseDA.SaveChanges();
                result = "Thêm mới thành công";
            }
            catch (Exception ex)
            {
                
                
                result = "Lỗi hệ thống";
            }

            return result;
        }

        public string DeleteGuest(int id)
        {
            var result = "";
            try
            {
                var guest = (from g in aDatabaseDA.Guests
                             where g.ID == id
                             select g).FirstOrDefault();
                aDatabaseDA.Guests.Remove(guest);
                aDatabaseDA.SaveChanges();
                result = "Xóa thành công";
            }
            catch (Exception ex)
            {
                
                
                result = "Lỗi hệ thống";
            }
            return result;
        }

        public string EditGuest(int id, string name, string national, string info)
        {
            var result = "";
            try
            {
                var guest = (from g in aDatabaseDA.Guests
                             where g.ID == id
                             select g).FirstOrDefault();
                guest.Name = name;
                guest.Nationality = national;
                guest.Info = info;
                aDatabaseDA.SaveChanges();
                result = "Thay đổi thành công";
            }
            catch (Exception ex)
            {
                
                
                result = "Lỗi hệ thống";
            }

            return result;
        }

        public Guests GuestDetail(int id)
        {
            var dt = new DataTable();
            try
            {
                List<Guests> ret = new List<Guests>();
                ret = aDatabaseDA.Guests.Where(p => p.ID == id).ToList();
                if (ret.Count == 0)
                {
                    return new Guests();
                }
                else
                {
                    return ret[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetListGuestBooking(int type)
        {
            var dt = new DataTable();
            try
            {
                var result = from v in aDatabaseDA.vw__SearchCustomer__Companies_CustomerGroups_Customers
                    where v.Companies_Type == type
                    select new
                           {
                               v.Companies_ID,v.Companies_Name,v.Companies_Type,v.CustomerGroups_ID, 
                               v.CustomerGroups_Name, v.CustomerGroups_Type,v.Customers_Address, v.Customers_Birthday,
                               v.Customers_Disable, v.Customers_Email,  v.Customers_Identifier1, v.Customers_Identifier2,
                               v.Customers_Identifier3, v.Customers_Name, v.Customers_Nationality, v.Customers_Status, v.Customers_Tel, v.Customers_Type,
                               CDVAL = v.Customers_ID, CDCONTENT = v.Customers_Name + "-" + v.Customers_Identifier1
                           };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                
                
            }
            return dt;
        }

        //Author : Linhting
        public List<Guests> Select_All()
        {
            try
            {
                return aDatabaseDA.Guests.OrderByDescending(c => c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("GuestsBO.Select_All:" + ex.ToString());
            }
        }
        //Author : Linhting
        public Guests Select_ByID(int id)
        {
            try
            {
                return aDatabaseDA.Guests.Where(a => a.ID == id).ToList()[0];
            }
            catch (Exception ex)
            {

                throw new Exception("GuestsBO.Select_ByID:" + ex.ToString());
            }
        }
        //Author : Linhting

        public int Insert(Guests aGuests)
        {
            try
            {
                aDatabaseDA.Guests.Add(aGuests);
                aDatabaseDA.SaveChanges();
                return aGuests.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("GuestsBO.Insert:" + ex.ToString());
            }
        }
        //Author : Linhting
        public int Update(Guests aGuests)
        {
            try
            {
                aDatabaseDA.Guests.AddOrUpdate(aGuests);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("GuestsBO.Update:" + ex.ToString());
            }
        }
        //Author : Linhting
        public int Delete(int id)
        {
            try
            {
                Guests aGuests = aDatabaseDA.Guests.Find(id);
                aDatabaseDA.Guests.Remove(aGuests);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("GuestsBO.Delete:" + ex.ToString());
            }
        }
    }
}
