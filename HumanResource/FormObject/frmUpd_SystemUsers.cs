using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using System.Globalization;

namespace HumanResource
{
    public partial class frmUpd_SystemUsers : DevExpress.XtraEditors.XtraForm
    {
        SystemUsersBO aSysUserBO = new SystemUsersBO();
        public string username = "";
        public frmMain afrmMain_old;
        private frmLst_SystemUsers afrmLst_SystemUsers_Old;
        private int ID_Old;
        private IFormatProvider culture = new CultureInfo("es-ES", true);
        public frmUpd_SystemUsers(frmLst_SystemUsers afrmLst_SystemUsers, int ID)
        {
            InitializeComponent();
            ID_Old = ID;
            afrmLst_SystemUsers_Old = afrmLst_SystemUsers;
        }
        public frmUpd_SystemUsers(frmMain afrmMain)
        {
            InitializeComponent();
            afrmMain_old = afrmMain;
        }

        #region Xử lý Ảnh
        public void SearchImage() 
        {
            UploadImage = new OpenFileDialog();
            UploadImage.Filter = UploadImage.Filter = "JPG files (*.jpg)|*.jpg|All file (*.*)|*.*";
            UploadImage.FilterIndex = 1;
            UploadImage.RestoreDirectory = true;
            DialogResult result = UploadImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureNV.Image = Image.FromFile(UploadImage.FileName);
                txtImage.Text = System.IO.Path.GetFileName(UploadImage.FileName);
                System.IO.Directory.SetCurrentDirectory(Application.StartupPath+"/Pictures");
            }
        }

        public void SaveImage()
        {
            saveImage.FileName = txtImage.Text;
            if (saveImage.FileName!="")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveImage.OpenFile();

                this.pictureNV.Image.Save(fs,System.Drawing.Imaging.ImageFormat.Jpeg);

                fs.Close();
              }
         }

        
        #endregion

        /*------Hàm trả về thông tin User------*/
        public void SetInfoUser(List<SystemUsers> aSysUser)
        {
            txtUsername.Text=aSysUser[0].Username;
            cbxSysUserGroup.EditValue = aSysUser[0].UserGroup;
            txtHo.Text= aSysUser[0].Name.Split(' ')[0];
            txtTen.Text = aSysUser[0].Name.Remove(0, aSysUser[0].Name.IndexOf(" ") + 1);
            txtEmail.Text = aSysUser[0].Email.Split('@')[0];
            cbxEmail.EditValue = aSysUser[0].Email.Remove(0, aSysUser[0].Email.LastIndexOf("@"));
            txtBirthday.Text = aSysUser[0].Birthday.ToString();
            //txtImage.Text = aSysUser[0].Image;
            pictureNV.Image = Image.FromFile(Application.StartupPath + "/Pictures/"
                    + txtImage.Text);
            //cbxQue.SelectedItem = aSysUser[0].Hometown;
            //txtMaBH.Text = aSysUser[0].InsuranceNumber;
            //txtNamCtac.Text = aSysUser[0].YearJob.ToString();
            //txtNam.Text = aSysUser[0].YearUnemploymentInsurance;
            //txtBacLuong.Text = aSysUser[0].YearPayroll.ToString();
            cbxType.EditValue = aSysUser[0].Type;
            cbxStatus.EditValue = aSysUser[0].Status;
        }
        /*------------------------*/
        private void bnUpload_Click(object sender, EventArgs e)
        {
            SearchImage();
            SaveImage();
        }

        private void bnExit_Click(object sender, EventArgs e)
        {
            //afrmMain_old.Reload();
            this.Close();
           
        }

        private void bnComfirm_Click(object sender, EventArgs e)
        {
            List<SystemUsers> aListSysUsers = aSysUserBO.Select_ByName(txtUsername.Text);
            foreach (var aSysUsers in aListSysUsers)
            {
                aSysUsers.Username = txtUsername.Text;
                aSysUsers.UserGroup = int.Parse(cbxSysUserGroup.SelectedItem.ToString());
                aSysUsers.Name = txtHo.Text + " " + txtTen.Text;
                aSysUsers.Email = txtEmail.Text + "" + cbxEmail.SelectedItem.ToString();
                aSysUsers.Birthday = DateTime.ParseExact(txtBirthday.Text,"dd/MM/yyyy",culture);
                //aSysUsers.Birthday = DateTime.ParseExact(txtBirthday.Text, "dd/MM/yyyy", culture);
                //aSysUsers.BirthPlace = txtNoiSinh.Text;
                //aSysUsers.Image = txtImage.Text;
                //aSysUsers.Hometown = cbxQue.SelectedItem.ToString();
                //aSysUsers.Address = txtDiaChi.Text;
                //aSysUsers.YearJob = int.Parse(txtNamCtac.Text);
                //aSysUsers.InsuranceNumber = txtMaBH.Text;
                //aSysUsers.YearPayroll = int.Parse(txtBacLuong.Text);
                //aSysUsers.YearUnemploymentInsurance = txtNam.Text;
                aSysUsers.IDRefAnotherSystem = 1;
                aSysUsers.IDRefMailSystem = 1;
                aSysUsers.Type = int.Parse(cbxType.SelectedItem.ToString());
                aSysUsers.Status = int.Parse(cbxStatus.SelectedItem.ToString());
                int ret = aSysUserBO.Update(aSysUsers);
                if (ret == 1)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else { MessageBox.Show("Thất bại"); }
            }
     
        }

        private void frmUpd_SystemUsers_Load(object sender, EventArgs e)
        {

        }

        /*-----------------hàm đổ dữ liệu vào combobox----------------------*/
        //public void FillCombobox()
        //{

        //    List<SystemUsers> alist = aSysUserBO.Sel_all();

        //    for (int i = 0; i < alist.Count; i++)
        //    {

        //        cbxSysUserGroup.Properties.Items.Add(new ImageComboBoxItem(alist[i].Name, alist[i].ID, i));
        //    }
        //}
        /*-------------------------------------------------------------------*/
    }
}