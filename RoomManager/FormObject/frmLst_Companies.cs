using System;
using System.Windows.Forms;
using BussinessLogic;

using DataAccess;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;


namespace RoomManager
{
    public partial class frmLst_Companies : DevExpress.XtraEditors.XtraForm
    {
        #region Room
        public frmLst_Companies()
        {
            InitializeComponent();
            this.gridColumn14.Visible = false;
        }

        private frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2 = null;
        private frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2 = null;
        private frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = null;
        private frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2 = null;

        private frmTsk_Booking_Step2 afrmTsk_Booking_Step2 = null;
        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers_Old = null;
        frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New = null;
        private int Type = 0;

        public frmLst_Companies(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers)
        {
            InitializeComponent();
            afrmIns_CustomerGroups_Customers_Old = afrmIns_CustomerGroups_Customers;
        }
        public frmLst_Companies(frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2, int Type)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Goverment_Step2 = afrmTsk_CheckIn_Goverment_Step2;
            this.Type = Type;
        }
        public frmLst_Companies(frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New, int Type)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer_New = afrmTsk_BookingHall_Customer_New;
            this.Type = Type;
        }
        //hiennv
        public frmLst_Companies(frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2, int Type)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = afrmTsk_CheckInGoverment_ForRoomBooking_Step2;
            this.Type = Type;
        }
        //hiennv
        public frmLst_Companies(frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2, int Type)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 = afrmTsk_CheckInGroup_ForRoomBooking_Step2;
            this.Type = Type;
        }


        public frmLst_Companies(frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2, int Type)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Group_Step2 = afrmTsk_CheckIn_Group_Step2;
            this.Type = Type;
        }

        public frmLst_Companies(frmTsk_Booking_Step2 afrmTsk_Booking_Step2, int Type)
        {
            InitializeComponent();
            this.afrmTsk_Booking_Step2 = afrmTsk_Booking_Step2;
            this.Type = Type;
        }

     

        private void btnSelectIDCompanies_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(viewAvailableCompanies.GetFocusedRowCellValue("ID").ToString());
                if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                {
                    this.afrmTsk_CheckIn_Goverment_Step2.CallBackIDCompany(id);
                }
                else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                {
                    this.afrmTsk_CheckIn_Group_Step2.CallBackIDCompany(id);
                }
                else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null)
                {
                    this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.CallBackIDCompany(id);
                }
                else if (this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null)
                {
                    this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.CallBackIDCompany(id);
                }
                else if (this.afrmTsk_Booking_Step2 != null)
                {
                    this.afrmTsk_Booking_Step2.CallBackIDCompany(id);
                }
                else if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    afrmIns_CustomerGroups_Customers_Old.CallBackIDCompany(id);
                }
                if (this.afrmTsk_BookingHall_Goverment != null)
                {
                    this.afrmTsk_BookingHall_Goverment.CallBackIDCompany(id);
                }
                if (this.afrmTsk_BookingHall_Group != null)
                {
                    this.afrmTsk_BookingHall_Group.CallBackIDCompany(id);
                }
                if (this.afrmTsk_UpdBooking != null)
                {
                    this.afrmTsk_UpdBooking.CallBackIDCompany(id);
                }
                if (this.afrmTsk_BookingHall_Customer_New != null)
                {
                    this.afrmTsk_BookingHall_Customer_New.CallBackIDCompany(id);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Companies.btnSelectIDCompanies_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLst_Companies_Load(object sender, EventArgs e)
        {
            try
            {
                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Companies.frmLst_Companies_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReloadData()
        {
            try
            {
                dgvAvailableCompanies.DataSource = null;

                List<Companies> aListCompanies = new List<Companies>();
                CompaniesBO aCompaniesBO = new CompaniesBO();
                if (afrmTsk_CheckIn_Goverment_Step2 != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else if (afrmTsk_CheckIn_Group_Step2 != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else if (afrmTsk_Booking_Step2 != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    aListCompanies = aCompaniesBO.Select_All();
                    btnAdd.Visible = false;
                }
                else if (afrmTsk_BookingHall_Customer_New != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else
                {
                    aListCompanies = aCompaniesBO.Select_All();
                    btnAdd.Visible = true;
                }
               

                dgvAvailableCompanies.DataSource = aListCompanies;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Companies.ReloadData\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CompaniesBO aCompaniesBO = new CompaniesBO();
            int ID = int.Parse(viewAvailableCompanies.GetFocusedRowCellValue("ID").ToString());
            string Name = aCompaniesBO.Select_ByID(ID).Name;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa công ty " + Name + " này không?", "Xóa công ty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aCompaniesBO.Delete(ID);
                MessageBox.Show("Xóa thành công");
                this.ReloadData();
            }

        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(viewAvailableCompanies.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Companies afrmUpd_Companies = new frmUpd_Companies(ID, this);
            afrmUpd_Companies.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmIns_Companies afrmIns_Companies = new frmIns_Companies(this);
            afrmIns_Companies.ShowDialog();
        }
        #endregion
        #region Sale

        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;

        public frmLst_Companies(frmTsk_UpdBooking afrmTsk_UpdBooking, int Type)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.Type = Type;
        }

        public frmLst_Companies(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group, int Type)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
            this.Type = Type;
        }
        public frmLst_Companies(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment, int Type)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
            this.Type = Type;
        }
        #endregion
    }
}