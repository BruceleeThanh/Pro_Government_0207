using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
   public class CompaniesBO
    {
       private   DatabaseDA aDatabaseDA = new DatabaseDA();
       CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
       BookingRsBO aBookingRsBO = new BookingRsBO();
       BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();

       //=======================================================
       //Author: LinhTing
       //Function : Chon tat ca Company
       //=======================================================
              public List<Companies> Select_All()
       {
            try
            {
                var aList = aDatabaseDA.Companies.ToList();
                return aList;
            }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Sel_All :"+ ex.Message.ToString()));
           }
       }


       //=======================================================
       //Author: Hiennv
       //Function : Select_ByType
       //=======================================================
       public List<Companies> Select_ByType(int type)
       {
           try
           {
               return aDatabaseDA.Companies.Where(c=>c.Type == type).OrderByDescending(c=>c.ID).ToList();
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByType :"+ ex.Message.ToString()));
           }
       }


       //=======================================================
       //Author: Hiennv
       //Function : Select_ByName
       //=======================================================
       public List<Companies> Select_ByName(string name)
       {
           try
           {
               return aDatabaseDA.Companies.Where(c => c.Name.Contains(name)).ToList();

           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByName :"+ ex.Message.ToString()));
           }
       }
       //=======================================================
       //Author: Hiennv
       //Function : Select_ByName_ByType
       //=======================================================
       public List<Companies> Select_ByName_ByType(string name,int type)
       {
           try
           {
               return aDatabaseDA.Companies.Where(c=>c.Name.Contains(name)).Where(c=>c.Type==type).ToList();
               
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByName_ByType :"+ ex.Message.ToString()));
           }
       }

       
       //=======================================================
       //Author: LinhTing
       //Function : Chon Company bang ID
       //=======================================================
       public Companies Select_ByID(int? ID)
       {
           try
           {
               List<Companies> aListCompanies = aDatabaseDA.Companies.Where(c => c.ID == ID).ToList();
               if(aListCompanies.Count > 0)
               {
                   return aListCompanies[0];
               }
               return null;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Sel_ByID :"+ ex.Message.ToString()));
           }
       }
       //=======================================================
       //Author: LinhTing
       //Function : Chon Company bang ListID
       //=======================================================
       public List<Companies> Select_ByListID(List<int> ListID)
       {
           try
           {
               List<Companies> aListCompanies = aDatabaseDA.Companies.Where(c => ListID.Contains(c.ID)).ToList();
               return aListCompanies;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByListID :" + ex.Message.ToString()));
           }
       }
       //=======================================================
       //Author: LinhTing
       //Function : Chon Company bang ID CustomerGroup
       //=======================================================
       public Companies Select_ByIDCustomerGroup(int IDCustomerGroup)
       {
           try
           {
               CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(IDCustomerGroup);
               if(aCustomerGroups !=null)
               {
                   return this.Select_ByID(aCustomerGroups.IDCompany);
               }
               else
               {
                   return null;
               }
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByIDCustomerGroup :"+ ex.Message.ToString()));
           }
       }
       // Linhting --- Select by List IDCustomerGroup
       public List<Companies> Select_ByListIDCustomerGroup(List<int> ListIDCustomerGroup)
       {
           try
           {
               List<CustomerGroups> aListCustomerGroups = aCustomerGroupsBO.Select_ByListID(ListIDCustomerGroup);
               List<Companies> aListCompanies = new List<Companies>();
               List<int> aListIDCompanies = new List<int>();
               int aTemp;
               foreach (CustomerGroups item in aListCustomerGroups)
               {
                   aTemp = new int();
                   aTemp = item.IDCompany;
                   aListIDCompanies.Add(aTemp);
               }
               aListCompanies = Select_ByListID(aListIDCompanies);
               return aListCompanies;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByListIDCustomerGroup :" + ex.Message.ToString()));
           }
       }
       //=======================================================
       //Author: LinhTing
       //Function : Chon Company bang ID CustomerGroup
       //=======================================================
       public Companies Select_ByIDBookingRoom(int IDBookingRoom)
       {
           try
           {
               BookingRooms aItem = new BookingRooms();
               aItem = aBookingRoomsBO.Select_ByID(IDBookingRoom);
               int IDBookingR = 0 ;

               if (aItem != null)
               {
                   IDBookingR = aItem.IDBookingR;
               }
               int IDCustomerGroup = aBookingRsBO.Select_ByID(IDBookingR).IDCustomerGroup;
               Companies aCompanies = this.Select_ByIDCustomerGroup(IDCustomerGroup);
               return aCompanies;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByIDCustomerGroup :"+ ex.Message.ToString()));
           }
       }
       public List<Companies> Select_ByListIDBookingRoom(List<int> ListIDBookingRoom)
       {
           try
           {
               List<BookingRs> aListBookingRs = aBookingRsBO.Select_ByListIDBookingRoom(ListIDBookingRoom);
               List<int> aListIDCustomerGroups = new List<int>();
               int aIDCustomerGroups;
               for (int i = 0; i < aListBookingRs.Count; i++)
               {
                   aIDCustomerGroups = new int();
                   aIDCustomerGroups = aListBookingRs[i].IDCustomerGroup;
                   aListIDCustomerGroups.Add(aIDCustomerGroups);
               }
               List<Companies> aListCompanies = this.Select_ByListIDCustomerGroup(aListIDCustomerGroups);
               return aListCompanies;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Select_ByListIDBookingRoom :" + ex.Message.ToString()));
           }
       }
       //=======================================================
       //Author: LinhTing
       //Function : Them Company
       //=======================================================
       public int Insert(Companies Companies)
       {
           try
           {
               aDatabaseDA.Companies.Add(Companies);
               aDatabaseDA.SaveChanges();
               return Companies.ID;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Insert :"+ ex.Message.ToString()));
           }
       }

       //=======================================================
       //Author: LinhTing
       //Function : Xoa Company bang ID
       //=======================================================
       public int Delete(int ID)
       {
           try
           {
               Companies com = aDatabaseDA.Companies.Find(ID);
               aDatabaseDA.Companies.Remove(com);
               return aDatabaseDA.SaveChanges();
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Delete :"+ ex.Message.ToString()));
           }
       }

       //=======================================================
       //Author: LinhTing
       //Function : Updata Company
       //=======================================================
       public int Update(Companies Companies)
       {
           try
           {
               aDatabaseDA.Companies.AddOrUpdate(Companies);
               return aDatabaseDA.SaveChanges();
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.Update :"+ ex.Message.ToString()));
           }
       }
       // Linhting - Tạo công ty tự động
       public int AutoInsertCompany(string NameCompany,int Type)
       {
           try
           {

               Companies Companies = new Companies();
               Companies.Name = NameCompany;
               Companies.Status = 1;
               Companies.Disable = false;
               Companies.Type = Type;
               this.Insert(Companies);
               return Companies.ID;
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("CompaniesBO.AutoInsertCompany :" + ex.Message.ToString()));
           }
       }
       

    }
}
