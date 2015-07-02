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
using DevExpress.Utils;


namespace HumanResource
{
    public partial class frmLst_Allowances : DevExpress.XtraEditors.XtraForm
    {
       
        public frmLst_Allowances()
        {
            InitializeComponent();
        }

        private void frmLst_Allowances_Load(object sender, EventArgs e)
        {
           this.Reload();
        }
        public void Reload()
        {
            AllowancesBO aAllowancesBO = new AllowancesBO();
            colSalaryPlus.DisplayFormat.FormatType = FormatType.Numeric;
            colSalaryPlus.DisplayFormat.FormatString = "{0:0,0}";
            dgvAllowances.DataSource = aAllowancesBO.Select_All();
            dgvAllowances.RefreshDataSource();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_Allowance afrmIns_Allowance = new frmIns_Allowance(this);
            afrmIns_Allowance.ShowDialog();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvAllowance.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Allowances afrmUpd_Allowances = new frmUpd_Allowances(ID, this);
            afrmUpd_Allowances.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                AllowancesBO aAllowancesBO = new AllowancesBO();
                int ID = int.Parse(grvAllowance.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa Allowance " + Name + " này không?", "Xóa Allowance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aAllowancesBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Allowances.btnDelete_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}