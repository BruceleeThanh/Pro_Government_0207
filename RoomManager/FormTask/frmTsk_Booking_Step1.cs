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
using Entity;
using DataAccess;
using BussinessLogic;
using DevExpress.Utils;
using CORESYSTEM;
using System.Globalization;

namespace RoomManager
{
    public partial class frmTsk_Booking_Step1 : DevExpress.XtraEditors.XtraForm
    {
        private List<RoomsEN> aListAvaiableRooms = new List<RoomsEN>();
        private List<Rooms> aListTemp = new List<Rooms>();
        private BookingEN aBookingEN = new BookingEN();
        public frmMain afrmMain = null;
        private string codeRoom = string.Empty;
        private int CustomerType;


        public frmTsk_Booking_Step1(frmMain afrmMain, int CustomerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.CustomerType = CustomerType;
        }
        public frmTsk_Booking_Step1(frmMain afrmMain, string codeRoom, int CustomerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.codeRoom = codeRoom;
            this.CustomerType = CustomerType;
        }
        

        private void frmTsk_Booking_Step1_Load(object sender, EventArgs e)
        {
            try
            {
                
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (String.IsNullOrEmpty(this.codeRoom) == false)
                {
                    



                    dtpFrom.DateTime = DateTime.Now;
                    dtpTo.DateTime = aReceptionTaskBO.SetDateValueDefault(DateTime.Now.AddDays(30));
                    this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                    List<RoomsEN> aListRoomEN = aListAvaiableRooms.Where(p => p.Code == this.codeRoom).ToList();
                    if (aListRoomEN.Count > 0)
                    {
                        this.aListAvaiableRooms.Remove(aListRoomEN[0]);
                        dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                        dgvAvailableRooms.RefreshDataSource();

                        this.aBookingEN.aListRoomsEN.Insert(this.aBookingEN.aListRoomsEN.Count, aListRoomEN[0]);
                        dgvSelectedRooms.DataSource = this.aBookingEN.aListRoomsEN;
                        dgvSelectedRooms.RefreshDataSource();
                    }
                }
                else
                {
                    dtpFrom.DateTime = DateTime.Now;
                    dtpTo.DateTime = aReceptionTaskBO.SetDateValueDefault(DateTime.Now.AddDays(30));
                    this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step1.frmTsk_Booking_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomsEN aRoomEN = new RoomsEN();

                aRoomEN.Code = Convert.ToString(viewAvailableRooms.GetFocusedRowCellValue("Code"));

                aRoomEN.Sku = Convert.ToString(viewAvailableRooms.GetFocusedRowCellValue("Sku"));

                aRoomEN.Type = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Type"));
                aRoomEN.TypeDisplay = Convert.ToString(viewAvailableRooms.GetFocusedRowCellValue("TypeDisplay"));

                aRoomEN.Bed1 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Bed1"));

                aRoomEN.Bed2 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("Bed2"));

                aRoomEN.CostRef = Convert.ToDecimal(viewAvailableRooms.GetFocusedRowCellValue("CostRef"));

                aBookingEN.aListRoomsEN.Insert(aBookingEN.aListRoomsEN.Count, aRoomEN);
                dgvSelectedRooms.DataSource = aBookingEN.aListRoomsEN;
                dgvSelectedRooms.RefreshDataSource();

                RoomsEN Temps = aListAvaiableRooms.Where(p => p.Sku == viewAvailableRooms.GetFocusedRowCellValue("Sku").ToString()).ToList()[0];
                aListAvaiableRooms.Remove(Temps);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step1.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomsEN aRoomEN = new RoomsEN();
                aRoomEN.ID = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("ID"));
                aRoomEN.Code = Convert.ToString(viewSelectedRooms.GetFocusedRowCellValue("Code"));
                aRoomEN.Sku = Convert.ToString(viewSelectedRooms.GetFocusedRowCellValue("Sku"));
                aRoomEN.Type = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("Type"));
                aRoomEN.TypeDisplay = Convert.ToString(viewSelectedRooms.GetFocusedRowCellValue("TypeDisplay"));
                aRoomEN.Bed1 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("Bed1"));
                aRoomEN.Bed2 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("Bed2"));
                aRoomEN.CostRef = Convert.ToDecimal(viewSelectedRooms.GetFocusedRowCellValue("CostRef"));

                aListAvaiableRooms.Insert(0, aRoomEN);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                RoomsEN Temps = aBookingEN.aListRoomsEN.Where(p => p.Sku == viewSelectedRooms.GetFocusedRowCellValue("Sku").ToString()).ToList()[0];
                aBookingEN.aListRoomsEN.Remove(Temps);
                dgvSelectedRooms.DataSource = aBookingEN.aListRoomsEN;
                dgvSelectedRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step1.btnUnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                List<RoomsEN> aListRoomEN = aListAvaiableRooms.Where(p => p.Code == this.codeRoom).ToList();
                if (aListRoomEN.Count > 0)
                {
                    this.aListAvaiableRooms.Remove(aListRoomEN[0]);
                    dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                    dgvAvailableRooms.RefreshDataSource();

                    this.aBookingEN.aListRoomsEN.Insert(this.aBookingEN.aListRoomsEN.Count, aListRoomEN[0]);
                    dgvSelectedRooms.DataSource = this.aBookingEN.aListRoomsEN;
                    dgvSelectedRooms.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step1.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if(dtpFrom.DateTime > dtpTo.DateTime)
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
                MessageBox.Show("frmTsk_Booking_Step1.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    aBookingEN.aListRoomsEN.Clear();
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
                        aListAvaiableRooms.Add(aRoomEN);
                    }

                    dgvAvailableRooms.DataSource = aListAvaiableRooms;
                    dgvAvailableRooms.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step1.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (aBookingEN.aListRoomsEN.Count > 0)
                {
                    aBookingEN.CheckInActual = dtpFrom.DateTime;
                    aBookingEN.CheckOutActual = dtpTo.DateTime;
                    aBookingEN.CheckOutPlan = dtpTo.DateTime;

                    frmTsk_Booking_Step2 afrmTsk_Booking_Step2 = new frmTsk_Booking_Step2(this, aBookingEN, CustomerType);
                    afrmTsk_Booking_Step2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng trước khi thực hiện bước tiếp theo !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Booking_Step1.btnNext_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}