using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Entity;
using Library;


namespace BussinessLogic
{
    public class PermitsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        public  List<PermitViewAllEN> GetAllInfoLogin_ByEmail(string Email)
        {
            try
            {
                 List<PermitViewAllEN>  aRet = new List<PermitViewAllEN>();
                 List<vw__PermitInfo__SystemUsers_Permits_PermitDetails> aList = aDatabaseDA.vw__PermitInfo__SystemUsers_Permits_PermitDetails.Where(p => p.SystemUsers_Email == Email).ToList();
                 for (int i = 0; i < aList.Count; i++)
                 {
                     aRet[i].Convert(aList[i]);
                 }
                 return aRet;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SystemUsersDA_GetAllInfoLogin_ByEmail: {0}"+ ex.Message.ToString()));
            }
        }
        public  List<PermitViewAllEN> GetAllInfoLogin_ByUsername(string Username)
        {
            try
            {
                List<PermitViewAllEN> aRet = new List<PermitViewAllEN>();
                List<vw__PermitInfo__SystemUsers_Permits_PermitDetails> aList1 = new List<vw__PermitInfo__SystemUsers_Permits_PermitDetails>();
                 aList1 = aDatabaseDA.vw__PermitInfo__SystemUsers_Permits_PermitDetails.ToList();
                List<vw__PermitInfo__SystemUsers_Permits_PermitDetails> aList = aDatabaseDA.vw__PermitInfo__SystemUsers_Permits_PermitDetails.Where(p => p.SystemUsers_Username == Username).ToList();
                PermitViewAllEN Item = new PermitViewAllEN();
                for (int i = 0; i < aList.Count; i++)
                {
                    Item = new PermitViewAllEN();
                    Item.Convert(aList[i]);
                    aRet.Add(Item);
                }
                return aRet;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SystemUsersDA_GetPermitViewAllEN_ByUsername: {0}"+ ex.Message.ToString()));
            }
        }
        public  List<PermitViewAllEN> GetAllInfoLogin_ByUsername(int UserID)
        {
            try
            {
                List<PermitViewAllEN> aRet = new List<PermitViewAllEN>();
                List<vw__PermitInfo__SystemUsers_Permits_PermitDetails> aList = aDatabaseDA.vw__PermitInfo__SystemUsers_Permits_PermitDetails.Where(p => p.SystemUsers_ID == UserID).ToList();
                for (int i = 0; i < aList.Count; i++)
                {
                    aRet[i].Convert(aList[i]);
                }
                return aRet;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SystemUsersDA_GetPermitViewAllEN_ByUsername: {0}"+ ex.Message.ToString()));
            }
        }

        public List<Permits> Select_All()
        {
            try
            {
                return aDatabaseDA.Permits.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("PermitsBO.Select_All:" + ex.ToString());
            }
        }
        public Permits Select_ByID(int IDPermit)
        {
            try
            {
                List<Permits> aListPermits = aDatabaseDA.Permits.Where(b => b.ID == IDPermit).ToList();
                if (aListPermits.Count > 0)
                {
                    return aListPermits[0];
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("PermitsBO.Select_ByID:" + ex.ToString());
            }
        }
      

        //-----------------Add New ---------------------------------
        public int Insert(Permits aPermits)
        {
            try
            {
                aDatabaseDA.Permits.Add(aPermits);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("PermitsBO.Insert:" + ex.ToString());
            }
        }
        //----------------Update BookingRooms -----------------------------
        public int Update(Permits aPermits)
        {
            try
            {
                aDatabaseDA.Permits.AddOrUpdate(aPermits);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("PermitsBO.Update:" + ex.ToString());
            }
        }
        //----------------- Delete BookingRooms  -------------------------------
        public int Delete(int id)
        {
            try
            {
                Permits aPermits = aDatabaseDA.Permits.Find(id);
                aDatabaseDA.Permits.Remove(aPermits);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("PermitsBO.Delete:" + ex.ToString());
            }
        }
        //--------------------------------------------------------------------------
        public bool CheckPermit(int Type, string FrmName, CustomType.PermitActionType aPermitActionType, List<PermitViewAllEN> aList_PermitViewAll, SystemUsers aSystemUsers)
        {
        
            if (aSystemUsers != null)
            {
                for (int i = 0; i < aList_PermitViewAll.Count; i++)
                {
                    if (aPermitActionType == CustomType.PermitActionType.Delele)
                    {
                        if ((aList_PermitViewAll[i].PermitDetails_PageURL == FrmName) && (aList_PermitViewAll[i].Permits_SystemUsers_IsDelete == true))
                        { 
                            return true; 
                        }

                    }
                    else if (aPermitActionType == CustomType.PermitActionType.Insert)
                    {
                        if ((aList_PermitViewAll[i].PermitDetails_PageURL == FrmName) && (aList_PermitViewAll[i].Permits_SystemUsers_IsInsert == true))
                        { return true; }

                    }
                    else if (aPermitActionType == CustomType.PermitActionType.Special)
                    {
                        if ((aList_PermitViewAll[i].PermitDetails_PageURL == FrmName) && (aList_PermitViewAll[i].Permits_SystemUsers_IsSpecial == true))
                        { return true; }

                    }
                    else if (aPermitActionType == CustomType.PermitActionType.Update)
                    {
                        if ((aList_PermitViewAll[i].PermitDetails_PageURL == FrmName) && (aList_PermitViewAll[i].Permits_SystemUsers_IsUpdate == true))
                        { return true; }

                    }
                    else if (aPermitActionType == CustomType.PermitActionType.View)
                    {
                        if ((aList_PermitViewAll[i].PermitDetails_PageURL == FrmName) && (aList_PermitViewAll[i].Permits_SystemUsers_IsView == true))
                        { return true; }

                    }
                }
                return false;
            }
            return false;
        }
        //------------------------------------------------------------------------------

    }
}
