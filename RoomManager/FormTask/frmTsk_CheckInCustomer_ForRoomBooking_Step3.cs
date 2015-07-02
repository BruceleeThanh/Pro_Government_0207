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
using BussinessLogic;
using DataAccess;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_CheckInCustomer_ForRoomBooking_Step3 : DevExpress.XtraEditors.XtraForm
    {
        private frmTsk_CheckInCustomer_ForRoomBooking_Step2 afrmTsk_CheckInCustomer_ForRoomBooking_Step2 =null;
        private CheckInRoomBookingEN aCheckInRoomBookingEN = new CheckInRoomBookingEN();
        private List<Customers> aListCustomers;

        public frmTsk_CheckInCustomer_ForRoomBooking_Step3(frmTsk_CheckInCustomer_ForRoomBooking_Step2 afrmTsk_CheckInCustomer_ForRoomBooking_Step2, CheckInRoomBookingEN aCheckInRoomBookingEN)
        {
            InitializeComponent();
            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 = afrmTsk_CheckInCustomer_ForRoomBooking_Step2;
            this.aCheckInRoomBookingEN = aCheckInRoomBookingEN;
            CustomersBO aCustomersBO = new CustomersBO();
            this.aListCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(this.aCheckInRoomBookingEN.IDCustomerGroup);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Tsk_CheckIn_Customer_Step3_Load(object sender, EventArgs e)
        {
            try
            {
                lueIDRoom.Properties.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers;
                lueIDRoom.Properties.DisplayMember = "RoomSku";
                lueIDRoom.Properties.ValueMember = "RoomCode";
                lueIDRoom.EditValue = this.aCheckInRoomBookingEN.aListRoomMembers.ToList()[0].RoomCode;
                this.aListCustomers = this.RemoveCustomerExistInCheckInEN(this.aListCustomers);
                dgvAvailableCustomer.DataSource = this.aListCustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.frm_Tsk_CheckIn_Customer_Step3_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadLueIDRooms()
        {
            try
            {
                string CodeRoom = Convert.ToString(lueIDRoom.EditValue);
                RoomMemberEN aRoomMemberEN = this.aCheckInRoomBookingEN.aListRoomMembers.Where(p => p.RoomCode == CodeRoom).ToList()[0];
                int Index = this.aCheckInRoomBookingEN.aListRoomMembers.IndexOf(aRoomMemberEN);
                dgvSelectedCustomer.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers[Index].ListCustomer;
                dgvSelectedCustomer.RefreshDataSource();

                if (this.aCheckInRoomBookingEN.aListRoomMembers[Index].ListCustomer.Count > 0)
                {
                    this.ReloadExtendInfoBookingRoomMembers(aRoomMemberEN.ListCustomer[0].ID);
                }
                else
                {
                    lblIDCustomer.Text = null;
                    txtPurposeComeVietnam.Text = null;
                    txtOrganization.Text = null;
                    txtEnterGate.Text = null;
                    dtpDateEnterCountry.EditValue = null;
                    dtpLeaveDate.EditValue = null;
                    dtpLimitDateEnterCountry.EditValue = null;
                    dtpTemporaryResidenceDate.EditValue = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.LoadLueIDRooms\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lueIDRoom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadLueIDRooms();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.lueIDRoom_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Exchang(string CodeRoom)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = this.aCheckInRoomBookingEN.aListRoomMembers.Where(a => a.RoomCode == CodeRoom).ToList()[0];
                if (aRoomMemberEN.ListCustomer.Count > 0)
                {
                    CustomerInfoEN aCustomerInfo = this.aCheckInRoomBookingEN.GetCustomer(aRoomMemberEN.ListCustomer[0].ID);
                    lblIDCustomer.Text = aCustomerInfo.ID.ToString();
                    txtPurposeComeVietnam.Text = aCustomerInfo.PurposeComeVietnam;
                    txtOrganization.Text = aCustomerInfo.Organization;
                    txtEnterGate.Text = aCustomerInfo.EnterGate;
                    dtpDateEnterCountry.DateTime = aCustomerInfo.DateEnterCountry.GetValueOrDefault();
                    dtpLeaveDate.DateTime = aCustomerInfo.LeaveDate.GetValueOrDefault();
                    dtpLimitDateEnterCountry.DateTime = aCustomerInfo.LimitDateEnterCountry.GetValueOrDefault();
                    dtpTemporaryResidenceDate.DateTime = aCustomerInfo.TemporaryResidenceDate.GetValueOrDefault();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.Exchang\n" + ex.ToString());
            }

        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CustomerInfoEN aCustomersInfo = new CustomerInfoEN();
                aCustomersInfo.ID = Convert.ToInt16(grvAvailableCustomer.GetFocusedRowCellValue("ID"));
                aCustomersInfo.Name = Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Name"));
                aCustomersInfo.Identifier1 = Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Identifier1"));
                if (aCustomersInfo.Birthday !=null)
                {
                    aCustomersInfo.Birthday = Convert.ToDateTime(grvAvailableCustomer.GetFocusedRowCellValue("Birthday"));
                }

                RoomMemberEN aRoomMemberEN = this.aCheckInRoomBookingEN.aListRoomMembers.Where(a => a.RoomCode == lueIDRoom.EditValue.ToString()).ToList()[0];
                int index = this.aCheckInRoomBookingEN.aListRoomMembers.IndexOf(aRoomMemberEN);

                this.aCheckInRoomBookingEN.aListRoomMembers[index].ListCustomer.Add(aCustomersInfo);

                lblIDCustomer.Text = aCustomersInfo.ID.ToString();

                dgvSelectedCustomer.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers[index].ListCustomer;
                dgvSelectedCustomer.RefreshDataSource();

                Customers aCus = aListCustomers.Where(b => b.ID == Convert.ToInt32(grvAvailableCustomer.GetFocusedRowCellValue("ID"))).ToList()[0];
                aListCustomers.Remove(aCus);

                dgvAvailableCustomer.DataSource = aListCustomers;
                dgvAvailableCustomer.RefreshDataSource();

                txtPurposeComeVietnam.Text = null;
                txtEnterGate.Text = null;
                txtOrganization.Text = null;
                dtpDateEnterCountry.EditValue = null;
                dtpLeaveDate.EditValue = null;
                dtpLimitDateEnterCountry.EditValue = null;
                dtpTemporaryResidenceDate.EditValue = null;

                this.ReloadExtendInfoBookingRoomMembers(aCustomersInfo.ID);



            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.btnSelect_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Customers aCustomers = new Customers();
                aCustomers.ID = Convert.ToInt16(grvSelectedCustomer.GetFocusedRowCellValue("ID"));
                aCustomers.Name = Convert.ToString(grvSelectedCustomer.GetFocusedRowCellValue("Name"));
                aCustomers.Identifier1 = Convert.ToString(grvSelectedCustomer.GetFocusedRowCellValue("Identifier1"));
                if(aCustomers.Birthday !=null)
                {
                    aCustomers.Birthday = Convert.ToDateTime(grvSelectedCustomer.GetFocusedRowCellValue("Birthday"));
                }
                
                aListCustomers.Insert(0, aCustomers);

                dgvAvailableCustomer.DataSource = aListCustomers;
                dgvAvailableCustomer.RefreshDataSource();


                RoomMemberEN aRoomMemberEN = this.aCheckInRoomBookingEN.aListRoomMembers.Where(a => a.RoomCode == lueIDRoom.EditValue.ToString()).ToList()[0];
                int index = this.aCheckInRoomBookingEN.aListRoomMembers.IndexOf(aRoomMemberEN);

                CustomerInfoEN Temps = this.aCheckInRoomBookingEN.aListRoomMembers[index].ListCustomer.Where(a => a.ID == Convert.ToInt32(grvSelectedCustomer.GetFocusedRowCellValue("ID"))).ToList()[0];

                this.aCheckInRoomBookingEN.aListRoomMembers[index].ListCustomer.Remove(Temps);

                dgvSelectedCustomer.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers[index].ListCustomer;
                dgvSelectedCustomer.RefreshDataSource();
                this.LoadLueIDRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.btnUnSelect_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                ReceptionTaskBO aCheckInActionBO = new ReceptionTaskBO();

                aCheckInRoomBookingEN.BookingType = 3;   // 1: Dat onlie, 2: Dat qua dien thoai, 3: Truc tiep, 4: Cong van
                aCheckInRoomBookingEN.IDSystemUser = CORE.CURRENTUSER.SystemUser.ID; ;
                aCheckInRoomBookingEN.Status = 3; // 3 : da checkin

                if (aCheckInRoomBookingEN.BookingMoney > 0)
                {
                    aCheckInRoomBookingEN.StatusPay = 2; //2:Tam ung
                }
                else
                {
                    aCheckInRoomBookingEN.StatusPay = 1; //1:chua thanh toan
                }


                bool success = aCheckInActionBO.CheckInForRoomAlreadyBooking(aCheckInRoomBookingEN);
                if (success == true)
                {
                    MessageBox.Show("Đặt phòng thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.afrmTsk_ListBookingRs != null)
                    {
                        this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.afrmTsk_ListBookingRs.Reload();
                        if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.afrmTsk_ListBookingRs.afrmMain != null)
                        {
                            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.afrmTsk_ListBookingRs.afrmMain.ReloadData();
                        }
                    }
                    
                    if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.afrmMain !=null)
                    {
                        this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.afrmMain.ReloadData();
                    }

                    this.Close();
                    this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.Close();
                    this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.afrmTsk_CheckInCustomer_ForRoomBooking_Step1.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.btnCheckIn_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void grvSelectedCustomer_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int IDCustomer = Convert.ToInt32(grvSelectedCustomer.GetFocusedRowCellValue("ID"));

            txtPurposeComeVietnam.Text = null;
            txtEnterGate.Text =null;
            txtOrganization.Text =null;
            dtpDateEnterCountry.EditValue = null;
            dtpLeaveDate.EditValue = null;
            dtpLimitDateEnterCountry.EditValue = null;
            dtpTemporaryResidenceDate.EditValue = null;

            this.ReloadExtendInfoBookingRoomMembers(IDCustomer);
        }

        public void ReloadExtendInfoBookingRoomMembers(int IDCustomer)
        {
            try
            {
                CustomerInfoEN aCustomerInfo = this.aCheckInRoomBookingEN.GetCustomer(IDCustomer);
                lblIDCustomer.Text = aCustomerInfo.ID.ToString();
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
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.ReloadExtendInfoBookingRoomMembers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region

        private void txtPurposeComeVietnam_Leave(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(txtPurposeComeVietnam.Text) == false)
                {
                    this.AddExtendInfoBookingRoomMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step3.txtPurposeComeVietnam_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnterGate_Leave(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(txtEnterGate.Text) == false)
                {
                    this.AddExtendInfoBookingRoomMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step3.txtEnterGate_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtOrganization_Leave(object sender, EventArgs e)
        {
            try
            {
               if(String.IsNullOrEmpty(txtOrganization.Text) == false)
               {
                   this.AddExtendInfoBookingRoomMembers();
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step3.txtOrganization_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddExtendInfoBookingRoomMembers()
        {
            try
            {
                DateTime? DateNull = null;

                int IDCustomer =String.IsNullOrEmpty(lblIDCustomer.Text)==true? 0 :Convert.ToInt32(lblIDCustomer.Text);
                RoomMemberEN aRoomMemberEN = this.aCheckInRoomBookingEN.aListRoomMembers.Where(a => a.RoomCode == lueIDRoom.EditValue.ToString()).ToList()[0];
                int index = this.aCheckInRoomBookingEN.aListRoomMembers.IndexOf(aRoomMemberEN);
                string RoomCode = this.aCheckInRoomBookingEN.aListRoomMembers[index].RoomCode;

                CustomerInfoEN aCustomerInfo = this.aCheckInRoomBookingEN.GetCustomer(IDCustomer);
                aCustomerInfo.PurposeComeVietnam = String.IsNullOrEmpty(txtPurposeComeVietnam.Text) == true ? null : txtPurposeComeVietnam.Text;

                aCustomerInfo.LimitDateEnterCountry = dtpLimitDateEnterCountry.EditValue == null ? DateNull : dtpLimitDateEnterCountry.DateTime;

                aCustomerInfo.Organization = String.IsNullOrEmpty(txtOrganization.Text) == true ? null : txtOrganization.Text;

                aCustomerInfo.LeaveDate = dtpLeaveDate.EditValue == null ? DateNull : dtpLeaveDate.DateTime;

                aCustomerInfo.TemporaryResidenceDate = dtpTemporaryResidenceDate.EditValue == null ? DateNull : dtpTemporaryResidenceDate.DateTime;

                aCustomerInfo.EnterGate = String.IsNullOrEmpty(txtEnterGate.Text) == true ? null : txtEnterGate.Text;

                aCustomerInfo.DateEnterCountry = dtpDateEnterCountry.EditValue == null ? DateNull : dtpDateEnterCountry.DateTime;
                if(IDCustomer > 0)
                {
                    this.aCheckInRoomBookingEN.UpdateCustomerToRoom(RoomCode, aCustomerInfo);
                    dgvSelectedCustomer.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers[index].ListCustomer;
                    dgvSelectedCustomer.RefreshDataSource();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step3.AddExtendInfoBookingRoomMembers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Customers> RemoveCustomerExistInCheckInEN(List<Customers> aList)
        {
            try
            {
                List<Customers> aListCustomer = new List<Customers>();

                for (int i = 0; i < this.aCheckInRoomBookingEN.aListRoomMembers.Count; i++)
                {
                    for (int ii = 0; ii < this.aCheckInRoomBookingEN.aListRoomMembers[i].ListCustomer.Count; ii++)
                    {
                        aListCustomer = aList.Where(p => p.ID == this.aCheckInRoomBookingEN.aListRoomMembers[i].ListCustomer[ii].ID).ToList();
                        if (aListCustomer.Count > 0)
                        {
                            aList.Remove(aListCustomer[0]);
                        }
                    }
                }
                return aList;
            }
            catch (Exception ex)
            {
                return null;
                MessageBox.Show("frmTsk_CheckIn_Customer_Step3.RemoveCustomerExistInCheckInEN\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

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
                        string b = txtEnterGate.Text;
                        string a = txtEnterGate.Properties.NullValuePrompt.ToString();
                        this.AddExtendInfoBookingRoomMembers();
                    } 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.dtpDateEnterCountry_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.dtpTemporaryResidenceDate_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.dtpLeaveDate_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_CheckInCustomer_ForRoomBooking_Step3.dtpLimitDateEnterCountry_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}