using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_CheckIn_Goverment_Step3 : DevExpress.XtraEditors.XtraForm
    {
        private frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2 = null;
        private CheckInEN aCheckInEN = new CheckInEN();
        private List<Customers> aListCustomers = new List<Customers>();

        public frmTsk_CheckIn_Goverment_Step3(frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2, CheckInEN aCheckInEN)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Goverment_Step2 = afrmTsk_CheckIn_Goverment_Step2;
            this.aCheckInEN = aCheckInEN;
            CustomersBO aCustomersBO = new CustomersBO();
            this.aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(aCheckInEN.IDCustomerGroup);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTsk_CheckIn_Goverment_Step3_Load(object sender, EventArgs e)
        {
            try
            {

                lueIDRooms.Properties.DataSource = aCheckInEN.aListRoomMembers;
                lueIDRooms.Properties.DisplayMember = "RoomSku";
                lueIDRooms.Properties.ValueMember = "RoomCode";
                lueIDRooms.EditValue = aCheckInEN.aListRoomMembers.ToList()[0].RoomCode;
                this.aListCustomers = this.RemoveCustomerExistInCheckInEN(this.aListCustomers);
                dgvAvailableCustomer.DataSource = this.aListCustomers;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.frmTsk_CheckIn_Goverment_Step3_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLueIDRooms()
        {
            try
            {
                string CodeRoom = Convert.ToString(lueIDRooms.EditValue);
                RoomMemberEN aRoomMemberEN = aCheckInEN.aListRoomMembers.Where(p => p.RoomCode == CodeRoom).ToList()[0];
                int Index = aCheckInEN.aListRoomMembers.IndexOf(aRoomMemberEN);
                dgvSelectCustomer.DataSource = aCheckInEN.aListRoomMembers[Index].ListCustomer;
                dgvSelectCustomer.RefreshDataSource();

                if (aCheckInEN.aListRoomMembers[Index].ListCustomer.Count > 0)
                {
                    this.ReloadExtendInfoBookingRoomMembers(aRoomMemberEN.ListCustomer[0].ID);
                }
                else
                {
                    lblIDCustomer.Text =null;
                    txtPurposeComeVietnam.Text =null;
                    txtOrganization.Text = null;
                    txtEnterGate.Text =null;
                    dtpDateEnterCountry.EditValue = null;
                    dtpLeaveDate.EditValue=null;
                    dtpLimitDateEnterCountry.EditValue =null;
                    dtpTemporaryResidenceDate.EditValue =null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.LoadLueIDRooms\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lueIDRooms_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadLueIDRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.lueIDRooms_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CustomerInfoEN aCustomersInfo = new CustomerInfoEN();
                aCustomersInfo.ID = Convert.ToInt32(Convert.ToString(viewAvailableCustomer.GetFocusedRowCellValue("ID")));
                aCustomersInfo.Name = Convert.ToString(viewAvailableCustomer.GetFocusedRowCellValue("Name"));
                aCustomersInfo.Identifier1 = Convert.ToString(viewAvailableCustomer.GetFocusedRowCellValue("Identifier1"));

                if(aCustomersInfo.Birthday !=null)
                {
                    aCustomersInfo.Birthday = Convert.ToDateTime(viewAvailableCustomer.GetFocusedRowCellValue("Birthday"));
                }

                RoomMemberEN aItem = aCheckInEN.aListRoomMembers.Where(p => p.RoomCode == lueIDRooms.EditValue.ToString()).ToList()[0];
                int Index = aCheckInEN.aListRoomMembers.IndexOf(aItem);
                aCheckInEN.aListRoomMembers[Index].ListCustomer.Add(aCustomersInfo);
                dgvSelectCustomer.DataSource = aCheckInEN.aListRoomMembers[Index].ListCustomer;
                dgvSelectCustomer.RefreshDataSource();

                Customers Temps = aListCustomers.Where(c => c.ID == Convert.ToInt32(viewAvailableCustomer.GetFocusedRowCellValue("ID"))).ToList()[0];
                aListCustomers.Remove(Temps);
                dgvAvailableCustomer.DataSource = this.aListCustomers;
                dgvAvailableCustomer.RefreshDataSource();

                txtPurposeComeVietnam.Text = null;
                txtEnterGate.Text = null;
                txtOrganization.Text =null;
                dtpDateEnterCountry.EditValue = null;
                dtpLeaveDate.EditValue = null;
                dtpLimitDateEnterCountry.EditValue = null;
                dtpTemporaryResidenceDate.EditValue = null;

                this.ReloadExtendInfoBookingRoomMembers(aCustomersInfo.ID);

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.btnSelectCustomer_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Customers aCustomers = new Customers();
                aCustomers.ID = Convert.ToInt32(Convert.ToString(viewSelectCustomer.GetFocusedRowCellValue("ID")));
                aCustomers.Name = Convert.ToString(viewSelectCustomer.GetFocusedRowCellValue("Name"));
                aCustomers.Identifier1 = Convert.ToString(viewSelectCustomer.GetFocusedRowCellValue("Identifier1"));
                if(aCustomers.Birthday !=null)
                {
                    aCustomers.Birthday = Convert.ToDateTime(viewSelectCustomer.GetFocusedRowCellValue("Birthday"));
                }

                aListCustomers.Insert(0, aCustomers);
                dgvAvailableCustomer.DataSource = aListCustomers;
                dgvAvailableCustomer.RefreshDataSource();

                RoomMemberEN aItem = aCheckInEN.aListRoomMembers.Where(p => p.RoomCode == lueIDRooms.EditValue.ToString()).ToList()[0];
                int Index = aCheckInEN.aListRoomMembers.IndexOf(aItem);

                CustomerInfoEN Temps = aCheckInEN.aListRoomMembers[Index].ListCustomer.Where(c => c.ID == Convert.ToInt32(viewSelectCustomer.GetFocusedRowCellValue("ID"))).ToList()[0];
                aCheckInEN.aListRoomMembers[Index].ListCustomer.Remove(Temps);
                dgvSelectCustomer.DataSource = aCheckInEN.aListRoomMembers[Index].ListCustomer;
                dgvSelectCustomer.RefreshDataSource();
                this.LoadLueIDRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.btnRemoveCustomer_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btReservation_Click(object sender, EventArgs e)
        {
            try
            {
                ReceptionTaskBO aCheckInActionBO = new ReceptionTaskBO();

                aCheckInEN.CustomerType = 1;  // 1: Khach nha nuoc, 2: Khach doan, 3: khach le, 4: Khach vang lai
                aCheckInEN.BookingType = 3;   // 1: Dat onlie, 2: Dat qua dien thoai, 3: Truc tiep, 4: Cong van
                aCheckInEN.IDSystemUser = CORE.CURRENTUSER.SystemUser.ID; ;
                aCheckInEN.PayMenthod = 1;     //1:Tien mat
                if (aCheckInEN.BookingMoney > 0)
                {
                    aCheckInEN.StatusPay = 2; //2:Tam ung
                }
                else
                {
                    aCheckInEN.StatusPay = 1; //1:chua thanh toan
                }
                aCheckInEN.ExchangeRate = 0;
                aCheckInEN.Status = 3; // 3 : da checkin
                aCheckInEN.Type = -1;
                aCheckInEN.Disable = false;


                aCheckInActionBO.CheckIn(aCheckInEN);
                MessageBox.Show("Đặt phòng thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.afrmTsk_CheckIn_Goverment_Step2.Close();
                this.afrmTsk_CheckIn_Goverment_Step2.afrmTsk_CheckIn_Goverment_Step1.Close();
                if (this.afrmTsk_CheckIn_Goverment_Step2.afrmTsk_CheckIn_Goverment_Step1.afrmMain != null)
                {
                    this.afrmTsk_CheckIn_Goverment_Step2.afrmTsk_CheckIn_Goverment_Step1.afrmMain.ReloadData();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.btReservation_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewSelectCustomer_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int IDCustomer = Convert.ToInt32(viewSelectCustomer.GetFocusedRowCellValue("ID"));

                txtPurposeComeVietnam.Text = null;
                txtEnterGate.Text =null;
                txtOrganization.Text =null;
                dtpDateEnterCountry.EditValue = null;
                dtpLeaveDate.EditValue = null;
                dtpLimitDateEnterCountry.EditValue = null;
                dtpTemporaryResidenceDate.EditValue = null;

                this.ReloadExtendInfoBookingRoomMembers(IDCustomer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.viewSelectCustomer_RowClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReloadExtendInfoBookingRoomMembers(int IDCustomer)
        {
            try
            {
                CustomerInfoEN aCustomerInfo = this.aCheckInEN.GetCustomer(IDCustomer);

                lblIDCustomer.Text = Convert.ToString(aCustomerInfo.ID);

                if (String.IsNullOrEmpty(aCustomerInfo.PurposeComeVietnam) == false)
                {
                    txtPurposeComeVietnam.Text = aCustomerInfo.PurposeComeVietnam;
                }

                if (String.IsNullOrEmpty(aCustomerInfo.Organization) == false)
                {
                    txtOrganization.Text = aCustomerInfo.Organization;
                }

                if (String.IsNullOrEmpty(aCustomerInfo.EnterGate) == false)
                {
                    txtEnterGate.Text = aCustomerInfo.EnterGate;
                }

                if (aCustomerInfo.DateEnterCountry != null)
                {
                    dtpDateEnterCountry.DateTime = aCustomerInfo.DateEnterCountry.GetValueOrDefault();
                }
                if (aCustomerInfo.LeaveDate != null)
                {
                    dtpLeaveDate.DateTime = aCustomerInfo.LeaveDate.GetValueOrDefault();
                }
                if (aCustomerInfo.LimitDateEnterCountry != null)
                {
                    dtpLimitDateEnterCountry.DateTime = aCustomerInfo.LimitDateEnterCountry.GetValueOrDefault();
                }
                if (aCustomerInfo.TemporaryResidenceDate != null)
                {
                    dtpTemporaryResidenceDate.DateTime = aCustomerInfo.TemporaryResidenceDate.GetValueOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.ReloadExtendInfoBookingRoomMembers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region
        private void txtPurposeComeVietnam_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPurposeComeVietnam.Text) == false)
            {
                this.AddExtendInfoBookingRoomMembers();
            }
        }

        private void txtEnterGate_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEnterGate.Text) == false)
            {
                this.AddExtendInfoBookingRoomMembers();
            }
        }

        private void txtOrganization_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOrganization.Text) == false)
            {
                this.AddExtendInfoBookingRoomMembers();
            }
        }

        private void AddExtendInfoBookingRoomMembers()
        {
            DateTime? DateNull = null;

            int IDCustomer = String.IsNullOrEmpty(lblIDCustomer.Text) == true ? 0 : Convert.ToInt32(lblIDCustomer.Text);
            
            RoomMemberEN aRoomMemberEN = aCheckInEN.aListRoomMembers.Where(a => a.RoomCode == lueIDRooms.EditValue.ToString()).ToList()[0];
            int index = aCheckInEN.aListRoomMembers.IndexOf(aRoomMemberEN);
            string RoomCode = aCheckInEN.aListRoomMembers[index].RoomCode;

            CustomerInfoEN aCustomerInfo = this.aCheckInEN.GetCustomer(IDCustomer);

            aCustomerInfo.PurposeComeVietnam = String.IsNullOrEmpty(txtPurposeComeVietnam.Text) == true ? null : txtPurposeComeVietnam.Text;

            aCustomerInfo.LimitDateEnterCountry = dtpLimitDateEnterCountry.EditValue == null ? DateNull : dtpLimitDateEnterCountry.DateTime;

            aCustomerInfo.Organization = String.IsNullOrEmpty(txtOrganization.Text) == true ? null : txtOrganization.Text;

            aCustomerInfo.LeaveDate = dtpLeaveDate.EditValue == null ? DateNull : dtpLeaveDate.DateTime;

            aCustomerInfo.TemporaryResidenceDate = dtpTemporaryResidenceDate.EditValue == null ? DateNull : dtpTemporaryResidenceDate.DateTime;

            aCustomerInfo.EnterGate = String.IsNullOrEmpty(txtEnterGate.Text) == true ? null : txtEnterGate.Text;

            aCustomerInfo.DateEnterCountry = dtpDateEnterCountry.EditValue == null ? DateNull : dtpDateEnterCountry.DateTime;

            if (IDCustomer > 0)
            {
                this.aCheckInEN.UpdateCustomerToRoom(RoomCode, aCustomerInfo);
                dgvSelectCustomer.DataSource = aCheckInEN.aListRoomMembers[index].ListCustomer;
                dgvSelectCustomer.RefreshDataSource();
            }
        }

        private List<Customers> RemoveCustomerExistInCheckInEN(List<Customers> aList)
        {
            List<Customers> aListCustomer = new List<Customers>();

            for (int i = 0; i < this.aCheckInEN.aListRoomMembers.Count; i++)
            {
                for (int ii = 0; ii < this.aCheckInEN.aListRoomMembers[i].ListCustomer.Count; ii++)
                {
                    aListCustomer = aList.Where(p => p.ID == this.aCheckInEN.aListRoomMembers[i].ListCustomer[ii].ID).ToList();
                    if (aListCustomer.Count > 0)
                    {
                        aList.Remove(aListCustomer[0]);
                    }
                }
            }
            return aList;
        }

        #endregion

        private void dtpTemporaryResidenceDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dtpTemporaryResidenceDate.EditValue != null)
                {
                    if (dtpTemporaryResidenceDate.DateTime > DateTime.Now.Date)
                    {
                        dtpTemporaryResidenceDate.Focus();
                        MessageBox.Show("Ngày đăng ký tạm trú phải nhỏ hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.AddExtendInfoBookingRoomMembers();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.dtpDateEnterCountry_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpLeaveDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dtpLeaveDate.EditValue != null)
                {
                    if (dtpLeaveDate.DateTime < DateTime.Now.Date)
                    {
                        dtpLeaveDate.Focus();
                        MessageBox.Show("Ngày đi dự kiến phải lớn hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.AddExtendInfoBookingRoomMembers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.dtpDateEnterCountry_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpLimitDateEnterCountry_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dtpLimitDateEnterCountry.EditValue != null)
                {
                    if (dtpLimitDateEnterCountry.DateTime < DateTime.Now.Date)
                    {
                        dtpLimitDateEnterCountry.Focus();
                        MessageBox.Show("Ngày hết hạn cư trú phải lớn hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.AddExtendInfoBookingRoomMembers();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.dtpDateEnterCountry_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDateEnterCountry_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateEnterCountry.EditValue != null)
                {
                    if (dtpDateEnterCountry.DateTime > DateTime.Now.Date)
                    {
                        dtpDateEnterCountry.Focus();
                        MessageBox.Show("Ngày nhập cảnh phải nhỏ hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.AddExtendInfoBookingRoomMembers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step3.dtpDateEnterCountry_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

