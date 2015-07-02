using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class ServiceGroupsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        public List<ServiceGroups> Sel_all()
        {
            try
            {
                var aList = aDatabaseDA.ServiceGroups.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServiceGroupsBO.Sel_all:" + ex.Message));
            }
        }

        public ServiceGroups Sel_ByID(int ID)
        {
            try
            {
                List<ServiceGroups> aListServiceGroups= aDatabaseDA.ServiceGroups.Where(c => c.ID == ID).ToList();
                if (aListServiceGroups.Count > 0)
                {
                  return  aDatabaseDA.ServiceGroups.Where(c => c.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServiceGroupsBO.Sel_ByID :" + ex.Message));
            }
        }

        public int Insert(ServiceGroups serviceGroups)
        {
            try
            {
                aDatabaseDA.ServiceGroups.Add(serviceGroups);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServiceGroupsBO.Ins :" + ex.Message));
            }
        }

        public int Delete_ByID(int ID)
        {
            ServiceGroups com = aDatabaseDA.ServiceGroups.Find(ID);
            aDatabaseDA.ServiceGroups.Remove(com);
            return aDatabaseDA.SaveChanges();
        }
        public int Update(ServiceGroups serviceGroups)
        {
            try
            {
                aDatabaseDA.ServiceGroups.AddOrUpdate(serviceGroups);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw new Exception(string.Format("ServiceGroupsBO.Upd :" + ex.Message));
            }
        }
        #region SaleManager      

        public int Ins(ServiceGroups serviceGroups)
        {
            try
            {
                aDatabaseDA.ServiceGroups.Add(serviceGroups);
                int ret = aDatabaseDA.SaveChanges();
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServiceGroupsBO.Ins :" + ex.Message));
            }
        }

        public int Del_ByID(int ID)
        {
            ServiceGroups com = aDatabaseDA.ServiceGroups.Find(ID);
            aDatabaseDA.ServiceGroups.Remove(com);
            int ret = aDatabaseDA.SaveChanges();
            return ret;
        }
        public void Upd(ServiceGroups serviceGroups)
        {
            try
            {
                aDatabaseDA.ServiceGroups.AddOrUpdate(serviceGroups);
                aDatabaseDA.SaveChanges();
                //return ret;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("ServiceGroupsBO.Upd :" + ex.Message));
            }
        }
        #endregion
    }
    public class ServiceGroup_Member
    {
        public int ID; public string Name;
        public ServiceGroup_Member() { }

        public ServiceGroup_Member(string Name,int ID)
        {
            this.ID = ID; 
            this.Name = Name;
        }
    }

}
