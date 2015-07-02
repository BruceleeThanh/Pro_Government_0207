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
using CORESYSTEM;
using Entity;

namespace HumanResource
{
    public partial class frmIns_Contracts : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Contracts afrmLst_Contracts = null;
        TableSalariesBO aTableSalariesBO = new TableSalariesBO();
        frmMain afrmMain = null;
        int IDSystemUser;

        public frmIns_Contracts()
        {
            InitializeComponent();
        }
        public frmIns_Contracts(int IDSystemUser, frmMain afrmMain)
        {
            InitializeComponent();
            this.IDSystemUser = IDSystemUser;
            this.afrmMain = afrmMain;

        }
        public frmIns_Contracts(frmLst_Contracts afrmLst_Contracts)
        {
            InitializeComponent();
            this.afrmLst_Contracts = afrmLst_Contracts;
        }

        //Hiennv
        public bool CheckDataBeforInsert()
        {
            try
            {

                if (Convert.ToInt32(lueSystemUser.EditValue) == 0)
                {
                    lueSystemUser.Focus();
                    MessageBox.Show("Vui lòng chọn tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtpContractDate.EditValue == null)
                {
                    dtpContractDate.Focus();
                    MessageBox.Show("Vui lòng chọn ngày ký hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtpFrom.EditValue == null)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (dtpTo.EditValue == null)
                {
                    dtpTo.Focus();
                    MessageBox.Show("Vui lòng chọn ngày kết thúc hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if(dtpFrom.DateTime.Date >= dtpTo.DateTime.Date)
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


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforInsert() == true)
                {

                    ContractsBO aContractsBO = new ContractsBO();
                    //Disable hợp đồng cũ
                    Contracts aContracts_Old = new Contracts();
                    List<Contracts> aLisTemp = aContractsBO.Select_ByIDSystemUser(Convert.ToInt16(lueSystemUser.EditValue));

                    if (aLisTemp!= null)
                    {
                        aContracts_Old = aLisTemp.Where(a => a.Disable == false).ToList()[0];
                        aContracts_Old.Disable = true;
                        aContractsBO.Update(aContracts_Old);
                    }
                    // Tạo hợp đồng mới
                    Contracts aContracts = new Contracts();
                    aContracts.CreatedDate = DateTime.Now;
                    aContracts.ContractDate = dtpContractDate.DateTime;
                    aContracts.NumberContract = txtNumberContract.Text;
                    aContracts.NumberTemplateContract = txtNumberTemplateContract.Text;
                    aContracts.IDSystemUser = Convert.ToInt32(lueSystemUser.EditValue);
                    aContracts.Company = txtCompany.Text;
                    aContracts.StatutoryRepresent = txtStatutoryRepresent.Text;
                    aContracts.StatutoryRepresentGender = Convert.ToInt32(lueStatutoryRepresentGender.EditValue);
                    aContracts.StatutoryRepresentIdentifier = txtStatutoryRepresentIdentifier.Text;
                    aContracts.ContractType = Convert.ToInt32(lueContractType.EditValue);
                    aContracts.FromDate =dtpFrom.DateTime;
                    aContracts.ToDate = dtpTo.DateTime;

                    int SkuTableSalary = txtSkuTableSalary.Text.Length == 0 ? 0 : Convert.ToInt32(txtSkuTableSalary.Text);
                    double Coefficent = txtCoefficent.Text.Length == 0 ? 0 : Convert.ToDouble(txtCoefficent.Text);
                    decimal SalaryNet = txtSalaryNet.Text.Length == 0 ? 0 : Convert.ToDecimal(txtSalaryNet.Text);
                    decimal SalaryCross = txtSalaryCross.Text.Length == 0 ? 0 : Convert.ToDecimal(txtSalaryCross.Text);

                    aContracts.SkuTableSalary = SkuTableSalary;
                    aContracts.Coefficent = Coefficent;
                    aContracts.SalaryNet = SalaryNet;
                    aContracts.SalaryCross = SalaryCross;

                    aContracts.Type = Convert.ToInt32(lueType.EditValue);
                    aContracts.Status = cboStatus.SelectedIndex + 1;
                    aContracts.Disable = Convert.ToBoolean(cboDisable.Text);
                    aContractsBO.Insert(aContracts);
                    MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.afrmLst_Contracts != null)
                    {
                        this.afrmLst_Contracts.ReloadData();
                        this.Close();
                    }
                    else if (this.afrmMain != null)
                    {
                        this.afrmMain.ReloadGridView();
                        this.Close();
                    }
                    else
                    {
                        int IDSystemUser = Convert.ToInt32(lueSystemUser.EditValue);
                        ReloadGridView(IDSystemUser);
                    }
                 
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts.btnAddNew_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmIns_Contracts_Load(object sender, EventArgs e)
        {

            try
            {
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                List<SystemUsers> aListSystemUser = aSystemUsersBO.Select_All();
                dgvSysUsers.DataSource = aListSystemUser;
                dgvSysUsers.RefreshDataSource();              

                lueContractType.Properties.DataSource = CORE.CONSTANTS.ListContractTypes;//Load contractType 
                lueContractType.Properties.DisplayMember = "Name";
                lueContractType.Properties.ValueMember = "ID";

                lueType.Properties.DataSource = CORE.CONSTANTS.ListSalaryTypes;//Load SalaryType 
                lueType.Properties.DisplayMember = "Name";
                lueType.Properties.ValueMember = "ID";

                lueStatutoryRepresentGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gender 
                lueStatutoryRepresentGender.Properties.DisplayMember = "Name";
                lueStatutoryRepresentGender.Properties.ValueMember = "ID";

                lueSystemUser.Properties.DataSource = aListSystemUser;
                lueSystemUser.Properties.DisplayMember = "Name";
                lueSystemUser.Properties.ValueMember = "ID";

                if (afrmMain != null)
                {
                    lueSystemUser.EditValue = IDSystemUser;
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts.frmIns_Contracts_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(grvSystemUser.GetFocusedRowCellValue("ID"));
            lueSystemUser.EditValue = IDSystemUser;
        }

        private void lueSystemUser_EditValueChanged(object sender, EventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(lueSystemUser.EditValue);
            ReloadGridView(IDSystemUser);
        }
        private void ReloadGridView(int IDSystemUser)
        {
            ContractsBO aContractsBO = new ContractsBO();
            SystemUsersBO aSystemUsersBO = new SystemUsersBO();
            List<ContractsEN> aListContractsEN = new List<ContractsEN>();
            List<Contracts> aListTemp = aContractsBO.Select_ByIDSystemUser(IDSystemUser);
            ContractsEN aContractsEN;
            if (aListTemp != null)
            {
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aContractsEN = new ContractsEN();
                    aContractsEN.SetValue(aListTemp[i]);
                    aContractsEN.Name = aSystemUsersBO.Select_ByID(aListTemp[i].IDSystemUser).Name;
                    aListContractsEN.Add(aContractsEN);
                }               
            }
            dgvContracts.DataSource = aListContractsEN;
            dgvContracts.RefreshDataSource();
        }

        private void btnChoose_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(grvSystemUser.GetFocusedRowCellValue("ID"));
            lueSystemUser.EditValue = IDSystemUser;
        }


    }
}