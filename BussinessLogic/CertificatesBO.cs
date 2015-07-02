using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;
using Entity;

namespace BussinessLogic
{
    public class CertificatesBO
    {
        SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
        DatabaseDA aDatabaseDA = new DatabaseDA();
        //Author : LinhTing
        // Select tat ca Certificates
        public List<Certificates> Select_All()
        {
            try
            {
                List<Certificates> aList = aDatabaseDA.Certificates.OrderByDescending(c=>c.ID).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.Sel_All :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select Certificates = ID, Type
        public Certificates Select_ByID_ByType(int ID, int Type)
        {
            try
            {
                List<Certificates> alistCertificates = aDatabaseDA.Certificates.Where(a => a.ID == ID).Where(a => a.Type == Type).ToList();
                if (alistCertificates.Count > 0)
                {
                    return alistCertificates[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.Select_ByID_ByType :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select Certificates = ID, Type
        public Certificates Select_ByID(int ID)
        {
            try
            {
                List<Certificates> aListCertificates = aDatabaseDA.Certificates.Where(a => a.ID == ID).ToList();
                if (aListCertificates.Count > 0)
                {
                    return aDatabaseDA.Certificates.Where(a => a.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }
        //Author : LinhTing
        //Function : Select Certificates = ID
        public List<Certificates> Select_ByIDSystemUser(int IDSystemUser)
        {
            List<SystemUsers_Certificates> aListSystemUsers_Certificates = aSystemUsers_CertificatesBO.Select_All().Where(p => p.IDSystemUser == IDSystemUser).ToList();
            List<int> aListID = aListSystemUsers_Certificates.Select(p => p.IDCertificate).ToList();
            List<Certificates> aListCertificates = new List<Certificates>();
            Certificates aCertificate;
            for (int i = 0; i < aListID.Count; i++)
            {
                aCertificate = new Certificates();
                aCertificate = Select_ByID(aListID[i]);
                aListCertificates.Add(aCertificate);
            }
            return aListCertificates;
        }

        //Author : LinhTing
        //Function : Select CertificatesExt = IDSystemUser, Type
        public List<vw__CertificatesInfo__SystemUsers_Certificates> GetCertificateExt_ByIDSystemUser_ByType(int Type, int IDSystemUser)
        {
            try
            {
                List<vw__CertificatesInfo__SystemUsers_Certificates> aListTemp = new List<vw__CertificatesInfo__SystemUsers_Certificates>();
                aListTemp = aDatabaseDA.vw__CertificatesInfo__SystemUsers_Certificates.Where(a => a.SystemUsers_ID == IDSystemUser).Where(a => a.Certificates__Type == Type).ToList();
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.GetCertificateExt_ByIDSystemUser_ByType :"+ ex.Message.ToString()));
            }

        }

        //Author : LinhTing
        //Function : Select bang Chinh quy
        public List<vw__CertificatesInfo__SystemUsers_Certificates> GetRegularCertificate(int IDSystemUser)
        {
            try
            {
                List<vw__CertificatesInfo__SystemUsers_Certificates> aListTemp = new List<vw__CertificatesInfo__SystemUsers_Certificates>();
                var ListTypeSubCertificate = new int?[] { 1,2,3,4,5,6,7,8 };
                aListTemp = aDatabaseDA.vw__CertificatesInfo__SystemUsers_Certificates.Where(a => a.SystemUsers_ID == IDSystemUser).Where(a => ListTypeSubCertificate.Contains(a.Certificates__Type)).ToList();
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.GetRegularCertificate :"+ ex.Message.ToString()));
            }

        }

        //Author : LinhTing
        //Function : Select bang va chung chi phu
        public List<vw__CertificatesInfo__SystemUsers_Certificates> GetSubCertificate(int IDSystemUser)
        {
            try
            {
                List<vw__CertificatesInfo__SystemUsers_Certificates> aListTemp = new List<vw__CertificatesInfo__SystemUsers_Certificates>();
                var ListTypeSubCertificate = new int?[] { 9,10,11};

                aListTemp = aDatabaseDA.vw__CertificatesInfo__SystemUsers_Certificates.Where(a => a.SystemUsers_ID == IDSystemUser).Where(a => ListTypeSubCertificate.Contains(a.Certificates__Type)).ToList();
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.GetSubCertificate :"+ ex.Message.ToString()));
            }

        }

        //Author : LinhTing
        //Function : Select ly luan chinh tri
        public List<vw__CertificatesInfo__SystemUsers_Certificates> GetPoliticalGorvenmentManagerCertificate(int IDSystemUser)
        {
            try
            {
                List<vw__CertificatesInfo__SystemUsers_Certificates> aListTemp = new List<vw__CertificatesInfo__SystemUsers_Certificates>();
                var ListTypeSubCertificate = new int?[] { 12,13 };
                aListTemp = aDatabaseDA.vw__CertificatesInfo__SystemUsers_Certificates.Where(a => a.SystemUsers_ID == IDSystemUser).Where(a => ListTypeSubCertificate.Contains(a.Certificates__Type)).ToList();
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.GetPoliticalGorvenmentManagerCertificate :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Select quan ly nha nuoc
        public List<vw__CertificatesInfo__SystemUsers_Certificates> GetGorvenmentManagerCertificate(int IDSystemUser)
        {
            try
            {
                List<vw__CertificatesInfo__SystemUsers_Certificates> aListTemp = new List<vw__CertificatesInfo__SystemUsers_Certificates>();
                aListTemp = aDatabaseDA.vw__CertificatesInfo__SystemUsers_Certificates.Where(a => a.SystemUsers_ID == IDSystemUser).Where(p => p.Certificates__Type == 13).ToList();
                return aListTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.GetGorvenmentManagerCertificate :"+ ex.Message.ToString()));
            }

        }
        //Author : LinhTing
        //Function : Insert Certificates
        public int Insert(Certificates aCertificates)
        {
            try
            {
                aDatabaseDA.Certificates.Add(aCertificates);
                aDatabaseDA.SaveChanges();
                return aCertificates.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Update Certificates
        public int Update(Certificates aCertificates)
        {
            try
            {
                aDatabaseDA.Certificates.AddOrUpdate(aCertificates);
                aDatabaseDA.SaveChanges();
                return aCertificates.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author : LinhTing
        //Function : Delete Certificates
        public int Delete(int ID)
        {
            try
            {
                Certificates aCertificates = Select_ByID(ID);
                aDatabaseDA.Certificates.Remove(aCertificates);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CertificatesBO.Delete :"+ ex.Message.ToString()));
            }
        }
    }
}
