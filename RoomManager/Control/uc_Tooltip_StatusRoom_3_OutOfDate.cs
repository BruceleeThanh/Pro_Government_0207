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
    public partial class uc_Tooltip_StatusRoom_3_OutOfDate : UserControl
    {
        public frmMain afrmMain = null;
        public RoomExtStatusEN Datasource = new RoomExtStatusEN();
        public int StatusButtonPopup = 0;

        public uc_Tooltip_StatusRoom_3_OutOfDate(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        
        public uc_Tooltip_StatusRoom_3_OutOfDate(RoomExtStatusEN Datasource)
        {
            InitializeComponent();
            this.Datasource = Datasource;
        }

        public uc_Tooltip_StatusRoom_3_OutOfDate()
        {
            InitializeComponent();
            this.Datasource =   new RoomExtStatusEN();
        }
        
        public void DataBind()
        {
        
            this.lblStatus_3.Text = "Phòng "+ this.Datasource.Sku + " đang có người ở";
            this.lblCompany_3.Text = !string.IsNullOrEmpty(this.Datasource.Companies_Name) ? this.Datasource.Companies_Name : "";
            this.lblCustomer_3.Text = !string.IsNullOrEmpty(this.Datasource.Customers_Name) ? this.Datasource.Customers_Name : "";
            this.lblCustomerGroup_3.Text = !string.IsNullOrEmpty(this.Datasource.CustomerGroups_Name) ? this.Datasource.CustomerGroups_Name : "";
           
            this.lblFrom_3.Text = this.Datasource.CheckInActual.ToString("dd/MM/yyyy HH:mm");
            this.lblTo_3.Text = this.Datasource.CheckOutPlan.ToString("dd/MM/yyyy HH:mm");
            this.lblBookingMoney.Text = String.Format(CultureInfo.InvariantCulture, "{0:#.##}", this.Datasource.BookingRs_BookingMoney.ToString());
            this.lblTel_3.Text = this.Datasource.Customers_Tel;

            this.lblBookingR_3.Text = this.Datasource.BookingRs_Subject != null ? this.Datasource.BookingRs_Subject.ToString() : "";

            this.lblIDBookingR_3.Text = this.Datasource.BookingRs_ID != null ? this.Datasource.BookingRs_ID.ToString() : "";

            this.lblIDBookingRoom_3.Text = this.Datasource.BookingRooms_ID != null ? this.Datasource.BookingRooms_ID.ToString() : "";

            this.lblBookingRoomName_3.Text = string.IsNullOrEmpty(this.Datasource.Note)? "" :this.Datasource.Note.Substring(0, Math.Min(25, this.Datasource.Note.Length)) + "...";
            
            this.lblBookingRoomName_3.ToolTip = this.Datasource.Note;

            if (this.Datasource.BookingRs_CustomerType == 1)
            {
                this.lblCustomerType_3.Text = "Khách nhà nước";
            }
            else if (this.Datasource.BookingRs_CustomerType == 2)
            {
                this.lblCustomerType_3.Text = "Khách đoàn";
            }
            else if (this.Datasource.BookingRs_CustomerType == 3)
            {
                this.lblCustomerType_3.Text = "Khách lẻ";
            }
            else if (this.Datasource.BookingRs_CustomerType == 4)
            {
                this.lblCustomerType_3.Text = "Khách vãng lai";
            }

          
            pan_Status_3.Dock = DockStyle.Fill;

        }

        public void ShowDialog()
        {
            if (this.StatusButtonPopup == 0) // Mac dinh
            {
                this.btnCheckOut_3.Enabled = false;
           
                this.btnPaymen_3.Enabled = false;
           
              
            }
            else if (this.StatusButtonPopup == 1) //Qua khu
            {
                this.btnCheckOut_3.Enabled = false;
             
                this.btnPaymen_3.Enabled = false;
            
            }
            else if (this.StatusButtonPopup == 2) // hien tai
            {
                this.btnCheckOut_3.Enabled = true;
                
                this.btnPaymen_3.Enabled = true;
              
            }
            else if (this.StatusButtonPopup == 3) // tuong lai
            {
                this.btnCheckOut_3.Enabled = false;
          
                this.btnPaymen_3.Enabled = false;
          
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


        private void btnUseService_3_Click(object sender, EventArgs e)
        {
            frmTsk_UseServices afrm = new frmTsk_UseServices(this.Datasource.Code, this.Datasource.BookingRs_ID.GetValueOrDefault(),this.Datasource.BookingRooms_ID);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }

        private void btnLockRoom_Click(object sender, EventArgs e)
        {
            frmTsk_PendingRoom_Step1 afrm = new frmTsk_PendingRoom_Step1(this.afrmMain, this.Datasource.Code);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }

        private void btnCheckOut_3_Click(object sender, EventArgs e)
        {
            frmTsk_CheckOut afrm = new frmTsk_CheckOut(this.afrmMain,this.Datasource.BookingRooms_ID);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }

        private void btnPaymen_3_Click(object sender, EventArgs e)
        {
            frmTsk_Payment_Step1 afrm = new frmTsk_Payment_Step1(this.afrmMain,this.Datasource.BookingRs_ID.GetValueOrDefault(),this.Datasource.BookingRs_CustomerType.GetValueOrDefault(),this.Datasource.CheckInPlan,this.Datasource.CheckOutPlan);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmTsk_EditBooking afrm = new frmTsk_EditBooking(this.Datasource.BookingRooms_ID, this.afrmMain);
            afrm.ShowDialog();
            this.Parent.Dispose();
        }

        //Hiennv
        private void btnCheckInHalls_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.Datasource.BookingRs_CustomerType == 1)
                {
                    frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = new frmTsk_BookingHall_Goverment(this.Datasource.BookingRs_ID,this.Datasource.Companies_ID,this.Datasource.CustomerGroups_ID,this.Datasource.Customers_ID);
                    afrmTsk_BookingHall_Goverment.ShowDialog();
                    this.Parent.Dispose();
                }
                else if (this.Datasource.BookingRs_CustomerType == 2)
                {
                    frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = new frmTsk_BookingHall_Group(this.Datasource.BookingRs_ID, this.Datasource.Companies_ID, this.Datasource.CustomerGroups_ID, this.Datasource.Customers_ID);
                    afrmTsk_BookingHall_Group.ShowDialog();
                    this.Parent.Dispose();
                }
                else if (this.Datasource.BookingRs_CustomerType == 3)
                {
                    frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = new frmTsk_BookingHall_Customer(this.Datasource.BookingRs_ID, this.Datasource.Companies_ID, this.Datasource.CustomerGroups_ID, this.Datasource.Customers_ID);
                    afrmTsk_BookingHall_Customer.ShowDialog();
                    this.Parent.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("uc_Tooltip_StatusRoom_3.btnCheckInHalls_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetailRooms_Click(object sender, EventArgs e)
        {
            try
            {
                BookingRs_BookingHsBO aBookingRs_BookingHsBO = new BookingRs_BookingHsBO();
                BookingRs_BookingHs aBookingRs_BookingHs = aBookingRs_BookingHsBO.Select_ByIDBookingR(Convert.ToInt32(this.Datasource.BookingRs_ID));
                int IDBookingH = 0;
                if(aBookingRs_BookingHs !=null)
                {
                    IDBookingH = Convert.ToInt32(aBookingRs_BookingHs.IDBookingH);
                }
                frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = new frmTsk_Payment_Step2(afrmMain, Convert.ToInt32(this.Datasource.BookingRs_ID), IDBookingH,3,true);
                afrmTsk_Payment_Step2.ShowDialog();
                this.Parent.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("uc_Tooltip_StatusRoom_3.btnDetailRooms_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
