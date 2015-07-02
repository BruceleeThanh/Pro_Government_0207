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
using CORESYSTEM;
using DevExpress.XtraReports.UI;
using System.IO;

namespace RoomManager
{
    public partial class frmTsk_PaymentHall : DevExpress.XtraEditors.XtraForm
    {
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        private int IDBookingH;
        private int CurrentIDBookingHall = 0;

        public frmTsk_PaymentHall(int IDBookingH)
        {
            InitializeComponent();
            this.IDBookingH = IDBookingH;

        }
        // Author : Linhting
        public void InitData( int IDBookingH)
        {

            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                BookingHsBO aBookingHsBO = new BookingHsBO();
                CustomersBO aCustomersBO = new CustomersBO();
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                HallsBO aHallsBO = new HallsBO();
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                FoodsBO aFoodsBO = new FoodsBO();


                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);              
                

                    // Truyen du lieu cho List BookingRoom cua NewPayment
                 
                    if (aBookingHs != null)
                    {
                         aNewPaymentEN.IDCustomer = aBookingHs.IDCustomer;
                    Customers aCustomers = aCustomersBO.Select_ByID(aBookingHs.IDCustomer);
                    if (aCustomers != null)
                    {
                        aNewPaymentEN.NameCustomer = aCustomers.Name;
                    }
                    aNewPaymentEN.IDSystemUser = aBookingHs.IDSystemUser;
                    SystemUsers aSystemUsers = aSystemUsersBO.Select_ByID(aBookingHs.IDSystemUser);
                    if (aSystemUsers != null)
                    {
                        aNewPaymentEN.NameSystemUser = aSystemUsers.Name;
                    }
                    aNewPaymentEN.IDCustomerGroup = aBookingHs.IDCustomerGroup;
                    CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingHs.IDCustomerGroup);
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
                        aNewPaymentEN.IDBookingH = aBookingHs.ID;
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
                  
                                List<ServiceUsedEN> aListServiceTemp = aReceptionTaskBO.GetListServiceUsedInHall_ByIDBookingHall(item.ID);
                                foreach (ServiceUsedEN aTemp in aListServiceTemp)
                                {
                                    aBookingHallUsedEN.aListServiceUsed.Add(aTemp);
                                }
                                aNewPaymentEN.aListBookingHallUsed.Add(aBookingHallUsedEN);
                            }
                        }
                    }


                }
            
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.InitData\n" + ex.ToString());
            }

        }
        // Author : Linhting
        public void LoadData()
        {
            lblCompany.Text = this.aNewPaymentEN.NameCompany;
            lblNameCustomerGroup.Text = this.aNewPaymentEN.NameCustomerGroup;
            lblNameCustomer.Text = this.aNewPaymentEN.NameCustomer;
            txtAddressH.Text = this.aNewPaymentEN.AddressCompany;
            txtTaxNumberCodeH.Text = this.aNewPaymentEN.TaxNumberCodeCompany;
            // Trang thai, hinh thuc thanh toan
            lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", this.aNewPaymentEN.GetMoneyHalls());
            txtBookingMoney.EditValue = this.aNewPaymentEN.BookingHMoney;
            lblTotalMoney.Text = String.Format("{0:0,0}", this.aNewPaymentEN.GetMoneyHalls() - this.aNewPaymentEN.BookingHMoney);
            // Thong tin gia tiền, đặt trước
            luePayMethod.Properties.DataSource = CORE.CONSTANTS.ListPayMethods;
            luePayMethod.Properties.DisplayMember = "Name";
            luePayMethod.Properties.ValueMember = "ID";
            luePayMethod.EditValue = CORE.CONSTANTS.SelectedPayMethod(Convert.ToInt32(this.aNewPaymentEN.PayMenthodH)).ID;
            // Danh sách các hội trường
            dgvHalls.DataSource = this.aNewPaymentEN.aListBookingHallUsed;
            dgvHalls.RefreshDataSource();

            if (this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList().Count > 0)
            {
                BookingHallUsedEN aBookingHallUsedEN = this.aNewPaymentEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0];
                lblSkuHall.Text = Convert.ToString(aBookingHallUsedEN.HallSku);
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
                txtPercentTax_Hall.EditValue = aBookingHallUsedEN.PercentTax;

                lblMoneyHall.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetMoneyAHall(aBookingHallUsedEN.ID));

                decimal? BookingHallsCost = aBookingHallUsedEN.Cost == null ? aBookingHallUsedEN.CostRef_Halls : aBookingHallUsedEN.Cost;

                txtBookingHallsCost.EditValue = BookingHallsCost;
                dgvServices.DataSource = this.aNewPaymentEN.GetListServiceUsedInHall(aBookingHallUsedEN.ID);
                dgvServices.RefreshDataSource();
                lblTotalMoneyService.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentEN.GetMoneyListServiceUsedInAHall(aBookingHallUsedEN.ID));
                              
              
            }              
        }
    

        private void frmTsk_PaymentHall_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitData(this.IDBookingH);
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.frmTsk_PaymentHall_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnEditBookingHall_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                this.CurrentIDBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("ID"));
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.btnEditBookingHall_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        public Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv
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
                MessageBox.Show("frmTsk_PaymentHall.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
     
        //hiennv
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
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.txtPercentTax_Hall_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewServices.GetFocusedRowCellValue("IDBookingService"));

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
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.txtQuantity_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void txtPercentTaxService_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewServices.GetFocusedRowCellValue("IDBookingHallService"));

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
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.txtPercentTaxService_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void txtServiceCost_Leave(object sender, EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewServices.GetFocusedRowCellValue("IDBookingHallService"));

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
                this.LoadData();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.txtServiceCost_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public bool CheckDataBeforePayment()
        {
            try
            {
                if (luePayMethod.EditValue == null)
                {
                    luePayMethod.Focus();
                    MessageBox.Show("Vui lòng chọn hình thực thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.CheckDataBeforePayment\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //hiennv
        private void btnPaymentHall_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforePayment() == true)
                {
                    this.aNewPaymentEN.PaymentHall();
                        MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                  
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.btnPaymentHall_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
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
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.txtBookingHallsCost_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //frmRpt_PaymentBookingHs afrmRpt_PaymentBookingHs = new frmRpt_PaymentBookingHs(this.aNewPaymentEN);
                //ReportPrintTool tool = new ReportPrintTool(afrmRpt_PaymentBookingHs);
                //tool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            
            frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = new frmIns_BookingHalls_Services(this, this.CurrentIDBookingHall);
            afrmIns_BookingHalls_Services.ShowDialog();
        }

        //Hiennv
        private void txtBookingMoney_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal? bookingMoney;
                if (string.IsNullOrEmpty(txtBookingMoney.Text) == true)
                {
                    bookingMoney = 0;
                }
                else
                {
                    bookingMoney = Convert.ToDecimal(txtBookingMoney.Text);
                }
                this.aNewPaymentEN.BookingHMoney = bookingMoney;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.txtBookingMoney_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnPrepay_Click(object sender, EventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(this.IDBookingH);
                if (aBookingHs !=null)
                {
                    aBookingHs.BookingMoney = this.aNewPaymentEN.BookingHMoney;
                    aBookingHs.PayMenthod = 2; // tam ung
                    aBookingHsBO.Update(aBookingHs);
                    MessageBox.Show("Thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.btnPrepay_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv

    }
}