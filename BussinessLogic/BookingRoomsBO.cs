using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Entity;



namespace BussinessLogic
{
    public class BookingRoomsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        Rooms aRooms = new Rooms();

        //Insert/Delete/Update/Select
        //Select_All, Select_ByID, Select_ByName...

        //---------------- Display BookingRoom ----------------------
        public List<BookingRooms> Select_All()
        {
            try
            {
                return aDatabaseDA.BookingRooms.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsBO.Select_All:" + ex.ToString());
            }
        }


        //hiennv
        public BookingRooms Select_ByID(int IDBookingRoom)
        {
            try
            {
                List<BookingRooms> aListBookingRooms = aDatabaseDA.BookingRooms.Where(b => b.ID == IDBookingRoom).ToList();
                if (aListBookingRooms.Count > 0)
                {
                    return aDatabaseDA.BookingRooms.Where(b => b.ID == IDBookingRoom).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsBO.Select_ByIDBookingRoom:" + ex.ToString());
            }
        }

        public bool ChangeStatus(int IDBookingRoom, int ChangeStatusTo)
        {

            BookingRooms aItem = new BookingRooms();
            aItem = this.Select_ByID(IDBookingRoom);

            aItem.Status = ChangeStatusTo;
            int i = this.Update(aItem);
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public List<BookingRooms> Select_ByIDBookingRs(int IDBookingRs)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(b => b.IDBookingR == IDBookingRs).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsBO.Select_ByIDBookingRs:" + ex.ToString());
            }
        }


        ////Hiennv

        public List<BookingRooms> Select_ByIDBookingRsAndCodeRoom(int IDBookingRs, string codeRoom)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(b => b.IDBookingR == IDBookingRs && b.CodeRoom == codeRoom).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsBO.Select_ByIDBookingRsAndCodeRoom:" + ex.ToString());
            }
        }
        //Hiennv   26/11/2014 
        public BookingRooms Select_ByIDBookingRsAndIDBookingRoom(int IDBookingRs, int IDBookingRoom)
        {
            try
            {
                List<BookingRooms> aListTemp = aDatabaseDA.BookingRooms.Where(b => b.IDBookingR == IDBookingRs && b.ID == IDBookingRoom).ToList();
                if(aListTemp.Count > 0)
                {
                    return aListTemp[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByIDBookingRsAndIDBookingRoom:" + ex.ToString());
            }
        }




        //Author: Hiennv    
        public List<BookingRooms> Select_ByIDBookingR_ByStatus_ByTime(int IDBookingR, DateTime Now, int Status)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(a => a.IDBookingR == IDBookingR).Where(a => a.Status == Status).Where(b => b.CheckInActual <= Now && b.CheckOutPlan > Now).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByIDBookingR_ByStatus_ByTime:" + ex.ToString());
            }
        }

        //Author: Tqtrung
        public List<BookingRoomsEN> GetListRoomsCheckOutPlanInDayAndH(DateTime Checktime, int Status)
        {
            try
            {

                DateTime Checktime2 = Checktime.AddDays(1);



                RoomsBO aRoomsBO = new RoomsBO();
                List<BookingRooms> aListTemp = aDatabaseDA.BookingRooms.Where(b => b.Status == Status).Where(b => b.CheckOutPlan > Checktime && b.CheckOutPlan < Checktime2).ToList();
                List<BookingRooms> alistTemp2 = aDatabaseDA.BookingRooms.Where(c => c.Status == Status).Where(b => b.CheckOutPlan < Checktime).ToList();
                List<BookingRoomsEN> aListBookingRoomEN = new List<BookingRoomsEN>();
                BookingRoomsEN aBookingRoomEN, aBookingRoomEN2;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aBookingRoomEN = new BookingRoomsEN();
                    aBookingRoomEN.SetValue(aListTemp[i]);
                    if (aRoomsBO.Select_ByCodeRoom(aListTemp[i].CodeRoom, 1) != null)
                    {
                        aBookingRoomEN.RoomSku = aRoomsBO.Select_ByCodeRoom(aListTemp[i].CodeRoom, 1).Sku;
                    }
                    aListBookingRoomEN.Add(aBookingRoomEN);
                }

                for (int y = 0; y < alistTemp2.Count; y++)
                {
                    aBookingRoomEN2 = new BookingRoomsEN();
                    aBookingRoomEN2.SetValue(alistTemp2[y]);
                    if (aRoomsBO.Select_ByCodeRoom(alistTemp2[y].CodeRoom, 1) != null)
                    {
                        aBookingRoomEN2.RoomSku = aRoomsBO.Select_ByCodeRoom(alistTemp2[y].CodeRoom, 1).Sku;
                    }
                    aListBookingRoomEN.Add(aBookingRoomEN2);
                }
            
                return aListBookingRoomEN;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.GetListRoomsCheckOutPlanInDayAndH:" + ex.ToString());
            }
        }


        //Author: LinhTing
        //Function : Lấy danh sách bookingroom có trạng thái Status và phạm vi thời gian bao quanh Now     
        public List<BookingRooms> Select_ByStatus_ByTime(DateTime Now, int Status)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(a => a.Status == Status).Where(b => b.CheckInActual <= Now && b.CheckOutPlan > Now).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByStatus_ByTime:" + ex.ToString());
            }
        }
        //hiennv
        public List<BookingRooms> Select_ByDateAndCodeRoomAndStaus(DateTime Now, string codeRoom, int Status)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(a => a.Status == Status).Where(b => b.CheckInActual <= Now && b.CheckOutPlan > Now).Where(b => b.CodeRoom.Contains(codeRoom)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByDateAndCodeRoomAndStaus:" + ex.ToString());
            }
        }

        //Author: LinhTing
        //Function : Select Ds khách qua đêm mới

        public List<BookingRooms> Select_ByStatus_ByTime(DateTime To, DateTime From, int Status)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(a => a.Status == Status).Where(b => b.CheckInActual <= To && b.CheckInActual > From && b.CheckOutPlan > To).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.SelectNewBookingRoom_ByStatus_ByTime:" + ex.ToString());
            }
        }
        public List<BookingRooms> Select_ByStatus(int Status)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(a => a.Status == Status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByStatus:" + ex.ToString());
            }
        }
        

        //-----------------Add New ---------------------------------

        public int Insert(BookingRooms bookingRooms)
        {
            try
            {


                aDatabaseDA.BookingRooms.Add(bookingRooms);
                aDatabaseDA.SaveChanges();
                return bookingRooms.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Insert:" + ex.ToString());
            }
        }


        //----------------Update BookingRooms -----------------------------
        public int Update(BookingRooms bookingRooms)
        {
            try
            {
                aDatabaseDA.BookingRooms.AddOrUpdate(bookingRooms);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Update:" + ex.ToString());
            }
        }


        //----------------- Delete BookingRooms  ------------------------------
        public int Delete(int id)
        {
            try
            {
                BookingRooms aBookingRooms = aDatabaseDA.BookingRooms.Find(id);
                aDatabaseDA.BookingRooms.Remove(aBookingRooms);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRooms.Delete:" + ex.ToString());
            }
        }
        //Hiennv  26/11/2014   xoa bookingRoom theo 1 list cac bookingRoom
        public int Remove(List<BookingRooms> aListBookingRoom)
        {
            try
            {
                for (int i = 0; i < aListBookingRoom.Count;i++)
                {
                    this.Delete(aListBookingRoom[i].ID);
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRooms.Remove:" + ex.ToString());
                return 0;
            }
        }


        //Hiennv
        public List<BookingRooms> Select_ByIDBookingR_ByStatus(int IDBookingR,int Status)
        {
            try
            {
                return aDatabaseDA.BookingRooms.Where(b => b.IDBookingR == IDBookingR && b.Status != Status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByIDBookingR_ByStatus:" + ex.ToString());
            }
        }
        //Linh -- Select by list ID
        public List<BookingRooms> Select_ByListID(List<int> ListIDBookingRoom)
        {
            try
            {
               return  aDatabaseDA.BookingRooms.Where(b => ListIDBookingRoom.Contains(b.ID)).ToList();             
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsBO.Select_ByListIDBookingRoom:" + ex.ToString());
            }
        }
        // Ngocbm 
        public List<vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups> SelectListInfoCustomer_ByIDBookingR(int IDBookingR)
        {
            
            DatabaseDA aDatabaseDA = new DatabaseDA();
            return aDatabaseDA.vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups.Where(p => p.BookingRooms_IDBookingR == IDBookingR).ToList();
            
        }


    }
}
