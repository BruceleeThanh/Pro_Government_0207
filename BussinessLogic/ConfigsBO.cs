using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;

namespace BussinessLogic
{
    public class ConfigsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<Configs> Select_All()
        {
            try
            
            {
                return aDatabaseDA.Configs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ConfigsBO.Select_All :"+ ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public Configs Select_ByID(int ID)
        {
            try
            {
                List<Configs> aListConfigs = aDatabaseDA.Configs.Where(c => c.ID == ID).ToList();
                if (aListConfigs.Count > 0)
                {
                    return aListConfigs[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ConfigsBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }


        //=======================================================
        //Author: Hiennv
        //Function : SearchListConfigs_ByAccessKey
        //=======================================================
        public List<Configs> SearchListConfigs_ByAccessKey(string  accessKey)
        {
            try
            {
                return aDatabaseDA.Configs.Where(c => c.AccessKey.Contains(accessKey)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ConfigsBO.SearchListConfigs_ByAccessKey :"+ ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(Configs aConfigs)
        {
            try
            {
                aDatabaseDA.Configs.Add(aConfigs);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ConfigsBO.Insert :" + ex.Message));
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
                Configs aConfigs = aDatabaseDA.Configs.Find(ID);
                aDatabaseDA.Configs.Remove(aConfigs);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ConfigsBO.Delete :" + ex.Message));
            }
        }
       
        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(Configs aConfigs)
        {
            try
            {
                aDatabaseDA.Configs.AddOrUpdate(aConfigs);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ConfigsBO.Update :" + ex.Message));
            }
        }
    }
}
