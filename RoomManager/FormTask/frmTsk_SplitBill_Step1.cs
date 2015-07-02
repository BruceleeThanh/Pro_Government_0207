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
using Entity;
using BussinessLogic;
using System.Globalization;


namespace RoomManager
{
    public partial class frmTsk_SplitBill_Step1 : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = null;
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();

        public frmTsk_SplitBill_Step1(frmTsk_Payment_Step2 afrmTsk_Payment_Step2, NewPaymentEN aNewPaymentEN)
        {
            InitializeComponent();
            this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
            this.aNewPaymentEN = aNewPaymentEN;
        }

        //Hiennv
        private void frmTsk_SplitBill_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.frmTsk_SplitBill_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            try
            {
                dgvRooms.DataSource = this.aNewPaymentEN.aListBookingRoomUsed;
                dgvRooms.RefreshDataSource();
                dgvHalls.DataSource = this.aNewPaymentEN.aListBookingHallUsed;
                dgvHalls.RefreshDataSource();
                dgvServicesRoom.DataSource = this.aNewPaymentEN.GetAllServiceUsedInRoom();
                dgvServicesRoom.RefreshDataSource();
                dgvServicesHall.DataSource = this.aNewPaymentEN.GetAllServiceUsedInHall();
                dgvServicesHall.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.LoadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                this.aNewPaymentEN.Save();
                frmTsk_SplitBill_Step2 afrmTsk_SplitBill_Step2 = new frmTsk_SplitBill_Step2(this,this.aNewPaymentEN);
                afrmTsk_SplitBill_Step2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.btnSplit_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void txtAddToSubPaymentR_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtChooseRooms = (TextEdit)sender;

                int IDBookingRooms = Convert.ToInt32(viewRooms.GetFocusedRowCellValue("ID"));
                this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == IDBookingRooms).ToList()[0].IndexSubPayment = Convert.ToInt32(txtChooseRooms.EditValue);
                this.aNewPaymentEN.ListIndex.Add(Convert.ToInt32(txtChooseRooms.EditValue));
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.txtChooseRooms_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void txtAddToSubPaymentServicesR_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtChooseService = (TextEdit)sender;
                int IDBookingRoomsService = Convert.ToInt32(viewServicesRoom.GetFocusedRowCellValue("IDBookingService"));
                BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                int IDBookingRoom = aBookingRooms_ServicesBO.Select_ByID(IDBookingRoomsService).IDBookingRoom;
                this.aNewPaymentEN.ChangeIndexSubPaymentServiceRoom(IDBookingRoom, IDBookingRoomsService, Convert.ToInt32(txtChooseService.EditValue));
                this.aNewPaymentEN.ListIndex.Add(Convert.ToInt32(txtChooseService.EditValue));

                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.txtChooseService_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void txtAddSubPaymentH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtChooseHalls = (TextEdit)sender;
                int IDBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("ID"));
                this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].IndexSubPayment = Convert.ToInt32(txtChooseHalls.EditValue);
                this.aNewPaymentEN.ListIndex.Add(Convert.ToInt32(txtChooseHalls.EditValue));

                this.LoadData();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.txtAddSubPaymentH_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        private void txtChooseService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtChooseService = (TextEdit)sender;
                int IDBookingHallsService = Convert.ToInt32(viewServicesHall.GetFocusedRowCellValue("IDBookingService"));
                BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                int IDBookingHall = aBookingHalls_ServicesBO.Select_ByID(IDBookingHallsService).IDBookingHall;
                this.aNewPaymentEN.ChangeIndexSubPaymentServiceHall(IDBookingHall, IDBookingHallsService, Convert.ToInt32(txtChooseService.EditValue));
                this.aNewPaymentEN.ListIndex.Add(Convert.ToInt32(txtChooseService.EditValue));

                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.txtAddToSubPaymentServicesH_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        



    }
}