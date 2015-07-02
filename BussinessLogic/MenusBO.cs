using System;
using System.Data;
using System.Linq;
using BussinessLogic;
using DataAccess;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class MenusBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        
        private readonly HelperClass aHelperClass = new HelperClass();

        public DataTable GetGuestList(int bookinghallId)
        {
            var dt = new DataTable();
            try
            {
                var result = from g in aDatabaseDA.Guests
                             join bhs in aDatabaseDA.BookingHs on g.ID equals bhs.IDGuest
                             join bh in aDatabaseDA.BookingHalls on bhs.ID equals bh.IDBookingH
                             where bh.ID == bookinghallId
                             select new
                             {
                                 g.Name,
                                 g.Nationality,
                                 g.Info
                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {

                
            }
            return dt;
        }

        public string CreateMenu(string name, int idbookinghall, int idsystemuser)
        {
            string result = "0";
            try
            {
                var menu = new Menus() { Name = name, IDBookingHall = idbookinghall, IDSystemUser = idsystemuser };
                aDatabaseDA.Menus.Add(menu);
                aDatabaseDA.SaveChanges();

                var id = (from m in aDatabaseDA.Menus
                          orderby m.ID descending
                          select m.ID).FirstOrDefault();
                result = id.ToString();

            }
            catch (Exception ex)
            {

                
                result = "Lỗi hệ thống";
            }
            return result;
        }

        public string CreateMenu_Food(int menuid, DataTable idfood)
        {
            string result = "0";
            try
            {

                foreach (DataRow dataRow in idfood.Rows)
                {
                    var menufood = new Menus_Foods() { IDFood = Convert.ToInt32(dataRow["ID"]), IDMenu = menuid };
                    aDatabaseDA.Menus_Foods.Add(menufood);
                    aDatabaseDA.SaveChanges();
                    result = "Tạo menu thành công";
                }
            }
            catch (Exception ex)
            {

                
                result = "Lỗi hệ thống";
            }
            return result;
        }

        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<Menus> Select_All()
        {
            try
            {
                return aDatabaseDA.Menus.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Select_All :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Select_ByType
        //=======================================================
        public List<Menus> Select_ByType(int type)
        {
            try
            {
                return aDatabaseDA.Menus.Where(m => m.Type == type).OrderByDescending(m=>m.ID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Select_ByType :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Select_ByNameAndIDBookingHall
        //=======================================================
        public List<Menus> Select_ByNameAndIDBookingHall(string name,int IDBookingHall)
        {
            try
            {
                return aDatabaseDA.Menus.Where(m => m.Name.Contains(name) && m.IDBookingHall == IDBookingHall).OrderByDescending(m=>m.ID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Select_ByNameAndIDBookingHall :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public Menus Select_ByID(int ID)
        {
            try
            {
                List<Menus> aListMenus = aDatabaseDA.Menus.Where(c => c.ID == ID).ToList();
                if (aListMenus.Count > 0)
                {
                    return aDatabaseDA.Menus.Where(c => c.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Select_ByID :" + ex.Message.ToString()));
            }
        }


        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(Menus aMenus)
        {
            try
            {
                aDatabaseDA.Menus.Add(aMenus);
                aDatabaseDA.SaveChanges();
                return aMenus.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Insert :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Delete_ByID
        //=======================================================
        public int Delete(int ID)
        {
            try
            {
                Menus aMenus = aDatabaseDA.Menus.Find(ID);
                aDatabaseDA.Menus.Remove(aMenus);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Delete :" + ex.Message));
            }
        }


        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(Menus aMenus)
        {
            try
            {
                aDatabaseDA.Menus.AddOrUpdate(aMenus);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Update :" + ex.Message));
            }
        }
        //Linhting
        public List<Menus> Select_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                return aDatabaseDA.Menus.Where(a =>a.IDBookingHall == IDBookingHall).OrderByDescending(m => m.ID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("MenusBO.Select_ByIDBookingHall :" + ex.Message.ToString()));
            }
        }
    }
}
