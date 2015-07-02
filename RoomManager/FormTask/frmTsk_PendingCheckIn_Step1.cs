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
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_PendingCheckIn_Step1 : DevExpress.XtraEditors.XtraForm
    {
        public frmMain afrmMain = null;
        public frmTsk_PendingCheckIn_Step1(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

        private void frmTsk_PendingCheckIn_Step1_Load(object sender, EventArgs e)
        {
            try
            {
                int Status = cboStatus.SelectedIndex + 2;
                this.LoadDataBookingRoom(Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingCheckIn_Step1.frmTsk_PendingCheckIn_Step1_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDataBookingRoom(int Status)
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                List<BookingRooms> aListTemp = aBookingRoomsBO.Select_ByStatus_ByTime(DateTime.Now,Status);
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

                    //dung tam truong Note de hien thi trang thai phong
                    aBookingRooms.Note = CORE.CONSTANTS.SelectedBookingRoomStatus(item.Status.GetValueOrDefault()).Name;

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
                dgvBookingRooms.DataSource = aListBookingRoom;
                dgvBookingRooms.RefreshDataSource();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingCheckIn_Step1.LoadDataBookingRoom\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int temp = cboStatus.SelectedIndex;
                int Status = 0;
                if (temp == 0)
                {
                    Status = 2;    //2: checked
                }
                else if (temp == 1)
                {
                    Status = 5;   //5: pending
                }
                int IDBookingRoom = Convert.ToInt32(viewBookingRooms.GetFocusedRowCellValue("ID"));
                int IDBookingR = Convert.ToInt32(viewBookingRooms.GetFocusedRowCellValue("IDBookingR"));
                string CodeRoom = Convert.ToString(viewBookingRooms.GetFocusedRowCellValue("CodeRoom"));
                DateTime CheckOutPlan = Convert.ToDateTime(viewBookingRooms.GetFocusedRowCellValue("CheckOutPlan"));
                frmTsk_PendingCheckIn_Step2 afrmTsk_PendingCheckIn_Step2 = new frmTsk_PendingCheckIn_Step2(this,IDBookingRoom, IDBookingR, CodeRoom, CheckOutPlan,Status);
                afrmTsk_PendingCheckIn_Step2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingCheckIn_Step1.btnCheckIn_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = cboStatus.SelectedIndex;
                int Status = 0;
                if(temp == 0)
                {
                    Status = 2;    //2: checked
                }
                else if(temp == 1)
                {
                    Status = 5;   //5: pending
                }
                this.LoadDataBookingRoom(Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingCheckIn_Step1.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}