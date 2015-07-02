using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BussinessLogic;
using DataAccess;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Library;
using Entity;
using CORESYSTEM;

namespace SaleManagement
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
        frmMain afrmMain = new frmMain();
        public frmLogin(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        private void bnLogin_Click(object sender, EventArgs e)
        {

                if (CORE.Login_WinForm(txtUserName.Text, txtPassword.Text) == true)
                {
                    if (CORE.CheckPermit_WinForm(afrmMain) == true)
                    {
                        afrmMain.Reload();
                        afrmMain.Show();
                        this.Close();
                    }

                }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CORE.Login_WinForm(txtUserName.Text, txtPassword.Text) == true)
                {

                    if (CORE.CheckPermit_WinForm(afrmMain) == true)
                    {
                        afrmMain.Reload();
                        afrmMain.Show();
                        this.Close();
                    }

                }
            }  
        }
    }
}