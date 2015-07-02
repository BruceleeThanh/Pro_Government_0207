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
    public partial class frmLst_TableSalaries : DevExpress.XtraEditors.XtraForm
    {
        
        
        public frmLst_TableSalaries()
        {
            InitializeComponent();
        }
        public void Reload()
        {
            try
            {
                TableSalariesBO aTableSalariesBO = new TableSalariesBO();
                GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
                GroupTableSalaries aGroupTableSalaries = aGroupTableSalariesBO.Select_ByDisable();
                if (aGroupTableSalaries !=null)
                {
                    List<TableSalaries> aList = aTableSalariesBO.Select_ByIDGroupTableSalaries(aGroupTableSalaries.ID);
                    dgvTableSalaries.DataSource = aList;
                    dgvTableSalaries.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_TableSalaries.Reload\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmLst_TableSalaries_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmIns_ScaleOfSalaries afrmIns_ScaleOfSalaries = new frmIns_ScaleOfSalaries(this);
            afrmIns_ScaleOfSalaries.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmIns_TableSalaries afrmIns_TableSalaries = new frmIns_TableSalaries(this);
            afrmIns_TableSalaries.ShowDialog();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvTableSalaries.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Scale0fSalaries afrmUpd_Scale0fSalaries = new frmUpd_Scale0fSalaries(ID, this);
            afrmUpd_Scale0fSalaries.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                TableSalariesBO aTableSalariesBO = new TableSalariesBO();
                int ID = int.Parse(grvTableSalaries.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa TableSalaries " + ID + " này không?", "Xóa TableSalaries", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aTableSalariesBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_TableSalaries.btnDelete_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvTableSalaries_Click(object sender, EventArgs e)
        {

        }
    }
}