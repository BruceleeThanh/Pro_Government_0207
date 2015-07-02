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

namespace SaleManagement
{
    public partial class frmTsk_PaymentHall : DevExpress.XtraEditors.XtraForm
    {
        private PaymentHallsEN aPaymentHallsEN = new PaymentHallsEN();
        private int IDBookingH;
        private int IDBookingHall = 0;

        public frmTsk_PaymentHall(int IDBookingH)
        {
            InitializeComponent();
            this.IDBookingH = IDBookingH;
            this.InitData(this.aPaymentHallsEN, this.IDBookingH);

        }
        //hiennv
        public void InitData(PaymentHallsEN aPaymentHallsEN, int IDBookingH)
        {

            try
            {
                HallsBO aHallsBO = new HallsBO();
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                FoodsBO aFoodsBO = new FoodsBO();
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                CustomersBO aCustomersBO = new CustomersBO();
                BookingHsBO aBookingHsBO = new BookingHsBO();
                CompaniesBO aCompaniesBO = new CompaniesBO();
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();

                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
                if (aBookingHs != null)
                {
                    aPaymentHallsEN.IDBookingH = aBookingHs.ID;
                    aPaymentHallsEN.IDCustomerGroup = aBookingHs.IDCustomerGroup;
                    CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingHs.IDCustomerGroup);
                    if (aCustomerGroups != null)
                    {
                        aPaymentHallsEN.NameCustomerGroup = aCustomerGroups.Name;
                        aPaymentHallsEN.IDCompany = aCustomerGroups.IDCompany;
                        Companies aCompanies = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany);
                        if (aCompanies != null)
                        {
                            aPaymentHallsEN.NameCompany = aCompanies.Name;
                            aPaymentHallsEN.TaxNumberCodeCompany = aCompanies.TaxNumberCode;
                        }
                    }
                    aPaymentHallsEN.IDCustomer = aBookingHs.IDCustomer;
                    Customers aCustomers = aCustomersBO.Select_ByID(aBookingHs.IDCustomer);
                    if (aCustomers != null)
                    {
                        aPaymentHallsEN.NameCustomer = aCustomers.Name;
                       
                    }
                    aPaymentHallsEN.IDSystemUser = aBookingHs.IDSystemUser;
                    SystemUsers aSystemUsers = aSystemUsersBO.Select_ByID(aBookingHs.IDSystemUser);
                    if (aSystemUsers != null)
                    {
                        aPaymentHallsEN.NameSystemUser = aSystemUsers.Name;
                    }
                    aPaymentHallsEN.CreatedDate_BookingH = aBookingHs.CreatedDate;
                    aPaymentHallsEN.CustomerType = aBookingHs.CustomerType;
                    aPaymentHallsEN.BookingType = aBookingHs.BookingType;
                    aPaymentHallsEN.PayMenthod = aBookingHs.PayMenthod;
                    aPaymentHallsEN.StatusPay = aBookingHs.StatusPay;
                    aPaymentHallsEN.Status_BookingH = aBookingHs.Status;
                    aPaymentHallsEN.ExchangeRate = aBookingHs.ExchangeRate;
                    aPaymentHallsEN.Level = aBookingHs.Level;
                    aPaymentHallsEN.BookingMoney = aBookingHs.BookingMoney;
                }

                List<BookingHalls> aListBookingHalls = new List<BookingHalls>();
                aListBookingHalls = aBookingHallsBO.Select_ByIDBookigH(IDBookingH);
                InfoDetailPaymentHallsEN aInfoDetailPaymentHallsEN;
                for (int i = 0; i < aListBookingHalls.Count; i++)
                {
                    aInfoDetailPaymentHallsEN = new InfoDetailPaymentHallsEN();
                    Halls aHalls = aHallsBO.Select_ByCodeHall(aListBookingHalls[i].CodeHall, 1);
                    if (aHalls != null)
                    {
                        aInfoDetailPaymentHallsEN.Sku = aHalls.Sku;
                    }
                    else
                    {
                        aInfoDetailPaymentHallsEN.Sku = string.Empty;
                    }
                    aInfoDetailPaymentHallsEN.aBookingHalls = aListBookingHalls[i];
                    aInfoDetailPaymentHallsEN.aMenusEN = aReceptionTaskBO.GetDetailMenu_ByIDBookingHall(aListBookingHalls[i].ID);
                    aInfoDetailPaymentHallsEN.aListServicesHallsEN = aReceptionTaskBO.GetListServicesHallsEN_ByIDBookingHall(aListBookingHalls[i].ID);

                    aPaymentHallsEN.aListInfoDetailPaymentHallsEN.Insert(i, aInfoDetailPaymentHallsEN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.InitData\n" + ex.ToString());
            }

        }
        //hiennv
        public void LoadListHall()
        {
            try
            {
                List<HallsEN> aListHallsEN = new List<HallsEN>();
                HallsEN aHallsEN;
                for (int i = 0; i < aPaymentHallsEN.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    aHallsEN = new HallsEN();
                    HallsBO aHallsBO = new HallsBO();
                    Halls aHalls = aHallsBO.Select_ByCodeHall(aPaymentHallsEN.aListInfoDetailPaymentHallsEN[i].aBookingHalls.CodeHall, 1);
                    aHallsEN.Sku = aHalls.Sku;
                    aHallsEN.CodeHall = aPaymentHallsEN.aListInfoDetailPaymentHallsEN[i].aBookingHalls.CodeHall;
                    aHallsEN.IDBookingH = aPaymentHallsEN.IDBookingH;
                    aHallsEN.IDBookingHall = aPaymentHallsEN.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID;
                    aHallsEN.TotalMoney = aPaymentHallsEN.GetMoneyHallAndService(aPaymentHallsEN.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID);
                    aListHallsEN.Add(aHallsEN);
                }
                dgvHalls.DataSource = aListHallsEN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.LoadListHall\n" + ex.ToString());
            }
        }
        // Author : Linhting
        public void LoadCustomerInfo()
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                CustomersBO aCustomersBO = new CustomersBO();
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                CompaniesBO aCompaniesBO = new CompaniesBO();
                int IDCustomer = aBookingHsBO.Select_ByID(this.IDBookingH).IDCustomer;
                int IDCustomerGroup = aBookingHsBO.Select_ByID(this.IDBookingH).IDCustomerGroup;

                lblCompany.Text = aCompaniesBO.Select_ByIDCustomerGroup(IDCustomerGroup).Name;
                lblNameCustomerGroup.Text = aCustomerGroupsBO.Select_ByID(IDCustomerGroup).Name;
                lblNameCustomer.Text = aCustomersBO.Select_ByID(IDCustomer).Name;
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.LoadCustomerInfo\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_PaymentHall_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadListHall();
                this.LoadCustomerInfo();
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                txtBookingMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));

                luePayMethod.Properties.DataSource = CORE.CONSTANTS.ListPayMethods;
                luePayMethod.Properties.DisplayMember = "Name";
                luePayMethod.Properties.ValueMember = "ID";
                luePayMethod.EditValue = CORE.CONSTANTS.SelectedPayMethod(1).ID;
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
                lblSku.Visible = true;
                lblDate.Visible = true;
                lblLunarDate.Visible = true;
                lblStartTime.Visible = true;
                lblEndTime.Visible = true;
                txtBookingHallsCost.Visible = true;
                txtPercentTax_Hall.Visible = true;
                lblMoneyHall.Visible = true;
                lblNameMenu.Visible = true;

                IDBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("IDBookingHall"));
                BookingHalls aBookingHalls = aPaymentHallsEN.GetDetailBookingHall_ByID(IDBookingHall);
                HallsBO aHallsBO = new HallsBO();
                Halls aHalls = aHallsBO.Select_ByCodeHall(aBookingHalls.CodeHall, 1);
                lblSku.Text = aHalls.Sku;
                decimal? cost = 0;
                if (aBookingHalls.Cost == null || aBookingHalls.Cost == 0)
                {
                    cost = aBookingHalls.CostRef_Halls;
                }
                else
                {
                    cost = aBookingHalls.Cost;
                }

                lblDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHalls.Date);
                lblLunarDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHalls.LunarDate);
                lblStartTime.Text = String.Format(@"{0:hh\:mm}", aBookingHalls.StartTime);
                lblEndTime.Text = String.Format(@"{0:hh\:mm}", aBookingHalls.EndTime);

                MenusEN aMenusEN = aPaymentHallsEN.GetDetailMenus(IDBookingHall);
                lblNameMenu.Text = aMenusEN.Name;

                List<Foods> aListFoods = new List<Foods>();
                FoodsBO aFoodsBO = new FoodsBO();
                foreach (Foods item in aMenusEN.aListFoods)
                {
                    Foods aFoods = aFoodsBO.Select_ByID(item.ID);
                    if (aFoods.Image1 != null)
                    {
                        if (aFoods.Image1.Length <= 0)
                        {
                            Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                            image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                            Byte[] aImageByte = this.ConvertImageToByteArray(image);
                            aFoods.Image1 = aImageByte;
                        }
                    }
                    else
                    {
                        Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }
                    aListFoods.Add(aFoods);

                }

                dgvFoods.DataSource = aListFoods;
                dgvFoods.RefreshDataSource();



                txtPercentTax_Hall.EditValue =aBookingHalls.PercentTax;

                lblMoneyHall.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetMoneyHall(IDBookingHall));

                decimal? BookingHallsCost = aBookingHalls.Cost == null ? aBookingHalls.CostRef_Halls : aBookingHalls.Cost;

                txtBookingHallsCost.EditValue =BookingHallsCost;


                this.LoadDataService(this.IDBookingHall);

                lblTotalMoneyService.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetTotalMoneyServiceHallBehindTax_ByIDBookingHall(IDBookingHall));


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
        public void LoadDataService(int IDBookingHall)
        {
            try
            {
                dgvServices.DataSource = aPaymentHallsEN.GetListServicesHallsEN(IDBookingHall);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.LoadService\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                aPaymentHallsEN.SetPercentTaxHall(IDBookingHall, PercentTax);
                this.LoadListHall();
                lblMoneyHall.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetMoneyHall(IDBookingHall));
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                txtBookingMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));
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
                int IDBookingHallService = Convert.ToInt32(viewServices.GetFocusedRowCellValue("IDBookingHallService"));

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
                aPaymentHallsEN.SetQuantityServiceInUse(IDBookingHallService, Quantity);
                this.LoadDataService(this.IDBookingHall);
                lblTotalMoneyService.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetTotalMoneyServiceHallBehindTax_ByIDBookingHall(this.IDBookingHall));
                this.LoadListHall();
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                txtBookingMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));
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

                aPaymentHallsEN.SetPercentTaxServices(IDBookingHallService, PercentTaxService);
                this.LoadDataService(this.IDBookingHall);
                lblTotalMoneyService.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetTotalMoneyServiceHallBehindTax_ByIDBookingHall(this.IDBookingHall));
                this.LoadListHall();
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                txtBookingMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));
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
                aPaymentHallsEN.SetServiceCost(IDBookingHallService, Cost);
                this.LoadDataService(this.IDBookingHall);
                lblTotalMoneyService.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetTotalMoneyServiceHallBehindTax_ByIDBookingHall(this.IDBookingHall));
                this.LoadListHall();
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
               txtBookingMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.txtServiceCost_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void txtBookingHallsCost_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string input = txtBookingHallsCost.Text;
                decimal? cost;
                if (string.IsNullOrEmpty(input) == true)
                {
                    cost = 0;
                }
                else
                {
                    cost = Convert.ToDecimal(input);
                }

                aPaymentHallsEN.SetCostBookingHall(IDBookingHall, cost);
                this.LoadListHall();
                lblMoneyHall.Text = String.Format("{0:0,0} (VND)", aPaymentHallsEN.GetMoneyHall(IDBookingHall));
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                txtBookingMoney.EditValue = this.aPaymentHallsEN.GetBookingMoney();
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));

            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.txtBookingHallsCost_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Hiennv
        private void txtBookingMoney_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.aPaymentHallsEN.SetBookingMoney(Convert.ToDecimal(txtBookingMoney.EditValue));
                lblTotalMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));
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
                    aBookingHs.BookingMoney = this.aPaymentHallsEN.GetBookingMoney();
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                frmRpt_PaymentBookingHs afrmRpt_PaymentBookingHs = new frmRpt_PaymentBookingHs(this.aPaymentHallsEN);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_PaymentBookingHs);
                tool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnAddService_Click(object sender, EventArgs e)
        {
            IDBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("IDBookingHall"));
            frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = new frmIns_BookingHalls_Services(this, IDBookingHall);
            afrmIns_BookingHalls_Services.ShowDialog();
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
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    this.aPaymentHallsEN.PayMenthod = Convert.ToInt32(luePayMethod.EditValue);
                    bool status = aReceptionTaskBO.PaymentHall(this.aPaymentHallsEN);
                    if (status == true)
                    {
                        MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán bị thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_PaymentHall.btnPaymentHall_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void txtTaxNumberCode_Leave(object sender, EventArgs e)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                Companies aCompanies = aCompaniesBO.Select_ByID(this.aPaymentHallsEN.IDCompany);
                if (aCompanies != null)
                {
                    aCompanies.TaxNumberCode = txtTaxNumberCode.Text;
                    aCompaniesBO.Update(aCompanies);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PaymentHall.txtTaxNumberCode_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

    }
}