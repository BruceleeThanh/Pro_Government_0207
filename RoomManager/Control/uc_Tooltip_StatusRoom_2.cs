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
    public partial class uc_Tooltip_StatusRoom_2 : UserControl
    {
        public frmMain afrmMain = null;
        public RoomExtStatusEN Datasource = new RoomExtStatusEN();
        public int StatusButtonPopup = 0;

        //hiennv
        public uc_Tooltip_StatusRoom_2(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

        public uc_Tooltip_StatusRoom_2(RoomExtStatusEN Datasource)
        {
            InitializeComponent();
            this.Datasource = Datasource;
        }
        public uc_Tooltip_StatusRoom_2()
        {
            InitializeComponent();
            this.Datasource = new RoomExtStatusEN(); ;
        }
        public void DataBind()
        {
            if (this.Datasource.RoomStatus == 1)
            {
                this.lblStatus_2.Text = "Phòng " + this.Datasource.Sku + " đang có người đặt. Thông tin chưa được xác thực";

                this.btnCheckIn_2.Enabled = false;
            }
            else if (this.Datasource.RoomStatus == 2)
            {
                this.lblStatus_2.Text = "Phòng " + this.Datasource.Sku + " đang có người đặt.";

                this.btnCheckIn_2.Enabled = true;
            }


            this.lblCompany_2.Text = this.Datasource.Companies_Name;
            this.lblCustomer_2.Text = this.Datasource.Customers_Name;
            this.lblTel_2.Text = this.Datasource.Customers_Tel;


            this.lblCustomerGroup_2.Text = this.Datasource.CustomerGroups_Name;
            this.lblFrom_2.Text = this.Datasource.CheckInPlan.ToString("dd/MM/yyyy HH:mm");
            this.lblTo_2.Text = this.Datasource.CheckOutPlan.ToString("dd/MM/yyyy HH:mm");
            this.lblBookingMoney.Text = String.Format(CultureInfo.InvariantCulture, "{0:#.##}", this.Datasource.BookingRs_BookingMoney.ToString());

            this.lblBookingR_2.Text = this.Datasource.BookingRs_Subject;

            this.lblIDBookingR_2.Text = this.Datasource.BookingRs_ID.ToString();
            this.lblIDBookingRoom_2.Text = this.Datasource.BookingRooms_ID.ToString();

            this.lblBookingRoomName_2.Text = string.IsNullOrEmpty(this.Datasource.Note) ? "" : this.Datasource.Note.Substring(0, Math.Min(25, this.Datasource.Note.Length)) + "...";
            this.lblBookingRoomName_2.ToolTip = this.Datasource.Note;

            if (this.Datasource.BookingRs_CustomerType == 1)
            {
                this.lblCustomerType_2.Text = "Khách nhà nước";
            }
            else if (this.Datasource.BookingRs_CustomerType == 2)
            {
                this.lblCustomerType_2.Text = "Khách đoàn";
            }
            else if (this.Datasource.BookingRs_CustomerType == 3)
            {
                this.lblCustomerType_2.Text = "Khách lẻ";
            }
            else if (this.Datasource.BookingRs_CustomerType == 4)
            {
                this.lblCustomerType_2.Text = "Khách vãng lai";
            }

            pan_Status_2.Show();
            pan_Status_2.Dock = DockStyle.Fill;


        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;

        }

        private void btnCancel_2_Click(object sender, EventArgs e)
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                int count = aBookingRoomsBO.Delete(this.Datasource.BookingRooms_ID);
                if (count > 0)
                {
                    this.afrmMain.ReloadData();
                    MessageBox.Show("Thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xẩy ra trong quá trình thực hiện vui lòng liên hệ với người quản trị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Parent.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("uc_Tooltip_StatusRoom_2.btnCancel_2_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowDialog()
        {
            if (this.StatusButtonPopup == 0) // Mac dinh
            {
                this.btnCancel_2.Enabled = false;

                this.btnCheckIn_2.Enabled = false;


            }
            else if (this.StatusButtonPopup == 1) //Qua khu
            {
                this.btnCancel_2.Enabled = true;

                this.btnCheckIn_2.Enabled = false;

            }
            else if (this.StatusButtonPopup == 2) // hien tai
            {
                this.btnCancel_2.Enabled = true;

                this.btnCheckIn_2.Enabled = true;
            }
            else if (this.StatusButtonPopup == 3) // tuong lai
            {
                this.btnCancel_2.Enabled = true;

                this.btnCheckIn_2.Enabled = false;
            }

            Form afrm = new Form();
            afrm.Controls.Add(this);

            afrm.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            afrm.BringToFront();
     
            afrm.Width = this.Width + 18;
            afrm.Height = this.Height + 20;
            afrm.ShowDialog();
        }

        private void btnChecked_2_Click(object sender, EventArgs e)
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

        private void btnCheckIn_2_Click(object sender, EventArgs e)
        {
            //if (this.Datasource.BookingRs_CustomerType == 1) // checkin cho khach nha nuoc
            //{
            //    frmTsk_CheckInGoverment_ForRoomBooking_Step1 afrmTsk_CheckInGoverment_ForRoomBooking_Step1 = new frmTsk_CheckInGoverment_ForRoomBooking_Step1(this.afrmMain, this.Datasource.BookingRs_ID.GetValueOrDefault(), this.Datasource.CheckOutPlan);
            //    afrmTsk_CheckInGoverment_ForRoomBooking_Step1.ShowDialog();
            //}
            //else if (this.Datasource.BookingRs_CustomerType == 2)//checkin cho khach doan
            //{
            //    frmTsk_CheckInGroup_ForRoomBooking_Step1 afrmTsk_CheckInGroup_ForRoomBooking_Step1 = new frmTsk_CheckInGroup_ForRoomBooking_Step1(this.afrmMain, this.Datasource.BookingRs_ID.GetValueOrDefault(), this.Datasource.CheckOutPlan);
            //    afrmTsk_CheckInGroup_ForRoomBooking_Step1.ShowDialog();
            //}
            //else if (this.Datasource.BookingRs_CustomerType == 3) // CheckIn cho khach le
            //{
            //    frmTsk_CheckInCustomer_ForRoomBooking_Step1 afrmTsk_CheckInCustomer_ForRoomBooking_Step1 = new frmTsk_CheckInCustomer_ForRoomBooking_Step1(this.afrmMain, this.Datasource.BookingRs_ID.GetValueOrDefault(), this.Datasource.CheckOutPlan);
            //    afrmTsk_CheckInCustomer_ForRoomBooking_Step1.ShowDialog();
            //}

            frmTsk_CheckInForRoomBooking afrmTsk_CheckInForRoomBooking = new frmTsk_CheckInForRoomBooking(this.afrmMain,this.Datasource.BookingRs_ID.GetValueOrDefault(),this.Datasource.CheckOutPlan);
            afrmTsk_CheckInForRoomBooking.ShowDialog();
            this.Parent.Dispose();

        }

        private void pan_Status_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditInfoBooking_Click(object sender, EventArgs e)
        {
            frmTsk_EditBooking afrm = new frmTsk_EditBooking(this.Datasource.BookingRooms_ID, this.afrmMain);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }
    }
}
