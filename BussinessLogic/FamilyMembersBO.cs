using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;
using BussinessLogic;


namespace BussinessLogic
{
    public class FamilyMembersBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        public List<FamilyMembers> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<FamilyMembers> aList = aDatabaseDA.FamilyMembers.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FamilyMembersBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public FamilyMembers Select_ByID(int ID)
        {
            try
            {
                List<FamilyMembers> aListTemp = aDatabaseDA.FamilyMembers.Where(a => a.ID == ID).ToList();
                if (aListTemp.Count > 0)
                {
                    return aDatabaseDA.FamilyMembers.Where(a => a.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FamilyMembersBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public int Insert(FamilyMembers aFamilyMembers)
        {
            try
            {
                aDatabaseDA.FamilyMembers.Add(aFamilyMembers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FamilyMembersBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //author:Hiennv
        public int Update(FamilyMembers aFamilyMembers)
        {
            try
            {
                aDatabaseDA.FamilyMembers.AddOrUpdate(aFamilyMembers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FamilyMembersBO.Update :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public int Delete(int id)
        {
            try
            {
                FamilyMembers aFamilyMembers = aDatabaseDA.FamilyMembers.Find(id);
                aDatabaseDA.FamilyMembers.Remove(aFamilyMembers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("FamilyMembersBO.Delete:" + ex.ToString());
            }
        }
    }
}
