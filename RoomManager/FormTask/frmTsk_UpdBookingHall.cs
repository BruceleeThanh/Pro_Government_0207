using System;
using System.Collections.Generic;
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
using Library;
using System.IO;
using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmTsk_UpdBookingHall : DevExpress.XtraEditors.XtraForm
    {
        CompaniesBO aCompaniesBO = new CompaniesBO();
        CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
        CustomersBO aCustomersBO = new CustomersBO();
        GuestsBO aGuestsBO = new GuestsBO();

        frmMain_Halls afrmMain_Halls = null;
        private List<HallExtStatusEN> aListAvailableHall = new List<HallExtStatusEN>();
        private NewPaymentHEN aNewPaymentHEN = new NewPaymentHEN();
        private int IDBookingH = 0;
        private int CurrentIDBookingHall = 0;

        // Khởi tạo cho chọn Menus
        private List<Foods> aListFoods = new List<Foods>();
        private MenusEN aMenusEN = new MenusEN();
        private AccountancyBO aAccountancyBO = new AccountancyBO();

        public frmTsk_UpdBookingHall()
        {
            InitializeComponent();
        }
        public frmTsk_UpdBookingHall(int IDBookingH)
        {
            InitializeComponent();
            this.IDBookingH = IDBookingH;
        }
        public frmTsk_UpdBookingHall(frmMain_Halls afrmMain_Halls,int IDBookingH)
        {
            InitializeComponent();
            this.IDBookingH = IDBookingH;
            this.afrmMain_Halls = afrmMain_Halls;
        }
        private void frmTsk_UpdBookingHall_Load(object sender, EventArgs e)
        {
            txtPercentTax_Hall.Enabled = false;
            btnAddServicesForHalls.Enabled = false;
            lueMenus.Enabled = false;
            btnAddFood.Enabled = false;
            this.InitData(this.IDBookingH);
            this.LoadData();
        }

        public void InitData(int IDBookingH)
        {
            CompaniesBO aCompaniesBO = new CompaniesBO();
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            SystemUsersBO aSystemUsersBO = new SystemUsersBO();
            BookingHsBO aBookingHsBO = new BookingHsBO();
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            HallsBO aHallsBO = new HallsBO();
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            FoodsBO aFoodsBO = new FoodsBO();
            List<int> aListIndexTemp = new List<int>();

            BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
            if (aBookingHs != null)
            {
                aNewPaymentHEN.IDCustomer = aBookingHs.IDCustomer;
                Customers aCustomers = aCustomersBO.Select_ByID(aBookingHs.IDCustomer);
                if (aCustomers != null)
                {
                    aNewPaymentHEN.NameCustomer = aCustomers.Name;
                }
                aNewPaymentHEN.IDSystemUser = aBookingHs.IDSystemUser;
                SystemUsers aSystemUsers = aSystemUsersBO.Select_ByID(aBookingHs.IDSystemUser);
                if (aSystemUsers != null)
                {
                    aNewPaymentHEN.NameSystemUser = aSystemUsers.Name;
                }
                aNewPaymentHEN.IDCustomerGroup = aBookingHs.IDCustomerGroup;
                CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingHs.IDCustomerGroup);
                if (aCustomerGroups != null)
                {
                    aNewPaymentHEN.NameCustomerGroup = aCustomerGroups.Name;
                    aNewPaymentHEN.IDCompany = aCustomerGroups.IDCompany;
                    Companies aCompanies = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany);
                    if (aCompanies != null)
                    {
                        aNewPaymentHEN.NameCompany = aCompanies.Name;
                        aNewPaymentHEN.TaxNumberCodeCompany = aCompanies.TaxNumberCode;
                        aNewPaymentHEN.AddressCompany = aCompanies.Address;
                    }
                }
                aNewPaymentHEN.Subject = aBookingHs.Subject;
                aNewPaymentHEN.PayMenthodH = aBookingHs.PayMenthod;
                aNewPaymentHEN.CreatedDate_BookingH = aBookingHs.CreatedDate;
                aNewPaymentHEN.CustomerType = aBookingHs.CustomerType;
                aNewPaymentHEN.Status_BookingH = aBookingHs.Status;
                aNewPaymentHEN.StatusPay = aBookingHs.StatusPay;
                aNewPaymentHEN.BookingHMoney = aBookingHs.BookingMoney;
                aNewPaymentHEN.AcceptDate = aBookingHs.AcceptDate;
                aNewPaymentHEN.InvoiceDate = aBookingHs.InvoiceDate;
                aNewPaymentHEN.InvoiceNumber = aBookingHs.InvoiceNumber;
                this.aNewPaymentHEN.IDBookingH = aBookingHs.ID;
                this.aNewPaymentHEN.PayMenthodH = aBookingHs.PayMenthod;
                this.aNewPaymentHEN.CreatedDate_BookingH = aBookingHs.CreatedDate;
                this.aNewPaymentHEN.CustomerType = aBookingHs.CustomerType;
                this.aNewPaymentHEN.Status_BookingH = aBookingHs.Status;
                this.aNewPaymentHEN.BookingHMoney = aBookingHs.BookingMoney;
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
                        aNewPaymentHEN.aListBookingHallUsed.Add(aBookingHallUsedEN);

                    }
                }
            }
            aNewPaymentHEN.ListIndex = aListIndexTemp.Distinct().ToList();

        }
        private void LoadData()
        {
                    
            //--------- Hội trường ----------------
            if (this.IDBookingH > 0)
            {
                //Thong tin nguoi dat
                lblCompany.Text = this.aNewPaymentHEN.NameCompany;
                lblCustomerGroup.Text = this.aNewPaymentHEN.NameCustomerGroup;
                lblNameCustomer.Text = this.aNewPaymentHEN.NameCustomer;
                txtAddress.Text = this.aNewPaymentHEN.AddressCompany;
                txtTaxNumberCode.Text = this.aNewPaymentHEN.TaxNumberCodeCompany;
                // Trang thai, hinh thuc thanh toan
                lblTotalMoneyBookingHs.Text = String.Format("{0:0,0}", this.aNewPaymentHEN.GetMoneyHalls());
                txtBookingHMoney.EditValue = this.aNewPaymentHEN.BookingHMoney;
                lblTotalMoneyH.Text = String.Format("{0:0,0}", this.aNewPaymentHEN.GetMoneyHalls() - this.aNewPaymentHEN.BookingHMoney);
                // Thong tin gia tiền, đặt trước
                lueBookingH_PayMethod.Properties.DataSource = CORE.CONSTANTS.ListPayMethods;
                lueBookingH_PayMethod.Properties.DisplayMember = "Name";
                lueBookingH_PayMethod.Properties.ValueMember = "ID";
                if (this.aNewPaymentHEN.PayMenthodH != 0)
                {
                    lueBookingH_PayMethod.EditValue = CORE.CONSTANTS.SelectedPayMethod(Convert.ToInt32(this.aNewPaymentHEN.PayMenthodH)).ID;
                }
                else
                {
                    lueBookingH_PayMethod.EditValue = 1;
                }
                // Danh sách các hội trường
                dgvHalls.DataSource = this.aNewPaymentHEN.aListBookingHallUsed;
                dgvHalls.RefreshDataSource();
                // Thông tin 1 hội trường

                if (this.aNewPaymentHEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList().Count > 0)
                {
                    BookingHallUsedEN aBookingHallUsedEN = this.aNewPaymentHEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0];
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

                    lueMenus.Properties.DataSource = aBookingHallUsedEN.aListMenuEN;
                    lueMenus.Properties.DisplayMember = "Name";
                    lueMenus.Properties.ValueMember = "ID";
                    if (aBookingHallUsedEN.aListMenuEN.Count > 0)
                    {
                        lueMenus.EditValue = aBookingHallUsedEN.aListMenuEN[0].ID;
                        MenusEN aMenusEN = aBookingHallUsedEN.aListMenuEN[0];
                        dgvFoods.DataSource = aMenusEN.aListFoods;
                        dgvFoods.RefreshDataSource();
                    }
                    txtPercentTax_Hall.EditValue = aBookingHallUsedEN.PercentTax;

                    lblMoneyHall.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentHEN.GetMoneyAHall(aBookingHallUsedEN.ID));

                    decimal? BookingHallsCost = aBookingHallUsedEN.Cost == null ? aBookingHallUsedEN.CostRef_Halls : aBookingHallUsedEN.Cost;

                    txtBookingHallsCost.EditValue = BookingHallsCost;
                    dgvBookingHallUseServices.DataSource = this.aNewPaymentHEN.GetListServiceUsedInHall(aBookingHallUsedEN.ID);
                    dgvBookingHallUseServices.RefreshDataSource();
                    lblTotalMoneyServices_BookingH.Text = String.Format("{0:0,0} (VND)", this.aNewPaymentHEN.GetMoneyListServiceUsedInAHall(aBookingHallUsedEN.ID));

                }
            }
        }
        public void Reload(NewPaymentHEN aNewPaymentH)
        {
            this.aNewPaymentHEN = aNewPaymentH;
            this.LoadData();
        }
        public void Reload()
        {
            this.aNewPaymentHEN = new NewPaymentHEN();
            this.InitData(this.IDBookingH);
            this.LoadData();
        }
        private void btnEditBookingHall_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                txtBookingHallsCost.Enabled = true;
                txtPercentTax_Hall.Enabled = true;
                btnAddServicesForHalls.Enabled = true;
                lueMenus.Enabled = true;
                btnAddFood.Enabled = true;
                this.CurrentIDBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("ID"));
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnEditBookingHall_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookingHallsCost_EditValueChanged(object sender, System.EventArgs e)
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

                this.aNewPaymentHEN.ChangeCostHall(this.CurrentIDBookingHall, cost);
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_UpdBookingHall.txtBookingHallsCost_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPercentTax_Hall_EditValueChanged(object sender, System.EventArgs e)
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
                this.aNewPaymentHEN.ChangePercentTaxHall(this.CurrentIDBookingHall, PercentTax);
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_UpdBookingHall.txtPercentTax_Hall_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueMenus_EditValueChanged(object sender, System.EventArgs e)
        {
            BookingHallUsedEN aBookingHallUsedEN = this.aNewPaymentHEN.aListBookingHallUsed.Where(a => a.ID == this.CurrentIDBookingHall).ToList()[0];
            MenusEN aMenusEN = aBookingHallUsedEN.aListMenuEN.Where(a => a.ID == Convert.ToInt32(lueMenus.EditValue)).ToList()[0];
            dgvFoods.DataSource = aMenusEN.aListFoods;
            dgvFoods.RefreshDataSource();
        }

        private void txtTaxNumberCode_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (txtTaxNumberCode.Text != this.aNewPaymentHEN.TaxNumberCodeCompany)
                {
                    this.aNewPaymentHEN.TaxNumberCodeCompany = txtTaxNumberCode.Text;
                    this.LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.txtTaxNumberCodeR_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAddress_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {

                if (txtAddress.Text != this.aNewPaymentHEN.AddressCompany)
                {
                    this.aNewPaymentHEN.AddressCompany = txtAddress.Text;
                    this.LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.txtTaxNumberCodeR_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpInvoiceDate_EditValueChanged(object sender, System.EventArgs e)
        {
            DateTime aTemp = dtpInvoiceDate.DateTime;
            dtpAcceptDate.DateTime = aTemp;
            this.aNewPaymentHEN.ChangeInvoiceDate(aTemp);
        }

        private void txtInvoiceNumber_EditValueChanged(object sender, System.EventArgs e)
        {
            string aTemp = txtInvoiceNumber.Text;
            this.aNewPaymentHEN.ChangeInvoiceNumber(aTemp);
        }

        private void dtpAcceptDate_EditValueChanged(object sender, System.EventArgs e)
        {
            DateTime aTemp = dtpAcceptDate.DateTime;
            this.aNewPaymentHEN.ChangeAcceptDate(aTemp);
        }

        private void txtBookingHMoney_EditValueChanged(object sender, System.EventArgs e)
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
                this.aNewPaymentHEN.BookingHMoney = bookingMoney;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.txtBookingH_BookingMoney_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueBookingH_PayMethod_EditValueChanged(object sender, System.EventArgs e)
        {
            this.aNewPaymentHEN.PayMenthodH = Convert.ToInt32(lueBookingH_PayMethod.EditValue);

        }

        private void btnAddServicesForHalls_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = new frmIns_BookingHalls_Services(this, this.CurrentIDBookingHall, this.aNewPaymentHEN);
                afrmIns_BookingHalls_Services.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnPrintPaymentTotal_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPaymentHall_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Thanh toán tất cả các hội trường. Tiếp tục?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aAccountancyBO.PaymentHall(this.aNewPaymentHEN);

                    MessageBox.Show("Thanh toán tiền hội trường thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_UpdBookingHall.btnPaymentHall_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintBookingH_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmRpt_PaymentBookingHs afrmRpt_PaymentBookingHs = new frmRpt_PaymentBookingHs(this.aNewPaymentHEN);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_PaymentBookingHs);
                tool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnAddFood_Click(object sender, System.EventArgs e)
        {
            frmIns_Menus afrmIns_Menus = new frmIns_Menus(this,this.CurrentIDBookingHall,1);
            afrmIns_Menus.ShowDialog();
        }

        private void btnServicesQuantityForHalls_Leave(object sender, System.EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewBookingHallUseServices.GetFocusedRowCellValue("IDBookingService"));

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
                this.aNewPaymentHEN.ChangeQuantityServiceUsedInHall(this.CurrentIDBookingHall, IDBookingHallService, Quantity);
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnServicesQuantityForHalls_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServicesPercentTaxForHalls_Leave(object sender, System.EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewBookingHallUseServices.GetFocusedRowCellValue("IDBookingHallService"));

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
                this.aNewPaymentHEN.ChangeTaxServiceInHall(this.CurrentIDBookingHall, IDBookingHallService, PercentTaxService);
                this.LoadData();

            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_UpdBookingHall.btnServicesPercentTaxForHalls_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServicesCostForHalls_Leave(object sender, System.EventArgs e)
        {
            try
            {
                int IDBookingHallService = Convert.ToInt32(viewBookingHallUseServices.GetFocusedRowCellValue("IDBookingHallService"));

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
                this.aNewPaymentHEN.ChangeCostServiceUsedInHall(this.CurrentIDBookingHall, IDBookingHallService, Cost);
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnServicesCostForHalls_Leave\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            aAccountancyBO.Save(this.aNewPaymentHEN);
            this.aNewPaymentHEN = new NewPaymentHEN();
            this.InitData( this.IDBookingH);
            this.LoadData();
            MessageBox.Show("Lưu thông tin hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrintMenu_Click(object sender, System.EventArgs e)
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
                    MessageBox.Show("Vui lòng chọn thực đơn hoặc thêm mới thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBookingHall.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }


}