using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;
namespace BussinessLogic
{
    public class SystemUserExtsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<SystemUserExts> Select_All()
        {
            try
            {
                return aDatabaseDA.SystemUserExts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserExtsBO.Select_All :"+ ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public SystemUserExts Select_ByID(int ID)
        {
            try
            {
                List<SystemUserExts> aListTemp = aDatabaseDA.SystemUserExts.Where(s => s.ID == ID).ToList();
                if (aListTemp.Count > 0)
                {
                    return aDatabaseDA.SystemUserExts.Where(s => s.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserExtsBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }

        //Author: Linhting
        //Function : Select_ByIDSystemUser
        public SystemUserExts Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<SystemUserExts> temp = aDatabaseDA.SystemUserExts.Where(s => s.IDSystemUser == IDSystemUser).ToList();
                if (temp.Count > 0)
                {
                    return aDatabaseDA.SystemUserExts.Where(s => s.IDSystemUser == IDSystemUser).ToList()[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserExtsBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }
        

        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(SystemUserExts aSystemUserExts)
        {
            try
            {
                aDatabaseDA.SystemUserExts.Add(aSystemUserExts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserExtsBO.Insert :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Delete_ByID
        //=======================================================
        public int Delete(int ID)
        {
            try
            {
                SystemUserExts aSystemUserExts = aDatabaseDA.SystemUserExts.Find(ID);
                aDatabaseDA.SystemUserExts.Remove(aSystemUserExts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserExtsBO.Delete :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(SystemUserExts aSystemUserExts)
        {
            try
            {
                aDatabaseDA.SystemUserExts.AddOrUpdate(aSystemUserExts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserExtsBO.Update :" + ex.Message));
            }
        }
    }
}
