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
    public partial class frmUpd_Contracts : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Contracts afrmLst_Contracts = null;
        private int ID;
        public frmUpd_Contracts(frmLst_Contracts afrmLst_Contracts, int ID)
        {
            InitializeComponent();
            this.afrmLst_Contracts = afrmLst_Contracts;
            this.ID = ID;
        }

        private void frmUpd_Contracts_Load(object sender, EventArgs e)
        {
            try
            {
                ContractsBO aContractsBO = new ContractsBO();
                Contracts aContracts = aContractsBO.Select_ByID(ID);
                txtNumberContract.Text = aContracts.NumberContract.ToString();
                txtNumberTemplateContract.Text = aContracts.NumberTemplateContract.ToString();
                dtpContractDate.EditValue = aContracts.ContractDate;
                txtCompany.Text = aContracts.Company.ToString();
                txtStatutoryRepresent.Text = aContracts.StatutoryRepresent.ToString();
                txtStatutoryRepresentGender.Text = aContracts.StatutoryRepresentGender.ToString();
                txtStatutoryRepresentIdentifier.Text = aContracts.StatutoryRepresentIdentifier.ToString();
                txtContractType.Text = aContracts.ContractType.ToString();

                dtpFrom.EditValue = aContracts.FromDate;
                dtpTo.EditValue = aContracts.ToDate;
            
                txtSkuTableSalary.Text = aContracts.SkuTableSalary.ToString();
                txtCoefficent.Text = String.Format("{0:0,0}",aContracts.Coefficent);
                txtSalaryNet.Text = String.Format("{0:0,0}",aContracts.SalaryNet);
                txtSalaryCross.Text = String.Format("{0:0,0}",aContracts.SalaryCross);
                cboType.SelectedIndex = Convert.ToInt32(aContracts.Type - 1);
                cboStatus.SelectedIndex = Convert.ToInt32(aContracts.Status - 1);
                cboDisable.Text = aContracts.Disable.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Contracts.frmUpd_Contracts_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        public bool CheckDataBeforUpdate()
        {
            try
            {
 
                if (dtpFrom.EditValue == null)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtpContractDate.EditValue == null)
                {
                    dtpContractDate.Focus();
                    MessageBox.Show("Vui lòng chọn ngày ký hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (dtpTo.EditValue == null)
                {
                    dtpTo.Focus();
                    MessageBox.Show("Vui lòng chọn ngày kết thúc hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (dtpFrom.DateTime.Date >= dtpTo.DateTime.Date)
                {
                    dtpTo.Focus();
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu hợp đồng phải nhỏ hơn ngày kết thúc hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts.CheckDataBeforInsert\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforUpdate() == true)
                {
                    ContractsBO aContractsBO = new ContractsBO();
                    Contracts aContracts = aContractsBO.Select_ByID(ID);
                    aContracts.ContractDate =dtpContractDate.DateTime;
                    aContracts.NumberContract = txtNumberContract.Text;
                    aContracts.NumberTemplateContract = txtNumberTemplateContract.Text;
                    aContracts.Company = txtCompany.Text;
                    aContracts.StatutoryRepresent = txtStatutoryRepresent.Text;
                    aContracts.StatutoryRepresentGender = Convert.ToInt32(txtStatutoryRepresentGender.Text);
                    aContracts.StatutoryRepresentIdentifier = txtStatutoryRepresentIdentifier.Text;
                    aContracts.ContractType = Convert.ToInt32(txtContractType.Text);
                    aContracts.FromDate =dtpFrom.DateTime;
                    aContracts.ToDate =dtpTo.DateTime;
                    aContracts.SkuTableSalary = Convert.ToInt32(txtSkuTableSalary.Text);
                    aContracts.Coefficent = Convert.ToDouble(txtCoefficent.Text);
                    aContracts.SalaryNet = Convert.ToDecimal(txtSalaryNet.Text);
                    aContracts.SalaryCross = Convert.ToDecimal(txtSalaryCross.Text);
                    aContracts.Type = cboType.SelectedIndex + 1;
                    aContracts.Status = cboStatus.SelectedIndex + 1;
                    aContracts.Disable = Convert.ToBoolean(cboDisable.Text);
                    aContractsBO.Update(aContracts);

                    if (this.afrmLst_Contracts != null)
                    {
                        this.afrmLst_Contracts.ReloadData();
                    }

                    MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Contracts.btnSave_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}