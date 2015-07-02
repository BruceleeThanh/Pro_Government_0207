using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Migrations;
using Library;
using Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BussinessLogic
{
    public class SystemUsersBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //#region Mã hóa mật khẩu

        //#endregion

        public SystemUsersBO()
        {

        }


        public bool Check_ByUsername(string Username)
        {
            try
            {
                var a = aDatabaseDA.SystemUsers.Any(p => p.Username == Username);
                return a;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.CheckID_ByUsername:" + ex.Message.ToString().ToString()));
            }
        }


        public SystemUsers CheckAccount(string Username, string Password)
        {
            try
            {
                string Pass = StringUtility.md5(Password);
                List<SystemUsers> aList = aDatabaseDA.SystemUsers.Where(p => p.Username == Username && p.Password == Pass).ToList();
                if (aList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return aList[0];
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.CheckAccount:" + ex.Message.ToString()));
            }
        }

        public int Insert(SystemUsers sysUser)
        {
            try
            {
                sysUser = aDatabaseDA.SystemUsers.Add(sysUser);
                aDatabaseDA.SaveChanges();
                return sysUser.ID;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Insert:" + ex.Message.ToString()));
            }
        }

        public int Update(SystemUsers aSystemUsers)
        {
            try
            {
                aDatabaseDA.SystemUsers.AddOrUpdate(aSystemUsers);
                int r = aDatabaseDA.SaveChanges();
                return r;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Update:" + ex.Message.ToString()));
            }
        }

        public int Delete(int ID)
        {
            try
            {
                SystemUsers sysUser = aDatabaseDA.SystemUsers.Find(ID);
                aDatabaseDA.SystemUsers.Remove(sysUser);
                int r = aDatabaseDA.SaveChanges();
                return r;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Delete:" + ex.Message.ToString()));
            }
        }
     
        public List<SystemUsers> Select_All()
        {
            try
            {
                var alist = aDatabaseDA.SystemUsers.ToList();
                return alist;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Select_All:" + ex.Message.ToString()));
            }
        }

        public SystemUsers Select_ByUsername(string Username)
        {
            try
            {
                var alist = aDatabaseDA.SystemUsers.Where(p => p.Username == Username).ToList();
                if (alist.Count > 0)
                {
                    return alist[0];
                }
                else { return new SystemUsers(); }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Select_ByUsername:" + ex.Message.ToString()));
            }
        }

        public List<SystemUsers> Select_ByName(string Name)
        {
            try
            {
                var alist = aDatabaseDA.SystemUsers.Where(p => p.Name.Contains(Name)).ToList();
                return alist;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Select_ByName:" + ex.Message.ToString()));
            }
        }

        public List<string> Sel_all_Name()
        {
            try
            {
                var alist = (from x in aDatabaseDA.SystemUsers
                             select x.Name).ToList();
                return alist;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Sel_ByName :" + ex.Message.ToString()));
            }
        }
        public List<string> Sel_All_Contain_Usernames(string username)
        {
            try
            {
                List<string> alist = (from x in aDatabaseDA.SystemUsers
                             where x.Username.Contains(username)
                             select x.Username).ToList();

                return alist;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Sel_All_Username :" + ex.Message.ToString()));
            }
        }
        public List<string> Sel_All_Usernames()
        {
            try
            {
                List<string> alist = (from x in aDatabaseDA.SystemUsers
                             select x.Username).ToList();

                return alist;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Sel_All_Usernames :" + ex.Message.ToString()));
            }
        }
        public SystemUsers Select_ByID(int ID)
        {
            try
            {
                List<SystemUsers> aListSystemUsers = aDatabaseDA.SystemUsers.Where(p => p.ID == ID).ToList();
                if (aListSystemUsers.Count > 0)
                {
                    return aListSystemUsers[0];
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("SystemUsersBO.Select_ByID:" + ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public List<SystemUsers> Select_ByDisable(bool Disable)
        {
            try
            {
                return aDatabaseDA.SystemUsers.Where(s => s.Disable == Disable).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsersBO.Select_ByDisable :" + ex.Message.ToString().ToString()));
            }
        }

        //Author : Hiennv
        public List<MOBSystemUsersEN> GetListSystemUsers()
        {
            try
            {
                List<vw__SystemUsersInfo__SystemUsers_Divisions> aListTemp = new List<vw__SystemUsersInfo__SystemUsers_Divisions>();
                aListTemp = aDatabaseDA.vw__SystemUsersInfo__SystemUsers_Divisions.ToList();
                List<MOBSystemUsersEN> aListMOBSystemUsersEN = new List<MOBSystemUsersEN>();
                MOBSystemUsersEN aMOBSystemUsersEN;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aMOBSystemUsersEN = new MOBSystemUsersEN();
                    aMOBSystemUsersEN.SystemUsers_ID = aListTemp[i].SystemUsers_ID;
                    aMOBSystemUsersEN.SystemUsers_Username = aListTemp[i].SystemUsers_Username;
                    aMOBSystemUsersEN.SystemUsers_Name = aListTemp[i].SystemUsers_Name;
                    aMOBSystemUsersEN.SystemUsers_Email = aListTemp[i].SystemUsers_Email;
                    aMOBSystemUsersEN.SystemUsers_Birthday = aListTemp[i].SystemUsers_Birthday;
                    aMOBSystemUsersEN.SystemUsers_Identifier1 = aListTemp[i].SystemUsers_Identifier1;
                    aMOBSystemUsersEN.SystemUsers_Identifier2 = aListTemp[i].SystemUsers_Identifier2;
                    aMOBSystemUsersEN.SystemUsers_Identifier3 = aListTemp[i].SystemUsers_Identifier3;
                    aMOBSystemUsersEN.SystemUsers_Image = aListTemp[i].SystemUsers_Image;
                    aMOBSystemUsersEN.SystemUsers_Disable = aListTemp[i].Divisions_Disable;

                    aMOBSystemUsersEN.Divisions_ID = aListTemp[i].Divisions_ID;
                    aMOBSystemUsersEN.Divisions_Name = aListTemp[i].Divisions_Name;
                    aMOBSystemUsersEN.Divisions_Disable = aListTemp[i].Divisions_Disable;
                    aListMOBSystemUsersEN.Add(aMOBSystemUsersEN);
                }

                return aListMOBSystemUsersEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUsersBO.GetListSystemUsers :" + ex.Message.ToString().ToString()));
            }
        }

        //author: hiennv
        public List<SystemUsers> SelectListSystemUsers_ByListIDSystemUsers(List<int> aListIDSystemUsers)
        {
            try
            {
                List<SystemUsers> aListSystemUsers = new List<SystemUsers>();
                for (int i = 0; i < aListIDSystemUsers.Count; i++)
                {
                    aListSystemUsers.Add(this.Select_ByID(int.Parse(aListIDSystemUsers[i].ToString())));
                }
                return aListSystemUsers;
            }
            catch (Exception ex)
            {

                throw new Exception("SystemUsersBO.SelectListSystemUsers_ByIDDivision\n" + ex.ToString());
            }

        }
        //Author:Hiennv
        public List<SystemUsers> SelectListSystemUsers_ByIDDivision(int IDDivision)
        {
            try
            {
                SystemUsers_DivisionsBO aSystemUsers_DivisionsBO = new SystemUsers_DivisionsBO();
                List<int> aListIDSystemUsers = aSystemUsers_DivisionsBO.Select_ByIDDivision(IDDivision).Where(s=>s.Disable == false).Select(s => s.IDSystemUser).Distinct().ToList();
                return this.SelectListSystemUsers_ByListIDSystemUsers(aListIDSystemUsers).Where(s => s.Disable == false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("SystemUsersBO.SelectListSystemUsers_ByIDDivision\n" + ex.ToString());
            }
        }
        public List<SystemUsers> SelectListAllSystemUsers_ByIDDivision(int IDDivision)
        {
            try
            {
                SystemUsers_DivisionsBO aSystemUsers_DivisionsBO = new SystemUsers_DivisionsBO();
                List<int> aListIDSystemUsers = aSystemUsers_DivisionsBO.Select_ByIDDivision(IDDivision).Select(s => s.IDSystemUser).Distinct().ToList();
                return this.SelectListSystemUsers_ByListIDSystemUsers(aListIDSystemUsers).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("SystemUsersBO.SelectListSystemUsers_ByListIDSystemUsers\n" + ex.ToString());
            }
        }
        //---------------------------------FUNCTIONS OF HMAILSERVER---------------------------------
        //Author ChuyenBV

        public int InsertEmailToDatabase(string UsernameAvaiable, string password, string domain)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["HMailServerDB"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from hm_domains where domainname = '" + domain + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                     int domainId = int.Parse(ds.Tables[0].Rows[0]["domainid"].ToString());

                     string sql = "insert into hm_accounts values (" + domainId + ",'','" + UsernameAvaiable + "@" + domain + "','" + Library.StringUtility.md5(password) + "',1,''" + ",'','','','','','','','','','','','','','" + DateTime.Today.ToString() + "','','','','')";
                     cmd = new SqlCommand(sql, conn);
                     int Return = cmd.ExecuteNonQuery();
                     conn.Close();
                     return Return;
                }
                else
                {
                    throw new Exception("Hệ thống email chưa có domain này");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserBO_InsertEmailToDatabase :" + ex.Message.ToString()));
            }
        }

        public int DisableEmail(string email)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["HMailServerDB"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                int Return = 0;
                cmd = new SqlCommand("update hm_accounts set accountactive = 0" + "where accountaddress = '" + email + "'", conn);
                Return = cmd.ExecuteNonQuery();
                conn.Close();
                return Return;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserBO_DisableEmail :" + ex.Message.ToString()));
            }
        }
        public int EnableEmail(string email)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["HMailServerDB"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                int r = 0;
                SqlCommand cmd = new SqlCommand("update hm_accounts set accountactive = 1" + "where accountaddress = '" + email + "'", conn);
                r = cmd.ExecuteNonQuery();
                conn.Close();
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserBO_DisableEmail :" + ex.Message.ToString()));
            }
        }
        public int ChangePassword(string email, string oldPassword, string newPassword)
        {
            try
            {
                int Return = 0;
                string strConn = ConfigurationManager.ConnectionStrings["HMailServerDB"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update hm_accounts set accountpassword = '" + newPassword + "' where accountaddress = '" + email + "' and accountpassword = '" + oldPassword + "'", conn);
                Return = cmd.ExecuteNonQuery();

                conn.Close();
                return Return;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserBO_ChangePassword :" + ex.Message.ToString()));
            }
        }


        private string CheckAvaiableUsername(string UsernameNotCheck, string Domain)
        {
            string strConn = ConfigurationManager.ConnectionStrings["HMailServerDB"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            //string connString = "Data Source=113.190.40.40,1807;Initial Catalog=HmailServerDB;User ID=appserver;Password=nhakhachChinhPhu2lethach";
    

            string cmd = "select accountaddress from hm_accounts where accountaddress like '%" + UsernameNotCheck + "%'";
            
            DataSet ds = new DataSet("temp");
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd, conn);
            myAdapter.Fill(ds, "temp");

            if (ds.Tables[0].Rows.Count > 0)
            {
                int num = ds.Tables[0].Rows.Count + 1;
                return UsernameNotCheck + num  ;
            }
            else
            {
                return UsernameNotCheck ;
            }
        }
        public string GetAvaiableUsername(string Name, string Domain)
        {
            string UsernameNotCheck = string.Empty;
            string UsernameAvaiable = string.Empty;

            try
            {
                UsernameNotCheck = Library.StringUtility.CreateUsername(Name);
                UsernameAvaiable = this.CheckAvaiableUsername(UsernameNotCheck, Domain);
                return UsernameAvaiable;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("SystemUserBO_CreateEmail :" + ex.Message.ToString()));
            }

        }
        //------------------------------------------------------------------------------------------

    }
}
