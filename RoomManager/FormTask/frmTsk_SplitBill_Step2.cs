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
using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmTsk_SplitBill_Step2 : DevExpress.XtraEditors.XtraForm
    {

        private frmTsk_SplitBill_Step1 afrmTsk_SplitBill_Step1 = null;
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();

        private List<ServiceUsedEN> aListServicesR = new List<ServiceUsedEN>();
        private List<ServiceUsedEN> aListServicesH = new List<ServiceUsedEN>();

        private List<BookingRoomUsedEN> aListRooms = new List<BookingRoomUsedEN>();
        private List<BookingHallUsedEN> aListHalls = new List<BookingHallUsedEN>();

        public frmTsk_SplitBill_Step2(frmTsk_SplitBill_Step1 afrmTsk_SplitBill_Step1, NewPaymentEN aNewPaymentEN)
        {
            InitializeComponent();
            this.afrmTsk_SplitBill_Step1 = afrmTsk_SplitBill_Step1;
            this.aNewPaymentEN = aNewPaymentEN;
        }
        
        private void frmTsk_SplitBill_Step2_Load(object sender, EventArgs e)
        {
            try
            {               
                lueIndexSub.Properties.DataSource = this.aNewPaymentEN.ListIndex.Distinct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2_Load.frmTsk_SplitBill_Step2_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        public void LoadListRooms_ByIndexSubPayment(NewPaymentEN aNewPaymentEN, int IndexSubPayment)
        {
            try
            {
                this.aListRooms.Clear();
                this.aListRooms = aNewPaymentEN.aListBookingRoomUsed.Where(r => r.IndexSubPayment == IndexSubPayment).OrderBy(r => r.RoomSku).ToList();
                dgvRooms.DataSource = this.aListRooms;
                dgvRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2.LoadListRooms_ByIndexSubRooms\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        public void LoadListServicesR_ByIndexSubPayment(NewPaymentEN aNewPaymentEN, int IndexSubPayment)
        {
            try
            {
                this.aListServicesR.Clear();
                this.aListServicesR = aNewPaymentEN.GetAllServiceUsedInRoom().Where(r => r.IndexSubPayment == IndexSubPayment).OrderBy(r => r.Sku).ToList();
                dgvServicesR.DataSource = this.aListServicesR;
                dgvServicesR.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2.LoadListServices_ByIndexSubServices\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        public void LoadListHalls_ByIndexSubPayment(NewPaymentEN aNewPaymentEN, int IndexSubPayment)
        {
            try
            {
                this.aListHalls.Clear();
                this.aListHalls = aNewPaymentEN.aListBookingHallUsed.Where(r => r.IndexSubPayment == IndexSubPayment).OrderBy(r => r.HallSku).ToList();
                dgvHalls.DataSource = this.aListHalls;
                dgvHalls.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2.LoadListHalls_ByIndexSubPayment\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        public void LoadListServicesH_ByIndexSubPayment(NewPaymentEN aNewPaymentEN, int IndexSubPayment)
        {
            try
            {
                this.aListServicesH.Clear();
                this.aListServicesH = aNewPaymentEN.GetAllServiceUsedInHall().Where(r => r.IndexSubPayment == IndexSubPayment).OrderBy(r => r.Sku).ToList();
                dgvServicesHall.DataSource = this.aListServicesH;
                dgvServicesHall.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2.LoadListServices_ByIndexSubServices\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void lueIndexSub_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpAcceptDate.EditValue = null;
                dtpInvoiceDate.EditValue = null;
                txtInvoiceNumber.ResetText();
                int indexSub = Convert.ToInt32(lueIndexSub.Text);

                this.LoadListRooms_ByIndexSubPayment(this.aNewPaymentEN, indexSub);
                this.LoadListServicesR_ByIndexSubPayment(this.aNewPaymentEN, indexSub);
                this.LoadListHalls_ByIndexSubPayment(this.aNewPaymentEN, indexSub);
                this.LoadListServicesH_ByIndexSubPayment(this.aNewPaymentEN, indexSub);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2_Load.lueIndexSub_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnPrintSplitBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lueIndexSub.Text) == true)
                {
                    lueIndexSub.Focus();
                    MessageBox.Show("Vui lòng chọn phiếu thanh toán cần in !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int indexSub = Convert.ToInt32(lueIndexSub.Text);
                    if ((this.aListRooms.Count() == 0 && this.aListServicesR.Count() == 0) && (this.aListHalls.Count() > 0 || this.aListServicesH.Count() > 0))
                    {
                        frmRpt_SplitPayment_BookingHs afrmRpt_SplitPayment_BookingHs = new frmRpt_SplitPayment_BookingHs(this.aNewPaymentEN, indexSub);
                        ReportPrintTool toolHall = new ReportPrintTool(afrmRpt_SplitPayment_BookingHs);
                        toolHall.ShowPreview();
                    }
                    else if ((this.aListHalls.Count() == 0 && this.aListServicesH.Count() == 0) && (this.aListRooms.Count() > 0 || this.aListServicesR.Count() > 0))
                    {
                        frmRpt_SplitPayment_BookingRs afrmRpt_SplitPayment_BookingRs = new frmRpt_SplitPayment_BookingRs(this.aNewPaymentEN, indexSub);
                        ReportPrintTool toolRoom = new ReportPrintTool(afrmRpt_SplitPayment_BookingRs);
                        toolRoom.ShowPreview();
                    }
                    else
                    {
                        frmRpt_SplitPayment_BookingRsAndBookingHs afrmRpt_SplitPayment_BookingRsAndBookingHs = new frmRpt_SplitPayment_BookingRsAndBookingHs(this.aNewPaymentEN, indexSub);
                        ReportPrintTool tool = new ReportPrintTool(afrmRpt_SplitPayment_BookingRsAndBookingHs);
                        tool.ShowPreview();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2_Load.btnPrintSplitBill_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lueIndexSub.Text) == true)
                {
                    lueIndexSub.Focus();
                    MessageBox.Show("Vui lòng chọn phiếu thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    if (this.aListRooms.Count > 0)
                    {
                        aReceptionTaskBO.SplitPaymentRoom(this.aNewPaymentEN, this.aListRooms);
                    }
                    if (this.aListHalls.Count > 0)
                    {
                        aReceptionTaskBO.SplitPaymentHall(this.aNewPaymentEN, this.aListHalls);
                    }
                    if (this.aListServicesR.Count > 0)
                    {
                        aReceptionTaskBO.SplitPaymentService(this.aNewPaymentEN, this.aListServicesR, 1); //1 - trạng thái thanh toán set cho dịch vụ phòng
                    }
                    if (this.aListServicesH.Count > 0)
                    {
                        aReceptionTaskBO.SplitPaymentService(this.aNewPaymentEN, this.aListServicesH, 2); //2 - trạng thái thanh toán set cho dịch vụ phòng
                    }
                    if (this.afrmTsk_SplitBill_Step1.afrmTsk_Payment_Step2.afrmTsk_Payment_Step1 != null)
                    {
                        this.afrmTsk_SplitBill_Step1.afrmTsk_Payment_Step2.afrmTsk_Payment_Step1.LoadListBookingR();
                        if (this.afrmTsk_SplitBill_Step1.afrmTsk_Payment_Step2.afrmTsk_Payment_Step1.afrmMain != null)
                        {
                            this.afrmTsk_SplitBill_Step1.afrmTsk_Payment_Step2.afrmTsk_Payment_Step1.afrmMain.ReloadData();
                        }
                    }


                    //this.InsertDataToPayment();

                    MessageBox.Show("Thanh toán thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step2_Load.btnPayment_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {

            if (dtpInvoiceDate.EditValue == null)
            {
                dtpAcceptDate.EditValue = null;

            }
            else
            {
                DateTime aTemp = dtpInvoiceDate.DateTime;
                dtpAcceptDate.DateTime = aTemp;
                if (aListRooms.Count > 0)
                {
                    foreach (BookingRoomUsedEN aBookingRoom in aListRooms)
                    {
                        aBookingRoom.InvoiceDate = aTemp;

                    }
                }
                else if (aListHalls.Count > 0)
                {
                    foreach (BookingHallUsedEN aBookingHall in aListHalls)
                    {
                        aBookingHall.InvoiceDate = aTemp;
                    }
                }
                else if (aListServicesH.Count > 0)
                {
                    foreach (ServiceUsedEN aServiceH in aListServicesH)
                    {
                        aServiceH.InvoiceDate = aTemp;
                    }
                }
                else if (aListServicesR.Count > 0)
                {
                    foreach (ServiceUsedEN aServiceR in aListServicesR)
                    {
                        aServiceR.InvoiceDate = aTemp;
                    }
                }
            }
        }

        private void txtInvoiceNumber_Leave(object sender, EventArgs e)
        {
            string aTemp = txtInvoiceNumber.Text;
            if (aListRooms.Count > 0)
            {
                foreach (BookingRoomUsedEN aBookingRoom in aListRooms)
                {
                    aBookingRoom.InvoiceNumber = aTemp;
                }
            }
            else if (aListHalls.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in aListHalls)
                {
                    aBookingHall.InvoiceNumber = aTemp;
                }
            }
            else if (aListServicesH.Count > 0)
            {
                foreach (ServiceUsedEN aServiceH in aListServicesH)
                {
                    aServiceH.InvoiceNumber = aTemp;
                }
            }
            else if (aListServicesR.Count > 0)
            {
                foreach (ServiceUsedEN aServiceR in aListServicesR)
                {
                    aServiceR.InvoiceNumber = aTemp;
                }
            }
        }

        private void dtpAcceptDate_EditValueChanged(object sender, EventArgs e)
        {
            DateTime aTemp = dtpAcceptDate.DateTime;
            if (aListRooms.Count > 0)
            {
                foreach (BookingRoomUsedEN aBookingRoom in aListRooms)
                {
                    aBookingRoom.AcceptDate = aTemp;

                }
            }
            else if (aListHalls.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in aListHalls)
                {
                    aBookingHall.AcceptDate = aTemp;
                }
            }
            else if (aListServicesH.Count > 0)
            {
                foreach (ServiceUsedEN aServiceH in aListServicesH)
                {
                    aServiceH.AcceptDate = aTemp;
                }
            }
            else if (aListServicesR.Count > 0)
            {
                foreach (ServiceUsedEN aServiceR in aListServicesR)
                {
                    aServiceR.AcceptDate = aTemp;
                }
            }
        }

        

       

        //Hiennv
        //private void InsertDataToPayment()
        //{
        //    try
        //    {
        //        /*-------*/
        //        RoomsBO aRoomsBO = new RoomsBO();
        //        ServicesBO aServicesBO = new ServicesBO();
        //        PaymentBO aPaymentBO = new PaymentBO();
        //        Payment aPayment = new Payment();



        //        aPayment.IDBookingR = this.aNewPaymentEN.IDBookingR;
        //        aPayment.IDCustomer = this.aNewPaymentEN.IDCustomer;
        //        aPayment.NameCustomer = this.aNewPaymentEN.NameCustomer;
        //        aPayment.IDSystemUser = this.aNewPaymentEN.IDSystemUser;
        //        aPayment.NameSystemUser = this.aNewPaymentEN.NameSystemUser;
        //        aPayment.IDCustomerGroup = this.aNewPaymentEN.IDCustomerGroup;
        //        aPayment.NameCustomerGroup = this.aNewPaymentEN.NameCustomerGroup;
        //        aPayment.IDCompany = this.aNewPaymentEN.IDCompany;
        //        aPayment.NameCompany = this.aNewPaymentEN.NameCustomer;
        //        aPayment.CreatedDate_BookingR = this.aNewPaymentEN.CreatedDate_BookingR;
        //        aPayment.CustomerType = this.aNewPaymentEN.CustomerType;
        //        aPayment.BookingType = this.aNewPaymentEN.BookingType;
        //        aPayment.PayMenthod = this.aNewPaymentEN.PayMenthod;
        //        aPayment.StatusPay = 3;
        //        aPayment.BookingMoney = this.aNewPaymentEN.GetBookingMoney();
        //        aPayment.ExchangeRate = this.aNewPaymentEN.ExchangeRate;
        //        aPayment.Status_BookingR = 8;
        //        aPayment.Level = this.aNewPaymentEN.Level;
        //        aPayment.Status = 8; // de tam
        //        aPayment.Type = 1; // de tam


        //        if (this.aListRooms.Count > 0 && this.aListServicesR.Count < 1)
        //        {
        //            foreach (RoomsEN aRoomsEN in this.aListRooms)
        //            {

        //                aPayment.IDBookingRoom = aRoomsEN.IDBookingRooms;
        //                aPayment.CodeRoom = aRoomsEN.Code;
        //                Rooms aRooms = aRoomsBO.Select_ByCodeRoom(aRoomsEN.Code, 1);
        //                if (aRooms != null)
        //                {
        //                    aPayment.Sku = aRooms.Sku;
        //                }
        //                aPayment.Cost_BookingRoom = aRoomsEN.Cost;
        //                aPayment.PercentTax_BookingRoom = aRoomsEN.PercentTax;
        //                aPayment.CostRef_Rooms = aRoomsEN.CostRef;
        //                aPayment.CheckInActual = aRoomsEN.CheckInActual;
        //                aPayment.CheckOutActual = aRoomsEN.CheckOutActual;
        //                aPayment.Status_BookingRoom = 8;
        //                aPayment.TimeInUse = Convert.ToDecimal(aRoomsEN.TimeInUse * 24 * 60);
        //                aPayment.IndexSubRooms = aRoomsEN.IndexSubPayment;

        //                aPaymentBO.Insert(aPayment);
        //            }
        //        }


        //        if (this.aListServicesR.Count > 0 && this.aListRooms.Count < 1)
        //        {
        //            foreach (ServicesEN aServicesEN in this.aListServicesR)
        //            {
        //                aPayment.IDService = aServicesEN.IDService;
        //                aPayment.NameService = aServicesEN.Name;
        //                aPayment.Cost_Services = aServicesEN.Cost;
        //                aPayment.DateUseServices = aServicesEN.Date;
        //                aPayment.PercentTax_Services = aServicesEN.PercentTax;
        //                aPayment.CostRef_Services = aServicesEN.CostRef_Service;
        //                aPayment.Quantity_Services = aServicesEN.Quantity;
        //                aPayment.Status_Services = 8;
        //                aPayment.IndexSubRooms = aServicesEN.IndexSubPayment;

        //                aPaymentBO.Insert(aPayment);
        //            }
        //        }




        //        if (this.aListRooms.Count > 0 && this.aListServicesR.Count > 0)
        //        {
        //            foreach (InfoDetailNewPaymentEN item1 in this.aNewPaymentEN.aListInfoDetailNewPaymentEN)
        //            {
        //                List<RoomsEN> aListTemp1 = this.aListRooms.Where(r => r.IDBookingRooms == item1.aBookingRooms.ID).ToList();
        //                if (aListTemp1.Count > 0)
        //                {
        //                    aPayment.IDBookingRoom = item1.aBookingRooms.ID;
        //                    aPayment.CodeRoom = item1.aBookingRooms.CodeRoom;
        //                    Rooms aRooms = aRoomsBO.Select_ByCodeRoom(item1.aBookingRooms.CodeRoom, 1);
        //                    if (aRooms != null)
        //                    {
        //                        aPayment.Sku = aRooms.Sku;
        //                    }
        //                    aPayment.Cost_BookingRoom = item1.aBookingRooms.Cost;
        //                    aPayment.PercentTax_BookingRoom = item1.aBookingRooms.PercentTax;
        //                    aPayment.CostRef_Rooms = item1.aBookingRooms.CostRef_Rooms;
        //                    aPayment.CheckInActual = item1.aBookingRooms.CheckInActual;
        //                    aPayment.CheckOutActual = item1.aBookingRooms.CheckOutActual;
        //                    aPayment.Status_BookingRoom = 8;
        //                    aPayment.TimeInUse = Convert.ToDecimal(item1.DateInUse * 24 * 60);
        //                    aPayment.IndexSubRooms = item1.IndexSubRooms;
        //                }
        //                foreach (ServicesEN item2 in item1.aListService)
        //                {
        //                    List<ServicesEN> aListTemp2 = this.aListServicesR.Where(s => s.IDBookingRoomService == item2.IDBookingRoomService).ToList();

        //                    if (aListTemp2.Count > 0)
        //                    {
        //                        aPayment.IDService = item2.IDService;
        //                        aPayment.NameService = item2.Name;
        //                        aPayment.Cost_Services = item2.Cost;
        //                        aPayment.DateUseServices = item2.Date;
        //                        aPayment.PercentTax_Services = item2.PercentTax;
        //                        aPayment.CostRef_Services = item2.CostRef_Service;
        //                        aPayment.Quantity_Services = item2.Quantity;
        //                        aPayment.Status_Services = 8;
        //                        aPayment.IndexSubRooms = item2.IndexSubPayment;

        //                        aPaymentBO.Insert(aPayment);
        //                    }

        //                }

        //            }
        //        }

        //        /*-------*/
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("frmTsk_SplitBill_Step2.InsertDataToPayment\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}