using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using Library;

namespace HumanResource
{
    public partial class frmIns_SystemUsers : DevExpress.XtraEditors.XtraForm
    {
        SystemUsersBO aSysUserBO = new SystemUsersBO();
        SystemUsers aSysUser=new SystemUsers();
        public frmLogin afrmLogin_old;

        public frmIns_SystemUsers()
        {
            InitializeComponent();
        }
        public frmIns_SystemUsers(frmLogin afrmLogin)
        {
            InitializeComponent();
            Refesh();
            afrmLogin_old = afrmLogin;
        }

        private string s;
        public String GetCapcha()
        {
            Random rand = new Random();
            string s= StringUtility.md5(rand.Next().ToString());
            s = s.Substring(s.Length-4);
            return s;

        }

        private Bitmap DrawCapchaImg(string s)
        {
            Bitmap bm = new Bitmap(234,66);
            Graphics gp = Graphics.FromImage(bm);
            SolidBrush sb = new SolidBrush(Color.White);
            gp.FillRectangle(sb,0,0,234,66);
            System.Drawing.Font font = new Font("Arial", 25);

            sb=new SolidBrush(Color.Black);

            gp.DrawString(s, font, sb, (117 - 2 * font.Size), (33 - font.Size));

            int count = 0;
            Random rand = new Random();
            while (count < 1000)
            {
                gp.FillEllipse(sb, rand.Next(0, 234), rand.Next(0, 66), 2, 2);
                count++;
            }

            count = 0;

            while (count < 25)
            {
                gp.DrawLine(new Pen(Color.Black), rand.Next(0, 234), rand.Next(0, 66), rand.Next(0, 234), rand.Next(0, 66));
                count++;
            }
             
            return bm;
        }
        public void Refesh()
        {
            s=this.GetCapcha();

            txtCapcha.Text = "";

            panelControl2.ContentImage = DrawCapchaImg(s);
        }

        private void bnComfirm_Click(object sender, EventArgs e)
        {

        }

        private void frmAddSysUser_Load(object sender, EventArgs e)
        {

        }

        //private void bnComfirm_Click(object sender, EventArgs e)
        //{
        //    if (txtCapcha.Text == "") 
        //    {
        //        MessageBox.Show("Nhập lại mã xác thực");
        //    }
        //    if (txtCapcha.Text.ToUpper() == s.ToUpper())
        //    {
        //        aSysUser.Username = txtUserName.Text;
        //        aSysUser.Password = StringUtility.md5(txtPass.Text);
        //        int ret = aSysUserBO.Ins(aSysUser);
        //        if (ret == 1)
        //        {
        //            MessageBox.Show("Đăng ký thành công \n Cập nhật thông tin chi tiết trong trang chính");
        //            this.Hide();
        //            afrmLogin_old.GetText(txtUserName.Text,txtPass.Text);
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Lỗi!!");
        //        }

        //    }
        //}

        //private void bnRefesh_Click(object sender, EventArgs e)
        //{
        //    Refesh();
        //}

        //private void frmAddSysUser_Load(object sender, EventArgs e)
        //{

        //}
    }
}