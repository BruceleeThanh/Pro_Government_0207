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
    public partial class frmLst_PermitDetails : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        PermitDetailsBO aPermitDetailsBO = new PermitDetailsBO();
        public frmLst_PermitDetails()
        {
            InitializeComponent();
        }

        private void frmLst_PermitDetails_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPermitDetail.DataSource = aPermitDetailsBO.Select_All();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_PermitDetails.Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void Reload()
        {
            dgvPermitDetail.DataSource = aPermitDetailsBO.Select_All();
            dgvPermitDetail.RefreshDataSource();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = int.Parse(grvPermitDetail.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa permitdetail " + ID + " này không?", "Xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aPermitDetailsBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_PermitDetails.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_PermitDetail afrmIns_PermitDetail = new frmIns_PermitDetail(this);
            afrmIns_PermitDetail.ShowDialog();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvPermitDetail.GetFocusedRowCellValue("ID").ToString());
            frmUpd_PermitDetail afrmUpd_PermitDetail = new frmUpd_PermitDetail(ID, this);
            afrmUpd_PermitDetail.ShowDialog();
        }

    }
}