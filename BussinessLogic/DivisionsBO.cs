using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;

namespace BussinessLogic
{
    public class DivisionsBO
    {
        
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Author : LinhTing
        // Select tat ca Divisions
        public List<Divisions> Select_All()
        {
            try
            {
                List<Divisions> aList = aDatabaseDA.Divisions.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DivisionsBO.Select_All x:"+ ex.Message.ToString().ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select Divisions = ID
        public Divisions Select_ByID(int ID)
        {
            try
            {
                List<Divisions> aListDivisions = aDatabaseDA.Divisions.Where(a => a.ID == ID).ToList();
                if(aListDivisions.Count > 0)
                {
                    return aListDivisions[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DivisionsBO.Select_ByID :"+ ex.Message.ToString().ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select Divisions = Name
        public List<Divisions> Select_ByName(string Name)
        {
            try
            {
                List<Divisions> aList = aDatabaseDA.Divisions.Where(a => a.Name.Contains(Name)).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DivisionsBO.Select_ByName :"+ ex.Message.ToString().ToString()));
            }
        }
        //Author : LinhTing
        //Function : Insert Divisions
        public int  Insert(Divisions aDivisions)
        {
            try
            {
                aDatabaseDA.Divisions.Add(aDivisions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DivisionsBO.Insert :"+ ex.Message.ToString().ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update Divisions
        public int Update(Divisions aDivisions)
        {
            try
            {
                aDatabaseDA.Divisions.AddOrUpdate(aDivisions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DivisionsBO.Update :"+ ex.Message.ToString().ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete Divisions
        public int Delete(int ID)
        {
            try
            {
                Divisions aDivisions = Select_ByID(ID);
                aDatabaseDA.Divisions.Remove(aDivisions);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DivisionsBO.Delete :"+ ex.Message.ToString().ToString()));
            }
        }
    }
}
