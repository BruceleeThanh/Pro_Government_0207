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
    public partial class uc_Tooltip_StatusRoom_0 : UserControl
    {
        public RoomExtStatusEN Datasource = new RoomExtStatusEN();
        public int StatusButtonPopup = 0;

        public frmMain afrmMain = null;

        //hiennv
        public uc_Tooltip_StatusRoom_0(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

        public uc_Tooltip_StatusRoom_0(RoomExtStatusEN Datasource)
        {
            InitializeComponent();
            this.Datasource = Datasource;
        }
        public uc_Tooltip_StatusRoom_0()
        {
            InitializeComponent();
            this.Datasource =   new RoomExtStatusEN();;
        }

        public void DataBind()
        {
            this.lblStatus_0.Text = "Phòng "+ this.Datasource.Sku +" trống";

          
            pan_Status_0.Dock = DockStyle.Fill;

        }


        public void ShowDialog()
        {
            if (this.StatusButtonPopup == 0) // Mac dinh
            {
                this.btnBooking_Customer_0.Enabled = false;
                this.btnBooking_Gov_0.Enabled = false;
                this.btnBooking_Group_0.Enabled = false;

                this.btnCheckIn_Customer_0.Enabled = false;
                this.btnCheckIn_Gov_0.Enabled = false;
                this.btnCheckIn_Group_0.Enabled = false;
               
            }
            else if (this.StatusButtonPopup == 1) //Qua khu
            {
                this.btnBooking_Customer_0.Enabled = false;
                this.btnBooking_Gov_0.Enabled = false;
                this.btnBooking_Group_0.Enabled = false;

                this.btnCheckIn_Customer_0.Enabled = false;
                this.btnCheckIn_Gov_0.Enabled = false;
                this.btnCheckIn_Group_0.Enabled = false;
            }
            else if (this.StatusButtonPopup == 2) // hien tai
            {
                this.btnBooking_Customer_0.Enabled = true;
                this.btnBooking_Gov_0.Enabled = true;
                this.btnBooking_Group_0.Enabled = true;

                this.btnCheckIn_Customer_0.Enabled = true;
                this.btnCheckIn_Gov_0.Enabled = true;
                this.btnCheckIn_Group_0.Enabled = true;
            }
            else if (this.StatusButtonPopup == 3) // tuong lai
            {
                this.btnBooking_Customer_0.Enabled = true;
                this.btnBooking_Gov_0.Enabled = true;
                this.btnBooking_Group_0.Enabled = true;

                this.btnCheckIn_Customer_0.Enabled = false;
                this.btnCheckIn_Gov_0.Enabled = false;
                this.btnCheckIn_Group_0.Enabled = false;
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
        private void btnCheckIn_Gov_0_Click(object sender, EventArgs e)
        {
            //frmTsk_CheckIn_Goverment_Step1 afrm = new frmTsk_CheckIn_Goverment_Step1(this.afrmMain, this.Datasource.Code);
            //afrm.ShowDialog();

            frmTsk_CheckIn afrmTsk_CheckIn = new frmTsk_CheckIn(this.afrmMain, this.Datasource.Code,1);
            afrmTsk_CheckIn.ShowDialog();
            this.Parent.Dispose();
        }
        //hiennv
        private void btnCheckIn_Group_0_Click(object sender, EventArgs e)
        {
            //frmTsk_CheckIn_Group_Step1 afrm = new frmTsk_CheckIn_Group_Step1(this.afrmMain, this.Datasource.Code);
            //afrm.ShowDialog();
            //this.Parent.Dispose();

            frmTsk_CheckIn afrmTsk_CheckIn = new frmTsk_CheckIn(this.afrmMain, this.Datasource.Code,2);
            afrmTsk_CheckIn.ShowDialog();
            this.Parent.Dispose();
        }

        //hiennv
        private void btnCheckIn_Customer_0_Click(object sender, EventArgs e)
        {
            //frmTsk_CheckIn_Customer_Step1 afrm = new frmTsk_CheckIn_Customer_Step1(this.afrmMain,this.Datasource.Code);
            //afrm.ShowDialog();
            //this.Parent.Dispose();

            frmTsk_CheckIn afrmTsk_CheckIn = new frmTsk_CheckIn(this.afrmMain, this.Datasource.Code,3);
            afrmTsk_CheckIn.ShowDialog();
            this.Parent.Dispose();
        }

        private void btnBooking_Customer_0_Click(object sender, EventArgs e)
        {
            //frmTsk_Booking_Step1 afrm = new frmTsk_Booking_Step1(this.afrmMain, this.Datasource.Code,3);
            //afrm.ShowDialog();
            //this.Parent.Dispose();

            frmTsk_BookingForRoom afrmTsk_BookingForRoom = new frmTsk_BookingForRoom(this.afrmMain, this.Datasource.Code,3);
            afrmTsk_BookingForRoom.ShowDialog();
            this.Parent.Dispose();
        }

        private void btnBooking_Group_0_Click(object sender, EventArgs e)
        {
            //frmTsk_Booking_Step1 afrm = new frmTsk_Booking_Step1(this.afrmMain, this.Datasource.Code,2);
            //afrm.ShowDialog();
            //this.Parent.Dispose();
            frmTsk_BookingForRoom afrmTsk_BookingForRoom = new frmTsk_BookingForRoom(this.afrmMain, this.Datasource.Code,2);
            afrmTsk_BookingForRoom.ShowDialog();
            this.Parent.Dispose();
        }

        private void btnBooking_Gov_0_Click(object sender, EventArgs e)
        {
            //frmTsk_Booking_Step1 afrm = new frmTsk_Booking_Step1(this.afrmMain, this.Datasource.Code,1);
            //afrm.ShowDialog();

            frmTsk_BookingForRoom afrmTsk_BookingForRoom = new frmTsk_BookingForRoom(this.afrmMain, this.Datasource.Code, 1);
            afrmTsk_BookingForRoom.ShowDialog();
            this.Parent.Dispose();
        }









    }
}
