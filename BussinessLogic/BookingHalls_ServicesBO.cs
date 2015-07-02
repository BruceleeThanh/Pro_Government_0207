using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
   public class BookingHalls_ServicesBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //Author: Linhting
        public List<BookingHalls_Services> Select_All()
        {
            try
            {
                return aDatabaseDA.BookingHalls_Services.OrderByDescending(c => c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHalls_ServicesBO.Select_All:" + ex.ToString());
            }
        }

        //Author: Linhting
        public BookingHalls_Services Select_ByID(int ID)
        {
            try
            {
                List<BookingHalls_Services> aListBookingHalls_Services =aDatabaseDA.BookingHalls_Services.Where(a => a.ID == ID).ToList();
                if (aListBookingHalls_Services.Count > 0)
                {
                    return aListBookingHalls_Services[0];
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHalls_ServicesBO.Select_ByID:" + ex.ToString());
            }
        }

        //Author: Linhting
        public BookingHalls_Services Select_ByIDService_ByIDBookingHall(int IDService, int IDBookingHall)
        {
            try
            {

                List<BookingHalls_Services> aListBookingHalls_Services = aDatabaseDA.BookingHalls_Services.Where(c => c.IDService == IDService).Where(c => c.IDBookingHall == IDBookingHall).ToList();
                if (aListBookingHalls_Services.Count > 0)
                {
                    return aListBookingHalls_Services[0];
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHalls_ServicesBO.Select_ByIDService_ByIDBookingHall:" + ex.ToString());
            }
        }

        //Author: Linhting
        public List<BookingHalls_Services> Select_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                return aDatabaseDA.BookingHalls_Services.Where(c => c.IDBookingHall == IDBookingHall).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHalls_ServicesBO.Select_ByIDBookingHall:" + ex.ToString());
            }
        }

        //Author: Linhting
        public int Insert(BookingHalls_Services BookingHalls_Services)
        {
            try
            {
                aDatabaseDA.BookingHalls_Services.Add(BookingHalls_Services);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHalls_ServicesBO.Insert:" + ex.ToString());
            }
        }

        //Author: Linhting
        public int Update(BookingHalls_Services BookingHalls_Services)
        {
            try
            {
                aDatabaseDA.BookingHalls_Services.AddOrUpdate(BookingHalls_Services);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("BookingHalls_ServicesBO.Update:" + ex.ToString());
            }
        }

        public int Delete(int IDBookingHallService)
        {
            try
            {

                List<BookingHalls_Services> aBookingHalls_Services = aDatabaseDA.BookingHalls_Services.Where(c => c.ID == IDBookingHallService).ToList();
                aDatabaseDA.BookingHalls_Services.RemoveRange(aBookingHalls_Services);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHalls_ServicesBO.Delete:" + ex.ToString());
            }
        }

        public void DeleteListServiceUsed(int IDBookingHall)
        {
            try
            {
                List<BookingHalls_Services> aListBookingHalls_Services = this.Select_ByIDBookingHall(IDBookingHall);
                foreach (BookingHalls_Services aTemp in aListBookingHalls_Services)
                {
                    aDatabaseDA.BookingHalls_Services.Remove(aTemp);
                    aDatabaseDA.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHalls_ServicesBO.DeleteListServiceUsed:" + ex.ToString());
            }
        }
    }
}
