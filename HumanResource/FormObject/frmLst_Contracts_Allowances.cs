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
using DevExpress.Utils;
namespace HumanResource
{
    public partial class frmLst_Contracts_Allowances : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_Contracts_Allowances()
        {
            InitializeComponent();
        }

        
        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Convert.ToInt32(viewContracts_Allowances.GetFocusedRowCellValue("Contracts_Allowances_ID"));
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    Contracts_AllowancesBO aContracts_AllowancesBO = new Contracts_AllowancesBO();
                    aContracts_AllowancesBO.Delete(ID);
                    MessageBox.Show("Bạn đã xóa dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmLst_Contracts_Allowances.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ReloadData();
        }

        public void ReloadData()
        {
            try
            {
                Contracts_AllowancesBO aContracts_AllowancesBO = new Contracts_AllowancesBO();

                colSalaryPlus.DisplayFormat.FormatType = FormatType.Numeric;
                colSalaryPlus.DisplayFormat.FormatString = "{0:0,0}";
                colContracts_Allowances_RealSalaryPlus.DisplayFormat.FormatType = FormatType.Numeric;
                colContracts_Allowances_RealSalaryPlus.DisplayFormat.FormatString = "{0:0,0}";

                dgvContracts_Allowances.DataSource = aContracts_AllowancesBO.Select_ByContractsAllowances_Disable(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts_Allowances.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLst_Contracts_Allowances_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts_Allowances.frmLst_Contracts_Allowances_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Contracts_Allowances afrmIns_Contracts_Allowances = new frmIns_Contracts_Allowances(this);
                afrmIns_Contracts_Allowances.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts_Allowances.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisable_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Convert.ToInt32(viewContracts_Allowances.GetFocusedRowCellValue("Contracts_Allowances_ID"));
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiên ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    Contracts_AllowancesBO aContracts_AllowancesBO = new Contracts_AllowancesBO();
                    Contracts_Allowances aContracts_Allowances = aContracts_AllowancesBO.Select_ByID(ID);
                    aContracts_Allowances.Disable = true;
                    aContracts_AllowancesBO.Update(aContracts_Allowances);
                    MessageBox.Show("Bạn đã thực hiên thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmLst_Contracts_Allowances.btnDisable_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ReloadData();
        }
    }
}