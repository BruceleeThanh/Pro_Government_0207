using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entity;
using BussinessLogic;
using Library;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;


namespace CORESYSTEM
{
    public class CORE_SYSTEMUSER
    {
        public  SystemUsers SystemUser ;
        public  SystemUserExts SystemUserExts;
        public  List<PermitViewAllEN> ListPermitViewAll;


    }
    public class CORE_SYSTEM
    {
        public  string SystemKey = ""; //RoomManager
        public List<Configs> ListConfig;
    }
    


    public static class CORE
    {
        public static ConstantsXML CONSTANTS = new ConstantsXML();
        public static CORE_SYSTEMUSER CURRENTUSER = new CORE_SYSTEMUSER();
        public static CORE_SYSTEM SYSTEM = new CORE_SYSTEM();
    
        private static string GetFormName(Form aForm)
        {
            int a1 = (CORE.SYSTEM.SystemKey+".").ToString().Length;
            
            int a2 = aForm.Name.IndexOf(", Text:");
            string Name;
            if (a2 > 1)
            {
                Name = aForm.Name.Substring(a1 - 1, a2);
            }
            else
            {
                Name = aForm.Name;
            }
            return Name;
        }

        public static void INIT(string SystemKey)
        {
            CORE.SYSTEM.SystemKey = SystemKey;
            ConfigsBO aConfigsBO = new ConfigsBO();

            CORE.SYSTEM.ListConfig = aConfigsBO.Select_All().Where(p => p.Group == CORE.SYSTEM.SystemKey.ToString()).ToList();
            CORE.CONSTANTS.LoadAllConstant();
        }
        private static bool Login(string UserName, string Password)
        {
            try
            {
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();

                SystemUsers aSystemUsers = aSystemUsersBO.CheckAccount(UserName, Password);

                if (aSystemUsers != null)
                {
                    if (aSystemUsers.Disable == true)
                    {
                        throw new Exception("Bạn đang bị tạm khóa toàn hệ thống với lý do:[Chưa rõ]");
                    }
                    else
                    {

                        PermitsBO aPermitsBO = new PermitsBO();
                        CORE.CURRENTUSER.ListPermitViewAll = aPermitsBO.GetAllInfoLogin_ByUsername(aSystemUsers.Username)
                            .Where(p => p.Permits_SystemUsers_Disable == false)
                            .Where(p => p.Permits_Disable == false)
                            .Where(p => p.PermitDetails_Disable == false)
                            .Where(p => p.Permits_SystemKey == CORE.SYSTEM.SystemKey).ToList();

                        if (CORE.CURRENTUSER.ListPermitViewAll.Count == 0)
                        {
                            throw new Exception("Bạn không đủ quyền vào phần mềm này");
                        }
                        else
                        {
                            CORE.CURRENTUSER.SystemUser = aSystemUsers;
                            return true;
                        }

                    }

                }
                else
                {
                    throw new Exception("Sai username hoặc password");
                }
            }
            catch (Exception eee)
            {
                throw eee;
            }
        }

        private static bool CheckPermit(Form aForm)
        {

            string PageOrForm = CORE.GetFormName(aForm);


            try
            {

                if (string.IsNullOrEmpty(CORE.CURRENTUSER.SystemUser.Username) != true)
                {

                    SystemUsers aSystemUsers = CORE.CURRENTUSER.SystemUser;
                    if (aSystemUsers != null)
                    {
                        if (aSystemUsers.Disable == true)
                        {
                            throw new Exception("Bạn đang bị tạm khóa toàn hệ thống với lý do:[Chưa xác định]");

                        }
                        else
                        {
                            if (CORE.CURRENTUSER.ListPermitViewAll.Count == 0)
                            {
                                throw new Exception("Bạn không đủ quyền vào phần mềm này");
                            }
                            else
                            {
                                List<PermitViewAllEN> aList = CORE.CURRENTUSER.ListPermitViewAll.Where(p => p.PermitDetails_PageURL == PageOrForm).ToList();
                                if (aList.Count() > 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    throw new Exception("Bạn không đủ quyền vào Form này");
                                }
                            }

                        }

                    }
                    else
                    {
                        throw new Exception("Sai username hoặc password");
                    }
                }
                else
                {
                    throw new Exception("Bạn chưa đăng nhập");
                }
            }
            catch (Exception eee)
            {
                throw eee;
                
            }
        }

        public static bool Login_WinForm(string UserName, string Password)
        {
            try
            {
               return Login(UserName,  Password);

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                return false;
            }
        }

        public static bool CheckPermit_WinForm(Form aForm)
        {
            try
            {
                return CheckPermit(aForm);
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
                aForm.Dispose();
                return false;
            }
        }

        public static bool Login_Service(string UserName, string Password)
        {
            try
            {
                return Login(UserName, Password);

            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public static bool CheckPermit_Service(Form aForm)
        {
            try
            {
                return CheckPermit(aForm);
            }
            catch (Exception eee)
            {
                throw eee;
            }
        }
    }
}
