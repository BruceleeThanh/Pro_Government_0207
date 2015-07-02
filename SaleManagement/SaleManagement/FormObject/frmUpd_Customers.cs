using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Library;
using CORESYSTEM;


namespace SaleManagement
{
    public partial class frmUpd_Customers : DevExpress.XtraEditors.XtraForm
    {

        frmLst_Customers afrmLst_Customers = null;
        frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = null;
        private int IDCustomer;

        public frmUpd_Customers()
        {
            InitializeComponent();
        }
        public frmUpd_Customers(frmLst_Customers afrmLst_Customers, int IDCustomer)
        {
            InitializeComponent();
            this.afrmLst_Customers = afrmLst_Customers;
            this.IDCustomer = IDCustomer;
        }
        public frmUpd_Customers(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers, int IDCustomer)
        {
            InitializeComponent();
            this.afrmIns_CustomerGroups_Customers = afrmIns_CustomerGroups_Customers;
            this.IDCustomer = IDCustomer;
        }

        private bool ValidateData()
        {
            if (txtNames.Text == "")
            {
                MessageBox.Show("Nhập tên khách hàng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtIdentifier1.Text == "")
            {
                MessageBox.Show("Nhập số chứng minh nhân dân trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Nhập Email trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Nhập địa chỉ trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //if (recInfo.Text == "")
            //{
            //    MessageBox.Show("Nhập thông tin khách hàng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            if (cbbCustomerType.Text == "")
            {
                MessageBox.Show("Chọn loại khách hàng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpBirthday.DateTime == null)
            {
                MessageBox.Show("Nhập ngày sinh khách hàng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void frmUpdateCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                Customers aCustomer = aCustomersBO.Select_ByID(IDCustomer);
                lueStatus.Properties.DataSource = CORE.CONSTANTS.ListCustomerStatus;//Load CustomerStatus 
                lueStatus.Properties.DisplayMember = "Name";
                lueStatus.Properties.ValueMember = "ID";
                lueStatus.EditValue = aCustomer.Status;

                // lấy IDCustomer này từ FormCustomers

                txtNames.Text = aCustomer.Name;
                txtIdentifier1.Text = aCustomer.Identifier1;
                dtpBirthday.Text = Convert.ToString(aCustomer.Birthday);
                txtAddress.Text = aCustomer.Address;
                txtTel.Text = aCustomer.Tel.ToString();
                txtEmail.Text = aCustomer.Email.ToString();
                txtInfo.Text = aCustomer.Info.ToString();
                lueStatus.EditValue = aCustomer.Status;
                cbbCustomerType.Text = aCustomer.Type.ToString();

                cbbDisable.Text = Convert.ToString(aCustomer.Disable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpdateCustomers.frmUpdateCustomers_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CustomersBO acustomersBO = new CustomersBO();
                Customers aCustomers = acustomersBO.Select_ByID(IDCustomer);
                if (ValidateData() == true)
                {
                    aCustomers.ID = IDCustomer;
                    aCustomers.Name = txtNames.Text;
                    aCustomers.Identifier1 = txtIdentifier1.Text;

                    aCustomers.Birthday = dtpBirthday.DateTime;
                    aCustomers.Tel = txtTel.Text;
                    aCustomers.Address = txtAddress.Text;
                    aCustomers.Email = txtEmail.Text;
                    aCustomers.Info = txtInfo.Text;
                    aCustomers.Status = Convert.ToInt32(lueStatus.EditValue);
                    aCustomers.Type = Convert.ToInt32(cbbCustomerType.Text);
                    aCustomers.Disable = bool.Parse(cbbDisable.Text);

                    acustomersBO.Update(aCustomers);
                    if (this.afrmLst_Customers != null)
                    {
                        this.afrmLst_Customers.ReloadData();
                    }
                    if (this.afrmIns_CustomerGroups_Customers != null)
                    {
                        this.afrmIns_CustomerGroups_Customers.LoadDataAvailableCustomers();
                    }

                    MessageBox.Show("Sửa thông tin khách hàng thành công!", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpdateCustomers.btnUpdate_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}