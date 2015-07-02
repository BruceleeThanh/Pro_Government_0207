using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

using System.Collections.Generic;
using System.Linq;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmLst_Customers : DevExpress.XtraEditors.XtraForm
    {
       
        private frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2 = null;
        private frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2 = null;
        private frmTsk_CheckIn_Customer_Step2 afrm_Tsk_CheckIn_Customer_Step2 = null;

        private frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = null;
        private frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2 = null;
        private frmTsk_CheckInCustomer_ForRoomBooking_Step2 afrmTsk_CheckInCustomer_ForRoomBooking_Step2 = null;

        private frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New = null;
        private frmTsk_Booking_Step2 afrmTsk_Booking_Step2 = null;
        private frmMain afrmMain = null;
        private int IDCustomerGroup;
        
        public frmLst_Customers()
        {
            InitializeComponent();
            colChoose.Visible = false; // cot Fill (fill nguoc lai ve form goi fom nay- khoa trong truong hop khong co form cha)
           // AutoComplete(); // Hàm tự động tìm kiếm tên trên textbox tìm kiếm
        }

        public frmLst_Customers(frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Goverment_Step2 = afrmTsk_CheckIn_Goverment_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }

        public frmLst_Customers(frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Group_Step2 = afrmTsk_CheckIn_Group_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }

        public frmLst_Customers(frmTsk_CheckIn_Customer_Step2 afrm_Tsk_CheckIn_Customer_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrm_Tsk_CheckIn_Customer_Step2 = afrm_Tsk_CheckIn_Customer_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }

        //hiennv
        public frmLst_Customers(frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = afrmTsk_CheckInGoverment_ForRoomBooking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }
        //hiennv
        public frmLst_Customers(frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 = afrmTsk_CheckInGroup_ForRoomBooking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }
        //hiennv
        public frmLst_Customers(frmTsk_CheckInCustomer_ForRoomBooking_Step2 afrmTsk_CheckInCustomer_ForRoomBooking_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 = afrmTsk_CheckInCustomer_ForRoomBooking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }

        public frmLst_Customers(frmTsk_Booking_Step2 afrmTsk_Booking_Step2, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_Booking_Step2 = afrmTsk_Booking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
        }
        public frmLst_Customers(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            colChoose.Visible = false;
        }
        public frmLst_Customers(frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer_New = afrmTsk_BookingHall_Customer_New;
            
        }

        private void btnSelectIDCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(viewAvailableCustomers.GetFocusedRowCellValue("ID").ToString());
                if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                {
                    this.afrmTsk_CheckIn_Goverment_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                {
                    this.afrmTsk_CheckIn_Group_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrm_Tsk_CheckIn_Customer_Step2 != null)
                {
                    this.afrm_Tsk_CheckIn_Customer_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrmTsk_Booking_Step2 != null)
                {
                    this.afrmTsk_Booking_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null)
                {
                    this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null)
                {
                    this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 != null)
                {
                    this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.CallBackIDCustomer(id);
                }
                else if (this.afrmTsk_BookingHall_Customer_New != null)
                {
                    this.afrmTsk_BookingHall_Customer_New.CallBackIDCustomer(id);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBookingRs_Search_Customers.btnSelectIDCustomers_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLst_Customers_Load(object sender, EventArgs e)
        {
            try
            {
                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Customers.frmLst_Customers_Load \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ReloadData()
        {
            try
            {
                dgvAvailableCustomers.DataSource = null;
                CustomersBO aCustomersBO = new CustomersBO();
                List<Customers> aListCustomers = new List<Customers>();
                List<CustomerEN>  aListCustomersEN = new List<CustomerEN>();
                
                if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrm_Tsk_CheckIn_Customer_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrmTsk_Booking_Step2 != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    btnAddCustomer.Visible = false;
                    colChoose.Visible = true;
                }
                else if (this.afrmMain != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.Select_All();
                    btnAddCustomer.Visible = true;
                    colChoose.Visible = false;
                }
                else if (this.afrmTsk_BookingHall_Customer_New != null)
                {
                    aListCustomers.Clear();
                    aListCustomers = aCustomersBO.Select_All();
                    btnAddCustomer.Visible = true;                  
                }

                CustomerEN aCus;
                for (int i = 0; i < aListCustomers.Count; i++)
                {
                    aCus = new CustomerEN();
                    aCus.SetValue(aListCustomers[i]);
                    if (String.IsNullOrEmpty(aListCustomers[i].Gender) == false)
                    {
                        aCus.GenderDisplay = CORE.CONSTANTS.SelectedGender(Convert.ToInt32(aListCustomers[i].Gender)).Name;
                    }
                    if (String.IsNullOrEmpty(aListCustomers[i].Nationality) == false)
                    {
                        aCus.NationalityDisplay = CORE.CONSTANTS.SelectedCountry(Convert.ToString(aListCustomers[i].Nationality)).Name;
                    }
                    if (aListCustomers[i].Citizen != null)
                    {
                        aCus.CitizenDisplay = CORE.CONSTANTS.SelectedCitizen(Convert.ToInt32(aListCustomers[i].Citizen)).Name;
                    }
                    aListCustomersEN.Add(aCus);
                }
                dgvAvailableCustomers.DataSource = aListCustomersEN;
                dgvAvailableCustomers.RefreshDataSource();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Customers.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(viewAvailableCustomers.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Customers afrmUpd_Customers = new frmUpd_Customers(this,ID);
            afrmUpd_Customers.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(viewAvailableCustomers.GetFocusedRowCellValue("ID").ToString());
            string Name = viewAvailableCustomers.GetFocusedRowCellValue("Name").ToString();
            CustomersBO aCustomersBO = new CustomersBO();
            DialogResult result = MessageBox.Show("Bạn có muốn xóa khách hàng " + Name + " này không?", "Xóa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aCustomersBO.Delete(ID);
                MessageBox.Show("Xóa thành công");
                this.ReloadData();
            }           
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmIns_Customers afrmIns_Customers = new frmIns_Customers(this);
            afrmIns_Customers.Show();
        }
    }
}