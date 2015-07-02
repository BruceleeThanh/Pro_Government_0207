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
using DevExpress.Utils;
namespace RoomManager
{
    public partial class frmTsk_PendingRoom_Step1 : DevExpress.XtraEditors.XtraForm
    {

        public frmMain afrmMain = null;
        private string codeRoom = string.Empty;
        public frmTsk_PendingRoom_Step1(frmMain afrmMain, string codeRoom)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.codeRoom = codeRoom;
        }

        public frmTsk_PendingRoom_Step1(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }


        private void btnUnCharge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingRoom = Convert.ToInt32(viewBookingRooms.GetFocusedRowCellValue("ID"));
                int IDBookingR = Convert.ToInt32(viewBookingRooms.GetFocusedRowCellValue("IDBookingR"));
                string CodeRoom = Convert.ToString(viewBookingRooms.GetFocusedRowCellValue("CodeRoom"));
                DateTime CheckOutPlan = Convert.ToDateTime(viewBookingRooms.GetFocusedRowCellValue("CheckOutPlan"));
                frmTsk_PendingRoom_Free_Step2 afrmTsk_PendingUnCharge_Step2 = new frmTsk_PendingRoom_Free_Step2(this,IDBookingRoom, IDBookingR, CodeRoom, CheckOutPlan);
                afrmTsk_PendingUnCharge_Step2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingRoom_Step1.btnUnCharge_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCharge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingRoom = Convert.ToInt32(viewBookingRooms.GetFocusedRowCellValue("ID"));
                int IDBookingR = Convert.ToInt32(viewBookingRooms.GetFocusedRowCellValue("IDBookingR"));
                string CodeRoom = Convert.ToString(viewBookingRooms.GetFocusedRowCellValue("CodeRoom"));
                DateTime CheckOutPlan = Convert.ToDateTime(viewBookingRooms.GetFocusedRowCellValue("CheckOutPlan"));
                frmTsk_PendingRoom_Fee_Step2 afrmTsk_PendingCharge_Step2 = new frmTsk_PendingRoom_Fee_Step2(this,IDBookingRoom, IDBookingR, CodeRoom, CheckOutPlan);
                afrmTsk_PendingCharge_Step2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingRoom_Step1.btnCharge_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataBookingRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingRoom_Step1.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataBookingRoom()
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                List<BookingRooms> aListTemp = aBookingRoomsBO.Select_ByDateAndCodeRoomAndStaus(DateTime.Now,this.codeRoom,3); //3 = status = da check In
                BookingRooms aBookingRooms;
                List<BookingRooms> aListBookingRoom = new List<BookingRooms>();
                RoomsBO aRoomsBO = new RoomsBO();

                foreach (BookingRooms item in aListTemp)
                {
                    aBookingRooms = new BookingRooms();
                    aBookingRooms.ID = item.ID;
                    aBookingRooms.IDBookingR = item.IDBookingR;
                    aBookingRooms.CodeRoom = item.CodeRoom;
                    aBookingRooms.Cost = item.Cost;
                    aBookingRooms.PercentTax = item.PercentTax;
                    aBookingRooms.CostRef_Rooms = item.CostRef_Rooms;
                    aBookingRooms.Note = item.Note;
                    aBookingRooms.CheckInPlan = item.CheckInPlan;
                    aBookingRooms.CheckInActual = item.CheckInActual;
                    aBookingRooms.CheckOutPlan = item.CheckOutPlan;
                    aBookingRooms.CheckOutActual = item.CheckOutActual;
                    aBookingRooms.BookingStatus = item.BookingStatus;
                    aBookingRooms.Status = item.Status;
                    aBookingRooms.StartTime = item.StartTime;
                    aBookingRooms.EndTime = item.EndTime;
                    aBookingRooms.IsAllDayEvent = item.IsAllDayEvent;
                    aBookingRooms.Color = item.Color;
                    aBookingRooms.IsEditable = item.IsEditable;
                    aBookingRooms.IsRecurring = item.IsRecurring;
                    Rooms aRooms = aRoomsBO.Select_ByCodeRoom(item.CodeRoom, 1);//1= IDLang

                    //dung tam de hien thi sku
                    aBookingRooms.AdditionalColumn1 = aRooms.Sku;
                    aListBookingRoom.Add(aBookingRooms);

                }

                if (String.IsNullOrEmpty(txtSku.Text) == false)
                {
                    dgvBookingRooms.DataSource = aListBookingRoom.Where(b => b.AdditionalColumn1.Contains(txtSku.Text)).ToList();
                }
                else
                {
                    dgvBookingRooms.DataSource = aListBookingRoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingRoom_Step1.LoadDataBookingRoom\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_PendingRoom_Step1_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataBookingRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingRoom_Step1.frmTsk_PendingRoom_Step1_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}