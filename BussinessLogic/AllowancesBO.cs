using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class AllowancesBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Test 
        //Author : LinhTing
        // Select tat ca Allowances
        
        public List<Allowances> Select_All()
        {
            try
            {
                List<Allowances> aList = aDatabaseDA.Allowances.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AllowancesBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select Allowances = ID
        public Allowances Select_ByID(int ID)
        {
            try
            {
                List<Allowances> aListAllowances = aDatabaseDA.Allowances.Where(a => a.ID == ID).ToList();
                if(aListAllowances.Count > 0)
                {
                    return aListAllowances[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AllowancesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Insert Allowances
        public int Insert(Allowances aAllowances)
        {
            try
            {
                aDatabaseDA.Allowances.Add(aAllowances);
                return  aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AllowancesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update Allowances
        public int Update(Allowances aAllowances)
        {
            try
            {
                aDatabaseDA.Allowances.AddOrUpdate(aAllowances);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AllowancesBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete Allowances
        public int Delete(int ID)
        {
            try
            {
                Allowances aAllowances = Select_ByID(ID);
                aDatabaseDA.Allowances.Remove(aAllowances);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AllowancesBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
