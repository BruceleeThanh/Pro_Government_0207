using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Entity;
using DataAccess;

namespace BussinessLogic
{
   public  class SystemUsers_CertificatesBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
       //Author : LinhTing
        public List<SystemUsers_Certificates> Select_All()
        {
            try
            {
                return aDatabaseDA.SystemUsers_Certificates.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_CertificatesBO.Select_All :"+ ex.Message.ToString()));
            }
        }
        //Author : Hiennv
        public SystemUsers_Certificates Select_ByID(int ID)
        {
            try
            {
                List<SystemUsers_Certificates> aListTemps = aDatabaseDA.SystemUsers_Certificates.Where(s => s.ID == ID).ToList();
                if (aListTemps.Count > 0)
                {
                    return aDatabaseDA.SystemUsers_Certificates.Where(s => s.ID == ID).ToList()[0];
                }
                else 
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_CertificatesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        public List<SystemUsers_CertificatesEN> GetCertificateInfo(int IDSystemUser)
        {
            List<vw__CertificatesInfo__SystemUsers_Certificates> aListTemp = new List<vw__CertificatesInfo__SystemUsers_Certificates>();
            aListTemp = aDatabaseDA.vw__CertificatesInfo__SystemUsers_Certificates.Where(a => a.SystemUsers_ID == IDSystemUser).ToList();
            List<SystemUsers_CertificatesEN> aListReturn = new List<SystemUsers_CertificatesEN>();
            SystemUsers_CertificatesEN aSystemUsers_CertificatesEN;
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aSystemUsers_CertificatesEN = new SystemUsers_CertificatesEN();
                aSystemUsers_CertificatesEN.Name = aListTemp[i].SystemUsers_Name;
                aSystemUsers_CertificatesEN.Certificate = aListTemp[i].Certificates_Certificates;
                aSystemUsers_CertificatesEN.CreatedDate = aListTemp[i].SystemUsers_Certificates_CreatedDate;
                aSystemUsers_CertificatesEN.ExpirationDate = aListTemp[i].SystemUsers_Certificates_ExpirationDate;
                aSystemUsers_CertificatesEN.Organization_SystemUsers_Certificates = aListTemp[i].Certificates_Organization;
                aListReturn.Add(aSystemUsers_CertificatesEN);
            }
            return aListReturn;
        }
        //Author : LinhTing 
        public List<SystemUsers_Certificates> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<SystemUsers_Certificates> aList = aDatabaseDA.SystemUsers_Certificates.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_CertificatesBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        public int Insert(SystemUsers_Certificates aSystemUsers_Certificates)
        {
            try
            {
               aSystemUsers_Certificates =  aDatabaseDA.SystemUsers_Certificates.Add(aSystemUsers_Certificates);
               aDatabaseDA.SaveChanges();
               return aSystemUsers_Certificates.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_CertificatesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public int Update(SystemUsers_Certificates aSystemUsers_Certificates)
        {
            try
            {
                aDatabaseDA.SystemUsers_Certificates.AddOrUpdate(aSystemUsers_Certificates);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsers_CertificatesBO.Update :"+ ex.Message.ToString()));
            }
        }
        //author:Hiennv
        public int Delete(int id)
        {
            try
            {
                SystemUsers_Certificates aSystemUsers_Certificates = aDatabaseDA.SystemUsers_Certificates.Find(id);
                aDatabaseDA.SystemUsers_Certificates.Remove(aSystemUsers_Certificates);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("SystemUsers_CertificatesBO.Delete:" + ex.ToString());
            }
        }
    }
}
