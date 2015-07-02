using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class CheckPointBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        
        //=======================================================
        //Author: LinhTing
        //Function : Chon tat ca Check Point
        //=======================================================
        public List<CheckPoints> Select_All()
        {
            try
            {
                
                List<CheckPoints> aList = aDatabaseDA.CheckPoints.ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CheckPointsBO.Select :" + ex.Message));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Chon Check Point by ID
        //=======================================================
        public CheckPoints Select_ByID(int ID)
        {
            try
            {
                List<CheckPoints> aListCheckPoints = aDatabaseDA.CheckPoints.Where(c => c.ID == ID).ToList();
                if(aListCheckPoints.Count > 0)
                {
                    return aListCheckPoints[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CheckPointsBO.Sel_ByID :"+ ex.Message));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Them CheckPoints
        //=======================================================
        public int Insert(CheckPoints CheckPoints)
        {
            try
            {
                aDatabaseDA.CheckPoints.Add(CheckPoints);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CheckPointsBO.Insert :" + ex.Message));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Xoa CheckPoints bang ID
        //=======================================================
        public int Delete_ByID(int ID)
        {
            try
            {
                CheckPoints check = aDatabaseDA.CheckPoints.Find(ID);
                aDatabaseDA.CheckPoints.Remove(check);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CheckPointsBO.Delete_ByID :" + ex.Message));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Update CheckPoints
        //=======================================================
        public int Update(CheckPoints CheckPoints)
        {
            try
            {
                aDatabaseDA.CheckPoints.AddOrUpdate(CheckPoints);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CheckPointsBO.Update :" + ex.Message));
            }
        }
    }
}
