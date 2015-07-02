using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Entity;

namespace BussinessLogic
{
    public class RoomsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //=======================================================
        //Author: LinhTing
        //Function : Chon tat ca Room
        //=======================================================
        public List<Rooms> Select_All()
        {
            try
            {
                List<Rooms> aList = aDatabaseDA.Rooms.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Sel_All_byID :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Chon Room bang ID
        //=======================================================
        public Rooms Select_ByID(int ID)
        {
            try
            {
                List<Rooms> aListRooms = aDatabaseDA.Rooms.Where(c => c.ID == ID).ToList();
                if (aListRooms.Count > 0)
                {
                   return  aListRooms[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Sel_ByID :" + ex.Message.ToString()));
            }
        }
        public Rooms Select_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aTemp = aBookingRoomsBO.Select_ByID(IDBookingRoom);
                Rooms aRooms = this.Select_ByCodeRoom(aTemp.CodeRoom, 1);
                return aRooms;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Select_ByIDBookingRoom :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Chon Room bang IDLanguage
        //=======================================================
        public List<Rooms> Select_ByIDLang(int IDLang)
        {
            try
            {
                List<Rooms> aList = aDatabaseDA.Rooms.Where(c => c.IDLang == IDLang).OrderBy(r=>r.Sku).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Sel_ByIDLang :" + ex.Message));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Chon Room bang IDLanguage
        //=======================================================
        public Rooms Select_ByCodeRoom(string CodeRoom, int IDLang)
        {
            try
            {
                /*
                 * Hiennv bo xung them
                 */
                List<Rooms> aListRooms = aDatabaseDA.Rooms.Where(c => c.Code == CodeRoom).Where(p => p.IDLang == IDLang).ToList();
                if (aListRooms.Count > 0)
                {
                    return aDatabaseDA.Rooms.Where(c => c.Code == CodeRoom).Where(p => p.IDLang == IDLang).ToList()[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Select_ByCodeRoom :" + ex.Message));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Chon Room bang List CodeRoom
        //=======================================================
        public List<Rooms> Select_ByListCodeRoom(List<string> ListCodeRoom, int IDLang)
        {
            try
            {
                List<Rooms> aListRooms = aDatabaseDA.Rooms.Where(c => ListCodeRoom.Contains(c.Code)).Where(p => p.IDLang == IDLang).ToList();
                return aListRooms;
              
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Select_ByListCodeRoom :" + ex.Message));
            }
        }
        public RoomExtStatusEN GetStatusRoom(string CodeRoom, DateTime now)
        {
            RoomExtStatusEN aRoomExtStatusEN = new RoomExtStatusEN();
            Rooms aRooms = this.Select_ByCodeRoom(CodeRoom,1);
            if (aRooms != null)
            {
                aRoomExtStatusEN = this.GetStatusRoom(aRooms.ID, now);
                return aRoomExtStatusEN;
            }
            else
            {
                return null;
            }

        }
        public RoomExtStatusEN GetStatusRoom(int IDRoom, DateTime now)
        {
            List<sp_RoomExt_GetCurrentStatusRooms_ByIDRoom_ByTime_Result> aList = this.aDatabaseDA.sp_RoomExt_GetCurrentStatusRooms_ByIDRoom_ByTime(IDRoom, now).ToList();

            RoomExtStatusEN aRoomExtStatusEN = new RoomExtStatusEN();

            if (aList.Count > 0)
            {
                for (int i = 0; i < aList.Count; i++)
                {
                    aRoomExtStatusEN = new RoomExtStatusEN();
                    aRoomExtStatusEN.ID = aList[i].ID;
                    aRoomExtStatusEN.Bed1 = aList[i].Bed1;
                    aRoomExtStatusEN.Bed2 = aList[i].Bed2;
                    aRoomExtStatusEN.CostRef = aList[i].CostRef;
                    aRoomExtStatusEN.Code = aList[i].Code;
                    aRoomExtStatusEN.Sku = aList[i].Sku;
                    aRoomExtStatusEN.Note = aList[i].Note;
                    aRoomExtStatusEN.Type = aList[i].Type;
                    aRoomExtStatusEN.BookingRooms_ID = aList[i].BookingRooms_ID;

                    aRoomExtStatusEN.BookingRs_BookingMoney = aList[i].BookingRs_BookingMoney;
                    aRoomExtStatusEN.BookingRs_CustomerType = aList[i].BookingRs_CustomerType;
                    aRoomExtStatusEN.BookingRs_ID = aList[i].BookingRs_ID;
                    aRoomExtStatusEN.BookingRs_Subject = aList[i].BookingRs_Subject;
                    aRoomExtStatusEN.CheckInActual = aList[i].CheckInActual;
                    aRoomExtStatusEN.CheckInPlan = aList[i].CheckInPlan;
                    aRoomExtStatusEN.CheckOutActual = aList[i].CheckOutActual;
                    aRoomExtStatusEN.CheckOutPlan = aList[i].CheckOutPlan;
                    aRoomExtStatusEN.Color = aList[i].Color;
                    aRoomExtStatusEN.Companies_Name = aList[i].Companies_Name;
                    aRoomExtStatusEN.CostRef = aList[i].CostRef;
                    aRoomExtStatusEN.CustomerGroups_Name = aList[i].CustomerGroups_Name;
                    aRoomExtStatusEN.Customers_Address = aList[i].Customers_Address;
                    aRoomExtStatusEN.Customers_Name = aList[i].Customers_Name;
                    aRoomExtStatusEN.Customers_Nationality = aList[i].Customers_Nationality;
                    aRoomExtStatusEN.Customers_Tel = aList[i].Customers_Tel;
                    aRoomExtStatusEN.Companies_ID = aList[i].Companies_ID;
                    aRoomExtStatusEN.CustomerGroups_ID = aList[i].CustomerGroups_ID;
                    aRoomExtStatusEN.Customers_ID = aList[i].Customers_ID;
                    
                    if (aList[i].BookingRooms_Status == 1)
                    {
                        aRoomExtStatusEN.RoomStatus = 1;
                    }
                    else if (aList[i].BookingRooms_Status == 2)
                    {
                        aRoomExtStatusEN.RoomStatus = 2;
                    }
                    else if (aList[i].BookingRooms_Status == 3)
                    {
                        aRoomExtStatusEN.RoomStatus = 3;
                    }
                    else if (aList[i].BookingRooms_Status == 5)
                    {
                        aRoomExtStatusEN.RoomStatus = 5;
                    }
                    else if ((aList[i].BookingRooms_Status == 6) || (aList[i].BookingRooms_Status == 7) || (aList[i].BookingRooms_Status == 8))
                    {
                        aRoomExtStatusEN.RoomStatus = 0;
                    }

                }
                return aRoomExtStatusEN;
            }
            else
            {
                RoomsBO aRoomsBO = new RoomsBO();
                Rooms aRooms = aRoomsBO.Select_ByID(IDRoom);
                if (aRooms != null)
                {
                    aRoomExtStatusEN = new RoomExtStatusEN();
                    aRoomExtStatusEN.RoomStatus = 0;
                    aRoomExtStatusEN.Code = aRooms.Code;
                    aRoomExtStatusEN.Sku = aRooms.Sku;
                    aRoomExtStatusEN.Bed1 = aRooms.Bed1;
                    aRoomExtStatusEN.Bed2 = aRooms.Bed2;
                    aRoomExtStatusEN.Type = aRooms.Type;
                }
                else
                {
                    throw new Exception("Phòng cần check trạng thái không tồn tại");

                }
                return aRoomExtStatusEN;

            }
        }

        public List<RoomExtStatusEN> GetListStatusRoom(DateTime now)
        {
            RoomsBO aRoomsBO = new RoomsBO();
            List<Rooms> aList = aRoomsBO.Select_All().Where(p => p.IDLang == 1 && p.Disable == false).ToList();
            List<RoomExtStatusEN> ret = new List<RoomExtStatusEN>();
            for (int i = 0; i < aList.Count; i++)
            {
                try
                {
                    ret.Add(this.GetStatusRoom(aList[i].ID, now));
                }
                catch (Exception e)
                {
                    throw new Exception("Có lỗi khi lấy trạng thái phòng " + aList[i].ID.ToString() + "-" + aList[i].Sku + "|" + e.Message.ToString());
                }
            }
            return ret;
        }

        public List<RoomExtStatusEN> GetListUsingRooms(DateTime Now)
        {
            try
            {
                List<RoomExtStatusEN> aListTemp = new List<RoomExtStatusEN>();
                RoomsBO aRoomsBO = new RoomsBO();
                Rooms aRooms = new Rooms();
                aListTemp = aRoomsBO.GetListStatusRoom(Now).Where(p => p.RoomStatus == 3).ToList();
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception("UsingServiceTask.GetListUsingRooms\n" + ex.ToString());
            }
        }


        //hiennv
        public List<RoomExtStatusEN> GetListUsingRooms_ByCode(DateTime Now ,string code)
        {
            try
            {
                List<RoomExtStatusEN> aListTemp = new List<RoomExtStatusEN>();
                RoomsBO aRoomsBO = new RoomsBO();
                Rooms aRooms = new Rooms();
                if (String.IsNullOrEmpty(code) == true)
                {
                    aListTemp = aRoomsBO.GetListStatusRoom(Now).Where(p => p.RoomStatus == 3).ToList();
                }
                else
                {
                    aListTemp = aRoomsBO.GetListStatusRoom(Now).Where(p => p.RoomStatus == 3).Where(p => p.Code == code).ToList();
                }
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception("UsingServiceTask.GetListUsingRooms_ByCode\n" + ex.ToString());
            }
        }


        //=======================================================
        //Author: LinhTing
        //Function : Them Room
        //=======================================================
        public int Insert(Rooms Rooms)
        {
            try
            {
                aDatabaseDA.Rooms.Add(Rooms);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Insert :" + ex.Message));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Xoa Room bang ID
        //=======================================================
        public int Delete_ByID(int ID)
        {
            try
            {
                Rooms com = aDatabaseDA.Rooms.Find(ID);
                aDatabaseDA.Rooms.Remove(com);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Delete_ByID :" + ex.Message));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Xoa Room bang Code
        //=======================================================
        public int Delete_ByCode(string Code)
        {
            try
            {
                List<Rooms> aRoom = aDatabaseDA.Rooms.Where(row => row.Code == Code).ToList();
                for (int i = 0; i < aRoom.Count; i++)
                {
                    aDatabaseDA.Rooms.Remove(aRoom[i]);
                }
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Delete_ByCode :" + ex.Message));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Update Room
        //=======================================================
        public int Update(Rooms Rooms)
        {
            try
            {
                aDatabaseDA.Rooms.AddOrUpdate(Rooms);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RoomBO.Update :" + ex.Message));
            }
        }
    }
}
