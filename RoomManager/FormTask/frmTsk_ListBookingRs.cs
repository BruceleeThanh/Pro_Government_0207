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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_ListBookingRs : DevExpress.XtraEditors.XtraForm
    {
        public frmMain afrmMain = null;
        private int customerType = 0;
        private int IDBookingR = 0;


        public frmTsk_ListBookingRs(int IDBookingR, int customerType)
        {
            InitializeComponent();
            this.IDBookingR = IDBookingR;
            this.customerType = customerType;
        }

        public frmTsk_ListBookingRs(frmMain afrmMain ,int customerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.customerType = customerType;
        }
        public void Reload()
        {
            try
            {
                BookingRsBO aBookingRsBO = new BookingRsBO();
                List<BookingRsEN> aList_BookingRsEN = new List<BookingRsEN>();
                List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> aList = aBookingRsBO.Select_ByStatusAndDateAndCustomerType(2, DateTime.Now, this.customerType);// status = 2 :Checked ; customerType =1 : khach nha nuoc ; customerType =2 : khach doan ; customerType =3 : khach le
                BookingRsEN item;
                for (int i = 0; i < aList.Count; i++)
                {
                    item = new BookingRsEN();
                    item.StatusDisplay = CORE.CONSTANTS.SelectedBookingRoomStatus(aList[i].BookingRooms_Status.GetValueOrDefault()).Name;
                    item.CustomerTypeDisplay = CORE.CONSTANTS.SelectedCustomerType(aList[i].BookingRs_CustomerType.GetValueOrDefault()).Name;
                    item.SetValue(aList[i]);
                    aList_BookingRsEN.Add(item);
                }

                if (this.IDBookingR == 0)
                {
                    dgvBookingRs.DataSource = aList_BookingRsEN;
                    dgvBookingRs.RefreshDataSource();
                }
                else
                {
                    dgvBookingRs.DataSource = aList_BookingRsEN.Where(b=>b.BookingRs_ID == this.IDBookingR);
                    dgvBookingRs.RefreshDataSource();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingRs.ReLoad.\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_ListBookingRs_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void btnCancel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            int IDBookingRoom = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRooms_ID"));
            aBookingRoomsBO.Delete(IDBookingRoom);
            this.Reload();
            if(this.afrmMain !=null)
            {
                this.afrmMain.ReloadData();
            }
        }

        private void btnCheckIn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
                //if (CORE.CONSTANTS.SelectedCustomerType(this.customerType).ID == 1) //Khach nha nuoc
                //{
                //    int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
                //    DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));

                //    frmTsk_CheckInGoverment_ForRoomBooking_Step1 afrmTsk_CheckInGoverment_ForRoomBooking_Step1 = new frmTsk_CheckInGoverment_ForRoomBooking_Step1(this, IDBookingRs,CheckOutPlan);
                //    afrmTsk_CheckInGoverment_ForRoomBooking_Step1.ShowDialog();
                //}
                //if (CORE.CONSTANTS.SelectedCustomerType(this.customerType).ID == 2) //Khach doan
                //{
                //    int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
                //    DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));
                //    frmTsk_CheckInGroup_ForRoomBooking_Step1 afrmTsk_CheckInGroup_ForRoomBooking_Step1 = new frmTsk_CheckInGroup_ForRoomBooking_Step1(this, IDBookingRs, CheckOutPlan);
                //    afrmTsk_CheckInGroup_ForRoomBooking_Step1.ShowDialog();
                //}
                //if (CORE.CONSTANTS.SelectedCustomerType(this.customerType).ID == 3) //Khach le
                //{
                //    int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
                //    DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));
                //    frmTsk_CheckInCustomer_ForRoomBooking_Step1 afrmTsk_CheckInCustomer_ForRoomBooking_Step1 = new frmTsk_CheckInCustomer_ForRoomBooking_Step1(this, IDBookingRs, CheckOutPlan);
                //    afrmTsk_CheckInCustomer_ForRoomBooking_Step1.ShowDialog();
                //}

            int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
            DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));
            frmTsk_CheckInForRoomBooking afrmTsk_CheckInForRoomBooking = new frmTsk_CheckInForRoomBooking(this, IDBookingRs, CheckOutPlan);
            afrmTsk_CheckInForRoomBooking.Show();


        }

        private void grvBookingRs_RowClick(object sender, RowClickEventArgs e)
        {
            //if (CORE.CONSTANTS.SelectedCustomerType(this.customerType).ID == 1) //Khach nha nuoc
            //{
            //    int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
            //    DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));

            //    frmTsk_CheckInGoverment_ForRoomBooking_Step1 afrmTsk_CheckInGoverment_ForRoomBooking_Step1 = new frmTsk_CheckInGoverment_ForRoomBooking_Step1(this, IDBookingRs, CheckOutPlan);
            //    afrmTsk_CheckInGoverment_ForRoomBooking_Step1.ShowDialog();
            //}
            //if (CORE.CONSTANTS.SelectedCustomerType(this.customerType).ID == 2) //Khach doan
            //{
            //    int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
            //    DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));
            //    frmTsk_CheckInGroup_ForRoomBooking_Step1 afrmTsk_CheckInGroup_ForRoomBooking_Step1 = new frmTsk_CheckInGroup_ForRoomBooking_Step1(this, IDBookingRs, CheckOutPlan);
            //    afrmTsk_CheckInGroup_ForRoomBooking_Step1.ShowDialog();
            //}
            //if (CORE.CONSTANTS.SelectedCustomerType(this.customerType).ID == 3) //Khach le
            //{
            //    int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
            //    DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));
            //    frmTsk_CheckInCustomer_ForRoomBooking_Step1 afrmTsk_CheckInCustomer_ForRoomBooking_Step1 = new frmTsk_CheckInCustomer_ForRoomBooking_Step1(this, IDBookingRs, CheckOutPlan);
            //    afrmTsk_CheckInCustomer_ForRoomBooking_Step1.ShowDialog();
            //}

            int IDBookingRs = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("BookingRs_ID"));
            DateTime CheckOutPlan = Convert.ToDateTime(grvBookingRs.GetFocusedRowCellValue("BookingRooms_CheckOutPlan"));
            frmTsk_CheckInForRoomBooking afrmTsk_CheckInForRoomBooking = new frmTsk_CheckInForRoomBooking(this, IDBookingRs, CheckOutPlan);
            afrmTsk_CheckInForRoomBooking.Show();
        }
    }
}