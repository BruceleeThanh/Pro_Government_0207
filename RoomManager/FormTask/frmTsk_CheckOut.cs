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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;


namespace RoomManager
{
    public partial class frmTsk_CheckOut : DevExpress.XtraEditors.XtraForm
    {
        private BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
        int Status = 3;
        int aIDBookingRoom_Old = -1;
      
        private frmTsk_Payment_Step1 afrmTsk_Check_StatusPay_Old = null;
        private frmMain afrmMain = null;

        private List<Rooms> aListRooms = new List<Rooms>();



        public frmTsk_CheckOut(int aIDBookingRoom,frmTsk_Payment_Step1 afrmTsk_Check_StatusPay)
        {

            InitializeComponent();
            this.aIDBookingRoom_Old = aIDBookingRoom;
            this.afrmTsk_Check_StatusPay_Old = afrmTsk_Check_StatusPay;

        }
        //Hiennv
        public frmTsk_CheckOut(frmMain afrmMain,int aIDBookingRoom )
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.aIDBookingRoom_Old = aIDBookingRoom;

        }

        //cau tu nay dung de hien thi tat ca cac phong da duoc CheckIn
        //Hiennv
        public frmTsk_CheckOut(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }


        private void frmTsk_CheckOut_Load(object sender, EventArgs e)
        {
            List<BookingRooms> aListTemp = new List<BookingRooms>();
            if (aIDBookingRoom_Old == -1)
            {
                aListTemp.Clear();
               // aListTemp = aBookingRoomsBO.Select_ByStatus_ByTime(DateTime.Now, Status);
                aListTemp = aBookingRoomsBO.Select_ByStatus(Status);
            }
            else
            {
                aListTemp.Clear();
                aListTemp.Add(aBookingRoomsBO.Select_ByID(aIDBookingRoom_Old));
            }
            RoomsBO aRoomsBO = new RoomsBO();
            this.aListRooms = aRoomsBO.Select_All();
            dgvBookingRooms.DataSource = this.GetListBookingRooms(aListTemp, this.aListRooms);
            dgvBookingRooms.RefreshDataSource();
        }

        //hiennv
        private List<BookingRooms> GetListBookingRooms(List<BookingRooms> aListBookingRooms, List<Rooms> aListRooms)
        {
            try
            {
                List<BookingRooms> aListBookingRoomsTemp = new List<BookingRooms>();
                BookingRooms aBookingRooms;
                foreach (BookingRooms items in aListBookingRooms)
                {
                    aBookingRooms = new BookingRooms();
                    aBookingRooms.ID = items.ID;
                    aBookingRooms.IDBookingR = items.IDBookingR;
                    aBookingRooms.CodeRoom = items.CodeRoom;
                    aBookingRooms.Cost = items.Cost;
                    aBookingRooms.PercentTax = items.PercentTax;
                    aBookingRooms.CostRef_Rooms = items.CostRef_Rooms;
                    aBookingRooms.Note = items.Note;
                    aBookingRooms.CheckInPlan = items.CheckInPlan;
                    aBookingRooms.CheckOutPlan = items.CheckOutPlan;
                    aBookingRooms.CheckInActual = items.CheckInActual;
                    aBookingRooms.CheckOutActual = items.CheckOutActual;
                    aBookingRooms.BookingStatus = items.BookingStatus;
                    aBookingRooms.Status = items.Status;
                    aBookingRooms.StartTime = items.StartTime;
                    aBookingRooms.EndTime = items.EndTime;
                    aBookingRooms.IsAllDayEvent = items.IsAllDayEvent;
                    aBookingRooms.Color = items.Color;
                    aBookingRooms.IsRecurring = items.IsRecurring;
                    aBookingRooms.IsEditable = items.IsEditable;

                    //dung tam cot AdditionalColumn1 de hien thi ten phong(Sku)
                    if (aListRooms.Where(r => r.Code == items.CodeRoom).ToList().Count > 0)
                    {
                        aBookingRooms.AdditionalColumn1 = aListRooms.Where(r => r.Code == items.CodeRoom).ToList()[0].Sku;
                    }
                    aBookingRooms.CostPendingRoom = items.CostPendingRoom;
                    aBookingRooms.TimeInUse = items.TimeInUse;
                    aListBookingRoomsTemp.Add(aBookingRooms);
                }
                return aListBookingRoomsTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckOut.GetListBookingRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        private void btnCheckOut_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                AccountancyBO aAccountancyBO = new AccountancyBO();
                int IDBookingRoom = int.Parse(grvBookingRoom.GetFocusedRowCellValue("ID").ToString());
                DateTime CheckOutActual = DateTime.Parse(grvBookingRoom.GetFocusedRowCellValue("CheckOutActual").ToString());
     
       
                aAccountancyBO.CheckOut(IDBookingRoom, CheckOutActual);
                MessageBox.Show(" Đã check out xong ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);              

                List<BookingRooms> aListTemp = new List<BookingRooms>();
                aListTemp = aBookingRoomsBO.Select_ByStatus_ByTime(DateTime.Now, Status);
                dgvBookingRooms.DataSource = this.GetListBookingRooms(aListTemp, this.aListRooms);
                dgvBookingRooms.RefreshDataSource();

                if (aListTemp.Count <= 0)
                {
                    if (this.afrmTsk_Check_StatusPay_Old != null)
                    {
                        this.afrmTsk_Check_StatusPay_Old.LoadListBookingR();
                        if (this.afrmTsk_Check_StatusPay_Old.afrmMain != null)
                        {
                            this.afrmTsk_Check_StatusPay_Old.afrmMain.ReloadData();
                            this.Close();
                        }
                    }
                    
                    if(this.afrmMain !=null)
                    {
                        this.afrmMain.ReloadData();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckOut - CheckOut Click \n " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBookingRooms_Click(object sender, EventArgs e)
        {

        }
    }
}