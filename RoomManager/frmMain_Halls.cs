using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using RoomManager;
using CORESYSTEM;
using DataAccess;
using BussinessLogic;
using Entity;


namespace RoomManager
{
    public partial class frmMain_Halls : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain_Halls()
        {
            InitializeComponent();
            this.Visible = false;
        }
        #region Goverment
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer = new frmTsk_BookingHall_Customer_New(this, 1);
            afrmTsk_BookingHall_Customer.Show();
        }
        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_ManageBookingHs afrmTsk_ManageBookingHs = new frmTsk_ManageBookingHs();
            afrmTsk_ManageBookingHs.ShowDialog();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_CheckMenus afrmTsk_CheckMenus = new frmTsk_CheckMenus();
            afrmTsk_CheckMenus.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_ListBookingHs afrmTsk_ListBookingHs = new frmTsk_ListBookingHs();
            afrmTsk_ListBookingHs.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_UnpayBookingHs afrmTsk_UnpayBookingHs = new frmTsk_UnpayBookingHs();
            afrmTsk_UnpayBookingHs.ShowDialog();
        }
        #endregion
        #region Group
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer = new frmTsk_BookingHall_Customer_New(this, 2);
            afrmTsk_BookingHall_Customer.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_CheckMenus afrmTsk_CheckMenus = new frmTsk_CheckMenus();
            afrmTsk_CheckMenus.ShowDialog();

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_ListBookingHs afrmTsk_ListBookingHs = new frmTsk_ListBookingHs();
            afrmTsk_ListBookingHs.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_UnpayBookingHs afrmTsk_UnpayBookingHs = new frmTsk_UnpayBookingHs();
            afrmTsk_UnpayBookingHs.ShowDialog();
        }
        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_ManageBookingHs afrmTsk_ManageBookingHs = new frmTsk_ManageBookingHs();
            afrmTsk_ManageBookingHs.ShowDialog();
        }
        #endregion
        #region Customer
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer = new frmTsk_BookingHall_Customer_New(this, 3);
            afrmTsk_BookingHall_Customer.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_CheckMenus afrmTsk_CheckMenus = new frmTsk_CheckMenus();
            afrmTsk_CheckMenus.ShowDialog();

        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_ListBookingHs afrmTsk_ListBookingHs = new frmTsk_ListBookingHs();
            afrmTsk_ListBookingHs.ShowDialog();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTsk_UnpayBookingHs afrmTsk_UnpayBookingHs = new frmTsk_UnpayBookingHs();
            afrmTsk_UnpayBookingHs.ShowDialog();
        }
        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmTsk_ManageBookingHs afrmTsk_ManageBookingHs = new frmTsk_ManageBookingHs();
            afrmTsk_ManageBookingHs.ShowDialog();

        }
        #endregion
        #region Management Object
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_Companies afrmLst_Companies = new frmLst_Companies();
            afrmLst_Companies.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_Companies afrmIns_Companies = new frmIns_Companies();
            afrmIns_Companies.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_CustomerGroups afrmLst_CustomerGroups = new frmLst_CustomerGroups();
            afrmLst_CustomerGroups.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups();
            afrmIns_CustomerGroups.ShowDialog();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_Customers afrmLst_Customers = new frmLst_Customers();
            afrmLst_Customers.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_Customers afrmIns_Customers = new frmIns_Customers();
            afrmIns_Customers.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = new frmIns_CustomerGroups_Customers();
            afrmIns_CustomerGroups_Customers.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_Guests afrmLst_Guests = new frmLst_Guests();
            afrmLst_Guests.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_Guest afrmIns_Guest = new frmIns_Guest();
            afrmIns_Guest.ShowDialog();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_Halls afrmLst_Halls = new frmLst_Halls();
            afrmLst_Halls.Show();

        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_Halls afrmIns_Halls = new frmIns_Halls();
            afrmIns_Halls.ShowDialog();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_Services afrmLst_Services = new frmLst_Services();
            afrmLst_Services.Show();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_Services afrmIns_Services = new frmIns_Services();
            afrmIns_Services.ShowDialog();
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_Menus afrmLst_Menus = new frmLst_Menus();
            afrmLst_Menus.Show();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_Menus afrmIns_Menus = new frmIns_Menus(1);//type=1:thực đơn thông dụng
            afrmIns_Menus.ShowDialog();
        }
        #endregion
        #region Setup
        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLst_SystemUsers afrmLst_SystemUsers = new frmLst_SystemUsers();
            afrmLst_SystemUsers.Show();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmIns_SystemUsers afrmIns_SystemUsers = new frmIns_SystemUsers();
            afrmIns_SystemUsers.ShowDialog();
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        #endregion 

       

      
        #region LoadData
        private void frmMain_Load(object sender, EventArgs e)
        {
            Reload();
            
        }
        public void Reload()
        {
            try
            {
                dtpFrom.DateTime = DateTime.Now.AddDays(-7);
                dtpTo.DateTime = DateTime.Now.AddDays(1);
                lueStatus.Properties.DataSource = CORE.CONSTANTS.ListBookingHStatus;
                lueStatus.Properties.DisplayMember = "Name";
                lueStatus.Properties.ValueMember = "ID";
                lueStatus.EditValue = CORE.CONSTANTS.SelectedCustomerStatus(1).ID;

                dgvChecked.DataSource = LoadData(2);
                dgvChecked.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.Reload\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<BookingHEN> LoadData(int Status)
        {
          
                BookingHsBO aBookingHsBO = new BookingHsBO();
                List<BookingHEN> aListBookedHs = new List<BookingHEN>();
                List<BookingHs> aListTemp = new List<BookingHs>();
                aListTemp = aBookingHsBO.SelectBookingHs_ByTime_ByStatus(dtpFrom.DateTime, dtpTo.DateTime, Status);
                BookingHEN aBookingHEN;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aBookingHEN = new BookingHEN();
                    aBookingHEN.SetValue(aListTemp[i]);
                    aBookingHEN.StatusPayDisplay = CORE.CONSTANTS.SelectedStatusPay(Convert.ToInt16(aBookingHEN.StatusPay)).Name;
                    aBookingHEN.CustomerTypeDisplay = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt16(aBookingHEN.CustomerType)).Name;
                    aBookingHEN.StatusDisplay = CORE.CONSTANTS.SelectedBookingHStatus(Convert.ToInt16(aBookingHEN.Status)).Name;
                    if (aBookingHEN.Type == 1)
                    {
                        aBookingHEN.TypeDisplay = "Tiệc không thuộc phạm trù nhà bếp";
                    }
                    else
                    {
                        aBookingHEN.TypeDisplay = "Tiệc thuộc phạm trù nhà bếp";
                    }
                    aListBookedHs.Add(aBookingHEN);
                }
                return aListBookedHs;           
        }      
        #endregion

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            
            dgvAccepted.DataSource = LoadData(4);
            dgvAccepted.RefreshDataSource();
        }

      

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraTabPage1)
            {
                dgvChecked.DataSource = LoadData(2);
                dgvChecked.RefreshDataSource();
            }
            else if (e.Page == xtraTabPage2)
            {
                dgvAccepted.DataSource = LoadData(4);
                dgvAccepted.RefreshDataSource();
            }
            else if (e.Page == xtraTabPage3)
            {
                dgvReady.DataSource = LoadData(6);
                dgvReady.RefreshDataSource();
            }
            else if (e.Page == xtraTabPage4)
            {
                dgvDone.DataSource = LoadData(7);
                dgvDone.RefreshDataSource();
            }
        }

        private void lueStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (lueStatus.ItemIndex == 6)
            {
                gridColumn34.Visible = false;
            }
            else if (lueStatus.ItemIndex == 7)
            {
                gridColumn34.Visible = false;
            }
            int Status = Convert.ToInt32(lueStatus.EditValue);
            dgvBookingHs.DataSource = LoadData(Status);
            dgvBookingHs.RefreshDataSource();
        }

        private void btnEditBookingH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingH = Convert.ToInt32(grvChecked.GetFocusedRowCellValue("ID"));
                BookingRs_BookingHs aBookingRs_BookingHs = (new BookingRs_BookingHsBO()).Select_ByIDBookingH(IDBookingH);
                BookingRs aBookingRs = (new BookingRsBO()).Select_ByID(aBookingRs_BookingHs.IDBookingR.GetValueOrDefault(0));
                //frmTsk_UpdBookingHall afrmTsk_UpdBookingHall = new frmTsk_UpdBookingHall(this, IDBookingH);
                //afrmTsk_UpdBookingHall.ShowDialog();
                frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = new frmTsk_Payment_Step2(aBookingRs_BookingHs.IDBookingR.GetValueOrDefault(0), IDBookingH, aBookingRs.Status.GetValueOrDefault(0), false);
                afrmTsk_Payment_Step2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain_Halls.btnEdit_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditKitchenAccept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingH = Convert.ToInt32(grvAccepted.GetFocusedRowCellValue("ID"));
                frmTsk_UpdBooking afrmTsk_UpdBooking = new frmTsk_UpdBooking(this, IDBookingH);
                afrmTsk_UpdBooking.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain_Halls.btnEdit_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditReady_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingH = Convert.ToInt32(grvReady.GetFocusedRowCellValue("ID"));
                frmTsk_UpdBooking afrmTsk_UpdBooking = new frmTsk_UpdBooking(this, IDBookingH);
                afrmTsk_UpdBooking.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain_Halls.btnEdit_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
               
                int IDBookingH = Convert.ToInt32(grvReady.GetFocusedRowCellValue("ID"));
                frmTsk_UpdBooking afrmTsk_UpdBooking = new frmTsk_UpdBooking(this, IDBookingH);
                afrmTsk_UpdBooking.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain_Halls.btnEdit_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
  
                //lueStatus.Properties.DataSource = CORE.CONSTANTS.ListBookingHStatus;
                //lueStatus.Properties.DisplayMember = "Name";
                //lueStatus.Properties.ValueMember = "ID";
                //lueStatus.EditValue = CORE.CONSTANTS.SelectedCustomerStatus(1).ID;

                dgvChecked.DataSource = LoadData(2);
                dgvChecked.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.Reload\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                //lueStatus.Properties.DataSource = CORE.CONSTANTS.ListBookingHStatus;
                //lueStatus.Properties.DisplayMember = "Name";
                //lueStatus.Properties.ValueMember = "ID";
                //lueStatus.EditValue = CORE.CONSTANTS.SelectedCustomerStatus(1).ID;

                dgvChecked.DataSource = LoadData(2);
                dgvChecked.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.Reload\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  

               

      
       
    }
}