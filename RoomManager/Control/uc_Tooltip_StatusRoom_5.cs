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
    public partial class uc_Tooltip_StatusRoom_5 : UserControl
    {
        public RoomExtStatusEN Datasource = new RoomExtStatusEN();
        public int StatusButtonPopup = 0;

        public frmMain afrmMain = null;

        public uc_Tooltip_StatusRoom_5(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        public uc_Tooltip_StatusRoom_5(RoomExtStatusEN Datasource)
        {
            InitializeComponent();
            this.Datasource = Datasource;
        }
        public uc_Tooltip_StatusRoom_5()
        {
            InitializeComponent();
            this.Datasource =   new RoomExtStatusEN();;
        }

        public void DataBind()
        {
            this.lblStatus_5.Text = "Phòng " + this.Datasource.Sku + " đang tạm giữ cho khách hàng";
            this.lblCompany_5.Text = !string.IsNullOrEmpty(this.Datasource.Companies_Name) ? this.Datasource.Companies_Name : "";
            this.lblCustomer_5.Text = !string.IsNullOrEmpty(this.Datasource.Customers_Name) ? this.Datasource.Customers_Name : "";
            this.lblCustomerGroup_5.Text = !string.IsNullOrEmpty(this.Datasource.CustomerGroups_Name) ? this.Datasource.CustomerGroups_Name : "";
           
            this.lblFrom_5.Text = this.Datasource.CheckInActual.ToString("dd/MM/yyyy HH:mm");
            this.lblTo_5.Text = this.Datasource.CheckOutPlan.ToString("dd/MM/yyyy HH:mm");
            this.lblTel_5.Text = this.Datasource.Customers_Tel;

            this.lblBookingMoney.Text = String.Format(CultureInfo.InvariantCulture, "{0:#.##}", this.Datasource.BookingRs_BookingMoney.ToString());

            this.lblBookingR_5.Text = this.Datasource.BookingRs_Subject != null ? this.Datasource.BookingRs_Subject.ToString() : "";

            this.lblIDBookingR_5.Text = this.Datasource.BookingRs_ID != null ? this.Datasource.BookingRs_ID.ToString() : "";

            this.lblIDBookingRoom_5.Text = this.Datasource.BookingRooms_ID != null ? this.Datasource.BookingRooms_ID.ToString() : "";

            this.lblBookingRoomName_5.Text = string.IsNullOrEmpty(this.Datasource.Note) ? "" : this.Datasource.Note.Substring(0, Math.Min(25, this.Datasource.Note.Length)) + "...";
            this.lblBookingRoomName_5.ToolTip = this.Datasource.Note;

            if (this.Datasource.BookingRs_CustomerType == 1)
            {
                this.lblCustomerType_5.Text = "Khách nhà nước";
            }
            else if (this.Datasource.BookingRs_CustomerType == 2)
            {
                this.lblCustomerType_5.Text = "Khách đoàn";
            }
            else if (this.Datasource.BookingRs_CustomerType == 3)
            {
                this.lblCustomerType_5.Text = "Khách lẻ";
            }
            else if (this.Datasource.BookingRs_CustomerType == 4)
            {
                this.lblCustomerType_5.Text = "Khách vãng lai";
            }

          
            pan_Status_5.Dock = DockStyle.Fill;

        }

        public void ShowDialog()
        {
            if (this.StatusButtonPopup == 0) // Mac dinh
            {
                this.btnCheckOut_5.Enabled = false;
                this.btnPaymen_5.Enabled = false;
            }
            if (this.StatusButtonPopup == 1) //Qua khu
            {
                this.btnCheckOut_5.Enabled = false;
                this.btnPaymen_5.Enabled = false;
            }
            else if (this.StatusButtonPopup == 2) // hien tai
            {
                this.btnCheckOut_5.Enabled = true;
                this.btnPaymen_5.Enabled = true;
            }
            if (this.StatusButtonPopup == 3) // tuong lai
            {
                this.btnCheckOut_5.Enabled = false;
                this.btnPaymen_5.Enabled = false;
            }


            Form afrm = new Form();
            afrm.Controls.Add(this);

            afrm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            
            afrm.BringToFront();

            afrm.Width = this.Width + 18;
            afrm.Height = this.Height + 20;
            afrm.ShowDialog();

        }


        private void picClose_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;

        }
        //hiennv
        private void btnCheckOut_5_Click(object sender, EventArgs e)
        {
            frmTsk_CheckOut afrm = new frmTsk_CheckOut(this.afrmMain, this.Datasource.BookingRooms_ID);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }
        //hiennv
        private void btnPaymen_5_Click(object sender, EventArgs e)
        {
            frmTsk_Payment_Step1 afrm = new frmTsk_Payment_Step1(this.afrmMain, this.Datasource.BookingRs_ID.GetValueOrDefault(), this.Datasource.BookingRs_CustomerType.GetValueOrDefault(), this.Datasource.CheckInPlan, this.Datasource.CheckOutPlan);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }
        //Hiennv
        private void btnCheckIn_5_Click(object sender, EventArgs e)
        {
            frmTsk_PendingCheckIn_Step1 afrmTsk_PendingCheckIn_Step1 = new frmTsk_PendingCheckIn_Step1(this.afrmMain);
            afrmTsk_PendingCheckIn_Step1.ShowDialog();
        }


    }
}
