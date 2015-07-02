using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using DevExpress.XtraBars.Helpers;
using DataAccess;
using BussinessLogic;
using Entity;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraBars.Docking;
using System.IO;
using System.Globalization;
using CORESYSTEM;
using System.Timers;
using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // comment 

        public string a = "";
        SystemUsers aSystemUser = new SystemUsers();
        SystemUsersBO aSystemUserBO = new SystemUsersBO();
        DatabaseDA aDatabaseDA = new DatabaseDA();
        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
        ReportTaskBO aReportTaskBO = new ReportTaskBO();

        RoomsBO aRoomsBO = new RoomsBO();

        uc_CurrentUser auc_CurrentUser = new uc_CurrentUser();
        uc_StatusRooms auc_StatusRooms = new uc_StatusRooms();
        frmLogin afrmLogin = new frmLogin();
        public frmMain(frmLogin afrmLogin)
        {

            InitializeComponent();
            this.afrmLogin = afrmLogin;
        }
        #region Tabcontrol

        public void RefreshData_auc_StatusRooms(DateTime CheckTime)
        {
            //uc_StatusRooms
            auc_StatusRooms.Datasource = aRoomsBO.GetListStatusRoom(CheckTime).OrderBy(r => r.Sku).ToList();
            auc_StatusRooms.CheckTime = CheckTime;
            if (CheckTime.Date > DateTime.Now.Date) // tuong lai
            {
                auc_StatusRooms.StatusButtonPopup = 3;
            }
            else if (CheckTime.Date < DateTime.Now.Date) // Qua khu
            {
                auc_StatusRooms.StatusButtonPopup = 1;
            }
            else if (CheckTime.Date == DateTime.Now.Date) // hien tai
            {
                auc_StatusRooms.StatusButtonPopup = 2;
            }
            auc_StatusRooms.DataBind();

        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            // dong tab
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }

        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            // Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            RefreshData_auc_StatusRooms(DateTime.ParseExact(dtpSearch.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
        }

        public void LoadData()
        {
            try
            {
                dockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Fill);
                dtpSearch.DateTime = DateTime.Now;

                RefreshData_auc_StatusRooms(DateTime.Now);
                auc_StatusRooms.Dock = DockStyle.Fill;

                panStatusRoom.Controls.Add(auc_StatusRooms);

                auc_CurrentUser.DataSource = CORE.CURRENTUSER.SystemUser;
                auc_CurrentUser.DataSourceExtend = CORE.CURRENTUSER.SystemUserExts;
                auc_CurrentUser.Dock = DockStyle.Fill;

                dockCurrentUser.Text = dockCurrentUser.Text + " " + CORE.CURRENTUSER.SystemUser.Username;
                panCurrentUser.Controls.Add(auc_CurrentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.LoadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        //Hiennv
        public void ReloadData()
        {
            try
            {
                RefreshData_auc_StatusRooms(DateTime.Now);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.Visible = false;
            //frmLogin afrmLogin = new frmLogin(this);
            //afrmLogin.Top = 1000;
            //afrmLogin.Show();
            //LoadData();
            //dropDownButton1.DropDownControl = popupMenu3;

            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();

            this.barButtonItem2.Caption = "Caption 2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageIndex = 1;
            this.barButtonItem2.Name = "Caption name 2";

            this.barButtonItem1.Caption = "Caption 1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageIndex = 1;
            this.barButtonItem1.Name = "Caption name 1";

            popupMenu3.AddItem(barButtonItem1);
            popupMenu3.AddItem(barButtonItem2);


        }


        #region Nhân viên

        private void bnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void lbEdit_Click(object sender, EventArgs e)
        {

            frmUpd_SystemUsers afrmUpdSysUsers = new frmUpd_SystemUsers(this);
            afrmUpdSysUsers.ShowDialog();
        }

        #endregion


        #region ClickMenu


        private void bnViewCus_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLst_Customers afrmCus = new frmLst_Customers();
            afrmCus.ShowDialog();
        }

        private void bnAddCus_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIns_Customers afrmAddCus = new frmIns_Customers();
            afrmAddCus.ShowDialog();
        }

        private void bnViewCusGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLst_CustomerGroups afrmCustormerGroups = new frmLst_CustomerGroups();
            afrmCustormerGroups.ShowDialog();
        }


        private void bnViewSer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLst_Services afrmServices = new frmLst_Services();
            afrmServices.ShowDialog();
        }

        private void bnAddSer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIns_Services afrmAddSer = new frmIns_Services();
            afrmAddSer.ShowDialog();
        }

        private void bnViewSerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIns_ServiceGroups afrmAddSerGroup = new frmIns_ServiceGroups();
            afrmAddSerGroup.ShowDialog();
        }


        private void btnBooking_Type1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //frmTsk_Booking_Step1 afrmTsk_Booking_Step1 = new frmTsk_Booking_Step1(this, 1);// CustomerType =1 : Nha nuoc
                //afrmTsk_Booking_Step1.Show();

                frmTsk_BookingForRoom afrmTsk_BookingForRoom = new frmTsk_BookingForRoom(this, 1);
                afrmTsk_BookingForRoom.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnBooking_Type1_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBooking_Type2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //frmTsk_Booking_Step1 afrmTsk_Booking_Step1 = new frmTsk_Booking_Step1(this, 2);// CustomerType =2 : Khach doan
                //afrmTsk_Booking_Step1.Show();
                frmTsk_BookingForRoom afrmTsk_BookingForRoom = new frmTsk_BookingForRoom(this, 2);
                afrmTsk_BookingForRoom.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnBooking_Type2_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBooking_Type3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //frmTsk_Booking_Step1 afrmTsk_Booking_Step1 = new frmTsk_Booking_Step1(this, 3);// CustomerType =3 : Khach le
                //afrmTsk_Booking_Step1.Show();

                frmTsk_BookingForRoom afrmTsk_BookingForRoom = new frmTsk_BookingForRoom(this, 3);
                afrmTsk_BookingForRoom.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnBooking_Type3_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Type1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CheckIn afrmTsk_CheckIn = new frmTsk_CheckIn(this, 1);
                afrmTsk_CheckIn.Show();
                //frmTsk_CheckIn_Goverment_Step1 afrmTsk_CheckIn_Goverment_Step1 = new frmTsk_CheckIn_Goverment_Step1(this);
                //afrmTsk_CheckIn_Goverment_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckIn_Type1_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCheckIn_Type2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                frmTsk_CheckIn afrmTsk_CheckIn = new frmTsk_CheckIn(this, 2);
                afrmTsk_CheckIn.Show();
                //frmTsk_CheckIn_Group_Step1 afrmTsk_CheckIn_Group_Step1 = new frmTsk_CheckIn_Group_Step1(this);
                //afrmTsk_CheckIn_Group_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckIn_Type2_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Type3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CheckIn afrmTsk_CheckIn = new frmTsk_CheckIn(this, 3);
                afrmTsk_CheckIn.Show();
                //frmTsk_CheckIn_Customer_Step1 afrmTsk_CheckIn_Customer_Step1 = new frmTsk_CheckIn_Customer_Step1(this);
                //afrmTsk_CheckIn_Customer_Step1.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckIn_Type3_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUseService_Type1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_UseServices afrmTsk_UseServices = new frmTsk_UseServices();
                afrmTsk_UseServices.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnUseService_Type1_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUseService_Type2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_UseServices afrmTsk_UseServices = new frmTsk_UseServices();
                afrmTsk_UseServices.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnUseService_Type2_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUseService_Type3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_UseServices afrmTsk_UseServices = new frmTsk_UseServices();
                afrmTsk_UseServices.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnUseService_Type3_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_type1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_Payment_Step1 afrmTsk_Payment_Step1 = new frmTsk_Payment_Step1(this, 1);//1:Nha nuoc
                afrmTsk_Payment_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnPayment_type1_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_type2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_Payment_Step1 afrmTsk_Payment_Step1 = new frmTsk_Payment_Step1(this, 2);//2:Khach doan
                afrmTsk_Payment_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnPayment_type2_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_type3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_Payment_Step1 afrmTsk_Payment_Step1 = new frmTsk_Payment_Step1(this, 3); //3:Khach le
                afrmTsk_Payment_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnPayment_type3_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_type1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CheckOut afrmTsk_CheckOut = new frmTsk_CheckOut(this);
                afrmTsk_CheckOut.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckOut_type1_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_type2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CheckOut afrmTsk_CheckOut = new frmTsk_CheckOut(this);
                afrmTsk_CheckOut.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckOut_type2_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_type3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CheckOut afrmTsk_CheckOut = new frmTsk_CheckOut(this);
                afrmTsk_CheckOut.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckOut_type3_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLock_type1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_PendingRoom_Step1 afrmTsk_PendingRoom_Step1 = new frmTsk_PendingRoom_Step1(this);
                afrmTsk_PendingRoom_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLock_type1_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLock_type2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_PendingRoom_Step1 afrmTsk_PendingRoom_Step1 = new frmTsk_PendingRoom_Step1(this);
                afrmTsk_PendingRoom_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLock_type2_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLock_type3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_PendingRoom_Step1 afrmTsk_PendingRoom_Step1 = new frmTsk_PendingRoom_Step1(this);
                afrmTsk_PendingRoom_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLock_type3_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Companies afrmLst_Companies = new frmLst_Companies();
                afrmLst_Companies.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnListCompanies_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Companies afrmIns_Companies = new frmIns_Companies(this);
                afrmIns_Companies.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsCompanies_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListCustomerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_CustomerGroups afrmLst_CustomerGroups = new frmLst_CustomerGroups();
                afrmLst_CustomerGroups.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnListCustomerGroup_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsCustomerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups();
                afrmIns_CustomerGroups.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsCustomerGroup_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Customers afrmLst_Customers = new frmLst_Customers(this);
                afrmLst_Customers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstCustomer_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Customers afrmIns_Customers = new frmIns_Customers();
                afrmIns_Customers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsCustomer_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstGroupService_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_ServiceGroups afrmIns_ServiceGroups = new frmIns_ServiceGroups();
                afrmIns_ServiceGroups.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstGroupService_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsGroupService_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_ServiceGroups afrmIns_ServiceGroups = new frmIns_ServiceGroups();
                afrmIns_ServiceGroups.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsGroupService_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstService_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Services afrmLst_Services = new frmLst_Services();
                afrmLst_Services.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstService_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsService_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Services afrmIns_Services = new frmIns_Services();
                afrmIns_Services.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsService_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Rooms afrmLst_Rooms = new frmLst_Rooms(this);
                afrmLst_Rooms.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstRoom_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Rooms afrmIns_Rooms = new frmIns_Rooms(this);
                afrmIns_Rooms.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsRoom_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstSystemUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_SystemUsers afrmLst_SystemUsers = new frmLst_SystemUsers();
                afrmLst_SystemUsers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstSystemUser_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsSystemUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_SystemUsers afrmIns_SystemUsers = new frmIns_SystemUsers();
                afrmIns_SystemUsers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUser_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstSystemUserPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstSystemUserPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsSystemUserPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUserPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstDetailPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_PermitDetails afrmLst_PermitDetails = new frmLst_PermitDetails();
                afrmLst_PermitDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstDetailPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsDetailPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_PermitDetail afrmIns_PermitDetail = new frmIns_PermitDetail();
                afrmIns_PermitDetail.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsDetailPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Permits afrmLst_Permits = new frmLst_Permits();
                afrmLst_Permits.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Permits afrmIns_Permits = new frmIns_Permits();
                afrmIns_Permits.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportPerformance_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Permits afrmIns_Permits = new frmIns_Permits();
                afrmIns_Permits.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Configs afrmLst_Configs = new frmLst_Configs();
                afrmLst_Configs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstConfig_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Configs afrmIns_Configs = new frmIns_Configs();
                afrmIns_Configs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsConfig_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnRenvenuesRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_Calculator_Revenue afrmTsk_Calculator_Revenue = new frmTsk_Calculator_Revenue();
                afrmTsk_Calculator_Revenue.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnRevenuesRooms_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPerformanceRooms_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CalculationEfficiency afrmTsk_CalculationEfficiency = new frmTsk_CalculationEfficiency();
                afrmTsk_CalculationEfficiency.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnPerformancesRooms_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckInPending_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_PendingCheckIn_Step1 afrmTsk_PendingCheckIn_Step1 = new frmTsk_PendingCheckIn_Step1(this);
                afrmTsk_PendingCheckIn_Step1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckInPending_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = new frmIns_CustomerGroups_Customers();
            afrmIns_CustomerGroups_Customers.ShowDialog();
        }

        private void btnOverNightCus_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTsk_GetListOverNightCustomer afrmTsk_GetListOverNightCustomer = new frmTsk_GetListOverNightCustomer();
            afrmTsk_GetListOverNightCustomer.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIns_CheckPoint afrmIns_CheckPoint = new frmIns_CheckPoint();
            afrmIns_CheckPoint.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLst_CheckPoint afrmLst_CheckPoint = new frmLst_CheckPoint();
            afrmLst_CheckPoint.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTsk_ListBookingRs afrmTsk_ListBookingRs = new frmTsk_ListBookingRs(this, 1); //customerType =1: Khach nha nuoc
            afrmTsk_ListBookingRs.ShowDialog();
        }
        //hiennv
        private void btnCheckinGroupForRoomBooking_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_ListBookingRs afrmTsk_ListBookingRs = new frmTsk_ListBookingRs(this, 2);//customerType =2: Khach doan
                afrmTsk_ListBookingRs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckinGroupForRoomBooking_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnCheckInClientForRoomBooking_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_ListBookingRs afrmTsk_ListBookingRs = new frmTsk_ListBookingRs(this, 3);//customerType =3: Khach le
                afrmTsk_ListBookingRs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckInClientForRoomBooking_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //tqtrung
        private void btnCheckoutExpire_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_CheckOutExpire afrmTsk_CheckOutExpire = new frmTsk_CheckOutExpire();
                afrmTsk_CheckOutExpire.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnCheckInClientForRoomBooking_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime aTimeToExecute = DateTime.Now.Date.AddHours(21).AddMinutes(00);
            if (DateTime.Now.TimeOfDay == aTimeToExecute.TimeOfDay)
            {
                List<OverNightCustomerEN> aListForeign = aReportTaskBO.GetOverNightCustomer(DateTime.Now, 3).Where(a => a.Nationality != "VIET NAM").ToList();
                string FileName = aReceptionTaskBO.ExportDBF(aListForeign);
                string SendEmail = CORE.CONSTANTS.ListEmails.SenderMail.ID;
                string Pass = CORE.CONSTANTS.ListEmails.SenderMail.PassWord;
                string ReceiveEmail1 = CORE.CONSTANTS.ListEmails.ReceiverMail1.ID;
                string ReceiveEmail2 = CORE.CONSTANTS.ListEmails.ReceiverMail2.ID;
                string subject = "Gửi thông báo tạm trú ngày :" + String.Format("{0:MM-dd-yyyy}", DateTime.Now);
                aReceptionTaskBO.SendMail(SendEmail, Pass, ReceiveEmail1, subject, FileName);
                aReceptionTaskBO.SendMail(SendEmail, Pass, ReceiveEmail2, subject, FileName);
            }
        }

        private void btnListCustomersCurrentInRooms_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_ListCustomersCurrentInRoom afrmTsk_ListCustomersCurrentInRoom = new frmTsk_ListCustomersCurrentInRoom();
                afrmTsk_ListCustomersCurrentInRoom.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnListCustomersCurrentInRooms_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMain_Halls afrmMain_Halls = new frmMain_Halls();
            afrmMain_Halls.Show();
        }

        private void btnPerformanceRooms_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTsk_StatusInMonth_Room aTemp = new frmTsk_StatusInMonth_Room();
            aTemp.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTsk_AllRevenues afrmTsk_AllRevenues = new frmTsk_AllRevenues();
            afrmTsk_AllRevenues.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTsk_PaymentViewAll_New afrmTsk_PaymentViewAll_New = new frmTsk_PaymentViewAll_New();
            afrmTsk_PaymentViewAll_New.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmTsk_BookingHall_Customer_New aTemp = new frmTsk_BookingHall_Customer_New(this);
            aTemp.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.afrmLogin.Close();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLst_CustomerGroups_2 afrmLst_CustomerGroups_2 = new frmLst_CustomerGroups_2();
            afrmLst_CustomerGroups_2.ShowDialog();
        }

















    }
}