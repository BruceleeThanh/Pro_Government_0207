using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Library;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmUpd_Customers : DevExpress.XtraEditors.XtraForm
    {
        private int IDCustomer;
        private frmLst_Customers afrmLst_Customers = null;
        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = null;
        private frmTsk_EditBooking afrmTsk_EditBooking = null;
       private frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = null;
        public frmUpd_Customers()
        {
            InitializeComponent();
        }
        public frmUpd_Customers(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers, int IDCustomer)
        {
            InitializeComponent();
            this.afrmIns_CustomerGroups_Customers = afrmIns_CustomerGroups_Customers;
            this.IDCustomer = IDCustomer;
        }
        public frmUpd_Customers(frmLst_Customers afrmLst_Customers, int aIDCustomer)
        {
            InitializeComponent();
            this.afrmLst_Customers = afrmLst_Customers;
            this.IDCustomer = aIDCustomer;
        }
        public frmUpd_Customers(frmTsk_EditBooking afrmTsk_EditBooking, int aIDCustomer)
        {
            InitializeComponent();
            this.afrmTsk_EditBooking = afrmTsk_EditBooking;
            this.IDCustomer = aIDCustomer;
        }
        public frmUpd_Customers(frmTsk_Payment_Step2 afrmTsk_Payment_Step2, int aIDCustomer)
        {
            InitializeComponent();
            this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
            this.IDCustomer = aIDCustomer;
        }

        private void frmUpdateCustomers_Load(object sender, EventArgs e)
        {
            try
            {

                lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
                lueNationality.Properties.DisplayMember = "Name";
                lueNationality.Properties.ValueMember = "Code";


                lueCitizen.Properties.DataSource = CORE.CONSTANTS.ListCitizens;//Load Citizen 
                lueCitizen.Properties.DisplayMember = "Name";
                lueCitizen.Properties.ValueMember = "ID";

                lueGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gioi tinh
                lueGender.Properties.DisplayMember = "Name";
                lueGender.Properties.ValueMember = "ID";

                lueStatus.Properties.DataSource = CORE.CONSTANTS.ListCustomerStatus;//Load CustomerStatus 
                lueStatus.Properties.DisplayMember = "Name";
                lueStatus.Properties.ValueMember = "ID";


                CustomersBO aCustomersBO = new CustomersBO();
                // lấy IDCustomer này từ FormCustomers
                Customers aCustomer = aCustomersBO.Select_ByID(IDCustomer);
                if (aCustomer != null)
                {
                    txtNames.EditValue = aCustomer.Name;
                    txtIdentifier1.EditValue = aCustomer.Identifier1;
                    txtIdentifier2.EditValue = aCustomer.Identifier2;
                    txtIdentifier3.EditValue = aCustomer.Identifier3;
                    if (aCustomer.Birthday != null)
                    {
                        dtpBirthday.DateTime = aCustomer.Birthday.GetValueOrDefault();
                    }
                    if (String.IsNullOrEmpty(aCustomer.Gender) == false)
                    {
                        lueGender.EditValue = Convert.ToInt32(aCustomer.Gender);
                    }
                    
                    txtAddress.EditValue = aCustomer.Address;

                    if(String.IsNullOrEmpty(aCustomer.Nationality) == false)
                    {
                        lueNationality.EditValue = aCustomer.Nationality;
                    }
                    if (lueNationality.EditValue == null)
                    {
                        lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(704).Code;
                    }
                    if (aCustomer.Citizen > 0)
                    {
                        lueCitizen.EditValue = aCustomer.Citizen;
                    }
                    else
                    {
                        lueCitizen.EditValue = CORE.CONSTANTS.SelectedCitizen(2).ID;
                    }
                    


                    txtTel.EditValue = aCustomer.Tel;
                    txtEmail.EditValue = aCustomer.Email;
                    txaInfo.EditValue = aCustomer.Info;
                    txaNote.EditValue = aCustomer.Note;
                    txaDescription.EditValue = aCustomer.Description;
                    lueStatus.EditValue = aCustomer.Status;
                    cbbCustomerType.Text = aCustomer.Type.ToString();
                    if (aCustomer.Disable != null)
                    {
                        cboDisable.Text = Convert.ToString(aCustomer.Disable);
                    }
                    else
                    {
                        cboDisable.Text = "False";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpdateCustomers.frmUpdateCustomers_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private bool CheckDataBeforeUpdate()
        {
            try
            {

                if (String.IsNullOrEmpty(txtNames.Text) == true)
                {
                    txtNames.Focus();
                    MessageBox.Show("Vui lòng nhập tên khách hàng .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtpBirthday.EditValue != null)
                {
                    dtpBirthday.Focus();
                    if (DateTime.Now <= dtpBirthday.DateTime)
                    {
                        MessageBox.Show("Nhập ngày sinh nhỏ hơn ngày hiện tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpdateCustomers.CheckDataBeforeUpdate\n" + ex.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CheckDataBeforeUpdate() == true)
                {
                    DateTime? NullDateTime = null;
                    CustomersBO acustomersBO = new CustomersBO();
                    Customers aCustomers = acustomersBO.Select_ByID(IDCustomer);
                    aCustomers.ID = IDCustomer;

                    aCustomers.Name = txtNames.Text;
                    aCustomers.Identifier1 = txtIdentifier1.Text;
                    aCustomers.Identifier2 = txtIdentifier2.Text;
                    aCustomers.Identifier3 = txtIdentifier3.Text;
                    aCustomers.Birthday = String.IsNullOrEmpty(dtpBirthday.Text) == true ? NullDateTime : dtpBirthday.DateTime;
                    aCustomers.Gender = Convert.ToString(lueGender.EditValue);
                    aCustomers.Address = txtAddress.Text;
                    aCustomers.Nationality = Convert.ToString(lueNationality.EditValue);
                    aCustomers.Tel = txtTel.Text;
                    aCustomers.Email = txtEmail.Text;
                    aCustomers.Info = txaInfo.Text;
                    aCustomers.Note = txaNote.Text;
                    aCustomers.Description = txaDescription.Text;
                    aCustomers.Status = Convert.ToInt32(lueStatus.EditValue);

                    aCustomers.Type = cbbCustomerType.SelectedIndex + 1;

                    aCustomers.Citizen = Convert.ToInt32(lueCitizen.EditValue);
                    aCustomers.Disable = bool.Parse(cboDisable.Text);

                    int count = acustomersBO.Update(aCustomers);
                    if (count > 0)
                    {
                        MessageBox.Show("Sửa thông tin khách hàng thành công!", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (this.afrmLst_Customers != null)
                        {
                            this.afrmLst_Customers.ReloadData();
                        }
                        if (this.afrmIns_CustomerGroups_Customers != null)
                        {
                            this.afrmIns_CustomerGroups_Customers.LoadDataAvailableCustomers();
                        }
                        else if (this.afrmTsk_EditBooking != null)
                        {
                            this.afrmTsk_EditBooking.ReloadCustomers();
                        }
                        else if (this.afrmTsk_Payment_Step2 != null)
                        {
                            this.afrmTsk_Payment_Step2.Reload();
                        }
                    }
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