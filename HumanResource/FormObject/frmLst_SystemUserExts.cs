using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using BussinessLogic;

namespace HumanResource
{
    public partial class frmLst_SystemUserExts : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_SystemUserExts()
        {
            InitializeComponent();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
                int ID = Convert.ToInt32(viewSystemUserExts.GetFocusedRowCellValue("ID"));
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    try
                    {
                        SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
                        aSystemUserExtsBO.Delete(ID);
                        MessageBox.Show("Bạn đã xóa dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("frmLst_SystemUserExts.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadData();
          
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewSystemUserExts.GetFocusedRowCellValue("ID"));
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    try
                    {
                        SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
                        SystemUserExts aSystemUserExts = aSystemUserExtsBO.Select_ByID(ID);
                        aSystemUserExts.Disable = true;
                        aSystemUserExtsBO.Update(aSystemUserExts);
                        MessageBox.Show("Cập nhật dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("frmLst_SystemUserExts.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUserExts.btnEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            try
            {
                SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
                dgvSystemUserExts.DataSource = aSystemUserExtsBO.Select_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUserExts.LoadData\n"+ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLst_SystemUserExts_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUserExts.frmLst_SystemUserExts_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}