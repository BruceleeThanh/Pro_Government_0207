using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Entity;
using DataAccess;
using BussinessLogic;
using DevExpress.Utils;
using CORESYSTEM;
using System.Globalization;
namespace RoomManager
{
    public partial class frmTsk_CheckIn_Goverment_Step1 : DevExpress.XtraEditors.XtraForm
    {

        private List<RoomsEN> aListAvaiableRooms = new List<RoomsEN>();
        private List<Rooms> aListTemp = new List<Rooms>();
        private CheckInEN aCheckInEN = new CheckInEN();
        public frmMain afrmMain = null;
        private string codeRoom = string.Empty;

        //hiennv
        public frmTsk_CheckIn_Goverment_Step1(frmMain afrmMain, string codeRoom)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.codeRoom = codeRoom;
        }
        public frmTsk_CheckIn_Goverment_Step1(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
 

        private void btnAddSelectedRooms_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();

                aRoomMemberEN.RoomCode = viewAvailableRooms.GetFocusedRowCellValue("Code").ToString();

                aRoomMemberEN.RoomSku = viewAvailableRooms.GetFocusedRowCellValue("Sku").ToString();

                aRoomMemberEN.RoomTypeDisplay = viewAvailableRooms.GetFocusedRowCellValue("TypeDisplay").ToString();

                aRoomMemberEN.RoomBed1 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Bed1"));

                aRoomMemberEN.RoomBed2 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Bed2"));

                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewAvailableRooms.GetFocusedRowCellValue("CostRef"));

                aCheckInEN.aListRoomMembers.Insert(aCheckInEN.aListRoomMembers.Count, aRoomMemberEN);
                dgvSelectedRooms.DataSource = aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

                RoomsEN Temps = aListAvaiableRooms.Where(p => p.Sku == viewAvailableRooms.GetFocusedRowCellValue("Sku").ToString()).ToList()[0];
                aListAvaiableRooms.Remove(Temps);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.btnAddSelectedRooms_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveSelectedRooms_ButtonClick(object sender, ButtonPressedEventArgs e)
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

                aListAvaiableRooms.Insert(0, aRoomEN);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                RoomMemberEN Temps = aCheckInEN.aListRoomMembers.Where(p => p.RoomSku == viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList()[0];
                aCheckInEN.aListRoomMembers.Remove(Temps);
                dgvSelectedRooms.DataSource = aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.btnRemoveSelectedRooms_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (aCheckInEN.aListRoomMembers.Count > 0)
                {
                    aCheckInEN.CheckInActual = dtpFrom.DateTime;
                    aCheckInEN.CheckOutActual = dtpTo.DateTime;
                    aCheckInEN.CheckOutPlan = dtpTo.DateTime;

                    frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2 = new frmTsk_CheckIn_Goverment_Step2(this, aCheckInEN);
                    afrmTsk_CheckIn_Goverment_Step2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng trước khi thực hiện bước tiếp theo !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.btnNext_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void frmTsk_CheckIn_Goverment_Step1_Load(object sender, EventArgs e)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (String.IsNullOrEmpty(this.codeRoom) == false)
                {
                    dtpFrom.DateTime = DateTime.Now;
                    dtpTo.DateTime = aReceptionTaskBO.SetDateValueDefault(DateTime.Now.AddDays(1));
                    this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);

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
                    this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.frmTsk_CheckIn_Goverment_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if(this.CheckData() == true)
                {
                    this.aCheckInEN.aListRoomMembers.Clear();
                    dgvSelectedRooms.DataSource = null;
                    aListTemp = aReceptionTaskBO.GetListAvailableRooms(fromDate, toDate, 1).OrderBy(r=>r.Sku).ToList(); // 1=IDLang
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

                        aListAvaiableRooms.Add(aRoomEN);
                    }
                    dgvAvailableRooms.DataSource = aListAvaiableRooms;
                    dgvAvailableRooms.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step1.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}