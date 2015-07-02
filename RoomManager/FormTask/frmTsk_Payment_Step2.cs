using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using Entity;
using DevExpress.XtraReports.UI;
using DevExpress.Utils;
using System.Globalization;
using CORESYSTEM;
using System.Drawing;
using System.IO;

namespace RoomManager
{
    public partial class frmTsk_Payment_Step2 : DevExpress.XtraEditors.XtraForm
    {
        public bool IsLockForm = false;

        public frmTsk_Payment_Step1 afrmTsk_Payment_Step1 = null;
        public frmTsk_PaymentViewAll_New afrmTsk_PaymentViewAll_New = null; // Chuyen tu form chi tiet thanh toan sang
        public frmMain afrmMain = null;

        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        
        private int IDBookingH = 0;
        private int IDBookingR = 0;
        private int CurrentIDBookingRoom = 0;
        private int CurrentIDBookingHall = 0;

        private int StatusPay = 0;

        
        
        private DateTime CheckOut = DateTime.Now;
     
        private string CodeRoom = string.Empty;
        AccountancyBO aAccountancyBO = new AccountancyBO();
        //Ngoc - Done

        public frmTsk_Payment_Step2(frmTsk_PaymentViewAll_New frm, int IDBookingR, int IDBookingH, int StatusInitForm, bool IsForcusTab1)
        {
            InitializeComponent();
            this.IDBookingR = IDBookingR;
            this.IDBookingH = IDBookingH;
            this.StatusPay = StatusInitForm;
            if (IsForcusTab1 == false)
            {
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
            this.afrmTsk_PaymentViewAll_New = frm;
        }
        public frmTsk_Payment_Step2(frmMain frm, int IDBookingR, int IDBookingH, int StatusInitForm, bool IsForcusTab1)
        {
            InitializeComponent();
            this.IDBookingR = IDBookingR;
            this.IDBookingH = IDBookingH;
            this.StatusPay = StatusInitForm;
            if (IsForcusTab1 == false)
            {
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
            this.afrmMain = frm;
        }
        public frmTsk_Payment_Step2(frmTsk_Payment_Step1 frm, int IDBookingR, int IDBookingH, int StatusInitForm, bool IsForcusTab1)
        {
            InitializeComponent();
            this.IDBookingR = IDBookingR;
            this.IDBookingH = IDBookingH;
            this.StatusPay = StatusInitForm;
            if (IsForcusTab1 == false)
            {
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
            this.afrmTsk_Payment_Step1 = frm;
        }
        public frmTsk_Payment_Step2(int IDBookingR, int IDBookingH, int StatusInitForm, bool IsForcusTab1)
        {
            InitializeComponent();
            this.IDBookingR = IDBookingR;
            this.IDBookingH = IDBookingH;
            this.StatusPay = StatusInitForm;
            if (IsForcusTab1 == false)
            {
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
        
        }

        // ===============================================================================
        // Khoi tao doi tuong Payment
        private void InitData(int IDBookingR, int IDBookingH)
        {
            CompaniesBO aCompaniesBO = new CompaniesBO();
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            SystemUsersBO aSystemUsersBO = new SystemUsersBO();
            BookingHsBO aBookingHsBO = new BookingHsBO();
            BookingRsBO aBookingRsBO = new BookingRsBO();
            BookingRoomsBO aBookingRoomBO = new BookingRoomsBO();
            CustomersBO aCustomersBO = new CustomersBO();
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            RoomsBO aRoomsBO = new RoomsBO();
            HallsBO aHallsBO = new HallsBO();
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            FoodsBO aFoodsBO = new FoodsBO();
            ExtraCostBO aExtraCostBO = new ExtraCostBO();
            List<int> aListIndexTemp = new List<int>();
            BookingHs aBookingHs = new BookingHs();
            BookingRs aBookingRs = aBookingRsBO.Select_ByID(IDBookingR);
            if (this.IDBookingH > 0)
            {
                aBookingHs = aBookingHsBO.Select_ByID(this.IDBookingH);
            }
            else
            {
                BookingRs_BookingHs aItem = (new BookingRs_BookingHsBO()).Select_ByIDBookingR(this.IDBookingR);
                if (aItem != null)
                {
                    this.IDBookingH = aItem.IDBookingH.GetValueOrDefault(0);
                    aBookingHs = aBookingHsBO.Select_ByID(this.IDBookingH);
                }
                
            }

            // Truyen du lieu chung cua NewPayment
            if (aBookingRs != null)
            {
                aNewPaymentEN.IDBookingR = aBookingRs.ID;
                aNewPaymentEN.IDCustomer = aBookingRs.IDCustomer;
                Customers aCustomers = aCustomersBO.Select_ByID(aBookingRs.IDCustomer);
                if (aCustomers != null)
                {
                    aNewPaymentEN.NameCustomer = aCustomers.Name;
                }
                aNewPaymentEN.IDSystemUser = aBookingRs.IDSystemUser;
                SystemUsers aSystemUsers = aSystemUsersBO.Select_ByID(aBookingRs.IDSystemUser);
                if (aSystemUsers != null)
                {
                    aNewPaymentEN.NameSystemUser = aSystemUsers.Name;
                }
                aNewPaymentEN.IDCustomerGroup = aBookingRs.IDCustomerGroup;
                CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
                if (aCustomerGroups != null)
                {
                    aNewPaymentEN.NameCustomerGroup = aCustomerGroups.Name;
                    aNewPaymentEN.IDCompany = aCustomerGroups.IDCompany;
                    Companies aCompanies = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany);
                    if (aCompanies != null)
                    {
                        aNewPaymentEN.NameCompany = aCompanies.Name;
                        aNewPaymentEN.TaxNumberCodeCompany = aCompanies.TaxNumberCode;
                        aNewPaymentEN.AddressCompany = aCompanies.Address;
                    }
                }
                aNewPaymentEN.PayMenthodR = aBookingRs.PayMenthod;
                aNewPaymentEN.CreatedDate_BookingR = aBookingRs.CreatedDate;
                aNewPaymentEN.CustomerType = aBookingRs.CustomerType;
                aNewPaymentEN.Status_BookingR = aBookingRs.Status;
                aNewPaymentEN.StatusPay = aBookingRs.StatusPay;
                aNewPaymentEN.BookingRMoney = aBookingRs.BookingMoney;
                aNewPaymentEN.Status_BookingR = aBookingRs.Status;
                aNewPaymentEN.AcceptDate = aBookingRs.AcceptDate;
                aNewPaymentEN.InvoiceDate = aBookingRs.InvoiceDate;
                aNewPaymentEN.InvoiceNumber = aBookingRs.InvoiceNumber;

                // Truyen du lieu cho List BookingRoom cua NewPayment
                List<BookingRooms> aListBookingRooms = aBookingRoomBO.Select_ByIDBookingRs(this.IDBookingR);
                if (aListBookingRooms.Count > 0)
                {
                    BookingRoomUsedEN aBookingRoomUsedEN;

                    foreach (BookingRooms item in aListBookingRooms)
                    {
                        aBookingRoomUsedEN = new BookingRoomUsedEN();
                        aBookingRoomUsedEN.SetValue(item);
                        aBookingRoomUsedEN.ListCustomer = aCustomersBO.SelectListCustomer_ByIDBookingRoom(item.ID);
                        Rooms aRooms = aRoomsBO.Select_ByCodeRoom(item.CodeRoom, 1);
                        if (aRooms != null)
                        {
                            aBookingRoomUsedEN.RoomSku = aRooms.Sku;
                        }
                        else
                        {
                            aBookingRoomUsedEN.RoomSku = string.Empty;
                        }
                        if (item.Status == 8 || item.Status == 7)
                        {
                            aBookingRoomUsedEN.AddTimeStart = Convert.ToDouble(aReceptionTaskBO.GetAddTimeStart(Convert.ToInt32(item.Type), item.CheckInActual));
                            aBookingRoomUsedEN.AddTimeEnd = Convert.ToDouble(aReceptionTaskBO.GetAddTimeEnd(Convert.ToInt32(item.Type), item.CheckOutActual));
                            aBookingRoomUsedEN.TimeInUse = Convert.ToDecimal(aReceptionTaskBO.GetTimeInUsed(item.CheckInActual, item.CheckOutActual) * 24 * 60);
                        }
                        else
                        {
                            aBookingRoomUsedEN.AddTimeStart = Convert.ToDouble(aReceptionTaskBO.GetAddTimeStart(Convert.ToInt32(item.Type), item.CheckInActual));
                            aBookingRoomUsedEN.AddTimeEnd = Convert.ToDouble(aReceptionTaskBO.GetAddTimeEnd(Convert.ToInt32(item.Type), item.CheckOutPlan));
                            aBookingRoomUsedEN.TimeInUse = Convert.ToDecimal(aReceptionTaskBO.GetTimeInUsed(item.CheckInActual, item.CheckOutPlan) * 24 * 60);

                        }
                        decimal? cost = 0;
                        if (item.Cost == null)
                        {
                            cost = item.CostRef_Rooms;
                            aBookingRoomUsedEN.Cost = cost + Convert.ToDecimal(aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(aRooms.Sku, aBookingRoomUsedEN.PriceType, aBookingRoomUsedEN.ListCustomer.Count).ExtraValue);
                        }
                        else
                        {
                            cost = item.Cost;
                            aBookingRoomUsedEN.Cost = cost;
                        }
                        List<ServiceUsedEN> aListServiceRTemp = aReceptionTaskBO.GetListServiceUsedInRoom_ByIDBookingRoom(item.ID);
                        foreach (ServiceUsedEN aTemp in aListServiceRTemp)
                        {
                            aBookingRoomUsedEN.ListServiceUsed.Add(aTemp);
                            aListIndexTemp.Add(Convert.ToInt32(aTemp.IndexSubPayment));
                        }
                        aListIndexTemp.Add(Convert.ToInt32(aBookingRoomUsedEN.IndexSubPayment));
                        aNewPaymentEN.aListBookingRoomUsed.Add(aBookingRoomUsedEN);
                    }
                }

                //====================================================================================================
                //====================================================================================================
                //====================================================================================================
                // Thành sửa ngày 04/06/2015
                // 
                //---------------
                // Lỗi sai điều kiện câu lệnh if khiến aBookingHs truyền dữ liệu CustomerType sai cho NewPaymentEN
                //---------------
                // Ban đầu : if (aBookingHs != null)
                //-------------------------------------
                if (aBookingHs.ID > 0)
                {
                    aNewPaymentEN.IDBookingH = aBookingHs.ID;
                    aNewPaymentEN.PayMenthodH = aBookingHs.PayMenthod;
                    aNewPaymentEN.CreatedDate_BookingH = aBookingHs.CreatedDate;
                    aNewPaymentEN.CustomerType = aBookingHs.CustomerType;
                    aNewPaymentEN.Status_BookingH = aBookingHs.Status;
                    aNewPaymentEN.BookingHMoney = aBookingHs.BookingMoney;
                    // Truyen du lieu cho List BookingHall cua NewPayment
                    List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookigH(this.IDBookingH);
                    if (aListBookingHalls != null)
                    {
                        BookingHallUsedEN aBookingHallUsedEN;
                        foreach (BookingHalls item in aListBookingHalls)
                        {
                            aBookingHallUsedEN = new BookingHallUsedEN();
                            aBookingHallUsedEN.SetValue(item);
                            Halls aHalls = aHallsBO.Select_ByCodeHall(item.CodeHall, 1);
                            if (aHalls != null)
                            {
                                aBookingHallUsedEN.HallSku = aHalls.Sku;
                            }
                            else
                            {
                                aBookingHallUsedEN.HallSku = string.Empty;
                            }
                            aBookingHallUsedEN.CustomerType = aBookingHs.CustomerType;
                            aBookingHallUsedEN.BookingTypeBookingH = aBookingHs.BookingType;
                            aBookingHallUsedEN.StatusPayBookingH = aBookingHs.StatusPay;
                            aBookingHallUsedEN.LevelBookingH = aBookingHs.Level;
                            aBookingHallUsedEN.aListMenuEN = aReceptionTaskBO.GetListMenus_ByIDBookingHall(item.ID);

                            aListIndexTemp.Add(Convert.ToInt32(aBookingHallUsedEN.IndexSubPayment));
                            List<ServiceUsedEN> aListServiceTemp = aReceptionTaskBO.GetListServiceUsedInHall_ByIDBookingHall(item.ID);
                            foreach (ServiceUsedEN aTemp in aListServiceTemp)
                            {
                                aBookingHallUsedEN.aListServiceUsed.Add(aTemp);
                                aListIndexTemp.Add(Convert.ToInt32(aTemp.IndexSubPayment));
                            }
                            aNewPaymentEN.aListBookingHallUsed.Add(aBookingHallUsedEN);
                        }
                    }
                }
                aNewPaymentEN.ListIndex = aListIndexTemp.Distinct().ToList();
            }
        }
        //====================================================================================================
        //====================================================================================================
        //====================================================================================================
        private int ConvertTypeBookingRoom(bool CheckIn, bool CheckOut)
        {
            if (CheckIn == true && CheckOut == true)
            {
                return 3;

            }
            else if (CheckIn == false && CheckOut == false)
            {
                return 0;

            }
            else if (CheckIn == false && CheckOut == true)
            {
                return 1;

            }
            else
            {
                return 2;
            }
        }
        public byte[] ConvertImageToByteArray(Image imageIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void ShowControlAutoCost(int BookingRooms_Type)
        {
            txtAddTimeStart.Properties.ReadOnly = true;
            txtAddTimeEnd.Properties.ReadOnly = true;
            txtNumberDate.Properties.ReadOnly = true;


            if (BookingRooms_Type == 3)//Tính checkin sớm và Checkout muộn
            {
                chkCheckIn.Enabled = true;
                chkCheckOut.Enabled = true;

                chkCheckIn.Checked = true;
                txtAddTimeStart.Enabled = true;

                chkCheckOut.Checked = true;
                txtAddTimeEnd.Enabled = true;
            }
            else if (BookingRooms_Type == 0)//Không tính checkIn sớm và checkout muộn.
            {
                chkCheckIn.Enabled = true;
                chkCheckOut.Enabled = true;

                chkCheckIn.Checked = false;
                txtAddTimeStart.Enabled = false;

                chkCheckOut.Checked = false;
                txtAddTimeEnd.Enabled = false;

            }
            else if (BookingRooms_Type == 2)//Tính checkin sớm ,không tính checkout muộn.
            {
                chkCheckIn.Enabled = true;
                chkCheckOut.Enabled = true;

                chkCheckIn.Checked = true;
                txtAddTimeStart.Enabled = true;

                chkCheckOut.Checked = false;
                txtAddTimeEnd.Enabled = false;

            }
            else if (BookingRooms_Type == 1)//Không tính checkin sớm ,tính checkout muộn
            {
                chkCheckIn.Enabled = true;
                chkCheckOut.Enabled = true;

                chkCheckIn.Checked = false;
                txtAddTimeStart.Enabled = false;

                chkCheckOut.Checked = true;
                txtAddTimeEnd.Enabled = true;
            }
        }

        //Load lai du lieu cho cac control moi khi select vao 1 phong moi
        // Ngoc - done

        private void LoadDataCurrentRoomForControl()
        {
            if (this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList().Count > 0)
            {
                BookingRoomUsedEN aBookingRoomUsedEN = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0];
                /*Ghi chu TypeBookingRooms
                 * Type = 2: //Tính checkin sớm , không tính checkout muộn.
                 * Type = 0: //Không tính checkIn sớm và checkout muộn.
                 * Type = 3: //Tính checkin sớm và Checkout muộn
                 * Type = 1: //Không tính checkin sớm , tính checkout muộn
                 */
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                
                if (aBookingRoomUsedEN.Status == 1 || aBookingRoomUsedEN.Status == 2)
                {
                    dtpCheckInActual.DateTime = aBookingRoomUsedEN.CheckInPlan;
                    dtpCheckOutActual.DateTime = aBookingRoomUsedEN.CheckOutPlan;

                    txtNumberDate.Text = ""; // Phong chua su dung
                    txtAddTimeEnd.Text = "";
                    txtAddTimeStart.Text = "";

                    lblCI.Text = "CI dự kiến";
                    lblCO.Text = "CO dự kiến";
                    lblCaptionStatusRoom.Text = ("Phòng " + aBookingRoomUsedEN.RoomSku + " đang ở trạng thái đặt").ToUpper();

                }
                else if (aBookingRoomUsedEN.Status == 3)
                {
                    dtpCheckInActual.DateTime = aBookingRoomUsedEN.CheckInActual;
                    dtpCheckOutActual.DateTime = aBookingRoomUsedEN.CheckOutPlan;

                    txtNumberDate.Text = aReceptionTaskBO.GetTimeInUsed(aBookingRoomUsedEN.CheckInActual, aBookingRoomUsedEN.CheckOutPlan).ToString();


                    txtAddTimeEnd.Text = aReceptionTaskBO.GetAddTimeEnd(aBookingRoomUsedEN.Type.GetValueOrDefault(0), aBookingRoomUsedEN.CheckOutPlan).ToString();
                    txtAddTimeStart.Text = aReceptionTaskBO.GetAddTimeStart(aBookingRoomUsedEN.Type.GetValueOrDefault(0), aBookingRoomUsedEN.CheckInActual).ToString();
                    lblCI.Text = "CI thực tế";
                    lblCO.Text = "CO dự kiến";
                    lblCaptionStatusRoom.Text = ("Phòng " + aBookingRoomUsedEN.RoomSku + " đang có người ở").ToUpper();
                }
                else if (aBookingRoomUsedEN.Status == 5)
                {
                    dtpCheckInActual.DateTime = aBookingRoomUsedEN.CheckInActual;
                    dtpCheckOutActual.DateTime = aBookingRoomUsedEN.CheckOutPlan;

                    txtNumberDate.Text = aReceptionTaskBO.GetTimeInUsed(aBookingRoomUsedEN.CheckInActual, aBookingRoomUsedEN.CheckOutPlan).ToString();
                    txtAddTimeEnd.Text = aReceptionTaskBO.GetAddTimeEnd(aBookingRoomUsedEN.Type.GetValueOrDefault(0), aBookingRoomUsedEN.CheckOutPlan).ToString();
                    txtAddTimeStart.Text = aReceptionTaskBO.GetAddTimeStart(aBookingRoomUsedEN.Type.GetValueOrDefault(0), aBookingRoomUsedEN.CheckInActual).ToString();
                    
                    lblCI.Text = "CI thực tế";
                    lblCO.Text = "CO dự kiến";
                    lblCaptionStatusRoom.Text = ("Phòng " + aBookingRoomUsedEN.RoomSku + " đang khóa").ToUpper();
                }
                else if (aBookingRoomUsedEN.Status == 7)
                {
                    dtpCheckInActual.DateTime = aBookingRoomUsedEN.CheckInActual;
                    dtpCheckOutActual.DateTime = aBookingRoomUsedEN.CheckOutActual;

                    txtNumberDate.Text = aReceptionTaskBO.GetTimeInUsed(aBookingRoomUsedEN.CheckInActual, aBookingRoomUsedEN.CheckOutActual).ToString();
                    txtAddTimeEnd.Text = aReceptionTaskBO.GetAddTimeEnd(aBookingRoomUsedEN.Type.GetValueOrDefault(0), aBookingRoomUsedEN.CheckOutActual).ToString();
                    txtAddTimeStart.Text = aReceptionTaskBO.GetAddTimeStart(aBookingRoomUsedEN.Type.GetValueOrDefault(0), aBookingRoomUsedEN.CheckInActual).ToString();
                    
                    lblCI.Text = "CI thực tế";
                    lblCO.Text = "CO thực tế";
                    lblCaptionStatusRoom.Text = ("Phòng " + aBookingRoomUsedEN.RoomSku + " đã checkout nhưng chưa thanh toán").ToUpper();
                }
                else if (aBookingRoomUsedEN.Status == 8)
                {
                    dtpCheckInActual.DateTime = aBookingRoomUsedEN.CheckInActual;
                    dtpCheckOutActual.DateTime = aBookingRoomUsedEN.CheckOutActual;

                    // Neu phong da dc thanh toan tuc la thong tin phong da chot. Vay lay thong tin nay de hien thi
                    txtNumberDate.Text = (aBookingRoomUsedEN.TimeInUse.GetValueOrDefault(0)/(24*60)).ToString();
                    txtAddTimeEnd.Text = aBookingRoomUsedEN.AddTimeEnd.ToString();
                    txtAddTimeStart.Text = aBookingRoomUsedEN.AddTimeStart.ToString();
                    
                    lblCI.Text = "CI thực tế";
                    lblCO.Text = "CO thực tế";
                    lblCaptionStatusRoom.Text = ("Phòng " + aBookingRoomUsedEN.RoomSku + " đã thanh toán").ToUpper();
                }
                lblSkuRooms.Text = aBookingRoomUsedEN.RoomSku;

                txtPercentTax_Room.Text = Convert.ToString(aBookingRoomUsedEN.PercentTax);
                lblMoneyRoom.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetOnlyMoneyRoom(aBookingRoomUsedEN.ID));

                if (string.IsNullOrEmpty(aBookingRoomUsedEN.Cost.ToString()) == false)
                {
                    txtBookingRoomsCost.EditValue = aBookingRoomUsedEN.Cost;
                }
                else
                {
                    txtBookingRoomsCost.EditValue = aAccountancyBO.CalculateCostRoom(this.CurrentIDBookingRoom, aBookingRoomUsedEN.PriceType, this.aNewPaymentEN.CustomerType.GetValueOrDefault(0), this.aNewPaymentEN.GetNumberCustomerInRoom(this.CurrentIDBookingRoom));
                }
                // Danh sách khách
                dgvCustomers.DataSource = aBookingRoomUsedEN.ListCustomer;
                dgvCustomers.RefreshDataSource();
                // Danh sách dịch vụ
                dgvServicesR.DataSource = aNewPaymentEN.GetListServiceUsedInRoom(aBookingRoomUsedEN.ID);
                dgvServicesR.RefreshDataSource();
                lblTotalMoneyServiceR.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetMoneyListServiceUsedInARoom(aBookingRoomUsedEN.ID));
            }
                //=========================================
                //=========================================
                //=========================================
                // Load lai  control khac
                //-------------- Phòng ---------------------
                //Thong tin nguoi dat
                lblNameCompany_BookingR.Text = this.aNewPaymentEN.NameCompany;
                lblNameCustomerGroup_BookingR.Text = this.aNewPaymentEN.NameCustomerGroup;
                lblNameCustomer_BookingR.Text = this.aNewPaymentEN.NameCustomer;
                txtAddressR.Text = this.aNewPaymentEN.AddressCompany;
                txtTaxNumberCodeR.Text = this.aNewPaymentEN.TaxNumberCodeCompany;

                // Thông tin hóa đơn
                txtInvoiceNumberR.Text = this.aNewPaymentEN.InvoiceNumber;
                dtpAcceptDateR.DateTime = this.aNewPaymentEN.AcceptDate.GetValueOrDefault(Convert.ToDateTime("01/01/1900"));
                dtpInvoiceDateR.DateTime = this.aNewPaymentEN.InvoiceDate.GetValueOrDefault(Convert.ToDateTime("01/01/1900"));
                // Trang thai, hinh thuc thanh toan
                lueBookingR_Paymethod.Properties.DataSource = CORE.CONSTANTS.ListPayMethods;
                lueBookingR_Paymethod.Properties.DisplayMember = "Name";
                lueBookingR_Paymethod.Properties.ValueMember = "ID";
                lueBookingR_Paymethod.EditValue = CORE.CONSTANTS.SelectedPayMethod(Convert.ToInt32(this.aNewPaymentEN.PayMenthodR)).ID;
                //--------------------------------------------------------------
                // Thong tin gia tiền, đặt trước
                lblTotalMoneyRooms.Text = String.Format("{0:0,0}", this.aNewPaymentEN.GetMoneyRooms());
                txtBookingRMoney.EditValue = this.aNewPaymentEN.BookingRMoney;
                lblTotalMoneyR.Text = String.Format("{0:0,0}", this.aNewPaymentEN.GetMoneyRooms() - this.aNewPaymentEN.BookingRMoney);
                // Bang danh sach phong
                dgvRooms.DataSource = this.aNewPaymentEN.aListBookingRoomUsed;
                dgvRooms.RefreshDataSource();
            

        }
        private void LoadDataCurrentHallForControl()
        {

            //--------- Hội trường ----------------
            if (this.IDBookingH > 0)
            {
                
                //Thong tin nguoi dat
                lblNameCompany_BookingH.Text = this.aNewPaymentEN.NameCompany;
                lblNameCustomerGroup_BookingH.Text = this.aNewPaymentEN.NameCustomerGroup;
                lblNameCustomer_BookingH.Text = this.aNewPaymentEN.NameCustomer;
                txtAddressH.Text = this.aNewPaymentEN.AddressCompany;
                txtTaxNumberCodeH.Text = this.aNewPaymentEN.TaxNumberCodeCompany;
                // Trang thai, hinh thuc thanh toan
                lblTotalMoneyHalls.Text = String.Format("{0:0,0}", this.aNewPaymentEN.GetMoneyHalls());
                txtBookingHMoney.EditValue = this.aNewPaymentEN.BookingHMoney;
                lblTotalMoneyH.Text = String.Format("{0:0,0}", this.aNewPaymentEN.GetMoneyHalls() - this.aNewPaymentEN.BookingHMoney);
                // Thong tin gia tiền, đặt trước
                lueBookingH_PayMethod.Properties.DataSource = CORE.CONSTANTS.ListPayMethods;
                lueBookingH_PayMethod.Properties.DisplayMember = "Name";
                lueBookingH_PayMethod.Properties.ValueMember = "ID";
                lueBookingH_PayMethod.EditValue = CORE.CONSTANTS.SelectedPayMethod(Convert.ToInt32(this.aNewPaymentEN.PayMenthodH)).ID;
                // Danh sách các hội trường
                dgvHalls.DataSource = this.aNewPaymentEN.aListBookingHallUsed;
                dgvHalls.RefreshDataSource();
                // Thông tin 1 hội trường


                if (this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList().Count > 0)
                {
                    BookingHallUsedEN aBookingHallUsedEN = this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0];
                    lblSkuHalls.Text = Convert.ToString(aBookingHallUsedEN.HallSku);
                    decimal? cost = 0;
                    if (aBookingHallUsedEN.Cost == null || aBookingHallUsedEN.Cost == 0)
                    {
                        cost = aBookingHallUsedEN.CostRef_Halls;
                    }
                    else
                    {
                        cost = aBookingHallUsedEN.Cost;
                    }

                    lblDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallUsedEN.Date);
                    lblLunarDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallUsedEN.LunarDate);
                    lblStartTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallUsedEN.StartTime);
                    lblEndTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallUsedEN.EndTime);

                    lueMenus.Properties.DataSource = aBookingHallUsedEN.aListMenuEN;
                    lueMenus.Properties.DisplayMember = "Name";
                    lueMenus.Properties.ValueMember = "ID";

                    if (aBookingHallUsedEN.aListMenuEN.Count > 0)
                    {
                        lueMenus.EditValue = aBookingHallUsedEN.aListMenuEN[0].ID;
                        MenusEN aMenusEN = aBookingHallUsedEN.aListMenuEN[0];

                        List<Foods> aListFoods = new List<Foods>();
                        FoodsBO aFoodsBO = new FoodsBO();
                        foreach (Foods item in aMenusEN.aListFoods)
                        {
                            Foods aFoods = aFoodsBO.Select_ByID(item.ID);
                            if (aFoods.Image1 != null)
                            {
                                if (aFoods.Image1.Length <= 0)
                                {
                                    Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                                    image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                                    Byte[] aImageByte = this.ConvertImageToByteArray(image);
                                    aFoods.Image1 = aImageByte;
                                }
                            }
                            else
                            {
                                Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                                image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                                Byte[] aImageByte = this.ConvertImageToByteArray(image);
                                aFoods.Image1 = aImageByte;
                            }
                            aListFoods.Add(aFoods);

                        }

                        dgvFoods.DataSource = aListFoods;
                        dgvFoods.RefreshDataSource();
                    }
                    else
                    {
                        List<Foods> aListFoods = new List<Foods>();
                        dgvFoods.DataSource = aListFoods;
                        dgvFoods.RefreshDataSource();
                    }
                    txtPercentTax_Hall.EditValue = aBookingHallUsedEN.PercentTax;

                    lblMoneyHall.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetMoneyAHall(aBookingHallUsedEN.ID));

                    decimal? BookingHallsCost = aBookingHallUsedEN.Cost == null ? aBookingHallUsedEN.CostRef_Halls : aBookingHallUsedEN.Cost;

                    txtBookingHallsCost.EditValue = BookingHallsCost;
                    dgvServicesH.DataSource = this.aNewPaymentEN.GetListServiceUsedInHall(aBookingHallUsedEN.ID);
                    dgvServicesH.RefreshDataSource();
                    lblTotalMoneyServiceH.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetMoneyListServiceUsedInAHall(aBookingHallUsedEN.ID));
                }
            }
            else
            {
                btnBookHall.Visible = true;
                btnPaymentHall.Enabled = false;
                btnPrintBookingH.Enabled = false;
                txtTaxNumberCodeH.Enabled = false;
                txtAddressH.Enabled = false;
            }
            // Thông tin tổng tiền
            lblTotalBookingRAndBookingHBeforeTax.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetTotalMoneyBeforeTax());
            lblTotalBookingRAndBookingHAfterTax.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetTotalMoney());
            if (this.aNewPaymentEN.BookingHMoney != null)
            {
                lblBookingMoney_BookingRAndBookingH.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.BookingHMoney + this.aNewPaymentEN.BookingRMoney);
                lblTotalBookingRAndBookingH.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetTotalMoney() - (this.aNewPaymentEN.BookingHMoney + this.aNewPaymentEN.BookingRMoney));
            }
            else
            {
                lblBookingMoney_BookingRAndBookingH.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.BookingRMoney);
                lblTotalBookingRAndBookingH.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetTotalMoney() - this.aNewPaymentEN.BookingRMoney);
            }
        }
        // Ngoc - Done
        private void CheckPaymentStatus()
        {
            if (StatusPay < 7) // Load khi chưa thanh toán hoặc check out
            {
                this.UnLockForm();
            }
            else if (StatusPay == 7) // Load hóa đơn đã thanh toán
            {
                this.LockForm_Status7();
            }
            else if (StatusPay >= 8) // Load hóa đơn đã thanh toán
            {
                this.LockForm_Status8();
            }
        }

        public void frmTsk_Payment_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                

                // Load du lieu vao khoi Payment
                this.InitData(this.IDBookingR, this.IDBookingH);
                // Set trang thai lock/unlock cac control tuy theo trang thai hoa don da dc thanh toan hay chua
                this.CheckPaymentStatus();

                this.LoadDataCurrentRoomForControl();
                this.LoadDataCurrentHallForControl();

            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.frmTsk_Payment_Step2_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        //Ngoc - Done
        private void LockForm_Status7()
        {
            this.IsLockForm = true;
            //----------------------------------------
            txtAddressH.Properties.ReadOnly = true;
            txtAddressR.Properties.ReadOnly = true;
            txtAddTimeEnd.Properties.ReadOnly = true;
            txtAddTimeStart.Properties.ReadOnly = true;
            txtBookingHallsCost.Properties.ReadOnly = true;
            txtBookingHMoney.Properties.ReadOnly = true;
            txtBookingRMoney.Properties.ReadOnly = true;
            txtBookingRoomsCost.Properties.ReadOnly = true;
            txtInvoiceNumberR.Properties.ReadOnly = true;
            txtInvoiceNumberH.Properties.ReadOnly = true;
            txtNumberDate.Properties.ReadOnly = true;
            txtPercentTax_Hall.Properties.ReadOnly = true;
            txtPercentTax_Room.Properties.ReadOnly = true;
            txtPercentTaxService.ReadOnly = true;
            txtQuantity.ReadOnly = true;
            txtServiceCost.ReadOnly = true;
            txtTaxNumberCodeH.Properties.ReadOnly = true;
            txtTaxNumberCodeR.Properties.ReadOnly = true;
            cbbPriceType.Properties.ReadOnly = true;

            dtpAcceptDateR.Properties.ReadOnly = true;
            dtpAcceptDateH.Properties.ReadOnly = true;
            dtpCheckInActual.Properties.ReadOnly = true;
            dtpCheckOutActual.Properties.ReadOnly = true;
            dtpInvoiceDateR.Properties.ReadOnly = true;
            dtpInvoiceDateH.Properties.ReadOnly = true;

            chkCheckIn.Properties.ReadOnly = true;
            chkCheckOut.Properties.ReadOnly = true;

            lueBookingH_PayMethod.Properties.ReadOnly = true;
            lueBookingR_Paymethod.Properties.ReadOnly = true;
            lueMenus.Properties.ReadOnly = true;
            //----------------------------
            btnAddService.Enabled = false;
            btnAddServicesForHalls.Enabled = false;
            btnCaculateTimeUsed.Enabled = false;

            btnPayment.Enabled = true;
            btnPaymentHall.Enabled = true;

            btnManageCustomer.Enabled = false;

            btnPaymentTotal.Enabled = false; // Lock Status 8
            btnBookHall.Enabled = false; // Lock Status 8

            btnSave.Enabled = false;
            btnEnableEdit.Enabled = true;

        }
        private void LockForm_Status8()
        {
            this.IsLockForm = true;
            //----------------------------------------
            txtAddressH.Properties.ReadOnly = true;
            txtAddressR.Properties.ReadOnly = true;
            txtAddTimeEnd.Properties.ReadOnly = true;
            txtAddTimeStart.Properties.ReadOnly = true;
            txtBookingHallsCost.Properties.ReadOnly = true;
            txtBookingHMoney.Properties.ReadOnly = true;
            txtBookingRMoney.Properties.ReadOnly = true;
            txtBookingRoomsCost.Properties.ReadOnly = true;
            txtInvoiceNumberR.Properties.ReadOnly = true;
            txtInvoiceNumberH.Properties.ReadOnly = true;
            txtNumberDate.Properties.ReadOnly = true;
            txtPercentTax_Hall.Properties.ReadOnly = true;
            txtPercentTax_Room.Properties.ReadOnly = true;
            txtPercentTaxService.ReadOnly = true;
            txtQuantity.ReadOnly = true;
            txtServiceCost.ReadOnly = true;
            txtTaxNumberCodeH.Properties.ReadOnly = true;
            txtTaxNumberCodeR.Properties.ReadOnly = true;
            cbbPriceType.Properties.ReadOnly = true;

            dtpAcceptDateR.Properties.ReadOnly = true;
            dtpAcceptDateH.Properties.ReadOnly = true;
            dtpCheckInActual.Properties.ReadOnly = true;
            dtpCheckOutActual.Properties.ReadOnly = true;
            dtpInvoiceDateR.Properties.ReadOnly = true;
            dtpInvoiceDateH.Properties.ReadOnly = true;

            chkCheckIn.Properties.ReadOnly = true;
            chkCheckOut.Properties.ReadOnly = true;

            lueBookingH_PayMethod.Properties.ReadOnly = true;
            lueBookingR_Paymethod.Properties.ReadOnly = true;
            lueMenus.Properties.ReadOnly = true;

            btnAddService.Enabled = false; 
            btnAddServicesForHalls.Enabled = false;
            btnCaculateTimeUsed.Enabled = false;
            btnPayment.Enabled = false;
            btnPaymentHall.Enabled = false;

            btnManageCustomer.Enabled = false;
    

            btnPaymentTotal.Enabled = false; // Lock Status 8
            btnBookHall.Enabled = false; // Lock Status 8

            btnSave.Enabled = false;

            btnEnableEdit.Enabled = true;
         
        }
    
        private void UnLockForm()
        {
            this.IsLockForm = false;
            //----------------------------------------
            txtAddressH.Properties.ReadOnly = false;
            txtAddressR.Properties.ReadOnly = false;
            txtAddTimeEnd.Properties.ReadOnly = false;
            txtAddTimeStart.Properties.ReadOnly = false;
            txtBookingHallsCost.Properties.ReadOnly = false;
            txtBookingHMoney.Properties.ReadOnly = false;
            txtBookingRMoney.Properties.ReadOnly = false;
            txtBookingRoomsCost.Properties.ReadOnly = false;
            txtInvoiceNumberR.Properties.ReadOnly = false;
            txtInvoiceNumberH.Properties.ReadOnly = false;
            txtNumberDate.Properties.ReadOnly = false;
            txtPercentTax_Hall.Properties.ReadOnly = false;
            txtPercentTax_Room.Properties.ReadOnly = false;
            txtPercentTaxService.ReadOnly = false;
            txtQuantity.ReadOnly = false;
            txtServiceCost.ReadOnly = false;
            txtTaxNumberCodeH.Properties.ReadOnly = false;
            txtTaxNumberCodeR.Properties.ReadOnly = false;
            cbbPriceType.Properties.ReadOnly = false;

            dtpAcceptDateR.Properties.ReadOnly = false;
            dtpAcceptDateH.Properties.ReadOnly = false;
            dtpCheckInActual.Properties.ReadOnly = false;
            dtpCheckOutActual.Properties.ReadOnly = false;
            dtpInvoiceDateR.Properties.ReadOnly = false;
            dtpInvoiceDateH.Properties.ReadOnly = false;

            chkCheckIn.Properties.ReadOnly = false;
            chkCheckOut.Properties.ReadOnly = false;

            lueBookingH_PayMethod.Properties.ReadOnly = false;
            lueBookingR_Paymethod.Properties.ReadOnly = false;
            lueMenus.Properties.ReadOnly = false;

            btnAddService.Enabled = true;
            btnAddServicesForHalls.Enabled = true;
            btnCaculateTimeUsed.Enabled = true;
            btnPayment.Enabled = true;
            btnPaymentHall.Enabled = true;

            btnManageCustomer.Enabled = true;

            btnManageCustomer.Enabled = true;
            btnSave.Enabled = true; 

            btnPaymentTotal.Enabled = true; // UnLock Status 8
            btnBookHall.Enabled = true; // UnLock Status 8
        }


        public void Reload()
        {
            this.aNewPaymentEN = new NewPaymentEN();
            this.InitData(this.IDBookingR, this.IDBookingH);
            this.LoadDataCurrentHallForControl();
            this.LoadDataCurrentRoomForControl();

        }
   

        //Ngoc - done
        private void btnDetailRooms_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                this.CurrentIDBookingRoom = Convert.ToInt32(viewRooms.GetFocusedRowCellValue("ID"));
                if (this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].Status == 7)
                {
                    this.LockForm_Status7();
                }
                else if (this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].Status == 8)
                {
                    this.LockForm_Status8();
                }
                else
                {
                    this.UnLockForm();
                }
   

                this.CodeRoom = Convert.ToString(viewRooms.GetFocusedRowCellValue("CodeRoom"));
                cbbPriceType.Text = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].PriceType;

                //this.LoadData();
                int BookingRoomType = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].Type.GetValueOrDefault(0);
                this.ShowControlAutoCost(BookingRoomType);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnDetailRooms_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        //Ngoc - done
        private void txtTaxNumberCodeR_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTaxNumberCodeR.Text != this.aNewPaymentEN.TaxNumberCodeCompany)
                {
                    this.aNewPaymentEN.TaxNumberCodeCompany = txtTaxNumberCodeR.Text;
                    this.LoadDataCurrentRoomForControl();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtTaxNumberCodeR_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtTaxNumberCodeH_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtTaxNumberCodeH.Text != this.aNewPaymentEN.TaxNumberCodeCompany)
                {
                    this.aNewPaymentEN.TaxNumberCodeCompany = txtTaxNumberCodeH.Text;
                    this.LoadDataCurrentRoomForControl();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtTaxNumberCodeH_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtAddressR_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtAddressR.Text != this.aNewPaymentEN.AddressCompany)
                {
                    this.aNewPaymentEN.AddressCompany = txtAddressR.Text;
                    this.LoadDataCurrentRoomForControl();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtTaxNumberCodeR_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtAddressH_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAddressH.Text != this.aNewPaymentEN.AddressCompany)
                {
                    this.aNewPaymentEN.AddressCompany = txtAddressH.Text;
                    this.LoadDataCurrentRoomForControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtTaxNumberCodeR_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // control nhom khac
        private void txtBookingMoney_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal? bookingMoney;
                if (string.IsNullOrEmpty(txtBookingRMoney.Text) == true)
                {
                    bookingMoney = 0;
                }
                else
                {
                    bookingMoney = Convert.ToDecimal(txtBookingRMoney.Text);
                }
                this.aNewPaymentEN.BookingRMoney = bookingMoney;
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtBookingMoney_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // control nhom khac
        private void txtBookingH_BookingMoney_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal? bookingMoney;
                if (string.IsNullOrEmpty(txtBookingHMoney.Text) == true)
                {
                    bookingMoney = 0;
                }
                else
                {
                    bookingMoney = Convert.ToDecimal(txtBookingHMoney.Text);
                }
                this.aNewPaymentEN.BookingHMoney = bookingMoney;
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtBookingH_BookingMoney_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ngoc - done
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingRoomService = Convert.ToInt32(viewServicesR.GetFocusedRowCellValue("IDBookingService"));

                DevExpress.XtraEditors.TextEdit txtQuality = (DevExpress.XtraEditors.TextEdit)sender;

                string input = txtQuality.Text;

                double Quantity;
                if (string.IsNullOrEmpty(input) == true)
                {
                    Quantity = 0;
                }
                else
                {
                    Quantity = double.Parse(input);
                }

                this.aNewPaymentEN.ChangeQuantityServiceUsedInRoom(this.CurrentIDBookingRoom, IDBookingRoomService, Quantity);
                this.LoadDataCurrentRoomForControl();

            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtQuantity_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtPercentTaxService_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingRoomSertvice = Convert.ToInt32(viewServicesR.GetFocusedRowCellValue("IDBookingService"));

                DevExpress.XtraEditors.TextEdit txtPercentTaxService = (DevExpress.XtraEditors.TextEdit)sender;

                string input = txtPercentTaxService.Text;


                double PercentTaxService;
                if (string.IsNullOrEmpty(input) == true)
                {
                    PercentTaxService = 0;
                }
                else
                {
                    PercentTaxService = double.Parse(input);
                }

                aNewPaymentEN.ChangeTaxServiceInRoom(this.CurrentIDBookingRoom, IDBookingRoomSertvice, PercentTaxService);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtPercentTaxService_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtServiceCost_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingRoomSertvice = Convert.ToInt32(viewServicesR.GetFocusedRowCellValue("IDBookingService"));

                DevExpress.XtraEditors.TextEdit txtCost = (DevExpress.XtraEditors.TextEdit)sender;

                string input = txtCost.Text;

                decimal Cost;
                if (string.IsNullOrEmpty(input) == true)
                {
                    Cost = 0;
                }
                else
                {
                    Cost = Convert.ToDecimal(txtCost.Text);
                }
                aNewPaymentEN.ChangeCostServiceUsedInRoom(this.CurrentIDBookingRoom, IDBookingRoomSertvice, Cost);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtServiceCost_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtBookingRoomsCost_Leave(object sender, EventArgs e)
        {
            try
            {

                string input = txtBookingRoomsCost.Text;
                decimal cost;

                if (string.IsNullOrEmpty(input) == true)
                {
                    cost = 0;
                }
                else
                {
                    cost = Convert.ToDecimal(input);
                }
                this.aNewPaymentEN.ChangeCostRoom(this.CurrentIDBookingRoom, cost);
                this.LoadDataCurrentRoomForControl();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.txtBookingRoomsCost_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ngoc - done
        private void txtNumberDate_Leave(object sender, EventArgs e)
        {
            try
            {
                string input = txtNumberDate.Text;
                decimal NumberDate;
                if (string.IsNullOrEmpty(input) == true)
                {
                    NumberDate = 0;
                }
                else
                {
                    NumberDate = decimal.Parse(input);
                }
                this.aNewPaymentEN.ChangeTimeInUsed(this.CurrentIDBookingRoom, NumberDate * 24 * 60);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtNumberDate_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void txtPercentTax_Room_Leave(object sender, EventArgs e)
        {
            try
            {
                string input = txtPercentTax_Room.Text;
                double PercentTax;
                if (string.IsNullOrEmpty(input) == true)
                {
                    PercentTax = 0;
                }
                else
                {
                    PercentTax = double.Parse(input);
                }
                this.aNewPaymentEN.ChangePercentTaxRoom(this.CurrentIDBookingRoom, PercentTax);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtPercentTax_Room_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void dtpCheckInActual_Leave(object sender, EventArgs e)
        {
            if (this.CurrentIDBookingRoom > 0)
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (dtpCheckInActual.DateTime < dtpCheckOutActual.DateTime)
                {
                    if (this.CheckChangeTime(CurrentIDBookingRoom, CodeRoom, dtpCheckInActual.DateTime, dtpCheckOutActual.DateTime) == true)
                    {
                        List<BookingRoomUsedEN> aTemp = new List<BookingRoomUsedEN>();
                        aTemp = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList();
                        if (aTemp.Count > 0)
                        {
                            if (aTemp[0].Status >= 3)
                            {
                                this.aNewPaymentEN.ChangeCheckInActual(this.CurrentIDBookingRoom, dtpCheckInActual.DateTime);
                            }
                            else if (aTemp[0].Status < 3)
                            {
                                this.aNewPaymentEN.ChangeCheckInPlan(this.CurrentIDBookingRoom, dtpCheckInActual.DateTime);
                            }
                        }
                    }
                    this.LoadDataCurrentRoomForControl();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày giờ CheckIn phải nhỏ hơn ngày giờ CheckOut", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Ngoc - done
        private void dtpCheckOutActual_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentIDBookingRoom > 0)
                {

                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    if (dtpCheckInActual.DateTime < dtpCheckOutActual.DateTime)
                    {
                        if (this.CheckChangeTime(CurrentIDBookingRoom, CodeRoom, dtpCheckInActual.DateTime, dtpCheckOutActual.DateTime) == true)
                        {
                            List<BookingRoomUsedEN> aTemp = new List<BookingRoomUsedEN>();
                            aTemp = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList();

                            if (aTemp.Count > 0)
                            {
                                // Phai kiem tra xem sua cai gi
                                if (aTemp[0].Status >= 7)
                                {
                                    this.aNewPaymentEN.ChangeCheckOutActual(this.CurrentIDBookingRoom, dtpCheckOutActual.DateTime);
                                }
                                else if (aTemp[0].Status < 7)
                                {
                                    this.aNewPaymentEN.ChangeCheckOutPlan(this.CurrentIDBookingRoom, dtpCheckOutActual.DateTime);

                                }
                                
                            }
                        }
                        this.LoadDataCurrentRoomForControl();
                    }
                    else
                    {

                        MessageBox.Show("Vui lòng nhập ngày giờ CheckIn phải nhỏ hơn ngày giờ CheckOut", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.dtpCheckOutActual_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngoc - done
        private void chkCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

            if (this.CurrentIDBookingRoom > 0)
            {
                int NewTypeBookingRoom = this.ConvertTypeBookingRoom(chkCheckIn.Checked, chkCheckOut.Checked);
                this.aNewPaymentEN.ChangeTypeBookingRoom(this.CurrentIDBookingRoom, NewTypeBookingRoom);
                this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].AddTimeEnd = aReceptionTaskBO.GetAddTimeStart(NewTypeBookingRoom, dtpCheckInActual.DateTime);
                this.ShowControlAutoCost(this.aNewPaymentEN.GetTypeBookingRoom(this.CurrentIDBookingRoom));
                this.LoadDataCurrentRoomForControl();
            }
        }
        //Ngoc - done
        private void chkCheckOut_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CurrentIDBookingRoom > 0)
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                int NewTypeBookingRoom = this.ConvertTypeBookingRoom(chkCheckIn.Checked, chkCheckOut.Checked);
                this.aNewPaymentEN.ChangeTypeBookingRoom(this.CurrentIDBookingRoom, NewTypeBookingRoom);

                this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].AddTimeEnd = aReceptionTaskBO.GetAddTimeEnd(NewTypeBookingRoom, dtpCheckOutActual.DateTime);
                this.ShowControlAutoCost(this.aNewPaymentEN.GetTypeBookingRoom(this.CurrentIDBookingRoom));
                this.LoadDataCurrentRoomForControl();
            }
        }

        private void btnCaculateTimeUsed_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            //    List<BookingRoomUsedEN> aList = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList();

            //    if (aList.Count > 0)
            //    {

            //        txtAddTimeStart.Text = aReceptionTaskBO.GetAddTimeStart(Convert.ToInt32(aList[0].Type), dtpCheckInActual.DateTime).ToString();
            //        txtAddTimeEnd.Text = aReceptionTaskBO.GetAddTimeEnd(Convert.ToInt32(aList[0].Type), dtpCheckOutActual.DateTime).ToString();
            //        txtNumberDate.Text = aReceptionTaskBO.GetTimeInUsed(dtpCheckInActual.DateTime, dtpCheckOutActual.DateTime).ToString();

            //        this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].AddTimeEnd = aReceptionTaskBO.GetAddTimeEnd(Convert.ToInt32(aList[0].Type), dtpCheckOutActual.DateTime);
            //        this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].AddTimeStart = aReceptionTaskBO.GetAddTimeStart(Convert.ToInt32(aList[0].Type), dtpCheckInActual.DateTime);
            //        //this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].DateUsed = aReceptionTaskBO.GetTimeInUsed( dtpCheckInActual.DateTime, dtpCheckOutActual.DateTime);

            //        txtBookingRoomsCost.Text = aAccountancyBO.CalculateCostRoom(this.CurrentIDBookingRoom, cbbPriceType.Text, this.aNewPaymentEN.CustomerType.GetValueOrDefault(0), aNewPaymentEN.GetNumberCustomerInRoom(this.CurrentIDBookingRoom)).GetValueOrDefault(0).ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("frmTsk_PaymentStep2.btnCaculateTimeUsed_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        //Ngoc - done
        private void cbbPriceType_EditValueChanged(object sender, EventArgs e)
        {
            decimal? CostDBCurrentRoom = this.aNewPaymentEN.GetOnlyMoneyRoom(this.CurrentIDBookingRoom);
            string CostTypeDBCurrentRoom = this.aNewPaymentEN.GetPriceType(this.CurrentIDBookingRoom);
            // Neu da co du lieu trong DB thi lay du lieu trong DB
            if (cbbPriceType.Text != CostTypeDBCurrentRoom)
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                this.aNewPaymentEN.SetPriceType(this.CurrentIDBookingRoom, cbbPriceType.Text);
                this.aNewPaymentEN.ChangeCostRoom(this.CurrentIDBookingRoom, aAccountancyBO.CalculateCostRoom(this.CurrentIDBookingRoom, this.aNewPaymentEN.GetPriceType(this.CurrentIDBookingRoom), this.aNewPaymentEN.CustomerType.GetValueOrDefault(0), this.aNewPaymentEN.GetNumberCustomerInRoom(this.CurrentIDBookingRoom)).GetValueOrDefault(0));

            }
            this.LoadDataCurrentRoomForControl();

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentIDBookingRoom > 0)
                {
                    frmTsk_UseServices afrmTsk_UseServices = new frmTsk_UseServices(this, this.CodeRoom, this.IDBookingR, this.CurrentIDBookingRoom, this.aNewPaymentEN);
                    afrmTsk_UseServices.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn phòng muốn thêm dịch vụ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnAddService_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phần Hội trường

        private void btnEditBookingHall_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //txtBookingHallsCost.Enabled = true;
                //txtPercentTax_Hall.Enabled = true;
                //btnAddServicesForHalls.Enabled = true;
                //lueMenus.Enabled = true;
                //btnPrintMenu.Enabled = true;

                this.CurrentIDBookingHall= Convert.ToInt32(viewHalls.GetFocusedRowCellValue("ID"));
                if (this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0].Status == 7)
                {
                    this.LockForm_Status7();
                }
                else if (this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0].Status == 8)
                {
                    this.LockForm_Status8();
                }
                else
                {
                    this.UnLockForm();
                }

                dgvFoods.RefreshDataSource();
                this.LoadDataCurrentHallForControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnEditBookingHall_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookingHallsCost_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string input = txtBookingHallsCost.Text;
                decimal cost;
                if (string.IsNullOrEmpty(input) == true)
                {
                    cost = 0;
                }
                else
                {
                    cost = Convert.ToDecimal(input);
                }

                this.aNewPaymentEN.ChangeCostHall(this.CurrentIDBookingHall, cost);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtBookingHallsCost_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPercentTax_Hall_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string input = txtPercentTax_Hall.Text;
                double PercentTax;
                if (string.IsNullOrEmpty(input) == true)
                {
                    PercentTax = 0;
                }
                else
                {
                    PercentTax = double.Parse(input);
                }
                this.aNewPaymentEN.ChangePercentTaxHall(this.CurrentIDBookingHall, PercentTax);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.txtPercentTax_Hall_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void AddServiceForBookingHall(int IDBookingHall)
        //{
        //    try
        //    {
        //        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
        //        List<ServicesHallsEN> aListServicesHallsEN = new List<ServicesHallsEN>();
        //        aListServicesHallsEN = aReceptionTaskBO.GetListServicesHallsEN_ByIDBookingHall(IDBookingHall);
        //        foreach (InfoDetailPaymentHallsEN aInfoDetailPaymentHallsEN in aPaymentHallsEN.aListInfoDetailPaymentHallsEN)
        //        {
        //            if (aInfoDetailPaymentHallsEN.aBookingHalls.ID == IDBookingHall)
        //            {
        //                aInfoDetailPaymentHallsEN.aListServicesHallsEN.Clear();
        //                foreach (ServicesHallsEN aServicesHallsEN in aListServicesHallsEN)
        //                {
        //                    aInfoDetailPaymentHallsEN.aListServicesHallsEN.Add(aServicesHallsEN);
        //                }
        //            }
        //        }
        //        this.LoadDataServiceForBookingHall(this.CurrentIDBookingHall);
        //        lblTotalMoneyServices_BookingH.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetTotalMoneyServiceHallAfterTax_ByIDBookingHall(this.cuIDBookingHall));
        //        this.LoadListHall();
        //        lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", Convert.ToDecimal(aPaymentHallsEN.GetTotalMoneyBookingHAfterTax()));
        //        txtBookingHMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
        //        lblTotalMoneyH.Text = String.Format("{0:0,0}", (Convert.ToDecimal(aPaymentHallsEN.GetTotalMoneyBookingHAfterTax()) - Convert.ToDecimal(this.aPaymentHallsEN.GetBookingMoney())));

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("frmTsk_PaymentStep2.AddServiceForBookingHall\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnServicesQuantityForHalls_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewServicesH.GetFocusedRowCellValue("IDBookingService"));

                DevExpress.XtraEditors.TextEdit txtQuality = (DevExpress.XtraEditors.TextEdit)sender;

                string input = txtQuality.Text;

                double Quantity;
                if (string.IsNullOrEmpty(input) == true)
                {
                    Quantity = 0;
                }
                else
                {
                    Quantity = double.Parse(input);
                }
                this.aNewPaymentEN.ChangeQuantityServiceUsedInHall(this.CurrentIDBookingHall, IDBookingHallService, Quantity);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnServicesQuantityForHalls_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServicesPercentTaxForHalls_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewServicesH.GetFocusedRowCellValue("IDBookingHallService"));

                DevExpress.XtraEditors.TextEdit txtPercentTaxService = (DevExpress.XtraEditors.TextEdit)sender;

                string input = txtPercentTaxService.Text;

                double PercentTaxService;
                if (string.IsNullOrEmpty(input) == true)
                {
                    PercentTaxService = 0;
                }
                else
                {
                    PercentTaxService = double.Parse(input);
                }
                this.aNewPaymentEN.ChangeTaxServiceInHall(this.CurrentIDBookingHall, IDBookingHallService, PercentTaxService);
                this.LoadDataCurrentRoomForControl();

            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.btnServicesPercentTaxForHalls_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServicesCostForHalls_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewServicesH.GetFocusedRowCellValue("IDBookingHallService"));

                DevExpress.XtraEditors.TextEdit txtCost = (DevExpress.XtraEditors.TextEdit)sender;

                string input = txtCost.Text;

                decimal Cost;
                if (string.IsNullOrEmpty(input) == true)
                {
                    Cost = 0;
                }
                else
                {
                    Cost = Convert.ToDecimal(txtCost.Text);
                }
                this.aNewPaymentEN.ChangeCostServiceUsedInHall(this.CurrentIDBookingHall, IDBookingHallService, Cost);
                this.LoadDataCurrentRoomForControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnServicesCostForHalls_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddServicesForHalls_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentIDBookingHall > 0)
                {
                    frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = new frmIns_BookingHalls_Services(this, this.CurrentIDBookingHall, this.aNewPaymentEN);
                    afrmIns_BookingHalls_Services.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn hội trường muốn add thêm dịch vụ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnPrintPaymentTotal_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Chức năng thanh toán phòng
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (aNewPaymentEN.Status_BookingR == 8 || aNewPaymentEN.Status_BookingR == 7)
                {
                    frmRpt_Payment_BookingRs afrmRpt_Payment_BookingRs = new frmRpt_Payment_BookingRs(this.aNewPaymentEN);
                    ReportPrintTool tool = new ReportPrintTool(afrmRpt_Payment_BookingRs);
                    tool.ShowPreview();
                }
                else
                {
                    frmRpt_Payment_BookingRsUnPay afrmRpt_Payment_BookingRs = new frmRpt_Payment_BookingRsUnPay(this.aNewPaymentEN);
                    ReportPrintTool tool = new ReportPrintTool(afrmRpt_Payment_BookingRs);
                    tool.ShowPreview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // In ra phiếu thanh toán của phòng

        private void btnDownPayment_Click(object sender, EventArgs e) // Tạm thanh toán ( Update lại BookingRMoney)
        {
            try
            {
                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = aBookingRsBO.Select_ByID(this.IDBookingR);
                aBookingRs.BookingMoney = this.aNewPaymentEN.BookingRMoney;
                aBookingRs.StatusPay = 2;// Tạm ứng
                int count = aBookingRsBO.Update(aBookingRs);
                if (this.afrmTsk_Payment_Step1 != null)
                {
                    this.afrmTsk_Payment_Step1.LoadListBookingR();
                }
                //this.LoadData();
                MessageBox.Show("Thực hiện thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnDownPayment_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Thanh toán tất cả các phòng. Tiếp tục?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aAccountancyBO.PaymentRoom(this.aNewPaymentEN);

                    if (this.afrmTsk_Payment_Step1 != null)
                    {
                        this.afrmTsk_Payment_Step1.LoadListBookingR();
                        if (this.afrmTsk_Payment_Step1.afrmMain != null)
                        {
                            this.afrmTsk_Payment_Step1.afrmMain.ReloadData();
                        }
                    }
                    else if (this.afrmMain != null)
                    {
                        this.afrmMain.ReloadData();
                    }


                    MessageBox.Show("Thanh toán tiền phòng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.btnPayment_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Chức năng thanh toán tiệc
        private void btnPrepay_Click(object sender, EventArgs e) // Tạm thanh toán ( Update lại BookingHMoney)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(this.IDBookingH);
                if (aBookingHs != null)
                {
                    aBookingHs.BookingMoney = this.aNewPaymentEN.BookingHMoney;
                    aBookingHs.PayMenthod = 2; // tam ung
                    aBookingHsBO.Update(aBookingHs);
                    MessageBox.Show("Thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnPrepay_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintBookingH_Click(object sender, EventArgs e) // In phiếu thanh toán của tiệc
        {
            try
            {
                frmRpt_PaymentBookingHs afrmRpt_PaymentBookingHs = new frmRpt_PaymentBookingHs(this.aNewPaymentEN);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_PaymentBookingHs);
                tool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnPrintBookingH_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaymentHall_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Thanh toán tất cả các hội trường. Tiếp tục?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aAccountancyBO.PaymentHall(this.aNewPaymentEN);

                    MessageBox.Show("Thanh toán tiền hội trường thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentStep2.btnPaymentHall_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Thanh toán tổng
        private void btnPrintPaymentTotal_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.aNewPaymentEN.aListBookingRoomUsed.Count > 0 && this.aNewPaymentEN.aListBookingHallUsed.Count > 0)
                {
                    frmRpt_Payment_BookingRsAndBookingHs afrmRpt_Payment_BookingRs = new frmRpt_Payment_BookingRsAndBookingHs(this.aNewPaymentEN);
                    ReportPrintTool tool = new ReportPrintTool(afrmRpt_Payment_BookingRs);
                    tool.ShowPreview();
                }
                else
                {
                    if (this.aNewPaymentEN.aListBookingRoomUsed.Count > 0)
                    {
                        frmRpt_Payment_BookingRs afrmRpt_Payment_BookingRs = new frmRpt_Payment_BookingRs(this.aNewPaymentEN);
                        ReportPrintTool tool = new ReportPrintTool(afrmRpt_Payment_BookingRs);
                        tool.ShowPreview();
                    }
                    else if (this.aNewPaymentEN.aListBookingHallUsed.Count > 0)
                    {
                        frmRpt_PaymentBookingHs afrmRpt_PaymentBookingHs = new frmRpt_PaymentBookingHs(this.aNewPaymentEN);
                        ReportPrintTool tool = new ReportPrintTool(afrmRpt_PaymentBookingHs);
                        tool.ShowPreview();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnPrintPaymentTotal_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaymentTotal_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Thanh toán tất cả các phòng + hội trường. Tiếp tục?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aAccountancyBO.PaymentTotal(this.aNewPaymentEN);
                    if (this.afrmTsk_Payment_Step1 != null)
                    {
                        this.afrmTsk_Payment_Step1.LoadListBookingR();
                        if (this.afrmTsk_Payment_Step1.afrmMain != null)
                        {
                            this.afrmTsk_Payment_Step1.afrmMain.ReloadData();
                        }

                    }
                    else if (this.afrmMain != null)
                    {
                        this.afrmMain.ReloadData();
                    }

                    MessageBox.Show("Thanh toán tiền thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnPaymentTotal_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Tách phiếu thu

        private void btnSplitBill_Click(object sender, EventArgs e)
        {
            try
            {
                frmTsk_SplitBill_Step1 afrmTsk_SplitBill_Step1 = new frmTsk_SplitBill_Step1(this, this.aNewPaymentEN);
                afrmTsk_SplitBill_Step1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentStep2.btnSplitBill_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lueMenus_EditValueChanged(object sender, EventArgs e)
        {
            BookingHallUsedEN aBookingHallUsedEN = this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0];
            MenusEN aMenusEN = aBookingHallUsedEN.aListMenuEN.Where(a => a.ID == Convert.ToInt32(lueMenus.EditValue)).ToList()[0];
            List<Foods> aListFoods = new List<Foods>();
            FoodsBO aFoodsBO = new FoodsBO();
            foreach (Foods item in aMenusEN.aListFoods)
            {
                Foods aFoods = aFoodsBO.Select_ByID(item.ID);
                if (aFoods.Image1 != null)
                {
                    if (aFoods.Image1.Length <= 0)
                    {
                        Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }
                }
                else
                {
                    Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                    image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                    Byte[] aImageByte = this.ConvertImageToByteArray(image);
                    aFoods.Image1 = aImageByte;
                }
                aListFoods.Add(aFoods);

            }

            dgvFoods.DataSource = aListFoods;
            dgvFoods.RefreshDataSource();
        }

        private void dtpInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            DateTime aTemp = dtpInvoiceDateR.DateTime;
            dtpInvoiceDateH.DateTime = aTemp;
            dtpAcceptDateR.DateTime = aTemp;
            this.aNewPaymentEN.ChangeInvoiceDate(aTemp);

        }

        private void txtInvoiceNumber_EditValueChanged(object sender, EventArgs e)
        {
            string aTemp = txtInvoiceNumberR.Text;
            txtInvoiceNumberH.Text = aTemp;
            this.aNewPaymentEN.ChangeInvoiceNumber(aTemp);

        }

        private void dtpAcceptDate_EditValueChanged(object sender, EventArgs e)
        {
            DateTime aTemp = dtpAcceptDateR.DateTime;
            dtpAcceptDateH.DateTime = aTemp;
            this.aNewPaymentEN.ChangeAcceptDate(aTemp);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            aAccountancyBO.Save(this.aNewPaymentEN);
            this.aNewPaymentEN = new NewPaymentEN();
            this.InitData(this.IDBookingR, this.IDBookingH);
            //this.LoadData();
            MessageBox.Show("Lưu thông tin hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (this.afrmMain != null)
            {
                this.afrmMain.ReloadData();
            }
        }


        private void btnEnableEdit_Click(object sender, EventArgs e)
        {
            this.UnLockForm();
            if (this.aNewPaymentEN.aListBookingRoomUsed.Count > 0)
            {
                int BookingRoomType = 3;
                if (this.CurrentIDBookingRoom > 0)
                {
                    BookingRoomType = this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].Type.GetValueOrDefault(0);
                }
                this.ShowControlAutoCost(BookingRoomType);
            }
            
        }

        private void lueBookingR_Paymethod_EditValueChanged(object sender, EventArgs e)
        {
            this.aNewPaymentEN.PayMenthodR = Convert.ToInt32(lueBookingR_Paymethod.EditValue);
        }

        private void lueBookingH_PayMethod_EditValueChanged(object sender, EventArgs e)
        {
            this.aNewPaymentEN.PayMenthodH = Convert.ToInt32(lueBookingH_PayMethod.EditValue);
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {

            frmUpd_Customers_2 afrmUpd_Customers = new frmUpd_Customers_2(this, this.CurrentIDBookingRoom);
            afrmUpd_Customers.ShowDialog();

        }

        private void btnEditCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsLockForm == false)
            {
                int IDCustomer = Convert.ToInt32(viewCustomers.GetFocusedRowCellValue("ID"));
                frmUpd_Customers_2 afrmUpd_Customers = new frmUpd_Customers_2(this, this.CurrentIDBookingRoom, IDCustomer);
                afrmUpd_Customers.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không thực hiện được chức năng này do form đang chế độ khóa");
            }
        }

        private void btnBookHall_Click(object sender, EventArgs e)
        {
            frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New = new frmTsk_BookingHall_Customer_New(this, this.aNewPaymentEN.IDBookingR, this.aNewPaymentEN.IDCompany, this.aNewPaymentEN.IDCustomer, this.aNewPaymentEN.CustomerType);
            afrmTsk_BookingHall_Customer_New.ShowDialog();
        }

        private void btnDeleteCus_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsLockForm == false)
            {
                if (this.aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == this.CurrentIDBookingRoom).ToList()[0].ListCustomer.Count == 1)
                {
                    MessageBox.Show("Không thể xóa", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Xóa khách khỏi phòng. Tiếp tục?", "Xóa khách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                        int IDCustomer = Convert.ToInt32(viewCustomers.GetFocusedRowCellValue("ID"));
                        aBookingRoomsMembersBO.Delete(this.CurrentIDBookingRoom, IDCustomer);
                        MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Reload();
                        txtBookingRoomsCost.Text = aAccountancyBO.CalculateCostRoom(this.CurrentIDBookingRoom, cbbPriceType.Text, this.aNewPaymentEN.CustomerType.GetValueOrDefault(0), aNewPaymentEN.GetNumberCustomerInRoom(this.CurrentIDBookingRoom)).GetValueOrDefault(0).ToString();
                        CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
                        aCustomerGroups_CustomersBO.DeleteCustomerFromCustomerGroup_ByIDBookingRs(IDCustomer, this.IDBookingR);


                    }
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện được chức năng này do form đang chế độ khóa");
            }
        }

        private void btnDeleteService_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsLockForm == false)
            {
                DialogResult result = MessageBox.Show("Xóa dịch vụ phòng đã sử dụng. Tiếp tục?", "Xóa dịch vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                    int IDBookingService = Convert.ToInt32(viewServicesR.GetFocusedRowCellValue("IDBookingService"));

                    aBookingRooms_ServicesBO.Delete(IDBookingService);
                    MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Reload();
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện được chức năng này do form đang chế độ khóa");
            }
        }

        private void btnDeleteServiceHall_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsLockForm == false)
            {
                DialogResult result = MessageBox.Show("Xóa dịch vụ hội trường đã sử dụng. Tiếp tục?", "Xóa dịch vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                    int IDBookingService = Convert.ToInt32(viewServicesH.GetFocusedRowCellValue("IDBookingService"));

                    aBookingHalls_ServicesBO.Delete(IDBookingService);
                    MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Reload();
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện được chức năng này do form đang chế độ khóa");
            }
        }

        private void btnDeleteRoom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsLockForm == false)
            {
                if (this.aNewPaymentEN.aListBookingRoomUsed.Count == 1)
                {
                    MessageBox.Show("Không thể xóa", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Xóa phòng. Tiếp tục?", "Xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                        BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                        BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                        int IDDeletedBookingRoom = Convert.ToInt32(viewRooms.GetFocusedRowCellValue("ID"));
                        aBookingRooms_ServicesBO.DeleteListServiceUsed(IDDeletedBookingRoom);
                        aBookingRoomsMembersBO.DeleteListBookingRoomsMembers(IDDeletedBookingRoom);
                        aBookingRoomsBO.Delete(IDDeletedBookingRoom);
                        MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Reload();


                    }
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện được chức năng này do form đang chế độ khóa");
            }
        }

        private void btnPrintMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lueMenus.EditValue) != 0)
                {
                    frmRpt_DetailMenus afrmRpt_DetailMenus = new frmRpt_DetailMenus(Convert.ToInt32(lueMenus.EditValue), this.CurrentIDBookingHall);
                    ReportPrintTool tool = new ReportPrintTool(afrmRpt_DetailMenus);
                    tool.ShowPreview();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPrintListCus_Click(object sender, EventArgs e)
        {
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            List<vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups> aListCustomerInGroup = aBookingRoomsBO.SelectListInfoCustomer_ByIDBookingR(this.IDBookingR);
            frmRpt_ListCustomersInGroup afrmRpt_ListCustomersInGroup = new frmRpt_ListCustomersInGroup(aListCustomerInGroup, this.aNewPaymentEN.NameCompany, this.aNewPaymentEN.NameCustomerGroup);
            ReportPrintTool tool = new ReportPrintTool(afrmRpt_ListCustomersInGroup);
            tool.ShowPreview();
        }

        private void btnDeleteBookingR_Click(object sender, EventArgs e)
        {
            BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
            BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            BookingRsBO aBookingRsBO = new BookingRsBO();
            CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            BookingHsBO aBookingHsBO = new BookingHsBO();
            BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            MenusBO aMenusBO = new MenusBO();
            Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
            try
            {
                MessageBox.Show("Chức năng này sẽ xóa tất cả các phòng và hóa đơn đặt phòng đã đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.IDBookingH == 0)
                {
                    DialogResult result = MessageBox.Show("Xóa tất cả các phòng đã đặt. Tiếp tục?", "Xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        foreach (BookingRoomUsedEN item in this.aNewPaymentEN.aListBookingRoomUsed)
                        {
                            aBookingRooms_ServicesBO.DeleteListServiceUsed(item.ID);
                            aBookingRoomsMembersBO.DeleteListBookingRoomsMembers(item.ID);
                            aBookingRoomsBO.Delete(item.ID);
                        }
                        aCustomerGroups_CustomersBO.DeleteAllCustomersFromCustomerGroup_ByIDBookingRs(this.IDBookingR);
                        aCustomerGroupsBO.Delete_ByID(Convert.ToInt32(this.aNewPaymentEN.IDCustomerGroup));
                        aBookingRsBO.Delete(this.IDBookingR);
                    }

                }
                else
                {
                    DialogResult result = MessageBox.Show("Xóa tất cả các phòng và hội trường đã đặt. Tiếp tục?", "Xóa hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        foreach (BookingRoomUsedEN item in this.aNewPaymentEN.aListBookingRoomUsed)
                        {
                            aBookingRooms_ServicesBO.DeleteListServiceUsed(item.ID);
                            aBookingRoomsMembersBO.DeleteListBookingRoomsMembers(item.ID);
                            aBookingRoomsBO.Delete(item.ID);
                        }
                        aCustomerGroups_CustomersBO.DeleteAllCustomersFromCustomerGroup_ByIDBookingRs(this.IDBookingR);
                        aCustomerGroupsBO.Delete_ByID(Convert.ToInt32(this.aNewPaymentEN.IDCustomerGroup));
                        aBookingRsBO.Delete(this.IDBookingR);
                        foreach (BookingHallUsedEN item1 in this.aNewPaymentEN.aListBookingHallUsed)
                        {
                            aBookingHalls_ServicesBO.DeleteListServiceUsed(item1.ID);
                            aBookingHallsBO.Delete(item1.ID);
                            foreach (MenusEN aMenu in item1.aListMenuEN)
                            {
                                aMenusBO.Delete(aMenu.ID);
                                aMenus_FoodsBO.Delete_ByIDMenu(aMenu.ID);
                            }
                        }
                        aBookingHsBO.Delete(this.IDBookingH);
                    }
                }
                MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                if (this.afrmMain != null)
                {
                    this.afrmMain.ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnDeleteBookingRs\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrintPayment_OldStyle_Click(object sender, EventArgs e)
        {
            List<int> ListIDServiceGroup = new List<int>();

            ListIDServiceGroup.Add(18);
            ListIDServiceGroup.Add(21);
            ListIDServiceGroup.Add(26);
            ListIDServiceGroup.Add(27);
            ListIDServiceGroup.Add(28);

            ListIDServiceGroup.Add(23);
            ListIDServiceGroup.Add(15);
            ListIDServiceGroup.Add(16);

            List<RptPaymentStyle1_ForDisplay> aList = this.aNewPaymentEN.ConvertDataFor_RptPaymentStyle1(ListIDServiceGroup);
            frmTsk_ReportPaymentStyle1 afrm = new frmTsk_ReportPaymentStyle1(aList.OrderBy(p=>p.Date).ToList(), ListIDServiceGroup, this.aNewPaymentEN.NameCompany, this.aNewPaymentEN.AddressCompany, this.aNewPaymentEN.NameCustomerGroup, this.aNewPaymentEN.InvoiceNumber, this.aNewPaymentEN.GetFirstDate(), this.aNewPaymentEN.GetLastDate(), this.aNewPaymentEN.BookingHMoney, this.aNewPaymentEN.BookingRMoney, this.IDBookingR);
            afrm.ShowDialog();
        }

        private void dtpInvoiceDateH_EditValueChanged(object sender, EventArgs e)
        {
            DateTime aTemp = dtpInvoiceDateH.DateTime;
            dtpInvoiceDateH.DateTime = aTemp;
            dtpAcceptDateH.DateTime = aTemp;
            this.aNewPaymentEN.ChangeInvoiceDate(aTemp);
        }

        private void btnDeleteHall_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsLockForm == false)
            {
                if (this.aNewPaymentEN.aListBookingRoomUsed.Count == 0 && this.aNewPaymentEN.aListBookingHallUsed.Count == 1)
                {
                    MessageBox.Show("Không thể xóa vì hóa đơn này sẽ rỗng. Hãy sử dụng chức năng xóa cả hóa đơn trong tình huống này", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Xóa hội trường/tiệc. Tiếp tục?", "Xóa Xóa hội trường/tiệc", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                        BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                        int IDDeletedBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("ID"));
                        aBookingHalls_ServicesBO.DeleteListServiceUsed(IDDeletedBookingHall);

                        aBookingHallsBO.Delete(IDDeletedBookingHall);
                        MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Reload();


                    }
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện được chức năng này do form đang chế độ khóa");
            }
        }

        private void frmTsk_Payment_Step2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.afrmTsk_PaymentViewAll_New != null)
            {
                this.afrmTsk_PaymentViewAll_New.LoadData();
            }
            else if (this.afrmTsk_Payment_Step1 != null)
            {
                this.afrmTsk_Payment_Step1.LoadData();
            }
            else if (this.afrmMain != null)
            {
                this.afrmMain.ReloadData();
            }

        }

        private void dtpAcceptDateH_EditValueChanged(object sender, EventArgs e)
        {
            DateTime aTemp = dtpAcceptDateH.DateTime;
            this.aNewPaymentEN.ChangeAcceptDate(aTemp);
        }

        private void dtpCheckOutActual_EditValueChanged(object sender, EventArgs e)
        {

        }
       
        private bool CheckChangeTime(int IDBookingRoom, string CodeRoom, DateTime From, DateTime To)
        {
          ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
          List<int> aListIDBookingRoom = aReceptionTaskBO.CheckAvaiableRoom(IDBookingRoom, CodeRoom, From, To);
          if (aListIDBookingRoom.Count > 0)
          {
             MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			 DialogResult result;

             result = MessageBox.Show("Không chuyển được thời gian do xung đột thời gian với mã đặt phòng :" + string.Join(",", aListIDBookingRoom.ToArray()) +". Bạn có muốn search xem chi tiết không ?","Thông báo", buttons);
              if (result == System.Windows.Forms.DialogResult.Yes)
              {
                  frmTsk_PaymentViewAll_New aFrm = new frmTsk_PaymentViewAll_New();
                  aFrm.ShowDialog();
                  this.Close();

              }    
              return false;
          }
          return true;
        }




    }
}