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

namespace RoomManager
{
    public partial class frmLst_Permits : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        PermitsBO aPermitsBO = new PermitsBO();
        public frmLst_Permits()
        {
            InitializeComponent();
        }

        public void frmLst_Permits_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPermits.DataSource = aPermitsBO.Select_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Permits.Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_Permits afrmIns_Permits = new frmIns_Permits(this);
            afrmIns_Permits.Show();
        }
        public void Reload()
        {
            try
            {
                dgvPermits.DataSource = aPermitsBO.Select_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Permits.ReLoad\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDPermit = int.Parse(grvPermits.GetFocusedRowCellValue("ID").ToString());
            aPermitsBO.Delete(IDPermit);
            this.Reload();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDPermit = int.Parse(grvPermits.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Permits afrmUpd_Permits = new frmUpd_Permits(IDPermit, this);
            afrmUpd_Permits.ShowDialog();
        }
    }
}