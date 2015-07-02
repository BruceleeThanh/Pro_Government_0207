using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;
namespace BussinessLogic
{
    public class ServicesBO
    {
        #region RoomManager
        DatabaseDA aDatabaseDA = new DatabaseDA();
        public List<Services> Select_All()
        {
            try
            {
                var aList = aDatabaseDA.Services.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServicesBO.Select_All:" + ex.Message));
            }
        }

        //Hiennv
        public Services Select_ByID(int ID)
        {
            try
            {
                List<Services> aListServices = aDatabaseDA.Services.Where(c => c.ID == ID).ToList();
                if (aListServices.Count > 0)
                {
                    return aDatabaseDA.Services.Where(c => c.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServicesBO.Select_ByID :" + ex.Message));
            }
        }

        public List<Services> Select_ByName(string Name)
        {
            try
            {
                var aList = aDatabaseDA.Services.Where(c => c.Name.Contains(Name)).ToList();
                return aList;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("ServicesBO.Select_ByName :" + ex.Message));
            }
        }

        public int Insert(Services aServices)
        {
            try
            {
                aDatabaseDA.Services.Add(aServices);
                aDatabaseDA.SaveChanges();
                return aServices.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServicesBO.Insert :" + ex.Message));
            }
        }

        public int Delete(int ID)
        {
            Services com = aDatabaseDA.Services.Find(ID);
            aDatabaseDA.Services.Remove(com);
            int ret = aDatabaseDA.SaveChanges();
            return ret;
        }
        public int Update(Services aServices)
        {
            aDatabaseDA.Services.AddOrUpdate(aServices);
            int ret = aDatabaseDA.SaveChanges();
            return ret;
        }

        //NgocBM
        public List<Services> Select_ServiceForRooms()
        {
            return aDatabaseDA.Services.Where(p => p.Type == 2).Where(p => p.Disable == false).ToList();
        }
        //NgocBM
        public List<Services> Select_ServiceForHalls()
        {
            return aDatabaseDA.Services.Where(p => p.Type == 1).Where(p => p.Disable == false).ToList();
        }


        public List<Services> SelectListService_ByListIDService(List<int> aListIDService)
        {
            try
            {
                List<Services> aListServices = new List<Services>();
                for (int i = 0; i < aListIDService.Count; i++)
                {
                    aListServices.Add(this.Select_ByID(aListIDService[i]));
                }
                return aListServices;
            }
            catch (Exception ex)
            {
                throw new Exception("ServicesBO.SelectListService_ByListIDService\n" + ex.ToString());
            }
        }

        public List<Services> SelectListServiceBy_IDBookingRoom(int IDBookingRoom)
        {
            try
            {
                BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                List<int> aListIDService = aBookingRooms_ServicesBO.Select_ByIDBookingRooms(IDBookingRoom).Select(b => b.IDService).ToList();
                return this.SelectListService_ByListIDService(aListIDService);
            }
            catch (Exception ex)
            {

                throw new Exception("ServicesBO.SelectListServiceBy_IDBookingRoom\n" + ex.ToString());
            }
        }
        #endregion
        #region SaleManager
     
        //Author : Linhting
        public List<Services> Select_ByType(int Type)// 1- hội trường, 2- phòng
        {
            try
            {
                return aDatabaseDA.Services.Where(a => a.Type == Type).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("ServicesBO.Select_ByType :" + ex.Message));
            }
        }     
        #endregion

    }
}
