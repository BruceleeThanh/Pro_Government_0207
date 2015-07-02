using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

namespace SaleManagement
{
    public partial class frmUpd_CustomerGroups : DevExpress.XtraEditors.XtraForm
    {
        private CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
        private frmLst_CustomerGroups afrmLst_CustomerGroups;
        private int IDCompany_Old;
        private int IDCustomerGroups_Old;

        public frmUpd_CustomerGroups(int IDCustomerGoup, int IDCompany, frmLst_CustomerGroups afrmLst_CustomerGroups)
        {
            InitializeComponent();
            this.afrmLst_CustomerGroups = afrmLst_CustomerGroups;
            this.IDCompany_Old = IDCompany;
            this.IDCustomerGroups_Old = IDCustomerGoup;
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên nhóm trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboType.Text == "--- Chọn lựa ---")
            {
                MessageBox.Show("Chọn loại nhóm trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboStatus.Text == "--- Chọn lựa ---")
            {
                MessageBox.Show("Chọn trạng thái nhóm trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    CustomerGroups aCustomerGroups = new CustomerGroups();
                    aCustomerGroups.ID = IDCustomerGroups_Old;
                    aCustomerGroups.IDCompany = int.Parse(lueCompany.EditValue.ToString());
                    aCustomerGroups.Name = txtName.Text;
                    aCustomerGroups.Status = cboStatus.SelectedIndex + 1;
                    aCustomerGroups.Type = cboType.SelectedIndex + 1;
                    aCustomerGroups.Disable = bool.Parse(cboDisable.Text);
                    aCustomerGroupsBO.Update(aCustomerGroups);
                    this.afrmLst_CustomerGroups.ReloadData();
                    MessageBox.Show("Cập nhật dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmEditCustomerGroup.btnUpdate_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmUpd_CustomerGroups_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(IDCustomerGroups_Old);
                CompaniesBO aCompaniesBO = new CompaniesBO();
                lueCompany.Properties.DataSource = aCompaniesBO.Select_All();
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
                lueCompany.EditValue = aCustomerGroups.IDCompany;
                lblIDCustomerGroup.Text = aCustomerGroups.ID.ToString();
               
                txtName.Text = aCustomerGroups.Name.ToString();
                cboType.Text = aCustomerGroups.Type.ToString();
                cboStatus.Text = aCustomerGroups.Status.ToString();
                cboDisable.Text = aCustomerGroups.Disable.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmEditCustomerGroup.frmEditCustomerGroup_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}