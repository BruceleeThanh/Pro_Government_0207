using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BussinessLogic
{
    public class BookingRs_BookingHsBO
    {

        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //=======================================================
        //Author: Hiennv
        //Function : Search
        //=======================================================
        public BookingRs_BookingHs Select_ByIDBookingR(int IDBookingR)
        {
            try
            {
                List<BookingRs_BookingHs> aListBookingRs_BookingHs =aDatabaseDA.BookingRs_BookingHs.Where(r => r.IDBookingR == IDBookingR).ToList();
                if(aListBookingRs_BookingHs.Count > 0)
                {
                    return aListBookingRs_BookingHs[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BookingRs_BookingHsBO.Select_ByIDBookingR :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(BookingRs_BookingHs aBookingRs_BookingHs)
        {
            try
            {
                aDatabaseDA.BookingRs_BookingHs.Add(aBookingRs_BookingHs);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BookingRs_BookingHsBO.Insert :" + ex.Message));
            }
        }

        // Ngoc
        public BookingRs_BookingHs Select_ByIDBookingH(int IDBookingH)
        {
            try
            {
                List<BookingRs_BookingHs> aListBookingRs_BookingHs = aDatabaseDA.BookingRs_BookingHs.Where(r => r.IDBookingH == IDBookingH).ToList();
                if (aListBookingRs_BookingHs.Count > 0)
                {
                    return aListBookingRs_BookingHs[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BookingRs_BookingHsBO.Select_ByIDBookingR :" + ex.Message));
            }
        }
    }
}
