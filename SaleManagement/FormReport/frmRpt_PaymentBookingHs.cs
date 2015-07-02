using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Entity;
using DataAccess;
using BussinessLogic;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
namespace SaleManagement
{
    public partial class frmRpt_PaymentBookingHs : DevExpress.XtraReports.UI.XtraReport
    {
        private PaymentHallsEN aPaymentHallsEN = new PaymentHallsEN();

        public frmRpt_PaymentBookingHs(PaymentHallsEN aPaymentHallsEN)
        {
            InitializeComponent();
            this.aPaymentHallsEN = aPaymentHallsEN;
            try
            {
                //------------------------------- Hoi truong ---------------------

                lblNumberVote.Text = Convert.ToString(this.aPaymentHallsEN.IDBookingH);
                lblIDBookingH.Text = Convert.ToString(this.aPaymentHallsEN.IDBookingH);
                lblNameCustomer.Text = this.aPaymentHallsEN.NameCustomer;
                lblGroup.Text = this.aPaymentHallsEN.NameCustomerGroup;
                lblCompany.Text = this.aPaymentHallsEN.NameCompany;
                lblTaxNumberCode.Text = this.aPaymentHallsEN.TaxNumberCodeCompany;

                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

                List<HallsEN> aListHallsEN = new List<HallsEN>();
                HallsEN aHallsEN;
                List<ServicesHallsEN> aListServicesHallsEN = new List<ServicesHallsEN>();
                ServicesHallsEN aServicesHallsEN;

                foreach (InfoDetailPaymentHallsEN aInfoDetailPaymentHallsEN in this.aPaymentHallsEN.aListInfoDetailPaymentHallsEN)
                {

                    aHallsEN = new HallsEN();
                    aHallsEN.IDBookingHall = aInfoDetailPaymentHallsEN.aBookingHalls.ID;
                    aHallsEN.IDBookingH = aInfoDetailPaymentHallsEN.aBookingHalls.IDBookingH;
                    aHallsEN.CodeHall = aInfoDetailPaymentHallsEN.aBookingHalls.CodeHall;
                    aHallsEN.Sku = aInfoDetailPaymentHallsEN.Sku;
                    aHallsEN.Date = aInfoDetailPaymentHallsEN.aBookingHalls.Date;
                    aHallsEN.Cost = aInfoDetailPaymentHallsEN.aBookingHalls.Cost;
                    aHallsEN.PercentTax = aInfoDetailPaymentHallsEN.aBookingHalls.PercentTax;
                    aHallsEN.CostRef_Halls = aInfoDetailPaymentHallsEN.aBookingHalls.CostRef_Halls;
                    aHallsEN.TotalMoney = aPaymentHallsEN.GetMoneyHall(aInfoDetailPaymentHallsEN.aBookingHalls.ID);
                    aListHallsEN.Add(aHallsEN);

                    foreach (ServicesHallsEN items in aInfoDetailPaymentHallsEN.aListServicesHallsEN)
                    {
                        aServicesHallsEN = new ServicesHallsEN();
                        aServicesHallsEN.SkuHall = aHallsEN.Sku;
                        aServicesHallsEN.NameService = items.NameService;
                        aServicesHallsEN.Date = items.Date;
                        aServicesHallsEN.Quantity = items.Quantity;
                        aServicesHallsEN.Cost = items.Cost;
                        aServicesHallsEN.PercentTax = items.PercentTax;
                        aListServicesHallsEN.Add(aServicesHallsEN);
                    }

                }

                //danh sach hoi truong
                this.DetailReportHall.DataSource = aListHallsEN;
                colSkuHall.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Sku");
                colCreateDate.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Date", "{0:dd/MM/yyyy}");
                colBookingHallCost.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Cost", "{0:0,0}");
                colPercentTax.DataBindings.Add("Text", this.DetailReportHall.DataSource, "PercentTax");
                colPaymentMoneyHall.DataBindings.Add("Text", this.DetailReportHall.DataSource, "TotalMoney", "{0:0,0}");


                //danh sach dich vu su dung
                this.DetailReportService.DataSource = aListServicesHallsEN;
                colService_Sku.DataBindings.Add("Text", this.DetailReportService.DataSource, "SkuHall");
                colService_Name.DataBindings.Add("Text", this.DetailReportService.DataSource, "NameService");
                colService_Date.DataBindings.Add("Text", this.DetailReportService.DataSource, "Date", "{0:dd/MM/yyyy}");
                colService_Quantity.DataBindings.Add("Text", this.DetailReportService.DataSource, "Quantity", "{0:0,0}");
                colService_Cost.DataBindings.Add("Text", this.DetailReportService.DataSource, "Cost", "{0:0,0}");
                colService_PercentTax.DataBindings.Add("Text", this.DetailReportService.DataSource, "PercentTax");
                colService_Money.DataBindings.Add("Text", this.DetailReportService.DataSource, "Total", "{0:0,0}");

                //tong tien hoi truong truoc thue
                lblTotalMoneyHallBeforeTax.Text = String.Format("{0:0,0} (VND)", Convert.ToDecimal(this.aPaymentHallsEN.GetTotalMoneyHallBeforeTax()));
                //tong tien hoi truong sau thue
                lblTotalMoneyHallBehindTax.Text = String.Format("{0:0,0} (VND)", Convert.ToDecimal(this.aPaymentHallsEN.GetTotalMoneyHallBehindTax()));

                //tong tien dich vu hoi truong truoc thue
                lblTotalMoneyService_BookingHBeforeTax.Text = String.Format("{0:0,0} (VND)", Convert.ToDecimal(this.aPaymentHallsEN.GetTotalMoneyServiceHallBeforeTax()));
                //tong tien dich vu hoi truong sau thue
                lblTotalMoneyServices_BookingHBehindTax.Text = String.Format("{0:0,0} (VND)", Convert.ToDecimal(this.aPaymentHallsEN.GetTotalMoneyServiceHallBehindTax()));


                //tong tien bookingh

                decimal? moneyBookingHBeforeTax = Convert.ToDecimal(this.aPaymentHallsEN.GetTotalMoneyBookingHBeforeTax());
                decimal? moneyBookingHBehindTax = Convert.ToDecimal(this.aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                lblTotalMoneyBookingHBeforeTax.Text = String.Format("{0:0,0} (VND)", moneyBookingHBeforeTax);
                lblTotalMoneyBookingHBehindTax.Text = String.Format("{0:0,0} (VND)", moneyBookingHBehindTax);
                lblBookingMoney_BookingH.Text = String.Format("{0:0,0} (VND)", Convert.ToDecimal(this.aPaymentHallsEN.GetBookingMoney()));
                lblTotalBookingH.Text = String.Format("{0:0,0} (VND)", (moneyBookingHBehindTax - Convert.ToDecimal(this.aPaymentHallsEN.GetBookingMoney())));


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRpt_PaymentBookingHs.frmRpt_PaymentBookingHs\n" + ex.ToString());
            }

        }
    }
}

