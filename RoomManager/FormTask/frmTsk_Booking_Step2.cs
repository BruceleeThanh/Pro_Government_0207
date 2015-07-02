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
using System.Collections.Generic;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_Booking_Step2 : DevExpress.XtraEditors.XtraForm
    {

        private frmTsk_Booking_Step1 afrmTsk_Booking_Step1 = null;
        private BookingEN aBookingEN = new BookingEN();
        public List<BookingRooms> aList_IDBookingRooms = new List<BookingRooms>();
        private int CustomerType;

        public frmTsk_Booking_Step2(frmTsk_Booking_Step1 afrmTsk_Booking_Step1, BookingEN aBookingEN, int CustomerType)
        {
            InitializeComponent();
            this.afrmTsk_Booking_Step1 = afrmTsk_Booking_Step1;
            this.aBookingEN = aBookingEN;
            this.CustomerType = CustomerType;
        }

        //Call Back Id Company
        public void CallBackIDCustomerGroup(int IDCustomerGroup)
        {
            try
            {
                lueIDCustomerGroups.EditValue = IDCustomerGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.CallBackIDCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Call Back data IDCustomer
        public void CallBackIDCustomer(int IDCustomer)
        {
            try
            {
                lueIDCustomers.EditValue = IDCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.CallBackIDCustomer\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Load IDCompany
        public void LoadIDCompanies(int Type)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                List<Companies> aListCompanies = aCompaniesBO.Select_ByType(Type);
                lueIDCompanies.Properties.DataSource = aListCompanies;
                lueIDCompanies.Properties.DisplayMember = "Name";
                lueIDCompanies.Properties.ValueMember = "ID";
                if (Type == 3)
                {
                    if (aListCompanies.Count > 0)
                    {
                        lueIDCompanies.EditValue = aListCompanies[0].ID;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.LoadIDCompanies\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CallBackIDCompany
        public void CallBackIDCompany(int IDCompany)
        {
            try
            {
                lueIDCompanies.EditValue = IDCompany;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.CallBackIDCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //LoadData IDCustomerGroup
        public void LoadIDCustomerGroups()
        {
            try
            {
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                int IDCompany = Convert.ToInt32(lueIDCompanies.EditValue.ToString());
                List<CustomerGroups> aListCustomerGroups = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                lueIDCustomerGroups.Properties.DataSource = aListCustomerGroups;
                lueIDCustomerGroups.Properties.DisplayMember = "Name";
                lueIDCustomerGroups.Properties.ValueMember = "ID";

                if (aListCustomerGroups.Count > 0)
                {
                    lueIDCustomerGroups.EditValue = aListCustomerGroups.ToList()[0].ID;
                }
                else
                {
                    lueIDCustomerGroups.EditValue = 0;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.LoadIDCustomerGroups\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Load IDCustomers 
        public void LoadIDCustomers()
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                int IDCustomerGroup = Int32.Parse(lueIDCustomerGroups.EditValue.ToString());
                List<Customers> aListCustomer = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                lueIDCustomers.Properties.DataSource = aListCustomer;
                lueIDCustomers.Properties.DisplayMember = "Name";
                lueIDCustomers.Properties.ValueMember = "ID";

                if (aListCustomer.Count > 0)
                {
                    lueIDCustomers.EditValue = aListCustomer.ToList()[0].ID;
                }
                else
                {
                    lueIDCustomers.EditValue = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.LoadIDCustomers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueIDCompanies_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIDCustomerGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.lueIDCompanies_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueIDCustomerGroups_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIDCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.lueIDCustomerGroups_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_Companies afrmLst_Companies = new frmLst_Companies(this, CustomerType);
                afrmLst_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.bt_BookingRs_Search_Company_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomerGroups_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueIDCompanies.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompnay = Convert.ToInt32(lueIDCompanies.EditValue.ToString());
                    frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups(this, IDCompnay, NameCompany);
                    afrmIns_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.btnAddCustomerGroups_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Companies afrmIns_Companies = new frmIns_Companies(this, CustomerType);
                afrmIns_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.btnCompanies_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomerGroups_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueIDCompanies.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompnay = Convert.ToInt32(lueIDCompanies.EditValue.ToString());
                    frmLst_CustomerGroups afrmLst_CustomerGroups = new frmLst_CustomerGroups(this, IDCompnay);
                    afrmLst_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_Booking_Step2.btnSearchCustomerGroups_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {

            if (txaDescription.Text.Length > 250)
            {
                txaDescription.Focus();
                MessageBox.Show("Mô tả chỉ được phép nhập tối đa là 250 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txaNote.Text.Length > 250)
            {
                txaNote.Focus();
                MessageBox.Show("Ghi chú chỉ được phép nhập tối đa là 250 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Convert.ToInt32(lueIDCompanies.EditValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn tên công ty.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Convert.ToInt32(lueIDCustomerGroups.EditValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn tên nhóm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Convert.ToInt32(lueIDCustomers.EditValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn tên người đại diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    aBookingEN.Subject = txtSubject.Text;
                    aBookingEN.Level = Convert.ToInt32(lueLevel.EditValue);
                    aBookingEN.Description = txaDescription.Text;
                    aBookingEN.Note = txaNote.Text;
                    aBookingEN.IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroups.EditValue.ToString());
                    aBookingEN.IDCustomer = Convert.ToInt32(lueIDCustomers.EditValue.ToString());

                    aBookingEN.CustomerType = cboCustomerType.SelectedIndex + 1;  // 1: Khach nha nuoc, 2: Khach doan, 3: khach le,
                    aBookingEN.BookingType = 3;   // 1: Dat onlie, 2: Dat qua dien thoai, 3: Truc tiep, 4: Cong van
                    aBookingEN.IDSystemUser = CORE.CURRENTUSER.SystemUser.ID;
                    aBookingEN.PayMenthod = 1;     //1:Tien mat
                    aBookingEN.StatusPay = 1;      //1:Chua thanh toan
                    aBookingEN.ExchangeRate = 0;
                    aBookingEN.Status = 2; // 2 : Checked
                    aBookingEN.Type = -1;
                    aBookingEN.Disable = false;

                    ReceptionTaskBO aCheckInActionBO = new ReceptionTaskBO();
                    aCheckInActionBO.Booking(aBookingEN);
                    MessageBox.Show("Đặt phòng thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.afrmTsk_Booking_Step1.Close();
                    if (this.afrmTsk_Booking_Step1.afrmMain != null)
                    {
                        this.afrmTsk_Booking_Step1.afrmMain.ReloadData();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.btnBooking_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_Booking_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                lueLevel.Properties.DataSource = CORE.CONSTANTS.ListLevels.Where(l => l.ID < 13).ToList();
                lueLevel.Properties.DisplayMember = "Name";
                lueLevel.Properties.ValueMember = "ID";

                if (CustomerType == 1)
                {
                    cboCustomerType.SelectedIndex = 0;
                    lueLevel.EditValue = CORE.CONSTANTS.SelectedLevel(11).ID;
                    lueLevel.Enabled = true;
                    btnAddCompanies.Visible = true;
                    btnSearchCompanies.Visible = true;
                    lueIDCompanies.Enabled = true;

                }
                else if (CustomerType == 2)
                {
                    cboCustomerType.SelectedIndex = 1;
                    lueLevel.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                    lueLevel.Enabled = false;
                    btnAddCompanies.Visible = true;
                    btnSearchCompanies.Visible = true;
                    lueIDCompanies.Enabled = true;
                }
                else if (CustomerType == 3)
                {
                    cboCustomerType.SelectedIndex = 2;
                    lueLevel.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                    lueLevel.Enabled = false;
                    btnAddCompanies.Visible = false;
                    btnSearchCompanies.Visible = false;
                    lueIDCompanies.Enabled = false;
                }
                LoadIDCompanies(CustomerType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.frmTsk_Booking_Step2_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueIDCustomerGroups.Text;
                string NameCompnay = lueIDCompanies.Text;
                if (NameCompnay.Equals("--- Chọn lựa ---") || NameCompnay.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroups.EditValue.ToString());
                    frmLst_Customers afrmLst_Customers = new frmLst_Customers(this, IDCustomerGroup);
                    afrmLst_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.btnSearchCustomers_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueIDCustomerGroups.Text;
                string NameCompnay = lueIDCompanies.Text;
                if (NameCompnay.Equals("--- Chọn lựa ---") || NameCompnay.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroups.EditValue.ToString());
                    frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = new frmIns_CustomerGroups_Customers(this, IDCustomerGroup, NameCustomerGroup, NameCompnay);
                    afrmIns_CustomerGroups_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step2.btnSearchCustomers_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}