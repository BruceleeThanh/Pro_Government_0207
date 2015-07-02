using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;
using Entity;

namespace BussinessLogic
{
    public  class BookingRooms_ServicesBO
    {
        private  DatabaseDA aDatabaseDA=new DatabaseDA();

        //Hiennv
        public List<BookingRooms_Services> Select_All()
        {
            try
            {
                return aDatabaseDA.BookingRooms_Services.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRooms_ServicesBO.Select_All:" + ex.ToString());
            }
        }
        //select By IDBookingRoom
        public List<BookingRooms_Services> Select_ByIDBookingRooms(int IDBookingRoom)
        {
            try
            {
                return aDatabaseDA.BookingRooms_Services.Where(b => b.IDBookingRoom == IDBookingRoom).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRooms_ServicesBO.Select_ByIDBookingRoom:" + ex.ToString());
            }
        }
        //Select by IDBookingRoom và IDService
        public BookingRooms_Services Select_ByIDBookingRoom_ByIDService(int IDBookingRoom,int IDService)
        {
            try
            {
                if (aDatabaseDA.BookingRooms_Services.Where(b => b.IDBookingRoom == IDBookingRoom).Where(a => a.IDService == IDService).ToList().Count > 0)
                {
                    return aDatabaseDA.BookingRooms_Services.Where(b => b.IDBookingRoom == IDBookingRoom).Where(a => a.IDService == IDService).ToList()[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRooms_ServicesBO.Select_ByIDBookingRoom:" + ex.ToString());
            }
        }
        //select By ID
        public BookingRooms_Services Select_ByID(int ID)
        {
            try
            {
                List<BookingRooms_Services> aListBookingRooms_Services = aDatabaseDA.BookingRooms_Services.Where(b => b.ID == ID).ToList();
                if (aListBookingRooms_Services.Count > 0)
                {
                    return aDatabaseDA.BookingRooms_Services.Where(b => b.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("BookingRooms_ServicesBO.Select_ByID:" + ex.ToString());
            }
        }
        //Hiennv
        public int Insert(BookingRooms_Services abookingRooms_Services)
        {
            try
            {
                aDatabaseDA.BookingRooms_Services.Add(abookingRooms_Services);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("BookingRooms_ServicesBO.Insert:" + ex.ToString());
            }
        }

        public int Update(BookingRooms_Services bookingRooms_Services)
        {
            try
            {
                aDatabaseDA.BookingRooms_Services.AddOrUpdate(bookingRooms_Services);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("BookingRooms_ServicesBO.Update:" + ex.ToString());
            }
        }

        //Hiennv
        public int Delete(int id)
        {
            try
            {
                BookingRooms_Services aBookingRooms_Services = aDatabaseDA.BookingRooms_Services.Find(id);
                aDatabaseDA.BookingRooms_Services.Remove(aBookingRooms_Services);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRooms.Delete:" + ex.ToString());
            }
        }

       

        public void DeleteListServiceUsed(int IDBookingRoom)
        {
            try
            {
                List < BookingRooms_Services > aListBookingRooms_Services =  this.Select_ByIDBookingRooms(IDBookingRoom);
                foreach (BookingRooms_Services aTemp in aListBookingRooms_Services)
                {
                    aDatabaseDA.BookingRooms_Services.Remove(aTemp);
                    aDatabaseDA.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRooms_ServicesBO.DeleteListServiceUsed:" + ex.ToString());
            }
        }
        public List<RoomServiceInfoEN> Select_Service_ByCodeRoom_ByStatus(string Code, DateTime now,int Status)
        {
            try
            {
                string Sku = string.Empty;
                RoomsBO aRoomsBO = new RoomsBO();
                Rooms aRooms = aRoomsBO.Select_ByCodeRoom(Code,1);
                if(aRooms !=null)
                {
                    Sku = aRooms.Sku;
                }

                int IDBookingRoom=0;
                BookingRsBO aBookingRsBO = new BookingRsBO();
                List<BookingRooms> aListBookingRooms =aDatabaseDA.BookingRooms.Where(p => p.CodeRoom == Code && p.CheckInActual < now && p.CheckOutActual > now && (p.Status == 3 || p.Status == 7)).ToList();
                if(aListBookingRooms.Count > 0)
                {
                    IDBookingRoom = aListBookingRooms[0].ID;
                }
                List<RoomServiceInfoEN> alist = aDatabaseDA.vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups
                                .Where(p => p.BookingRooms_Services_IDBookingRoom == IDBookingRoom && p.BookingRooms_Services_Status !=Status)
                                .Select(p => new RoomServiceInfoEN
                                {
                                    IDBookingRooms = IDBookingRoom,
                                    IDBookingRs = p.BookingRooms_IDBookingR,
                                    CodeRoom = Code,
                                    Sku = Sku,
                                    ID = p.BookingRooms_Services_ID,
                                    Date = p.BookingRooms_Services_Date,
                                    IDService=p.Services_ID,
                                    ServiceName = p.Services_Name,
                                    IDServiceGroup=p.ServiceGroups_ID,
                                    Quantity = p.BookingRooms_Services_Quantity,
                                    CostRef = p.Services_CostRef,
                                    Unit = p.Services_Unit,
                                    Cost = p.BookingRooms_Services_Cost,
                                    PercentTax = p.BookingRooms_Services_PercentTax,
                                    Status=p.BookingRooms_Services_Status

                                }).ToList();


                return alist;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingRooms_ServicesBO.Sel_Service_BySku\n" + ex.ToString());
            }
        }

        public RoomServiceInfoEN Select_All_ByName(string Name)
        {
            try
            {
                List<RoomServiceInfoEN> alist = Select_All_ByTypeServiceGroup(0).Where(p => p.Name == Name)
                    .Select(p => new RoomServiceInfoEN
                    {
                        IDService = p.ID,
                        ServiceName = p.Name,
                        CostRef = p.CostRef,
                        Unit = p.Unit,
                        IDServiceGroup = p.IDServiceGroups
                    }).ToList();
                return alist[0];
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("BookingRooms_ServicesBO.Select_All_ByName :" + ex.Message));
            }
        }
        public List<Services> Select_All_ByTypeServiceGroup(int type)
        {
            try
            {
                List<Services> alist = aDatabaseDA.Services.Join(aDatabaseDA.ServiceGroups, s => s.IDServiceGroups, sg => sg.ID, (s, sg) => new { s, sg })
                                        .Where(ssg => ssg.sg.Type == type)
                                        .Select(ssg => ssg.s).ToList();
                return alist;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("BookingRooms_ServicesBO.Select_All_ByTypeServiceGroup :" + ex.Message));
            }
        }

        public List<Services> Select_All_ByTypeServiceGroup_ByName(string ServiceName)
        {
            try
            {
                List<Services> alist = Select_All_ByTypeServiceGroup(0).Where(p => p.Name == ServiceName).ToList();
                return alist;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BookingRooms_ServicesBO.Select_All_ByTypeServiceGroup_ByName :" + ex.Message));
            }
        }
    }
}
