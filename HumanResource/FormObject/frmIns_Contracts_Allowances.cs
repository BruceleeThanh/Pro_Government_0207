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
using Entity;
namespace HumanResource
{
    public partial class frmIns_Contracts_Allowances : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Contracts_Allowances afrmLst_Contracts_Allowances = null;
        private Contracts_AllowancesEN aContracts_AllowancesEN = new Contracts_AllowancesEN();
        private List<Contracts> aListAvailableContracts = new List<Contracts>();
        private int IDAllowances = 0;

        public frmIns_Contracts_Allowances()
        {
            InitializeComponent();
        }
        public frmIns_Contracts_Allowances(frmLst_Contracts_Allowances afrmLst_Contracts_Allowances)
        {
            InitializeComponent();
            this.afrmLst_Contracts_Allowances = afrmLst_Contracts_Allowances;
        }
        private void frmIns_Contracts_Allowances_Load(object sender, EventArgs e)
        {
            try
            {
                AllowancesBO aAllowancesBO = new AllowancesBO();
                List<Allowances> aListAllowances = aAllowancesBO.Select_All();
                lueIDAllowances.Properties.DataSource = aListAllowances;
                lueIDAllowances.Properties.DisplayMember = "ID";
                lueIDAllowances.Properties.ValueMember = "ID";

                if (aListAllowances.Count > 0)
                {
                    lueIDAllowances.EditValue = aListAllowances[0].ID;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts_Allowances.frmIns_Contracts_Allowances_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            try
            {
                ContractsBO aContractsBO = new ContractsBO();
                aListAvailableContracts = aContractsBO.Select_ByIDAllowances(IDAllowances);
                dgvAvailableContracts.DataSource = aListAvailableContracts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts_Allowances.LoadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnSelectContracts_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Contracts aContracts = new Contracts();
                aContracts.ID = Convert.ToInt32(viewAvailableContracts.GetFocusedRowCellValue("ID"));
                aContracts.NumberContract = Convert.ToString(viewAvailableContracts.GetFocusedRowCellValue("NumberContract"));
                aContracts.ContractDate = Convert.ToDateTime(viewAvailableContracts.GetFocusedRowCellValue("ContractDate"));
                aContracts.Coefficent = Convert.ToDouble(viewAvailableContracts.GetFocusedRowCellValue("Coefficent"));

                AllowancesEN aAllowancesEN = new AllowancesEN();
                List<AllowancesEN> aListTemps = aContracts_AllowancesEN.aListAllowances.Where(d => d.ID == Convert.ToInt32(lueIDAllowances.EditValue)).ToList();
                if (aListTemps.Count == 0)
                {
                    aAllowancesEN.ID = Convert.ToInt32(lueIDAllowances.EditValue);
                    aContracts_AllowancesEN.aListAllowances.Add(aAllowancesEN);
                }
                aAllowancesEN = aContracts_AllowancesEN.aListAllowances.Where(d => d.ID == Convert.ToInt32(lueIDAllowances.EditValue)).ToList()[0];
                int Index = aContracts_AllowancesEN.aListAllowances.IndexOf(aAllowancesEN);
                aContracts_AllowancesEN.aListAllowances[Index].aListContracts.Add(aContracts);
                dgvSelectContracts.DataSource = aContracts_AllowancesEN.aListAllowances[Index].aListContracts;
                dgvSelectContracts.RefreshDataSource();

                Contracts Temps = aListAvailableContracts.Where(d => d.ID == Convert.ToInt32(viewAvailableContracts.GetFocusedRowCellValue("ID"))).ToList()[0];
                aListAvailableContracts.Remove(Temps);
                dgvAvailableContracts.DataSource = aListAvailableContracts;
                dgvAvailableContracts.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts_Allowances.btnSelectContracts_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverContracts_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Contracts aContracts = new Contracts();
                aContracts.ID = Convert.ToInt32(viewSelectContracts.GetFocusedRowCellValue("ID"));
                aContracts.NumberContract = Convert.ToString(viewSelectContracts.GetFocusedRowCellValue("NumberContract"));
                aContracts.ContractDate = Convert.ToDateTime(viewSelectContracts.GetFocusedRowCellValue("ContractDate"));
                aContracts.Coefficent = Convert.ToDouble(viewSelectContracts.GetFocusedRowCellValue("Coefficent"));

                aListAvailableContracts.Add(aContracts);
                dgvAvailableContracts.DataSource = aListAvailableContracts;
                dgvAvailableContracts.RefreshDataSource();

                AllowancesEN aAllowancesEN = aContracts_AllowancesEN.aListAllowances.Where(d => d.ID == Convert.ToInt32(lueIDAllowances.EditValue)).ToList()[0];
                int Index = aContracts_AllowancesEN.aListAllowances.IndexOf(aAllowancesEN);
                Contracts Temps = aContracts_AllowancesEN.aListAllowances[Index].aListContracts.Where(d => d.ID == Convert.ToInt32(viewSelectContracts.GetFocusedRowCellValue("ID"))).ToList()[0];
                aContracts_AllowancesEN.aListAllowances[Index].aListContracts.Remove(Temps);
                dgvSelectContracts.DataSource = aContracts_AllowancesEN.aListAllowances[Index].aListContracts;
                dgvSelectContracts.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts_Allowances.btnRemoverContracts_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lueIDAllowances_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                IDAllowances = Convert.ToInt32(lueIDAllowances.EditValue);
                LoadData();
                dgvAvailableContracts.RefreshDataSource();

                List<AllowancesEN> aListTemps = aContracts_AllowancesEN.aListAllowances.Where(d => d.ID == IDAllowances).ToList();
                if (aListTemps.Count > 0)
                {
                    AllowancesEN aAllowancesEN = aContracts_AllowancesEN.aListAllowances.Where(d => d.ID == IDAllowances).ToList()[0];
                    int Index = aContracts_AllowancesEN.aListAllowances.IndexOf(aAllowancesEN);
                    dgvSelectContracts.DataSource = aContracts_AllowancesEN.aListAllowances[Index].aListContracts;
                    dgvSelectContracts.RefreshDataSource();
                }
                else
                {
                    dgvSelectContracts.DataSource = null;
                    dgvSelectContracts.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts_Allowances.lueIDAllowances_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {

                aContracts_AllowancesEN.RealSalaryPlus = Convert.ToDecimal(txtRealSalaryPlus.Text);
                aContracts_AllowancesEN.ApplyDate = Convert.ToDateTime(dtpApplyDate.Text);
                aContracts_AllowancesEN.Type = cboType.SelectedIndex + 1;
                aContracts_AllowancesEN.Status = cboStatus.SelectedIndex + 1;
                aContracts_AllowancesEN.Disable = Convert.ToBoolean(cboDisable.Text);
                Contracts_AllowancesBO aContracts_AllowancesBO = new Contracts_AllowancesBO();
                aContracts_AllowancesBO.Insert(aContracts_AllowancesEN);
                MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.afrmLst_Contracts_Allowances.ReloadData();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Contracts_Allowances.btnAddNew_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}