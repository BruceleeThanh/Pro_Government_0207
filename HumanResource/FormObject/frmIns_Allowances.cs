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
using CORESYSTEM;

namespace HumanResource
{
    public partial class frmIns_Allowance : DevExpress.XtraEditors.XtraForm
    {
        AllowancesBO aAllowancesBO = new AllowancesBO();
        private frmLst_Allowances afrmLst_Allowances_Old =null;
        public frmIns_Allowance()
        {
            InitializeComponent();
        }
        public frmIns_Allowance(frmLst_Allowances afrmLst_Allowances)
        {
            InitializeComponent();
            afrmLst_Allowances_Old = afrmLst_Allowances;
        }

        private bool ValidateData()
        {
            if (txtSalaryPlus.Text == "")
            {
                MessageBox.Show("Nhập trợ cấp trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpCreateDate.Text == "")
            {
                MessageBox.Show("Chọn ngày tạo trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    Allowances aAllowances = new Allowances();
                    aAllowances.SalaryPlus =Convert.ToDecimal(txtSalaryPlus.EditValue);
                    aAllowances.CreatedDate =dtpCreateDate.DateTime;
                    aAllowances.ContractType = Convert.ToInt32(lueContractType.EditValue);
                    aAllowances.Disable = bool.Parse(cbbDisable.Text);
                    aAllowances.Status = int.Parse(cbbStatus.Text);
                    aAllowances.Type = int.Parse(cbbType.Text);
                    aAllowancesBO.Insert(aAllowances);
                    if (this.afrmLst_Allowances_Old != null)
                    {
                        this.afrmLst_Allowances_Old.Reload();
                    }

                    MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Allowance.btnAddNew_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmIns_Allowance_Load(object sender, EventArgs e)
        {
            lueContractType.Properties.DataSource = CORE.CONSTANTS.ListContractTypes;
            lueContractType.Properties.DisplayMember = "Name";
            lueContractType.Properties.ValueMember = "ID";
            lueContractType.EditValue = CORE.CONSTANTS.SelectedContractType(1).ID;
        }

     
    }
}