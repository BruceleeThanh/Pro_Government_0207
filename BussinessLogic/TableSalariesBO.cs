using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;


namespace BussinessLogic
{
    public class TableSalariesBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();

        //Author : LinhTing
        // Select tat ca TableSalaries
        public List<TableSalaries> Select_All()
        {
            try
            {
                List<TableSalaries> aList = aDatabaseDA.TableSalaries.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select TableSalaries = ID
        public TableSalaries Select_ByID(int ID)
        {
            try
            {
                List<TableSalaries> aListTableSalaries = aDatabaseDA.TableSalaries.Where(a => a.ID == ID).ToList();
                if(aListTableSalaries.Count > 0)
                {
                    return aListTableSalaries[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }


        //Author : LinhTing
        //Function : Select TableSalaries = Sku
        public TableSalaries Select_BySku(string Sku)
        {
            try
            {
                List<TableSalaries> aListTableSalaries = aDatabaseDA.TableSalaries.Where(a => a.Sku == Sku).ToList();
                if (aListTableSalaries.Count > 0)
                {
                    return aListTableSalaries[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Select_BySku :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Select TableSalaries = IDGroup
        public List<TableSalaries> Select_ByIDGroupTableSalaries(int IDGroupTableSalaries)
        {
            try
            {
                List<TableSalaries> aList = aDatabaseDA.TableSalaries.Where(a => a.IDGroupTableSalary == IDGroupTableSalaries).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Select_ByIDGroupTableSalaries :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Select TableSalaries = Name
        public List<TableSalaries> Select_ByName(string Name)
        {
            try
            {
                List<TableSalaries> aList = aDatabaseDA.TableSalaries.Where(a => a.Name == Name).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Select_ByName :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Insert TableSalaries
        public int Insert(TableSalaries aTableSalaries)
        {
            try
            {
                aDatabaseDA.TableSalaries.Add(aTableSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update TableSalaries
        public int Update(TableSalaries aTableSalaries)
        {
            try
            {
                aDatabaseDA.TableSalaries.AddOrUpdate(aTableSalaries);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete TableSalaries
        public int Delete(int ID)
        {
            try
            {
                TableSalaries aTableSalaries = Select_ByID(ID);
                aDatabaseDA.TableSalaries.Remove(aTableSalaries);                
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TableSalariesBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
