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
using DataAccess;
using BussinessLogic;
using Entity;
using DevExpress.XtraEditors.Controls;

namespace RoomManager
{
    public partial class frmTsk_CheckOutExpire : DevExpress.XtraEditors.XtraForm
    {
        public frmMain afrmMain = null;

        public frmTsk_CheckOutExpire()
        {
            InitializeComponent();
          
        }

        public frmTsk_CheckOutExpire(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

        //Hiennv
        private void frmTsk_CheckOutExpire_Load(object sender, EventArgs e)
        {
            dtpCheckTime.DateTime = DateTime.Now;
            try
            {

                dgvbookingcheckout.DataSource = this.LoadListRoomsCheckOutInDayAndH(dtpCheckTime.DateTime, 3);//status =3 : da checkIn
                dgvbookingcheckout.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckOutExpire.frmTsk_CheckOutExpire_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date3= DateTime.ParseExact(dtpCheckTime.Text, "dd/MM/yyyy HH:mm", null);

                dgvbookingcheckout.DataSource = this.LoadListRoomsCheckOutInDayAndH(date3, 3);//status =3 : da checkIn
                dgvbookingcheckout.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckOutExpire.btnSearch\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewdetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            try
            {
                int BookingRs_ID = Convert.ToInt32(viewBookingcheckout.GetFocusedRowCellValue("IDBookingR"));
                int BookingRoomID = Convert.ToInt32(viewBookingcheckout.GetFocusedRowCellValue("ID"));

                frmTsk_EditBooking afrmTsk_EditBooking = new frmTsk_EditBooking(BookingRoomID,this.afrmMain);
                afrmTsk_EditBooking.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckOutExpire.btnViewdetail_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       // tqtrung 
        public List<BookingRoomsEN> LoadListRoomsCheckOutInDayAndH(DateTime CheckOutPlan, int Status)
        {
            try
            {
               
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                return aBookingRoomsBO.GetListRoomsCheckOutPlanInDayAndH(CheckOutPlan, Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckOutExpire.GetListRoomsCheckOutPlanInDayAndH\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
    }
}