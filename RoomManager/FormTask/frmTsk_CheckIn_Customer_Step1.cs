using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BussinessLogic;
using Entity;
using DataAccess;
using DevExpress.Utils;
using CORESYSTEM;
using System.Globalization;

namespace RoomManager
{
    public partial class frmTsk_CheckIn_Customer_Step1 : DevExpress.XtraEditors.XtraForm
    {
        private List<RoomsEN> aListAvaiableRooms = new List<RoomsEN>();
        private List<Rooms> aListTemp = new List<Rooms>();
        private CheckInEN aCheckInEN = new CheckInEN();
        public frmMain afrmMain = null;
        private string codeRoom = string.Empty;

        //hiennv
        public frmTsk_CheckIn_Customer_Step1(frmMain afrmMain, string codeRoom)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.codeRoom = codeRoom;
        }
        public frmTsk_CheckIn_Customer_Step1(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = dtpFrom.DateTime;
                DateTime To = dtpTo.DateTime;
                this.aListAvaiableRooms.Clear();
                this.LoadListAvailableRooms(From, To);
                List<RoomsEN> aListRoomEN = this.aListAvaiableRooms.Where(p => p.Code == this.codeRoom).ToList();
                if (aListRoomEN.Count > 0)
                {
                    this.aListAvaiableRooms.Remove(aListRoomEN[0]);
                    dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                    dgvAvailableRooms.RefreshDataSource();

                    RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                    aRoomMemberEN.RoomSku = aListRoomEN[0].Sku;
                    aRoomMemberEN.RoomCode = aListRoomEN[0].Code;
                    aRoomMemberEN.RoomTypeDisplay = aListRoomEN[0].TypeDisplay;
                    aRoomMemberEN.RoomBed1 = aListRoomEN[0].Bed1.GetValueOrDefault();
                    aRoomMemberEN.RoomBed2 = aListRoomEN[0].Bed2.GetValueOrDefault();
                    aRoomMemberEN.RoomCostRef = aListRoomEN[0].CostRef.GetValueOrDefault();
                    this.aCheckInEN.aListRoomMembers.Insert(this.aCheckInEN.aListRoomMembers.Count, aRoomMemberEN);
                    dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                    dgvSelectedRooms.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step1.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnFill_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                aRoomMemberEN.RoomSku = grvAvaiableRooms.GetFocusedRowCellValue("Sku").ToString();
                aRoomMemberEN.RoomCode = grvAvaiableRooms.GetFocusedRowCellValue("Code").ToString();
                aRoomMemberEN.RoomTypeDisplay = grvAvaiableRooms.GetFocusedRowCellValue("TypeDisplay").ToString();
                aRoomMemberEN.RoomBed1 = Convert.ToInt16(grvAvaiableRooms.GetFocusedRowCellValue("Bed1"));
                aRoomMemberEN.RoomBed2 = Convert.ToInt16(grvAvaiableRooms.GetFocusedRowCellValue("Bed2"));
                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(grvAvaiableRooms.GetFocusedRowCellValue("CostRef"));


                this.aCheckInEN.aListRoomMembers.Insert(this.aCheckInEN.aListRoomMembers.Count, aRoomMemberEN);
                dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

                RoomsEN Temps = this.aListAvaiableRooms.Where(p => p.Sku == grvAvaiableRooms.GetFocusedRowCellValue("Sku").ToString()).ToList()[0];
                this.aListAvaiableRooms.Remove(Temps);
                dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check In Step 1 - Khách lẻ - Chọn " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnFill_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomsEN aRoomEN = new RoomsEN();

                aRoomEN.Sku = grvSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aRoomEN.Code = grvSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aRoomEN.TypeDisplay = Convert.ToString(grvSelectedRooms.GetFocusedRowCellValue("RoomTypeDisplay"));
                aRoomEN.Bed1 = Convert.ToInt32(grvSelectedRooms.GetFocusedRowCellValue("RoomBed1"));
                aRoomEN.Bed2 = Convert.ToInt32(grvSelectedRooms.GetFocusedRowCellValue("RoomBed2"));
                aRoomEN.CostRef = Convert.ToDecimal(grvSelectedRooms.GetFocusedRowCellValue("RoomCostRef"));

                this.aListAvaiableRooms.Insert(0, aRoomEN);
                dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                RoomMemberEN aRoomMemberEN = this.aCheckInEN.aListRoomMembers.Where(p => p.RoomSku == grvSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList()[0];
                this.aCheckInEN.aListRoomMembers.Remove(aRoomMemberEN);
                dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check In Step 1 - Khách lẻ - Bỏ chọn " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.aCheckInEN.aListRoomMembers.Count > 0)
                {
                    this.aCheckInEN.CheckInActual = dtpFrom.DateTime;
                    this.aCheckInEN.CheckOutActual = dtpTo.DateTime;
                    this.aCheckInEN.CheckOutPlan = dtpTo.DateTime;
                    frmTsk_CheckIn_Customer_Step2 afrm_Tsk_CheckIn_Customer_Step2 = new frmTsk_CheckIn_Customer_Step2(this, aCheckInEN);
                    afrm_Tsk_CheckIn_Customer_Step2.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng trước khi thực hiện bước tiếp theo !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Check In Step 1 - Khách lẻ - Tiếp theo " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_CheckIn_Customer_Step1_Load(object sender, EventArgs e)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (String.IsNullOrEmpty(this.codeRoom) == false) //khi checkIn trưc tiep tren cac control
                {
                    dtpFrom.DateTime = DateTime.Now;
                    dtpTo.DateTime = aReceptionTaskBO.SetDateValueDefault(DateTime.Now.AddDays(1));
                    
                    this.LoadListAvailableRooms(dtpFrom.DateTime,dtpTo.DateTime);

                    List<RoomsEN> aListRoomEN = this.aListAvaiableRooms.Where(p => p.Code == this.codeRoom).ToList();
                    if (aListRoomEN.Count > 0)
                    {
                        this.aListAvaiableRooms.Remove(aListRoomEN[0]);
                        dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                        dgvAvailableRooms.RefreshDataSource();

                        RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                        aRoomMemberEN.RoomSku = aListRoomEN[0].Sku;
                        aRoomMemberEN.RoomCode = aListRoomEN[0].Code;
                        aRoomMemberEN.RoomTypeDisplay = aListRoomEN[0].TypeDisplay;
                        aRoomMemberEN.RoomBed1 = aListRoomEN[0].Bed1.GetValueOrDefault();
                        aRoomMemberEN.RoomBed2 = aListRoomEN[0].Bed2.GetValueOrDefault();
                        aRoomMemberEN.RoomCostRef = aListRoomEN[0].CostRef.GetValueOrDefault();
                        this.aCheckInEN.aListRoomMembers.Insert(this.aCheckInEN.aListRoomMembers.Count, aRoomMemberEN);
                        dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                        dgvSelectedRooms.RefreshDataSource();
                    }
                }
                else
                {
                    dtpFrom.DateTime = DateTime.Now;
                    dtpTo.DateTime = aReceptionTaskBO.SetDateValueDefault(DateTime.Now.AddDays(1));                   
                    this.aListAvaiableRooms.Clear();
                    this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step1.frmTsk_CheckIn_Customer_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_CheckIn_Customer_Step1.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                if (this.CheckData() == true)
                {
                    this.aCheckInEN.aListRoomMembers.Clear();
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

                    dgvAvailableRooms.DataSource = aListAvaiableRooms;
                    dgvAvailableRooms.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Customer_Step1.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}