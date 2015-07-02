using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using System.Collections.Generic;


namespace RoomManager
{
    public partial class frmLst_SystemUsers : DevExpress.XtraEditors.XtraForm
    {
       
        SystemUsersBO aSysUserBO = new SystemUsersBO();

        public frmLst_SystemUsers()
        {
            InitializeComponent();
            AutoComplete();
        }

       

        private void frmSystemUser_Load(object sender, EventArgs e)
        {
            dgvSysUsers.DataSource = aSysUserBO.Select_All();
        }

        public void AutoComplete()
        {
            List<string> alist = aSysUserBO.Sel_all_Name();
            AutoCompleteStringCollection list = new AutoCompleteStringCollection();
            if (alist != null)
            {
                for (int i = 0; i < alist.Count; i++)
                {
                    list.Add(alist[i].ToString());
                }
            }

            txtSearch.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.MaskBox.AutoCompleteCustomSource = list;
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            dgvSysUsers.DataSource = aSysUserBO.Select_ByName(txtSearch.Text);
        }
        public void Reload()
        {
            dgvSysUsers.DataSource = aSysUserBO.Select_All();
        }
       

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvSystemUser.GetFocusedRowCellValue("ID").ToString());
            frmUpd_SystemUsers afrmUpd_SystemUsers = new frmUpd_SystemUsers(this, ID);
            afrmUpd_SystemUsers.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvSystemUser.GetFocusedRowCellValue("ID").ToString());
            string Name = aSysUserBO.Select_ByID(ID).Name;

            DialogResult result = MessageBox.Show("Bạn có muốn xóa công ty " + Name + " này không?", "Xóa công ty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aSysUserBO.Delete(ID);
                MessageBox.Show("Xóa thành công");
                this.Reload();
            }           
        }

        

    }
}