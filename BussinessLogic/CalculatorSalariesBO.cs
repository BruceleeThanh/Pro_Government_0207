using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class CalculatorSalariesBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Author : LinhTing
        // Select tat ca CalculatorSalaries
        public List<CalculatorSalaries> Select_All()
        {
            try
            {
                List<CalculatorSalaries> aList = aDatabaseDA.CalculatorSalaries.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CalculatorSalariesBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select CalculatorSalaries = ID
        public CalculatorSalaries Select_ByID(int ID)
        {
            try
            {
                List<CalculatorSalaries> aListCalculatorSalaries = aDatabaseDA.CalculatorSalaries.Where(a => a.ID == ID).ToList();
                if (aListCalculatorSalaries.Count > 0)
                {
                    return aListCalculatorSalaries[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CalculatorSalariesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select CalculatorSalaries = IDSystemUser
        public List<CalculatorSalaries> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<CalculatorSalaries> aList = aDatabaseDA.CalculatorSalaries.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CalculatorSalariesBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Insert CalculatorSalaries
        public int Insert(CalculatorSalaries aCalculatorSalaries)
        {
            try
            {
                aDatabaseDA.CalculatorSalaries.Add(aCalculatorSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CalculatorSalariesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update CalculatorSalaries
        public int Update(CalculatorSalaries aCalculatorSalaries)
        {
            try
            {
                aDatabaseDA.CalculatorSalaries.AddOrUpdate(aCalculatorSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CalculatorSalariesBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete CalculatorSalaries
        public int Delete(int ID)
        {
            try
            {
                CalculatorSalaries aCalculatorSalaries = Select_ByID(ID);
                aDatabaseDA.CalculatorSalaries.Remove(aCalculatorSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CalculatorSalariesBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
