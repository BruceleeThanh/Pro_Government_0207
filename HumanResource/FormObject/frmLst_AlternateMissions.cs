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
using BussinessLogic;
using DataAccess;


namespace HumanResource
{
    public partial class frmLst_AlternateMissions : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_AlternateMissions()
        {
            InitializeComponent();
        }

        private void frmLst_AlternateMissions_Load(object sender, EventArgs e)
        {
            try
            {
                this.Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_AlternateMissions.frmLst_AlternateMissions_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Reload()
        {
            try
            {
                AlternateMissionsBO aAlternateMissionsBO = new AlternateMissionsBO();
                dgvAlternateMissions.DataSource = aAlternateMissionsBO.SelectDetail_All();
                dgvAlternateMissions.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_AlternateMissions.Reload\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_AlternateMissions afrmIns_AlternateMissions = new frmIns_AlternateMissions(this);
                afrmIns_AlternateMissions.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_AlternateMissions.btnAdd_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(grvAlternateMissions.GetFocusedRowCellValue("ID"));
                frmUpd_AlternateMissions afrmUpd_AlternateMissions = new frmUpd_AlternateMissions(ID, this);
                afrmUpd_AlternateMissions.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_AlternateMissions.btnEdit_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = int.Parse(grvAlternateMissions.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa AlternateMissions " + ID + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AlternateMissionsBO aAlternateMissionsBO = new AlternateMissionsBO();
                    int count = aAlternateMissionsBO.Delete(ID);
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_AlternateMissions.btnDelete_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}