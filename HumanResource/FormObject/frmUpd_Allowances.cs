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
using CORESYSTEM;
using BussinessLogic;
using DataAccess;

namespace HumanResource
{
    public partial class frmUpd_Allowances : DevExpress.XtraEditors.XtraForm
    {
        AllowancesBO aAllowancesBO = new AllowancesBO();
        int ID_Old;
        frmLst_Allowances afrmLst_Allowances_Old = null;
        public frmUpd_Allowances(int ID, frmLst_Allowances afrmLst_Allowances)
        {
            InitializeComponent();
           this.ID_Old = ID;
           this.afrmLst_Allowances_Old = afrmLst_Allowances;
        }

        private void frmUpd_Allowance_Load(object sender, EventArgs e)
        {
            try
            {
                Allowances aAllowances = aAllowancesBO.Select_ByID(ID_Old);
                lueContractType.Properties.DataSource = CORE.CONSTANTS.ListContractTypes;
                lueContractType.Properties.DisplayMember = "Name";
                lueContractType.Properties.ValueMember = "ID";

                lueContractType.EditValue = aAllowances.ContractType;

                txtSalaryPlus.EditValue = aAllowances.SalaryPlus;

                cbbDisable.Text = Convert.ToString(aAllowances.Disable);

                cbbStatus.Text = Convert.ToString(aAllowances.Status);

                cbbType.Text = Convert.ToString(aAllowances.Type);

                lblID.Text = Convert.ToString(ID_Old);
                dtpCreateDate.DateTime = aAllowances.CreatedDate.GetValueOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Allowances.frmUpd_Allowance_Load \n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
              

        private bool ValidateData()
        {
            if (txtSalaryPlus.Text == "")
            {
                MessageBox.Show("Nhập trợ cấp trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpCreateDate.Text == "")
            {
                MessageBox.Show("Chọn ngày tạo trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(cbbType.Text))
            {
                MessageBox.Show("Chọn Loại trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    Allowances aAllowances = new Allowances();
                    aAllowances.ID = ID_Old;
                    aAllowances.SalaryPlus = Convert.ToDecimal(txtSalaryPlus.EditValue);
                    aAllowances.CreatedDate = dtpCreateDate.DateTime;
                    aAllowances.ContractType = Convert.ToInt32(lueContractType.EditValue);
                    //tqtrung
                    aAllowances.Type =Convert.ToInt32(cbbType.Text);
                    //end
                    aAllowances.Disable = bool.Parse(cbbDisable.Text);
                    aAllowances.Status = int.Parse(cbbStatus.Text);
                    aAllowancesBO.Update(aAllowances);
                    if (this.afrmLst_Allowances_Old != null)
                    {
                        this.afrmLst_Allowances_Old.Reload();
                    }
                   
                    MessageBox.Show("Sửa thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Allowances.btnEdit \n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    
    }
}