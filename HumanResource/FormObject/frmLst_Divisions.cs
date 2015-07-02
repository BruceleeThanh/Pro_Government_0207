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
    public partial class frmLst_Divisions : DevExpress.XtraEditors.XtraForm
    {
        
        public frmLst_Divisions()
        {
            InitializeComponent();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Convert.ToInt32(viewDivisions.GetFocusedRowCellValue("ID"));
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    DivisionsBO aDivisionBO = new DivisionsBO();
                    aDivisionBO.Delete(ID);
                    MessageBox.Show("Bạn đã xóa dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmLst_Divisions.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ReloadData();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewDivisions.GetFocusedRowCellValue("ID"));
                frmUpd_Divisions afrmUpd_Divisions = new frmUpd_Divisions(this, ID);
                afrmUpd_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Divisions.btnEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ReloadData()
        {
            try
            {
                DivisionsBO aDivisionBO = new DivisionsBO();
                dgvDivisions.DataSource = aDivisionBO.Select_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Divisions.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLst_Divisions_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Divisions.frmLst_Divisions_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Divisions afrmIns_Divisions = new frmIns_Divisions(this);
                afrmIns_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Divisions.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}