using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmIns_Companies : DevExpress.XtraEditors.XtraForm
    {
        private CompaniesBO aCompaniesBO = new CompaniesBO();

        public frmIns_Companies()
        {
            InitializeComponent();
        }

        private frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2 = null;
        private frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2 = null;
        private frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = null;
        private frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2 = null;

        private frmLst_Companies afrmLst_Companies_Old = null;
        private frmTsk_Booking_Step2 afrmTsk_Booking_Step2 = null;
        private frmMain afrmMain = null;
        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers_Old = null;
        private int Type = 0;



        public frmIns_Companies(frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Goverment_Step2 = afrmTsk_CheckIn_Goverment_Step2;
            this.Type = 1;
        }

        public frmIns_Companies(frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Group_Step2 = afrmTsk_CheckIn_Group_Step2;
            this.Type = 2;
        }

        //hiennv
        public frmIns_Companies(frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = afrmTsk_CheckInGoverment_ForRoomBooking_Step2;
            this.Type = 1;
        }
        //hiennv
        public frmIns_Companies(frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 = afrmTsk_CheckInGroup_ForRoomBooking_Step2;
            this.Type = 2;
        }

        public frmIns_Companies(frmLst_Companies afrmLst_Companies)
        {
            InitializeComponent();
            afrmLst_Companies_Old = afrmLst_Companies;
        }


        public frmIns_Companies(frmTsk_Booking_Step2 afrmTsk_Booking_Step2, int Type)
        {
            InitializeComponent();
            this.afrmTsk_Booking_Step2 = afrmTsk_Booking_Step2;
            this.Type = Type;
        }

        public frmIns_Companies(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

        public frmIns_Companies(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers)
        {
            InitializeComponent();
            this.afrmIns_CustomerGroups_Customers_Old = afrmIns_CustomerGroups_Customers;
        }
        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên công ty trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboStatus.Text == "")
            {
                MessageBox.Show("Chọn trạng thái trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if(String.IsNullOrEmpty(lueCustomerType.Text) == true)
            {
                lueCustomerType.Focus();
                MessageBox.Show("Vui lòng chọn loại khách hàng . !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    string name = txtName.Text;
                    if (name.Length <= 255)
                    {
                        Companies aCompanies = new Companies();
                        aCompanies.Type = Convert.ToInt32(lueCustomerType.EditValue);
                        aCompanies.Name = name;
                        aCompanies.TaxNumberCode = txtTaxNumberCode.Text;
                        aCompanies.Address = txtAddress.Text;
                        aCompanies.Status = cboStatus.SelectedIndex + 1;
                        aCompanies.Disable = bool.Parse(cboDisable.Text);
                        
                        aCompaniesBO.Insert(aCompanies);

                        int IDCompany = aCompanies.ID;

                        // Neu form AddNew_Company dc khoi dong tu form afrmAddNewBookingRs_Goverment thi reload lai afrmAddNewBookingRs_Goverment
                        if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                        {
                            this.afrmTsk_CheckIn_Goverment_Step2.LoadIDCompanies();
                            this.afrmTsk_CheckIn_Goverment_Step2.CallBackIDCompany(IDCompany);

                        }
                        else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                        {
                            this.afrmTsk_CheckIn_Group_Step2.LoadIDCompanies();
                            this.afrmTsk_CheckIn_Group_Step2.CallBackIDCompany(IDCompany);
                        }
                        else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.LoadIDCompanies();
                            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.CallBackIDCompany(IDCompany);
                        }
                        else if (this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.LoadIDCompanies();
                            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.CallBackIDCompany(IDCompany);
                        }
                        else if (afrmLst_Companies_Old != null)
                        {
                            afrmLst_Companies_Old.ReloadData();
                        }
                        else if (afrmTsk_Booking_Step2 != null)
                        {
                            this.afrmTsk_Booking_Step2.LoadIDCompanies(Type);
                            this.afrmTsk_Booking_Step2.CallBackIDCompany(IDCompany);
                        }
                        else if (afrmIns_CustomerGroups_Customers_Old != null)
                        {
                            this.afrmIns_CustomerGroups_Customers_Old.Reload();
                            this.afrmIns_CustomerGroups_Customers_Old.CallBackIDCompany(IDCompany);
                        }
                        else if (afrmTsk_BookingHall_Goverment != null)
                        {
                            afrmTsk_BookingHall_Goverment.ReloadData();
                        }
                        else if (afrmTsk_BookingHall_Group != null)
                        {
                            afrmTsk_BookingHall_Group.ReloadData();
                        }
                        this.Close();
                        MessageBox.Show("Thêm mới thành công .!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtName.Focus();
                        MessageBox.Show("Tên công ty chỉ được phép nhập tối đa 255 ký tự .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Companies.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmIns_Companies_Load(object sender, EventArgs e)
        {
            try
            {
                lueCustomerType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes; // Load Type
                lueCustomerType.Properties.DisplayMember = "Name";
                lueCustomerType.Properties.ValueMember = "ID";

                //lueCustomerType.EditValue = CORE.CONSTANTS.SelectedCustomerType(1).ID;

                if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                {
                    lueCustomerType.Enabled = false;
                    lueCustomerType.EditValue = Type;
                }
                else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                {
                    lueCustomerType.Enabled = false;
                    lueCustomerType.EditValue = Type;
                }
                else if (afrmLst_Companies_Old != null)
                {
                    lueCustomerType.Enabled = true;
                }
                else if (this.afrmTsk_Booking_Step2 != null)
                {
                    lueCustomerType.Enabled = false;
                    lueCustomerType.EditValue = Type;
                }
                else if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    lueCustomerType.Enabled = true;
                }
                else if (afrmMain != null)
                {
                    lueCustomerType.Enabled = true;
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Companies.frmIns_Companies_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Sale
       
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        int CusType;
        frmMain_Halls afrmMain_Halls = null;

        public frmIns_Companies(frmTsk_UpdBooking afrmTsk_UpdBooking, int CusType)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.CusType = CusType;
        }
        

        public frmIns_Companies(frmMain_Halls afrmMain_Halls)
        {
            InitializeComponent();
            this.afrmMain_Halls = afrmMain_Halls;
        }
        public frmIns_Companies(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
        }
        public frmIns_Companies(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
        }
        #endregion
    }
}