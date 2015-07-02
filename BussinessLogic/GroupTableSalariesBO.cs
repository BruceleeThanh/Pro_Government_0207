using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class GroupTableSalariesBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Author : LinhTing
        // Select tat ca GroupTableSalaries
        public List<GroupTableSalaries> Select_All()
        {
            try
            {
                List<GroupTableSalaries> aList = aDatabaseDA.GroupTableSalaries.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GroupTableSalariesBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select GroupTableSalaries = ID
        public GroupTableSalaries Select_ByID(int ID)
        {
            try
            {
                List<GroupTableSalaries> aListGroupTableSalaries = aDatabaseDA.GroupTableSalaries.Where(a => a.ID == ID).ToList();
                if(aListGroupTableSalaries.Count > 0)
                {
                    return aListGroupTableSalaries[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GroupTableSalariesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select GroupTableSalaries = Disable

        public GroupTableSalaries Select_ByDisable()
        {
            try
            {
                List<GroupTableSalaries> aListGroupTableSalaries = aDatabaseDA.GroupTableSalaries.Where(a => a.Disable == false).ToList();
                if (aListGroupTableSalaries.Count > 0)
                {
                    return aListGroupTableSalaries[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GroupTableSalariesBO.Select_ByDisable :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Insert GroupTableSalaries
        public int Insert(GroupTableSalaries aGroupTableSalaries)
        {
            try
            {
                aDatabaseDA.GroupTableSalaries.Add(aGroupTableSalaries);
                int r = aDatabaseDA.SaveChanges();
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GroupTableSalariesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update GroupTableSalaries
        public int Update(GroupTableSalaries aGroupTableSalaries)
        {
            try
            {
                aDatabaseDA.GroupTableSalaries.AddOrUpdate(aGroupTableSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GroupTableSalariesBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete GroupTableSalaries
        public int Delete(int ID)
        {
            try
            {
                GroupTableSalaries aGroupTableSalaries = Select_ByID(ID);
                aDatabaseDA.GroupTableSalaries.Remove(aGroupTableSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GroupTableSalariesBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
