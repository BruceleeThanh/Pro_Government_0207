using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using DataAccess;
using BussinessLogic;

namespace BussinessLogic
{
   public class AuditHistoriesBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        public List<AuditHistories> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<AuditHistories> aList = aDatabaseDA.AuditHistories.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AuditHistoriesBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public AuditHistories Select_ByID(int ID)
        {
            try
            {
                List<AuditHistories> aListTemps = aDatabaseDA.AuditHistories.Where(a => a.ID == ID).ToList();
                if (aListTemps.Count > 0)
                {
                    return aDatabaseDA.AuditHistories.Where(a => a.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AuditHistoriesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public int Insert(AuditHistories aAuditHistories)
        {
            try
            {
                aDatabaseDA.AuditHistories.Add(aAuditHistories);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AuditHistoriesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //author:Hiennv
        public int Update(AuditHistories aAuditHistories)
        {
            try
            {
                aDatabaseDA.AuditHistories.AddOrUpdate(aAuditHistories);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AuditHistoriesBO.Update :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public int Delete(int id)
        {
            try
            {
                AuditHistories aAuditHistories = aDatabaseDA.AuditHistories.Find(id);
                aDatabaseDA.AuditHistories.Remove(aAuditHistories);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("AuditHistoriesBO.Delete:" + ex.ToString());
            }
        }
    }
}
