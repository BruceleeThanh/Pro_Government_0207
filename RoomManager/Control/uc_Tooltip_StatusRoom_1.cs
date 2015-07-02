using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using System.Globalization;
using Entity;

namespace RoomManager
{
    public partial class uc_Tooltip_StatusRoom_1 : UserControl
    {
        public frmMain afrmMain = null;
        public RoomExtStatusEN Datasource = new RoomExtStatusEN();
        public int StatusButtonPopup = 0;

        public uc_Tooltip_StatusRoom_1(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        public uc_Tooltip_StatusRoom_1(RoomExtStatusEN Datasource)
        {
            InitializeComponent();
            this.Datasource = Datasource;
        }
        public uc_Tooltip_StatusRoom_1()
        {
            InitializeComponent();
            this.Datasource =   new RoomExtStatusEN();;
        }
        public void DataBind()
        {
            if (this.Datasource.RoomStatus == 1)
            {
                this.lblStatus_1.Text = "Phòng " + this.Datasource.Sku + " đang có người đặt. Thông tin chưa được xác thực";
                //this.btnChecked_1.Enabled = true;
                this.btnCheckIn_1.Enabled = false;
            }
            else if (this.Datasource.RoomStatus == 2)
            {
                this.lblStatus_1.Text = "Phòng " + this.Datasource.Sku + " đang có người đặt.";
                //this.btnChecked_1.Enabled = false;
                this.btnCheckIn_1.Enabled = true;
            }


            this.lblCompany_1.Text = this.Datasource.Companies_Name;
            this.lblCustomer_1.Text = this.Datasource.Customers_Name;
            this.lblCustomerGroup_1.Text = this.Datasource.CustomerGroups_Name;
            this.lblFrom_1.Text = this.Datasource.CheckInPlan.ToString("dd/MM/yyyy HH:mm");
            this.lblTo_1.Text = this.Datasource.CheckOutPlan.ToString("dd/MM/yyyy HH:mm");
            this.lblBookingMoney.Text = String.Format(CultureInfo.InvariantCulture, "{0:#.##}", this.Datasource.BookingRs_BookingMoney.ToString());
            this.lblTel_1.Text = this.Datasource.Customers_Tel;

            this.lblBookingR_1.Text = this.Datasource.BookingRs_Subject.ToString();
            this.lblIDBookingR_1.Text = this.Datasource.BookingRs_ID.ToString();
            this.lblIDBookingRoom_1.Text = this.Datasource.BookingRooms_ID.ToString();

            this.lblBookingRoomName_1.Text = string.IsNullOrEmpty(this.Datasource.Note) ? "" : this.Datasource.Note.Substring(0, Math.Min(25, this.Datasource.Note.Length)) + "...";
            this.lblBookingRoomName_1.ToolTip = this.Datasource.Note;

            if (this.Datasource.BookingRs_CustomerType == 1)
            {
                this.lblCustomerType_1.Text = "Khách nhà nước";
            }
            else if (this.Datasource.BookingRs_CustomerType == 2)
            {
                this.lblCustomerType_1.Text = "Khách đoàn";
            }
            else if (this.Datasource.BookingRs_CustomerType == 3)
            {
                this.lblCustomerType_1.Text = "Khách lẻ";
            }
            else if (this.Datasource.BookingRs_CustomerType == 4)
            {
                this.lblCustomerType_1.Text = "Khách vãng lai";
            }
            pan_Status_1.Show();
            pan_Status_1.Dock = DockStyle.Fill;


        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;
        }

        private void btnCancel_1_Click(object sender, EventArgs e)
        {
           BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
           bool i = aBookingRoomsBO.ChangeStatus( this.Datasource.BookingRooms_ID, 6); // 6: Cancel
           if (i == true)
           {
               MessageBox.Show("Đã chuyển trạng thái phòng");
           }
           else {
               MessageBox.Show("Chưa chuyển trạng thái phòng");
           }
        }

        public void ShowDialog()
        {
            Form afrm = new Form();
            afrm.Controls.Add(this);

            afrm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            
            afrm.BringToFront();
    
            afrm.Width = this.Width + 18;
            afrm.Height = this.Height + 20;
            afrm.ShowDialog();

        }
        private void pan_Status_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChecked_1_Click(object sender, EventArgs e)
        {
            if (this.Datasource.BookingRs_CustomerType == 1)
            {
                //frmTsk_CheckIn_Goverment_Step1 afrmTsk_CheckIn_Goverment_Step1 = new frmTsk_CheckIn_Goverment_Step1();

                //afrmTsk_CheckIn_Goverment_Step1.ShowDialog();
            }
            else if (this.Datasource.BookingRs_CustomerType == 2)
            {
                //frmTsk_CheckIn_Group_Step1 afrmTsk_CheckIn_Group_Step1 = new frmTsk_CheckIn_Group_Step1();
                //afrmTsk_CheckIn_Group_Step1.ShowDialog();
            }
            else if ((this.Datasource.BookingRs_CustomerType == 3) || (this.Datasource.BookingRs_CustomerType == 4))
            {
                //frmTsk_CheckIn_Customer_Step1 afrmTsk_CheckIn_Customer_Step1 = new frmTsk_CheckIn_Customer_Step1();
                //afrmTsk_CheckIn_Customer_Step1.ShowDialog();
            }
        }

        private void btnCheckIn_1_Click(object sender, EventArgs e)
        {
            frmTsk_ListBookingRs afrm = new frmTsk_ListBookingRs(Convert.ToInt32(this.Datasource.BookingRooms_ID), Convert.ToInt32(this.Datasource.BookingRs_CustomerType));
            afrm.ShowDialog();

            //frmTsk_CheckInForRoomBooking afrmTsk_CheckInForRoomBooking = new frmTsk_CheckInForRoomBooking(this.afrmMain, this.Datasource.BookingRs_ID.GetValueOrDefault(), this.Datasource.CheckOutPlan);
            //afrmTsk_CheckInForRoomBooking.ShowDialog();

            this.Parent.Dispose();
        }

        private void btnEditInfoBooking_Click(object sender, EventArgs e)
        {
            frmTsk_EditBooking afrm = new frmTsk_EditBooking(this.Datasource.BookingRooms_ID, this.afrmMain);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }


    }
}
