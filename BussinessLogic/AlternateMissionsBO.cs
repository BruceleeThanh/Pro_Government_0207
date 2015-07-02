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
    public class AlternateMissionsBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Author : NgocBM
        // Select tat ca AlternateMissions join voi SystemUser
        public List<AlternateMissionsExtEN> SelectDetail_All()
        {
            try
            {

                var ListData =
                     (from Al in aDatabaseDA.AlternateMissions
                      join Sy in aDatabaseDA.SystemUsers on Al.IDSystemUser equals Sy.ID
                    
                      
                     select new AlternateMissionsExtEN 
                     { 
                        Username =  Sy.Username,
                        Name =  Sy.Name, 
                        Country = Al.Country, 
                        CreatedDate = Al.CreatedDate, 
                        DecisionDate = Al.DecisionDate, 
                        DecisionLevel = Al.DecisionLevel, 
                        Description = Al.Description, 
                        Disable =  Al.Disable, 
                        FromDate = Al.FromDate, 
                        IDSystemUser = Al.IDSystemUser,
                        NumberDecision  = Al.NumberDecision,
                        Status = Al.Status,
                        Subject = Al.Subject,
                        ToDate = Al.ToDate,
                        Type = Al.Type,
                        ID = Al.ID
                       
                     }).ToList();
                return ListData;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Sel_All :" + ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        // Select tat ca AlternateMissions
        public List<AlternateMissions> Select_All()
        {
            try
            {

                List<AlternateMissions> aList = aDatabaseDA.AlternateMissions.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select AlternateMissions = ID
        public AlternateMissions Select_ByID(int ID)
        {
            try
            {
                List<AlternateMissions> aListAlternateMissions = aDatabaseDA.AlternateMissions.Where(a => a.ID == ID).ToList();
                if(aListAlternateMissions.Count > 0)
                {
                    return aListAlternateMissions[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }


        //Author : LinhTing
        //Function : Select AlternateMissions = IDSystemUser
        public List<AlternateMissions> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<AlternateMissions> aList = aDatabaseDA.AlternateMissions.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Insert AlternateMissions
        public int Insert(AlternateMissions aAlternateMissions)
        {
            try
            {
                aDatabaseDA.AlternateMissions.Add(aAlternateMissions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update AlternateMissions
        public int Update(AlternateMissions aAlternateMissions)
        {
            try
            {
                aDatabaseDA.AlternateMissions.AddOrUpdate(aAlternateMissions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete AlternateMissions
        public int Delete(int ID)
        {
            try
            {
                AlternateMissions aAlternateMissions = Select_ByID(ID);
                aDatabaseDA.AlternateMissions.Remove(aAlternateMissions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AlternateMissionsBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
