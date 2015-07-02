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
    public partial class frmLst_GroupTableSalaries : DevExpress.XtraEditors.XtraForm
    {
        
        public frmLst_GroupTableSalaries()
        {
            InitializeComponent();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
                int ID = int.Parse(grvGroupTableSalaries.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa GroupTableSalaries " + ID + " này không?", "Xóa GroupTableSalaries", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aGroupTableSalariesBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_GroupTableSalaries.btnDelete_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvGroupTableSalaries.GetFocusedRowCellValue("ID").ToString());
            frmUpd_GroupTableSalaries afrmUpd_GroupTableSalaries = new frmUpd_GroupTableSalaries(ID, this);
            afrmUpd_GroupTableSalaries.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_GroupTableSalaries afrmIns_GroupTableSalaries = new frmIns_GroupTableSalaries(this);
            afrmIns_GroupTableSalaries.ShowDialog();

        }

        private void frmLst_GroupTableSalaries_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        public void Reload()
        {
            try
            {
                GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
                dgvGroupTableSalaries.DataSource = aGroupTableSalariesBO.Select_All();
                dgvGroupTableSalaries.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_GroupTableSalaries.Reload\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}