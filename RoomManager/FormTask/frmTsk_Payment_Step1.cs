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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using Library;
using CORESYSTEM;
using DevExpress.Utils;

namespace RoomManager
{
    public partial class frmTsk_Payment_Step1 : DevExpress.XtraEditors.XtraForm
    {
        public frmMain afrmMain = null;
        private int IDBookingR = 0;
        private int CustomerType;
        private DateTime CheckInPlan;
        private DateTime CheckOutPlan;

        //Hiennv
        public frmTsk_Payment_Step1(frmMain afrmMain, int CustomerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.CustomerType = CustomerType;

        }
        //Hiennv
        public frmTsk_Payment_Step1(frmMain afrmMain, int IDBookingR, int CustomerType, DateTime CheckInPlan, DateTime CheckOutPlan)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.IDBookingR = IDBookingR;
            this.CustomerType = CustomerType;
            this.CheckInPlan = CheckInPlan;
            this.CheckOutPlan = CheckOutPlan;

        }
        
        // NgocBM
        // Form thanh toán được load tất cả các phòng chưa thanh toán bất kể loại nào
        public frmTsk_Payment_Step1(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;

        }
        //Hiennv
        // Ngoc da sua lai ten ham 26/12
        public void LoadListBookingR()
        {
            try
            {
                string StatusPay;
                DateTime From = dtpFrom.DateTime;
                DateTime To = dtpTo.DateTime;
                if (Convert.ToInt32(lueStatusPay.EditValue) == 4)
                {
                    StatusPay = "1,2,3";
                }
                else
                {
                    StatusPay = lueStatusPay.EditValue.ToString();
                }
                
                int CustomerType = Convert.ToInt32(lueCustomerType.EditValue);

                if (StatusPay == "1" || StatusPay == "2")
                {

                }
                else if (StatusPay == "3")
                {

                }
                
                if (this.IDBookingR == 0)
                {
                    if (From > To)
                    {
                        MessageBox.Show("Vui lòng nhập ngày bắt đầu kiểm tra nhỏ hơn ngày kết thúc .\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        dgvOwePay.DataSource = aReceptionTaskBO.GetListBookingRByStatus(From, To, CustomerType, StatusPay);
                        dgvOwePay.RefreshDataSource();
                    }
                }
                else if (this.IDBookingR > 0)
                {
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    dgvOwePay.DataSource = aReceptionTaskBO.GetListBookingRByStatus(From, To, CustomerType, StatusPay).Where(r=>r.IDBookingR == this.IDBookingR).ToList();
                    dgvOwePay.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Payment_Step1.GetListUnPayBookingR \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadListBookingR();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Payment_Step1.btnSearch_Click \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingRoom = int.Parse(viewOwePay.GetFocusedRowCellValue("IDBookingRoom").ToString());
            int BookingStatus = int.Parse(viewOwePay.GetFocusedRowCellValue("BookingRooms_Status").ToString());
            if (BookingStatus == 3)
            {
                frmTsk_CheckOut afrmTsk_CheckOut = new frmTsk_CheckOut(IDBookingRoom, this);
                afrmTsk_CheckOut.ShowDialog();
            }
            else
            {
                MessageBox.Show("Phòng này đã được check out . \n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnDiffView_Click(object sender, EventArgs e)
        {
            frmTsk_PaymentViewAll_New afrmTsk_PaymentViewAll_New = new frmTsk_PaymentViewAll_New();
            afrmTsk_PaymentViewAll_New.Show();
        }

        private void btnDetailBookingR_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookigR = Convert.ToInt32(viewOwePay.GetFocusedRowCellValue("IDBookingR"));
                int IDBookigH = Convert.ToInt32(viewOwePay.GetFocusedRowCellValue("IDBookingH"));
                int Status = Convert.ToInt32(viewOwePay.GetFocusedRowCellValue("BookingRooms_Status"));

                frmTsk_Payment_Step2 afrmTsk_Payment_Goverment_Step2 = new frmTsk_Payment_Step2(this, IDBookigR, IDBookigH, Status, true);
                afrmTsk_Payment_Goverment_Step2.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDetailBookingR.ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_Payment_Step1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                if (this.IDBookingR == 0)
                {
                    dtpFrom.DateTime = DateTime.Now.AddDays(-30);
                    dtpTo.DateTime = DateTime.Now;
                }
                else
                {
                    dtpFrom.DateTime = this.CheckInPlan;
                    dtpTo.DateTime = this.CheckOutPlan;
                    lueCustomerType.Enabled = false;
                    dtpFrom.Enabled = false;
                    dtpTo.Enabled = false;
                }

                lueCustomerType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes; // Load CustomerType
                lueCustomerType.Properties.DisplayMember = "Name";
                lueCustomerType.Properties.ValueMember = "ID";
                lueCustomerType.EditValue = this.CustomerType;

                lueStatusPay.Properties.DataSource = CORE.CONSTANTS.ListStatusPays;// Load StatusPay
                lueStatusPay.Properties.DisplayMember = "Name";
                lueStatusPay.Properties.ValueMember = "ID";
                lueStatusPay.EditValue = CORE.CONSTANTS.SelectedStatusPay(1).ID;
                this.LoadListBookingR();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Payment_Step1.frmTsk_Check_StatusPay_Load \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

    }
}