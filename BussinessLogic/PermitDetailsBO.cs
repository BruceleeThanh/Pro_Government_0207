using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Entity;
using Library;

namespace BussinessLogic
{
   public class PermitDetailsBO
    {
       DatabaseDA aDatabaseDA = new DatabaseDA();

       // Author : LinhTing
       // Chọn tất cả danh sách permitdetails

       public List<PermitDetails> Select_All()
       {
           try
           {
              return aDatabaseDA.PermitDetails.ToList();
           }
           catch (Exception ex)
           {
               throw new Exception("PermitDetailsBO.Select_All:" + ex.ToString());
           }
       }

        // Author : LinhTing
        // Get Permitdetails = ID
       public PermitDetails Select_ByIDPermitDetail(int IDPermitDetail)
       {
           try
           {
               List<PermitDetails> aListPermitDetails = aDatabaseDA.PermitDetails.Where(a => a.ID == IDPermitDetail).ToList();
               if(aListPermitDetails.Count > 0)
               {
                   return aListPermitDetails[0];
               }
               return null;
           }
           catch (Exception ex)
           {
               throw new Exception("PermitDetailsBO.Select_ByIDPermitDetail:" + ex.ToString());
           }
       }


        // Author : LinhTing
        // Get Permitdetails = IDPermit
       public List<PermitDetails> Select_ByIDPermit(int IDPermit)
       {
           try
           {
               return aDatabaseDA.PermitDetails.Where(a => a.IDPermit == IDPermit).ToList();           
           }
           catch (Exception ex)
           {
               throw new Exception("PermitDetailsBO.Select_ByIDPermit:" + ex.ToString());
           }
       }

        // Author : LinhTing
        // Thêm PermitDetail
       public int Insert(PermitDetails aPermitDetails)
       {
            try
            {
                aDatabaseDA.PermitDetails.Add(aPermitDetails);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("PermitDetailsBO.Insert:" + ex.ToString());
            }
        }

        // Author : LinhTing
        // Sửa PermitDetail
       public int Update ( PermitDetails aPermitDetails)
       {
            try
            {
                aDatabaseDA.PermitDetails.AddOrUpdate(aPermitDetails);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("PermitDetailsBO.Update:" + ex.ToString());
            }
       }

         // Author : LinhTing
        // Xóa PermitDetail
       public int Delete ( int ID)
       {
        try
            {
                PermitDetails aPermitDetails =  aDatabaseDA.PermitDetails.Find(ID);
                aDatabaseDA.PermitDetails.Remove(aPermitDetails);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("PermitDetailsBO.Delete:" + ex.ToString());
            }
       }
       }
    }

