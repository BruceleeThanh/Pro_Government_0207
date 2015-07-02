using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Library;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmUpd_Customers_2 : DevExpress.XtraEditors.XtraForm
    {
        private int IDCustomer;
        private int IDBookingRoom;
        private frmLst_Customers afrmLst_Customers = null;
        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = null;
        private frmTsk_EditBooking afrmTsk_EditBooking = null;
        private frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = null;

        // Ngoc 
        public frmUpd_Customers_2(frmTsk_Payment_Step2 afrmTsk_Payment_Step2, int IDBookingRoom)
        {
            InitializeComponent();
            this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
            this.IDBookingRoom = IDBookingRoom;
            this.IDCustomer = 0;
        }
        // Ngoc 
        public frmUpd_Customers_2(frmTsk_Payment_Step2 afrmTsk_Payment_Step2, int IDBookingRoom, int IDCustomer)
        {
            InitializeComponent();
            this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
            this.IDBookingRoom = IDBookingRoom;
            this.IDCustomer = IDCustomer;

        }

        //public frmUpd_Customers_2(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers, int IDCustomer)
        //{
        //    InitializeComponent();
        //    this.afrmIns_CustomerGroups_Customers = afrmIns_CustomerGroups_Customers;
        //    this.IDCustomer = IDCustomer;
        //}
        //public frmUpd_Customers_2(frmLst_Customers afrmLst_Customers, int aIDCustomer)
        //{
        //    InitializeComponent();
        //    this.afrmLst_Customers = afrmLst_Customers;
        //    this.IDCustomer = aIDCustomer;
        //}
        //public frmUpd_Customers_2(frmTsk_EditBooking afrmTsk_EditBooking, int aIDCustomer)
        //{
        //    InitializeComponent();
        //    this.afrmTsk_EditBooking = afrmTsk_EditBooking;
        //    this.IDCustomer = aIDCustomer;
        //}
        //public frmUpd_Customers_2(frmTsk_Payment_Step2 afrmTsk_Payment_Step2, int aIDCustomer)
        //{
        //    InitializeComponent();
        //    this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
        //    this.IDCustomer = aIDCustomer;
        //}

        private void frmUpdateCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                dgvAvailableCustomers.DataSource = (new CustomersBO()).Select_All();
                btnAdd.Enabled = false;


                lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
                lueNationality.Properties.DisplayMember = "Name";
                lueNationality.Properties.ValueMember = "Code";


                lueCitizen.Properties.DataSource = CORE.CONSTANTS.ListCitizens;//Load Citizen 
                lueCitizen.Properties.DisplayMember = "Name";
                lueCitizen.Properties.ValueMember = "ID";

                lueGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gioi tinh
                lueGender.Properties.DisplayMember = "Name";
                lueGender.Properties.ValueMember = "ID";




                CustomersBO aCustomersBO = new CustomersBO();
                // lấy IDCustomer này từ FormCustomers
                if (this.IDCustomer > 0)
                {
                    Customers aCustomer = aCustomersBO.Select_ByID(IDCustomer);
                    if (aCustomer != null)
                    {
                        txtNames.EditValue = aCustomer.Name;
                        txtIdentifier1.EditValue = aCustomer.Identifier1;
                        txtIdentifier2.EditValue = aCustomer.Identifier2;
                        txtIdentifier3.EditValue = aCustomer.Identifier3;
                        if (aCustomer.Birthday != null)
                        {
                            dtpBirthday.EditValue = aCustomer.Birthday;
                        }
                        if (String.IsNullOrEmpty(aCustomer.Gender) == false)
                        {
                            lueGender.EditValue = Convert.ToInt32(aCustomer.Gender);
                        }

                        txtAddress.EditValue = aCustomer.Address;

                        if (String.IsNullOrEmpty(aCustomer.Nationality) == false)
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
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpdateCustomers.frmUpdateCustomers_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
            BookingRoomsMembers aBookingRoomsMembers = new BookingRoomsMembers();

            DateTime? dateTime = null;

            CustomersBO aCustomersBO = new CustomersBO();
            Customers aCustomers = new Customers();

            //Update
            if (this.IDCustomer > 0)
            {
                aCustomers = aCustomersBO.Select_ByID(IDCustomer);
            }
            else
            {
                aCustomers = new Customers();
            }
            aCustomers.Address = txtAddress.Text;
            aCustomers.Birthday = String.IsNullOrEmpty(dtpBirthday.Text) ? dateTime : dtpBirthday.DateTime;
            aCustomers.Citizen = Convert.ToInt32(lueCitizen.EditValue);

            aCustomers.Email = txtEmail.Text;
            aCustomers.Gender = lueGender.EditValue.ToString();
            aCustomers.Identifier1 = txtIdentifier1.Text;
            aCustomers.Identifier2 = txtIdentifier2.Text;
            aCustomers.Identifier3 = txtIdentifier3.Text;

            aCustomers.Name = txtNames.Text;
            aCustomers.Nationality = lueNationality.EditValue.ToString();
            aCustomers.Tel = txtTel.Text;

            if (this.IDCustomer > 0)
            {
                aCustomersBO.Update(aCustomers);
            }
            else
            {
                this.IDCustomer = aCustomersBO.Insert(aCustomers);
            }
            /*Insert nguoi moi vao group*/
            CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
            aCustomerGroups_CustomersBO.InsertCustomerIntoCustomerGroup_ByIDBookingRs(this.IDCustomer, (new BookingRsBO()).Select_ByIDBookingRoom(this.IDBookingRoom).ID);
            /*--------------------------*/

            aBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom_ByIDCustomer(this.IDBookingRoom, this.IDCustomer);
            if (aBookingRoomsMembers == null)
            {
                aBookingRoomsMembers = new BookingRoomsMembers();
                aBookingRoomsMembers.IDBookingRoom = this.IDBookingRoom;
                aBookingRoomsMembers.IDCustomer = this.IDCustomer;
            }


            aBookingRoomsMembers.DateEnterCountry = String.IsNullOrEmpty(dtpDateEnterCountry.Text) ? dateTime : dtpDateEnterCountry.DateTime;
            aBookingRoomsMembers.EnterGate = txtEnterGate.Text;

            aBookingRoomsMembers.LeaveDate = String.IsNullOrEmpty(dtpLeaveDate.Text) ? dateTime : dtpLeaveDate.DateTime;
            aBookingRoomsMembers.LimitDateEnterCountry = String.IsNullOrEmpty(dtpLimitDateEnterCountry.Text) ? dateTime : dtpLimitDateEnterCountry.DateTime;
            aBookingRoomsMembers.Organization = txtOrganization.Text;
            aBookingRoomsMembers.PurposeComeVietnam = txtPurposeComeVietnam.Text;
            aBookingRoomsMembers.TemporaryResidenceDate = String.IsNullOrEmpty(dtpTemporaryResidenceDate.Text) ? dateTime : dtpTemporaryResidenceDate.DateTime;

            if (aBookingRoomsMembers.ID > 0)
            {
                aBookingRoomsMembersBO.Update(aBookingRoomsMembers);
            }
            else
            {
                aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);
            }
            MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.afrmTsk_Payment_Step2.Reload();
          //  this.afrmTsk_Payment_Step2.ReloadMoneyRoom();
            this.Close();
        }

        private void btnRemoveAvaiableCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.IDCustomer = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
            CustomersBO aCustomersBO = new CustomersBO();
            Customers aCustomers = new Customers();

            aCustomers = aCustomersBO.Select_ByID(this.IDCustomer);
            txtAddress.Text = aCustomers.Address;
            dtpBirthday.EditValue = aCustomers.Birthday;
            lueCitizen.EditValue = aCustomers.Citizen;

            txtEmail.Text = aCustomers.Email;


            if (String.IsNullOrEmpty(aCustomers.Gender) == false)
            {
                lueGender.EditValue = Convert.ToInt32(aCustomers.Gender);
            }

            txtIdentifier1.Text = aCustomers.Identifier1;
            txtIdentifier2.Text = aCustomers.Identifier2;
            txtIdentifier3.Text = aCustomers.Identifier3;

            txtNames.Text = aCustomers.Name;
            lueNationality.EditValue = aCustomers.Nationality;
            txtTel.Text = aCustomers.Tel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            txtAddress.Text = "";

            txtEmail.Text = "";
            lueGender.EditValue = 1;
            txtIdentifier1.Text = "";
            txtIdentifier2.Text = "";
            txtIdentifier3.Text = "";

            txtNames.Text = "";
            lueNationality.EditValue = 1;
            txtTel.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime? dateTime = null;

            CustomersBO aCustomersBO = new CustomersBO();
            Customers aCustomers = new Customers();

            //Update
            if (this.IDCustomer > 0)
            {
                aCustomers = aCustomersBO.Select_ByID(IDCustomer);
            }
            else
            {
                aCustomers = new Customers();
            }
            aCustomers.Address = txtAddress.Text;
            aCustomers.Birthday = String.IsNullOrEmpty(dtpBirthday.Text) ? dateTime : dtpBirthday.DateTime;
            aCustomers.Citizen = Convert.ToInt32(lueCitizen.EditValue);

            aCustomers.Email = txtEmail.Text;
            aCustomers.Gender = lueGender.EditValue.ToString();
            aCustomers.Identifier1 = txtIdentifier1.Text;
            aCustomers.Identifier2 = txtIdentifier2.Text;
            aCustomers.Identifier3 = txtIdentifier3.Text;

            aCustomers.Name = txtNames.Text;
            aCustomers.Nationality = lueNationality.EditValue.ToString();
            aCustomers.Tel = txtTel.Text;

            if (this.IDCustomer > 0)
            {
                aCustomersBO.Update(aCustomers);
            }
            else
            {
                this.IDCustomer = aCustomersBO.Insert(aCustomers);
            }
            MessageBox.Show("Thêm mới khách thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}