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

namespace HumanResource
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {

        SystemUsersBO aSystemUsersBO = new SystemUsersBO();

       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void bnLogin_Click(object sender, EventArgs e)
        {
            //if (Login() != null)
            //{
            //    this.Hide();
            //    splashScreenManager1.ShowWaitForm();
            //    Thread.Sleep(1000);
            //    splashScreenManager1.CloseWaitForm();
            //    frmMain afrmMain = new frmMain();
            //    afrmMain.InfoUser(txtUserName.Text);
            //    afrmMain.ShowDialog();
            //    this.Close();
            //}

           login();
           

        }
        public void login()
        {
            if (CORE.Login_WinForm(txtUserName.Text, txtPassword.Text) == true)
            {
                frmMain afrmMain = new frmMain(this);
                if (CORE.CheckPermit_WinForm(afrmMain) == true)
                {
                  
                    afrmMain.Show();
                   
                }
               
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
           
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }  
        }

    }
}