using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Library;
using CORESYSTEM;

namespace SaleManagement
{
    public partial class frmIns_Customers : DevExpress.XtraEditors.XtraForm
    {

        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = null;
        private frmLst_Customers afrmLst_Customers = null;
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;

        public frmIns_Customers()
        {
            InitializeComponent();
        }

        public frmIns_Customers(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers)
        {
            InitializeComponent();
            this.afrmIns_CustomerGroups_Customers = afrmIns_CustomerGroups_Customers;
        }

        public frmIns_Customers(frmLst_Customers afrmLst_Customers)
        {
            InitializeComponent();
            this.afrmLst_Customers = afrmLst_Customers;
        }

        public frmIns_Customers(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
        }
        private bool ValidateData()
        {
            if (txtNames.Text == "")
            {
                MessageBox.Show("Nhập tên khách hàng trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtIdentifier1.Text == "")
            {
                MessageBox.Show("Nhập số chứng minh nhân dân trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTel.Text == "")
            {
                MessageBox.Show("Nhập số điện thoại trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Nhập Email trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Nhập địa chỉ trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //if (recInfo.Text == "")
            //{
            //    MessageBox.Show("Nhập thông tin khách hàng trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            if (cbbCustomerType.Text == "")
            {
                MessageBox.Show("Chọn loại khách hàng trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpBirthday.Text == "")
            {
                MessageBox.Show("Nhập ngày sinh khách hàng trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (DateTime.Now <= dtpBirthday.DateTime)
                {
                    MessageBox.Show("Nhập ngày sinh nhỏ hơn ngày hiện tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
           
        }
        
        private void btCreateNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    CustomersBO acustomersBo = new CustomersBO();
                    Customers aCustomers = new Customers();
                    aCustomers.Name = txtNames.Text;
                    aCustomers.Identifier1 = txtIdentifier1.Text;
                    aCustomers.Birthday = dtpBirthday.DateTime;
                    aCustomers.Address = txtAddress.Text;
                    aCustomers.Tel = txtTel.Text;
                    aCustomers.Email = txtEmail.Text;
                    aCustomers.Info = txtInfo.Text;
                    aCustomers.Status = Convert.ToInt32(lueStatus.EditValue);
                    aCustomers.Type = Convert.ToInt32(cbbCustomerType.Text);
                    aCustomers.Disable = bool.Parse(cboDisable.Text);

                    acustomersBo.Insert(aCustomers);

                    if (this.afrmIns_CustomerGroups_Customers != null)
                    {
                        this.afrmIns_CustomerGroups_Customers.LoadDataAvailableCustomers();
                    }
                    else if (this.afrmLst_Customers != null)
                    {
                        this.afrmLst_Customers.ReloadData();
                    }

                    MessageBox.Show("Bạn đã thêm mới khách hàng thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddNewCustomers.btCreateNew_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmAddNewCustomers_Load(object sender, EventArgs e)
        {           
            lueStatus.Properties.DataSource = CORE.CONSTANTS.ListCustomerStatus;//Load CustomerStatus 
            lueStatus.Properties.DisplayMember = "Name";
            lueStatus.Properties.ValueMember = "ID";
            lueStatus.EditValue = CORE.CONSTANTS.SelectedCustomerStatus(1).ID;          

        }

      


    }
}