using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;

namespace BussinessLogic
{
    public class BookingRoomsMembersBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //----------------Display Customers----------------------
        public List<BookingRoomsMembers> Select_All()
        {
            try
            {
                return aDatabaseDA.BookingRoomsMembers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsMembersBO.Select_All:" + ex.ToString());
            }
        }

        //select By IDBookingRoom
        public List<BookingRoomsMembers> Select_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                return aDatabaseDA.BookingRoomsMembers.Where(b => b.IDBookingRoom == IDBookingRoom).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsMembersBO.Select_ByIDBookingRoom:" + ex.ToString());
            }
        }
        //Linhting
        public BookingRoomsMembers Select_ByIDBookingRoom_ByIDCustomer(int IDBookingRoom, int IDCustomer)
        {
            try
            {
                List<BookingRoomsMembers> aListBookingRoomsMembers= aDatabaseDA.BookingRoomsMembers.Where(b => b.IDBookingRoom == IDBookingRoom).Where(a => a.IDCustomer == IDCustomer).ToList();
                if (aListBookingRoomsMembers.Count > 0)
                {
                    return aListBookingRoomsMembers[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsMembersBO.Select_ByIDBookingRoom_ByIDCustomer:" + ex.ToString());
            }
        }
        //Linhting
        public List<BookingRoomsMembers> Select_ByListIDBookingRoom(List<int> ListIDBookingRoom)
        {
            try
            {
               return aDatabaseDA.BookingRoomsMembers.Where(a => ListIDBookingRoom.Contains(a.IDBookingRoom)).ToList();              
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsMembersBO.Select_ByListIDBookingRoom:" + ex.ToString());
            }
        }
        //-----------------Add New ---------------------------------

        public int Insert(BookingRoomsMembers bookingRoomsMembers)
        {
            try
            {
                aDatabaseDA.BookingRoomsMembers.Add(bookingRoomsMembers);
                aDatabaseDA.SaveChanges();
                return bookingRoomsMembers.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsMembersBO.Insert:" + ex.ToString());
            }
        }
        //----------------Update  -----------------------------
        public int Update(BookingRoomsMembers bookingRoomsMembers)
        {
            try
            {
                aDatabaseDA.BookingRoomsMembers.AddOrUpdate(bookingRoomsMembers);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsMembersBO.Update:" + ex.ToString());
            }
        }
        //----------------- Delete Customers  ------------------------------
        public int Delete(int id)
        {
            try
            {
                BookingRoomsMembers aBookingRoomsMembers = aDatabaseDA.BookingRoomsMembers.Find(id);
                aDatabaseDA.BookingRoomsMembers.Remove(aBookingRoomsMembers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsMembersBO.Delete:" + ex.ToString());
            }
        }
        //Linhting : Delete by IDBookingRoom + IDCustomer
        public int Delete(int IDBookingRoom, int IDCustomer)
        {
            try
            {
                BookingRoomsMembers aBookingRoomsMembers = this.Select_ByIDBookingRoom_ByIDCustomer(IDBookingRoom,IDCustomer);
                aDatabaseDA.BookingRoomsMembers.Remove(aBookingRoomsMembers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRoomsMembersBO.Delete:" + ex.ToString());
            }
        }
        //Linhting : Delete List BookingMember by IDBookingRoom
        public void DeleteListBookingRoomsMembers(int IDBookingRoom)
        {
            try
            {
                List<BookingRoomsMembers> aListBookingRoomsMembers = this.Select_ByIDBookingRoom(IDBookingRoom);
                foreach (BookingRoomsMembers aTemp in aListBookingRoomsMembers)
                {
                    aDatabaseDA.BookingRoomsMembers.Remove(aTemp);
                    aDatabaseDA.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRoomsMembersBO.Delete:" + ex.ToString());
            }
        }
    }
}
