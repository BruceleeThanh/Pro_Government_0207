using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class ExtraCostBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        //=======================================================
        //Author: LinhTing
        //Function : Chon tat ca Company
        //=======================================================
        public List<ExtraCosts> Select_All()
        {
            try
            {
               return aDatabaseDA.ExtraCosts.ToList();
               
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExtraCostsBO.Sel_All :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Chon Company bang ID
        //=======================================================
        public ExtraCosts Select_ByID(int? ID)
        {
            try
            {
                List<ExtraCosts> aListExtraCosts = aDatabaseDA.ExtraCosts.Where(c => c.ID == ID).ToList();
                if (aListExtraCosts.Count > 0)
                {
                    return aListExtraCosts[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExtraCostsBO.Sel_ByID :" + ex.Message.ToString()));
            }
        }

        public ExtraCosts Select_BySku_ByPriceType_ByNumberPeople(string Sku, string PriceType,int NumberPeople)
        {
            try
            {
                List<ExtraCosts> aTemp = aDatabaseDA.ExtraCosts.Where(a => a.Sku == Sku).Where(a => a.PriceType == PriceType).Where(a => a.NumberPeople == NumberPeople).ToList();
                if (aTemp.Count > 0)
                {
                    return aTemp[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExtraCostsBO.Select_BySku_ByPriceType_ByNumberPeople :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Them Company
        //=======================================================
        public int Insert(ExtraCosts ExtraCosts)
        {
            try
            {
                aDatabaseDA.ExtraCosts.Add(ExtraCosts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExtraCostsBO.Insert :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Xoa bang ID
        //=======================================================
        public int Delete(int ID)
        {
            try
            {
                ExtraCosts com = aDatabaseDA.ExtraCosts.Find(ID);
                aDatabaseDA.ExtraCosts.Remove(com);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExtraCostsBO.Delete :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Update
        //=======================================================
        public int Update(ExtraCosts ExtraCosts)
        {
            try
            {
                aDatabaseDA.ExtraCosts.AddOrUpdate(ExtraCosts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExtraCostsBO.Update :" + ex.Message.ToString()));
            }
        }
    }
}
