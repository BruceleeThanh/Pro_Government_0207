using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class BookingHsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        //Hiennv
        //select all BookingHs
        public List<BookingHs> Select_All()
        {
            try
            {
                return aDatabaseDA.BookingHs.OrderByDescending(c => c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHsBO.Select_All:" + ex.ToString());
            }
        }


        //Author : Linhting
        public BookingHs Select_ByID(int id)
        {
            try
            {
                List<BookingHs> aListBookingHs = aDatabaseDA.BookingHs.Where(a => a.ID == id).ToList();
                if (aListBookingHs.Count > 0)
                {
                    return aDatabaseDA.BookingHs.Where(a => a.ID == id).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("BookingHsBO.Select_ByID:" + ex.ToString());
            }
        }

        //Author : Linhting
        public List<BookingHs> Select_ByDate_byStatus(DateTime From, DateTime To)
        {
            try
            {
                var ListStatus = new int?[] {2,3,4,6};
                return aDatabaseDA.BookingHs.Where(a => a.CreatedDate >= From).Where(b => b.CreatedDate <= To).Where(c => ListStatus.Contains(c.Status)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHsBO.Select_ByDate_byStatus:" + ex.ToString());
            }
        }
        //Author : Linhting
        public void Insert(BookingHs bookingHs)
        {
            try
            {
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                aDatabaseDA.BookingHs.Add(bookingHs);
                aDatabaseDA.SaveChanges();
                aBookingHallsBO.AutoChangeStatusBookingHalls(bookingHs.ID);
              

            }
            catch (Exception ex)
            {
                throw new Exception("BookingHsBO.Insert:" + ex.ToString());
            }
        }

        //Author : Linhting
        public void Update(BookingHs bookingHs)
        {
            try
            {
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                aDatabaseDA.BookingHs.AddOrUpdate(bookingHs);
                aDatabaseDA.SaveChanges();
                aBookingHallsBO.AutoChangeStatusBookingHalls(bookingHs.ID);
               
               
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHsBO.Update:" + ex.ToString());
            }
        }

        //Author : Linhting
        public int Delete(int id)
        {
            try
            {
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                BookingHs aBookingHs = aDatabaseDA.BookingHs.Find(id);
                aDatabaseDA.BookingHs.Remove(aBookingHs);
                List<BookingHalls> aListTemp = aBookingHallsBO.Select_ByIDBookigH(id);
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aDatabaseDA.BookingHalls.Remove(aListTemp[i]);
                }
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingHsBO.Delete:" + ex.ToString());
            }
        }

        //Author : Linhting
        public List<BookingHs> SelectAvailableBookingHs(DateTime From, DateTime To)
        {
            try
            {
                var ListStatus = new int?[] { 1, 2, 3, 4,6,7 };
                return aDatabaseDA.BookingHs.Where(a => a.CreatedDate > From).Where(b => b.CreatedDate < To).Where(c => ListStatus.Contains(c.Status)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHsBO.SelectUnPayBookingHs:" + ex.ToString());
            }
        }

        public List<BookingHs> SelectBookingHs_ByTime_ByStatus(DateTime From, DateTime To, int Status)
        {
            try
            {

                return aDatabaseDA.BookingHs.Where(a => a.CreatedDate >= From).Where(b => b.CreatedDate <= To).Where(c => c.Status == Status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHsBO.SelectUnPayBookingHs:" + ex.ToString());
            }
        }


        public void AutoChangeStatusBookingH(int IDBookingH)
        {
            BookingHsBO aBookingHsBO = new BookingHsBO();      
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookigH(IDBookingH);
            List<int> ListStatusHall = new List<int>();
            int MinHallStatus;

            MinHallStatus = Convert.ToInt32( aListBookingHalls[0].Status);         

            for (int i = 0; i < aListBookingHalls.Count; i++)
            {
                if (MinHallStatus > aListBookingHalls[i].Status)
                {
                    MinHallStatus = Convert.ToInt32(aListBookingHalls[i].Status);              
                }
               
            }
            BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
            aBookingHs.Status = MinHallStatus;
            aBookingHsBO.UpdateUnSync(aBookingHs);           
        }

        //Author : Linhting
        public int InsertUnSync (BookingHs bookingHs)
        {
            try
            {
              //  bookingHs.ID = null;
                
                aDatabaseDA.BookingHs.Add(bookingHs);
              
                aDatabaseDA.SaveChanges();
                return bookingHs.ID;

            }
            catch (Exception ex)
            {
                throw new Exception("BookingHsBO.InsertUnSync:" + ex.ToString());
            }
        }

        //Author : Linhting
        public int UpdateUnSync (BookingHs bookingHs)
        {
            try
            {
                aDatabaseDA.BookingHs.AddOrUpdate(bookingHs);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("BookingHsBO.UpdateUnSync:" + ex.ToString());
            }
        }

    }
}
