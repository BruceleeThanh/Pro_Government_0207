using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BussinessLogic;
using Entity;
using DataAccess;
using DevExpress.Utils;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_CheckInGroup_ForRoomBooking_Step1 : DevExpress.XtraEditors.XtraForm
    {
        private List<RoomsEN> aListAvaiableRooms = new List<RoomsEN>();
        private List<Rooms> aListTemp = new List<Rooms>();
        private CheckInRoomBookingEN aCheckInRoomBookingEN = new CheckInRoomBookingEN();
        public frmMain afrmMain = null;
        public frmTsk_ListBookingRs afrmTsk_ListBookingRs = null;
        private int IDBookingRs = 0;
        private DateTime CheckOutPlan;
        //hiennv
        public frmTsk_CheckInGroup_ForRoomBooking_Step1(frmMain afrmMain, int IDBookingRs, DateTime CheckOutPlan)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.IDBookingRs = IDBookingRs;
            this.CheckOutPlan = CheckOutPlan;
        }
        //hiennv
        public frmTsk_CheckInGroup_ForRoomBooking_Step1(frmTsk_ListBookingRs afrmTsk_ListBookingRs, int IDBookingRs, DateTime CheckOutPlan)
        {
            InitializeComponent();
            this.afrmTsk_ListBookingRs = afrmTsk_ListBookingRs;
            this.IDBookingRs = IDBookingRs;
            this.CheckOutPlan = CheckOutPlan;
        }
        //hiennv
        private void btnAddSelectedRooms_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                aRoomMemberEN.RoomSku = viewAvailableRooms.GetFocusedRowCellValue("Sku").ToString();
                aRoomMemberEN.RoomCode = viewAvailableRooms.GetFocusedRowCellValue("Code").ToString();
                aRoomMemberEN.RoomTypeDisplay = viewAvailableRooms.GetFocusedRowCellValue("TypeDisplay").ToString();
                aRoomMemberEN.RoomBed1 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Bed1").ToString());
                aRoomMemberEN.RoomBed2 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Bed2").ToString());
                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewAvailableRooms.GetFocusedRowCellValue("CostRef").ToString());

                this.aCheckInRoomBookingEN.aListRoomMembers.Insert(this.aCheckInRoomBookingEN.aListRoomMembers.Count, aRoomMemberEN);
                dgvSelectedRooms.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();


                RoomsEN Temps = aListAvaiableRooms.Where(p => p.Sku == viewAvailableRooms.GetFocusedRowCellValue("Sku").ToString()).ToList()[0];
                aListAvaiableRooms.Remove(Temps);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.btnAddSelectedRooms_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnRemoveSelectedRooms_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomsEN aRoomEN = new RoomsEN();
                aRoomEN.Code = viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aRoomEN.Sku = viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aRoomEN.TypeDisplay = viewSelectedRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aRoomEN.Bed1 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed1"));
                aRoomEN.Bed2 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed2"));
                aRoomEN.CostRef = Convert.ToDecimal(viewSelectedRooms.GetFocusedRowCellValue("RoomCostRef"));

                this.aListAvaiableRooms.Insert(0, aRoomEN);
                dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                int ID = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("IDBookingRooms"));
                BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(ID);
                if (aBookingRooms != null)
                {
                    aBookingRoomsBO.Delete(aBookingRooms.ID);
                }

                RoomMemberEN Temps = this.aCheckInRoomBookingEN.aListRoomMembers.Where(p => p.RoomSku == viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList()[0];
                this.aCheckInRoomBookingEN.aListRoomMembers.Remove(Temps);
                dgvSelectedRooms.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.btnRemoveSelectedRooms_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                this.GetListSelectRooms(this.IDBookingRs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.aCheckInRoomBookingEN.aListRoomMembers.Count > 0)
                {
                    BookingRsBO aBookingRsBO = new BookingRsBO();
                    BookingRs aBookingRs = aBookingRsBO.Select_ByID(this.IDBookingRs);
                    if (aBookingRs != null)
                    {
                        this.aCheckInRoomBookingEN.IDCustomer = aBookingRs.IDCustomer;
                        this.aCheckInRoomBookingEN.IDCustomerGroup = aBookingRs.IDCustomerGroup;
                        this.aCheckInRoomBookingEN.Subject = aBookingRs.Subject;
                        this.aCheckInRoomBookingEN.Level = aBookingRs.Level;
                        this.aCheckInRoomBookingEN.Description = aBookingRs.Description;
                        this.aCheckInRoomBookingEN.Note = aBookingRs.Note;

                        CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                        CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
                        if (aCustomerGroups != null)
                        {
                            this.aCheckInRoomBookingEN.IDCompany = aCustomerGroups.IDCompany;
                        }

                    }

                    this.aCheckInRoomBookingEN.IDBookingR = this.IDBookingRs;
                    this.aCheckInRoomBookingEN.CheckInActual = dtpFrom.DateTime;
                    this.aCheckInRoomBookingEN.CheckOutActual = dtpTo.DateTime;
                    this.aCheckInRoomBookingEN.CheckOutPlan = dtpTo.DateTime;
                    frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2 = new frmTsk_CheckInGroup_ForRoomBooking_Step2(this,this.aCheckInRoomBookingEN);
                    afrmTsk_CheckInGroup_ForRoomBooking_Step2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng trước khi thực hiện bước tiếp theo !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.btnNext_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void frmTsk_CheckIn_Group_Step1_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFrom.DateTime = DateTime.Now;
                dtpTo.DateTime = this.CheckOutPlan;
                this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                this.GetListSelectRooms(this.IDBookingRs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.frmTsk_CheckIn_Group_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //hiennv
        public void GetListSelectRooms(int IDBookingR)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                RoomMemberEN aRoomMemberEN;
                List<RoomsEN> aListTempRooms = aReceptionTaskBO.GetListRooms_ByIDBookingR(IDBookingR);
                foreach (RoomsEN aRooms in aListTempRooms)
                {
                    aRoomMemberEN = new RoomMemberEN();
                    aRoomMemberEN.IDBookingRooms = aRooms.IDBookingRooms;
                    aRoomMemberEN.RoomSku = aRooms.Sku;
                    aRoomMemberEN.RoomCode = aRooms.Code;
                    aRoomMemberEN.RoomType = Convert.ToInt32(aRooms.Type);
                    aRoomMemberEN.RoomBed1 = Convert.ToInt32(aRooms.Bed1);
                    aRoomMemberEN.RoomBed2 = Convert.ToInt32(aRooms.Bed2);
                    aRoomMemberEN.RoomCostRef = Convert.ToDecimal(aRooms.CostRef);
                    aRoomMemberEN.RoomTypeDisplay = CORE.CONSTANTS.SelectedRoomsType(Convert.ToInt32(aRooms.Type)).Name;
                    this.aCheckInRoomBookingEN.aListRoomMembers.Add(aRoomMemberEN);
                }
                dgvSelectedRooms.DataSource = this.aCheckInRoomBookingEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.GetListSelectRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private bool CheckData()
        {
            try
            {
                if (dtpFrom.EditValue == null)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Vui lòng nhập ngày đặt phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (dtpTo.EditValue == null)
                {
                    dtpTo.Focus();
                    MessageBox.Show("Vui lòng nhập ngày trả phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (dtpFrom.DateTime > dtpTo.DateTime)
                    {
                        dtpTo.Focus();
                        MessageBox.Show("Vui lòng nhập đặt phòng phải nhỏ hơn hoặc bằng ngày trả phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //hiennv
        public void LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                if(this.CheckData() == true)
                {
                    this.aCheckInRoomBookingEN.aListRoomMembers.Clear();
                    dgvSelectedRooms.DataSource = null;
                    aListTemp = aReceptionTaskBO.GetListAvailableRooms(fromDate, toDate, 1).OrderBy(r => r.Sku).ToList(); // 1=IDLang
                    RoomsEN aRoomEN;
                    for (int i = 0; i < aListTemp.Count; i++)
                    {
                        aRoomEN = new RoomsEN();
                        aRoomEN.ID = aListTemp[i].ID;
                        aRoomEN.Code = aListTemp[i].Code;
                        aRoomEN.Sku = aListTemp[i].Sku;
                        aRoomEN.Image = aListTemp[i].Image;
                        aRoomEN.Bed1 = aListTemp[i].Bed1;
                        aRoomEN.Bed2 = aListTemp[i].Bed2;
                        aRoomEN.CostRef = aListTemp[i].CostRef;
                        aRoomEN.CostUnit = aListTemp[i].CostUnit;
                        aRoomEN.Info = aListTemp[i].Info;
                        aRoomEN.Intro = aListTemp[i].Intro;
                        aRoomEN.Disable = aListTemp[i].Disable;
                        aRoomEN.IDLang = aListTemp[i].IDLang;
                        aRoomEN.TypeDisplay = CORE.CONSTANTS.SelectedRoomsType(Convert.ToInt32(aListTemp[i].Type)).Name;
                      
                        this.aListAvaiableRooms.Add(aRoomEN);
                    }
                    dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInGroup_ForRoomBooking_Step1.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}