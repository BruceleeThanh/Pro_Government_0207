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
using System.Linq;
using System.Globalization;
namespace RoomManager
{
    public partial class frmRpt_SplitPayment_BookingHs : DevExpress.XtraReports.UI.XtraReport
    {
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        List<ServiceUsedEN> aListServiceUsedHall = new List<ServiceUsedEN>();
        List<ServiceGroupEN> aListServicesGroupHallEN = new List<ServiceGroupEN>();  

        List<int> aListIDServicesGroupHall = new List<int>();
        ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();

        private int IndexSub = 0;

        public frmRpt_SplitPayment_BookingHs(NewPaymentEN aNewPaymentEN, int IndexSub)
        {
            InitializeComponent();
            this.aNewPaymentEN = aNewPaymentEN;
            this.IndexSub = IndexSub;
            try
            {


                lblNumberVote.Text = Convert.ToString(this.aNewPaymentEN.IDBookingH);
                lblIDBookingH.Text = Convert.ToString(this.aNewPaymentEN.IDBookingH);
                lblNameCustomer.Text = this.aNewPaymentEN.NameCustomer;
                lblGroup.Text = this.aNewPaymentEN.NameCustomerGroup;
                lblCompany.Text = this.aNewPaymentEN.NameCompany;
                lblTaxNumberCode.Text = this.aNewPaymentEN.TaxNumberCodeCompany;

                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

               //Lấy dữ liệu

                List<BookingHallUsedEN> aListBookingHallUsedEN = new List<BookingHallUsedEN>();
                aListBookingHallUsedEN = this.aNewPaymentEN.aListBookingHallUsed.Where(r => r.IndexSubPayment == this.IndexSub).OrderBy(r => r.HallSku).ToList();
                aListBookingHallUsedEN.Count();             

                aListServiceUsedHall = this.aNewPaymentEN.GetAllServiceUsedInHall().Where(r => r.IndexSubPayment == this.IndexSub).OrderBy(r => r.Sku).ToList();
                //Lấy List< IDServiceGroup>
                List<int> aTemp1 = new List<int>();
                int IDServiceGroupHall;
                foreach (ServiceUsedEN item in aListServiceUsedHall)
                {
                    IDServiceGroupHall = new int();
                    IDServiceGroupHall = item.IDServiceGroup;
                    aTemp1.Add(IDServiceGroupHall);
                }
                aListIDServicesGroupHall = aTemp1.Distinct().ToList();
                ServiceGroupEN aServicesGroupHallEN;
                foreach (int item in aListIDServicesGroupHall)
                {
                    aServicesGroupHallEN = new ServiceGroupEN();
                    aServicesGroupHallEN.IDServiceGroup = item;
                    aServicesGroupHallEN.TotalMoneyBeforeTax = this.GetTotalMoneyServiceGroupHallBeforeTax(item);
                    aServicesGroupHallEN.TotalMoneyAfterTax = this.GetTotalMoneyServiceGroupHallAfterTax(item);
                    aServicesGroupHallEN.DisplayMoneyTax = aNewPaymentEN.GetMoneyTax(this.GetTotalMoneyServiceGroupHallBeforeTax(item), 10);
                    aServicesGroupHallEN.ServiceGroupName = aServiceGroupsBO.Sel_ByID(item).Name;
                    aListServicesGroupHallEN.Add(aServicesGroupHallEN);
                }
                decimal? sumMoneyHallBeforeTax = aListBookingHallUsedEN.Sum(r => r.GetMoneyHallBeforeTax());
                decimal? SumMoneyTaxHall = aListBookingHallUsedEN.Sum(r => r.GetTotalMoneyHall());
                decimal? sumMoneyHallAfterTax = aListBookingHallUsedEN.Sum(r => r.GetTotalMoneyHall());


                decimal? sumMoneyServiceHallBeforeTax = aListServicesGroupHallEN.Sum(s => s.TotalMoneyBeforeTax);
                decimal? sumMoneyTaxServices = aListServicesGroupHallEN.Sum(s => s.DisplayMoneyTax);
                decimal? sumMoneyServiceHallAfterTax = aListServicesGroupHallEN.Sum(s => s.TotalMoneyAfterTax);

                //Tong tien hoa don can thanh toan
                decimal? beforTax = sumMoneyHallBeforeTax + sumMoneyServiceHallBeforeTax;
                decimal? afterTax = sumMoneyHallAfterTax + sumMoneyServiceHallAfterTax;
                decimal? bookingMoney = Convert.ToDecimal(this.aNewPaymentEN.BookingHMoney);

                                //danh sach hoi truong
                this.DetailReportHall.DataSource = aNewPaymentEN.aListBookingHallUsed;
                colSkuHall.DataBindings.Add("Text", this.DetailReportHall.DataSource, "HallSku");
                colCreateDate.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Date", "{0:dd/MM/yyyy}");
                colBookingHallCost.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Cost", "{0:0,0}");
                colPercentTax.DataBindings.Add("Text", this.DetailReportHall.DataSource, "DisplayMoneyTaxHall", "{0:0,0}");
                colPaymentMoneyHall.DataBindings.Add("Text", this.DetailReportHall.DataSource, "MoneyHall", "{0:0,0}");

                XRSummary aXRSummaryDisplayMoneyTaxHall = new XRSummary();
                aXRSummaryDisplayMoneyTaxHall.Func = SummaryFunc.Sum;
                aXRSummaryDisplayMoneyTaxHall.Running = SummaryRunning.Group;
                aXRSummaryDisplayMoneyTaxHall.IgnoreNullValues = true;
                aXRSummaryDisplayMoneyTaxHall.FormatString = "{0:0,0}";
                XRBinding aXRBindingDisplayMoneyTaxHall = new XRBinding("Text", this.DetailReportHall.DataSource, "DisplayMoneyTaxHall", "{0:0,0}");
                XRBinding[] listXRBindingDisplayMoneyTaxHall = new XRBinding[] { aXRBindingDisplayMoneyTaxHall };
                lblSumMoneyHallsTax.DataBindings.AddRange(listXRBindingDisplayMoneyTaxHall);
                lblSumMoneyHallsTax.Summary = aXRSummaryDisplayMoneyTaxHall;

                //danh sach dich vu su dung
                this.DetailReportService.DataSource = aListServicesGroupHallEN;
                colNamServiceHall.DataBindings.Add("Text", this.DetailReportService.DataSource, "ServiceGroupName");
                colTotalMoneyServiceHallBeforeTax.DataBindings.Add("Text", this.DetailReportService.DataSource, "TotalMoneyBeforeTax", "{0:0,0}");
                colPercentTaxServiceHall.DataBindings.Add("Text", this.DetailReportService.DataSource, "DisplayMoneyTax", "{0:0,0}");

                colTotalMoneyServiceHallAfterTax.DataBindings.Add("Text", this.DetailReportService.DataSource, "TotalMoneyAfterTax", "{0:0,0}");

                XRSummary aXRSummaryDisplayMoneyServiceHallTax = new XRSummary();
                aXRSummaryDisplayMoneyServiceHallTax.Func = SummaryFunc.Sum;
                aXRSummaryDisplayMoneyServiceHallTax.Running = SummaryRunning.Group;
                aXRSummaryDisplayMoneyServiceHallTax.IgnoreNullValues = true;
                aXRSummaryDisplayMoneyServiceHallTax.FormatString = "{0:0,0}";
                lblSumMoneyServiceHallsTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReportService.DataSource, "DisplayMoneyTax", "{0:0,0}") });
                lblSumMoneyServiceHallsTax.Summary = aXRSummaryDisplayMoneyServiceHallTax;

                //tong tien hoi truong truoc thue
                lblSumMoneyHallsBeforeTax.Text = String.Format("{0:0,0}",sumMoneyHallBeforeTax);
                //tong tien hoi truong sau thue
                lblSumMoneyHallsAfterTax.Text = String.Format("{0:0,0}", sumMoneyHallAfterTax);

                //tong tien dich vu hoi truong truoc thue
                lblSumMoneyServiceHallsBeforeTax.Text = String.Format("{0:0,0}", sumMoneyServiceHallBeforeTax);
                //tong tien dich vu hoi truong sau thue
                lblSumMoneyServiceHallsAfterTax.Text = String.Format("{0:0,0}", sumMoneyServiceHallAfterTax);
                              


                //tong tien thanh toan truoc thue
                lblTotalMoneyBeforeTax.Text = String.Format("{0:0,0}", beforTax);
                //tien thue
                lblTotalMoneyTax.Text = String.Format("{0:0,0}", sumMoneyTaxServices+SumMoneyTaxHall);
                //tong tien thanh toan sau thue
                lblTotalMoneyAfterTax.Text = String.Format("{0:0,0}", afterTax);
                //So tien ung truoc
                lblBookingMoney.Text = String.Format("{0:0,0}", bookingMoney);
                //so tien con lai can thanh toan
                lblTotalMoney.Text = String.Format("{0:0,0}", afterTax - bookingMoney);
                string TotalMoney_BookingHString = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Library.StringUtility.ConvertDecimalToString(Convert.ToDecimal(afterTax - bookingMoney)));

                lblTotalMoneyString.Text = "(" + TotalMoney_BookingHString + ")";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        public decimal? GetTotalMoneyServiceGroupHallBeforeTax(int IDServiceGroup)
        {
            decimal? TotalMoneyServiceGroupBeforeTax = 0;
            List<ServiceUsedEN> aTemp = aListServiceUsedHall.Where(a => a.IDServiceGroup == IDServiceGroup).ToList();
            foreach (ServiceUsedEN item in aTemp)
            {
                decimal? cost = item.GetMoneyServiceBeforeTax();
                TotalMoneyServiceGroupBeforeTax = TotalMoneyServiceGroupBeforeTax + cost;
            }
            return TotalMoneyServiceGroupBeforeTax;
        }
        public decimal? GetTotalMoneyServiceGroupHallAfterTax(int IDServiceGroup)
        {
            decimal? TotalMoneyServiceGroupAfterTax = 0;
            List<ServiceUsedEN> aTemp = aListServiceUsedHall.Where(a => a.IDServiceGroup == IDServiceGroup).ToList();
            foreach (ServiceUsedEN item in aTemp)
            {
                decimal? cost = item.GetMoneyService();
                TotalMoneyServiceGroupAfterTax = TotalMoneyServiceGroupAfterTax + cost;
            }
            return TotalMoneyServiceGroupAfterTax;
        }
    }
}

