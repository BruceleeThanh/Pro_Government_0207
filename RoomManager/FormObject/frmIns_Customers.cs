using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Library;
using CORESYSTEM;
namespace RoomManager
{
    public partial class frmIns_Customers : DevExpress.XtraEditors.XtraForm
    {

        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = null;
        private frmLst_Customers afrmLst_Customers = null;
        private frmTsk_EditBooking afrmTsk_EditBooking = null;

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

        public frmIns_Customers(frmTsk_EditBooking afrmTsk_EditBooking)
        {
            InitializeComponent();
            this.afrmTsk_EditBooking = afrmTsk_EditBooking;
        }

        //hiennv
        private bool CheckDataBeforeCreateNew()
        {
            try
            {

                if (String.IsNullOrEmpty(txtNames.Text) == true)
                {
                    txtNames.Focus();
                    MessageBox.Show("Vui lòng nhập tên khách hàng .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtpBirthday.EditValue !=null)
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
                MessageBox.Show("frmAddNewCustomers.CheckDataBeforeCreateNew\n" + ex.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //hiennv
        private void btCreateNew_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CheckDataBeforeCreateNew() == true)
                {
                    DateTime? NullDateTime = null;

                    CustomersBO acustomersBo = new CustomersBO();
                    Customers aCustomers = new Customers();

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

                    int count = acustomersBo.Insert(aCustomers);

                    if (count > 0)
                    {
                        MessageBox.Show("Bạn đã thêm mới khách hàng thành công !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (this.afrmIns_CustomerGroups_Customers != null)
                        {
                            this.afrmIns_CustomerGroups_Customers.LoadDataAvailableCustomers();
                        }
                        else if (this.afrmLst_Customers != null)
                        {
                            this.afrmLst_Customers.ReloadData();
                        }
                        else if (this.afrmTsk_EditBooking != null)
                        {
                            this.afrmTsk_EditBooking.ReloadCustomers();
                        }
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddNewCustomers.btCreateNew_Click\n" + ex.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmAddNewCustomers_Load(object sender, EventArgs e)
        {

            try
            {
                lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
                lueNationality.Properties.DisplayMember = "Name";
                lueNationality.Properties.ValueMember = "Code";
                lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(704).Code;

                lueCitizen.Properties.DataSource = CORE.CONSTANTS.ListCitizens;//Load Citizen 
                lueCitizen.Properties.DisplayMember = "Name";
                lueCitizen.Properties.ValueMember = "ID";
                lueCitizen.EditValue = CORE.CONSTANTS.SelectedCitizen(2).ID;
                


                lueGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gioi tinh
                lueGender.Properties.DisplayMember = "Name";
                lueGender.Properties.ValueMember = "ID";

                lueStatus.Properties.DataSource = CORE.CONSTANTS.ListCustomerStatus;//Load CustomerStatus 
                lueStatus.Properties.DisplayMember = "Name";
                lueStatus.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddNewCustomers.frmAddNewCustomers_Load\n" + ex.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




    }
}