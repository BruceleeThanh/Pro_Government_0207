using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using DataAccess;


namespace BussinessLogic
{
    public class BookingRsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //----------------Display Customers----------------------
        public List<BookingRs> Select_All(int customerType)
        {
            try
            {
                return aDatabaseDA.BookingRs.Where(b => b.CustomerType == customerType).OrderByDescending(b => b.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRsBO.Select_All:" + ex.ToString());
            }
        }
       
        //-----------------Select by id-------------------------------
        public BookingRs Select_ByID(int id)
        {
            try
            {
                List<BookingRs> aListBookingRs = aDatabaseDA.BookingRs.Where(a => a.ID == id).ToList();
                if (aListBookingRs.Count > 0)
                {
                    return aDatabaseDA.BookingRs.Where(a => a.ID == id).ToList()[0];
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRsBO.Select_ByID:" + ex.ToString());
            }
        }
        //-----------------Select by list id-------------------------------
        public List<BookingRs> Select_ByListID(List<int> ListId)
        {
            try
            {
                List<BookingRs> aListBookingRs = aDatabaseDA.BookingRs.Where(a => ListId.Contains(a.ID)).ToList();
                return aListBookingRs;
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRsBO.Select_ByListID:" + ex.ToString());
            }
        }
        //-----------------Select by list idbookingroom-------------------------------
        public List<BookingRs> Select_ByListIDBookingRoom(List<int> ListIDBookingRoom)
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRsBO aBookingRsBO = new BookingRsBO();
                List<BookingRooms> aListItem = new List<BookingRooms>();
                aListItem = aBookingRoomsBO.Select_ByListID(ListIDBookingRoom);
                List<int> aListIDBookingRs = new List<int>();
                int aIDBookingRs;
                for (int i = 0; i < aListItem.Count; i++)
                {
                    aIDBookingRs = new int();
                    aIDBookingRs = aListItem[i].IDBookingR;
                    aListIDBookingRs.Add(aIDBookingRs);
                }
                List<BookingRs> aListBookingRs = aBookingRsBO.Select_ByListID(aListIDBookingRs);
                return aListBookingRs;
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRsBO.Select_ByListIDBookingRoom:" + ex.ToString());
            }
        }
        
        //-----------------Add New ---------------------------------

        public int Insert(BookingRs bookingRs)
        {
            try
            {
                aDatabaseDA.BookingRs.Add(bookingRs);
                aDatabaseDA.SaveChanges();
                return bookingRs.ID;

            }
            catch (Exception ex)
            {
                throw new Exception("BookingRsBO.Insert:" + ex.ToString());
            }
        }

        //----------------Update Customers -----------------------------
        public int Update(BookingRs bookingRs)
        {
            try
            {
                aDatabaseDA.BookingRs.AddOrUpdate(bookingRs);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("BookingRsBO.Update:" + ex.ToString());
                
            }
        }
        //----------------- Delete Customers  ------------------------------
        public int Delete(int id)
        {
            try
            {
                BookingRs aBookingRs = aDatabaseDA.BookingRs.Find(id);
                aDatabaseDA.BookingRs.Remove(aBookingRs);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRsBO.Delete:" + ex.ToString());
            }
        }
        public List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> Select_In_Status()
        {
            try
            {
                return aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(b => b.BookingRs_Status == 1 || b.BookingRs_Status == 2).OrderBy(b => b.Rooms_Sku).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRsBO.Select_In_Status:" + ex.ToString());
            }
        }

        //hiennv
        public List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> Select_ByStatusAndDateAndCustomerType(int status ,DateTime date, int customerType)
        {
            try
            {
                return aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(b => b.BookingRs_Status == status).Where(b => b.BookingRooms_CheckOutPlan > date).Where(b => b.BookingRs_CustomerType == customerType).OrderByDescending(b => b.BookingRs_ID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRsBO.Select_ByStatusAndDateAndCustomerType:\n" + ex.ToString());
            }
        }

        public List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> Select_ByID_ByStatus(int IDBookingR)
        {
            try
            {
                return aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(b => b.BookingRs_Status == 1 || b.BookingRs_Status == 2).Where(b => b.BookingRs_ID == IDBookingR).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRsBO.Select_ByID_ByStatus:" + ex.ToString());
            }
        }

        public List<Rooms> SelectListRooms_ByIDBookingR(int IDBookingR,int IDLang)
        {
            List<string> aListCodeRooms = aDatabaseDA.BookingRooms.Where(p=>p.IDBookingR == IDBookingR).Select(p=>p.CodeRoom).ToList();
            List<Rooms> aRet = aDatabaseDA.Rooms.Where(p => aListCodeRooms.Contains(p.Code)).Where(p => p.IDLang == IDLang).ToList();
            return aRet;

        }

        // Ngoc
        public BookingRs Select_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                int IDBookingR = aDatabaseDA.BookingRooms.Where(p => p.ID == IDBookingRoom).Select(p => p.IDBookingR).ToList()[0];
                return aDatabaseDA.BookingRs.Where(p => p.ID == IDBookingR).ToList()[0];
            }
            catch (Exception e)
            {
                throw new Exception("LỖi");
            }
        }

        public List<BookingRs> Select_ByIDCompany(int IDCompany)
        {
            List<int> aListIDCustomerGroup = (new CustomerGroupsBO()).Select_ByIDCompany(IDCompany).Select(p=>p.ID).ToList();
            List<BookingRs> ListBookingR_CustomerType1 =  this.Select_All(1).Where(p => aListIDCustomerGroup.Contains(p.IDCustomerGroup)).ToList();
            List<BookingRs> ListBookingR_CustomerType2 = this.Select_All(2).Where(p => aListIDCustomerGroup.Contains(p.IDCustomerGroup)).ToList();
            List<BookingRs> ListBookingR_CustomerType3 = this.Select_All(3).Where(p => aListIDCustomerGroup.Contains(p.IDCustomerGroup)).ToList();

             ListBookingR_CustomerType1.InsertRange(0,ListBookingR_CustomerType2);
             ListBookingR_CustomerType1.InsertRange(0, ListBookingR_CustomerType3);
             return ListBookingR_CustomerType1;
        }

    }
}
