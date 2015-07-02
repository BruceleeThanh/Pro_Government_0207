using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
   public class RewardAndPunishmentsBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Author : LinhTing
        // Select tat ca RewardAndPunishments
        public List<RewardAndPunishments> Select_All()
        {
            try
            {
                List<RewardAndPunishments> aList = aDatabaseDA.RewardAndPunishments.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select RewardAndPunishments = ID
        public RewardAndPunishments Select_ByID(int ID)
        {
            try
            {
                List<RewardAndPunishments> aListRewardAndPunishments = aDatabaseDA.RewardAndPunishments.Where(a => a.ID == ID).ToList();
                if (aListRewardAndPunishments.Count > 0)
                {
                    return aDatabaseDA.RewardAndPunishments.Where(a => a.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select RewardAndPunishments = IDSystemUser
        public List<RewardAndPunishments> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<RewardAndPunishments> aList = aDatabaseDA.RewardAndPunishments.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select RewardAndPunishments = IDSystemUser, Type
        public List<RewardAndPunishments> Select_ByIDSystemUser_ByType(int IDSystemUser, int Type)
        {
            try
            {
                List<RewardAndPunishments> aList = aDatabaseDA.RewardAndPunishments.Where(a => a.IDSystemUser == IDSystemUser).Where(a=>a.Type == Type).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Select_ByIDSystemUser_ByType :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Insert RewardAndPunishments
        public int Insert(RewardAndPunishments aRewardAndPunishments)
        {
            try
            {
                aDatabaseDA.RewardAndPunishments.Add(aRewardAndPunishments);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update RewardAndPunishments
        public int Update(RewardAndPunishments aRewardAndPunishments)
        {
            try
            {
                aDatabaseDA.RewardAndPunishments.AddOrUpdate(aRewardAndPunishments);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete RewardAndPunishments
        public int Delete(int ID)
        {
            try
            {
                RewardAndPunishments aRewardAndPunishments = Select_ByID(ID);
                aDatabaseDA.RewardAndPunishments.Remove(aRewardAndPunishments);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("RewardAndPunishmentsBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
