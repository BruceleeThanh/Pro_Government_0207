using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Entity;

namespace BussinessLogic
{
    public class SystemUsers_DivisionsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //Author :Hiennv
        public List<SystemUsers_Divisions> Select_All()
        {
            try
            {
                return aDatabaseDA.SystemUsers_Divisions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_All :"+ ex.Message.ToString()));
            }
        }

        //Author :Hiennv
        public List<SystemUsers_Divisions> Select_ByIDDivision(int IDDivision)
        {
            try
            {
                return aDatabaseDA.SystemUsers_Divisions.Where(s=>s.IDDivision==IDDivision).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_ByIDDivision :"+ ex.Message.ToString()));
            }
        }
        //Author :Hiennv
        public List<vw__SystemUsersInfo__SystemUsers_Divisions> Select_ByIDDivisionAndDate(string  NameDivision, DateTime ChooseDate)
        {
            try
            {
                return aDatabaseDA.vw__SystemUsersInfo__SystemUsers_Divisions.Where(s=>s.Divisions_Name==NameDivision).Where(s=>s.SystemUsers_Divisions_AvaiableDate <=ChooseDate && s.SystemUsers_Divisions_ExpireDate >=ChooseDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_All :"+ ex.Message.ToString()));
            }
        }
        //Author :Hiennv
        public List<vw__SystemUsersInfo__SystemUsers_Divisions> Select_BySystemUsersDivisions_Disable()
        {
            try
            {
                return aDatabaseDA.vw__SystemUsersInfo__SystemUsers_Divisions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_BySystemUsersDivisions_Disable :"+ ex.Message.ToString()));
            }
        }
        //Author : Hiennv
        public SystemUsers_Divisions Select_ByID(int ID)
        {
            try
            {
                List<SystemUsers_Divisions> aListSystemUsers_Divisions = aDatabaseDA.SystemUsers_Divisions.Where(s => s.ID == ID).ToList();
                if(aListSystemUsers_Divisions.Count > 0)
                {
                    return aListSystemUsers_Divisions[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }
        //Author :Hiennv
        public List<SystemUsers_Divisions> Select_ByIDSystemUsersAndDisable(int IDSystemUsers, bool Disable)
        {
            try
            {
                return aDatabaseDA.SystemUsers_Divisions.Where(s => s.IDSystemUser == IDSystemUsers && s.Disable == Disable).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_ByIDSystemUsersAndDisable :"+ ex.Message.ToString()));
            }
        }
        //Author :Hiennv
        public List<SystemUsers_Divisions> Select_ByIDSystemUsersAndIDDivisionAndDisable(int IDSystemUsers,int IDDivision,bool Disable)
        {
            try
            {
                return aDatabaseDA.SystemUsers_Divisions.Where(s => s.IDSystemUser == IDSystemUsers && s.IDDivision==IDDivision && s.Disable == Disable).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Select_ByIDSystemUsersAndIDDivisionAndDisable :"+ ex.Message.ToString()));
            }
        }
        //Author : Hiennv
        public int Update(SystemUsers_Divisions aSystemUsers_Divisions)
        {
            try
            {
                aDatabaseDA.SystemUsers_Divisions.AddOrUpdate(aSystemUsers_Divisions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author :Hiennv
        public int Delete(int ID)
        {
            try
            {
                SystemUsers_Divisions aSystemUsers_Divisions = this.Select_ByID(ID);
                aDatabaseDA.SystemUsers_Divisions.Remove(aSystemUsers_Divisions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_DivisionsBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
