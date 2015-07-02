using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BussinessLogic;
using Entity;
using DataAccess;
using DevExpress.XtraRichEdit.API.Word;
using System.Linq;
using System.Globalization;

namespace RoomManager
{
    public partial class frmRpt_PaymentBookingHs : DevExpress.XtraReports.UI.XtraReport
    {
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        private NewPaymentHEN aNewPaymentHEN = new NewPaymentHEN();

        List<ServiceGroupEN> aListServicesGroupHallEN = new List<ServiceGroupEN>();      
        List<ServiceUsedEN> aListServiceUsedHall = new List<ServiceUsedEN>();       
        List<int> aListIDServicesGroupHall = new List<int>();
        ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
        public frmRpt_PaymentBookingHs(NewPaymentHEN aNewPaymentHEN)
        {
            InitializeComponent();
            this.aNewPaymentHEN = aNewPaymentHEN;
            try
            {
                //------------------------------- Hoi truong ---------------------

                lblNumberVote.Text = Convert.ToString(this.aNewPaymentHEN.IDBookingH);
                lblIDBookingH.Text = Convert.ToString(this.aNewPaymentHEN.IDBookingH);
                lblNameCustomer.Text = this.aNewPaymentHEN.NameCustomer;
                lblGroup.Text = this.aNewPaymentHEN.NameCustomerGroup;
                lblCompany.Text = this.aNewPaymentHEN.NameCompany;
                lblTaxNumberCode.Text = this.aNewPaymentHEN.TaxNumberCodeCompany;
                lblSubject.Text = this.aNewPaymentHEN.Subject;

                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

                #region Truyền thông tin hội trường
                aListServiceUsedHall = this.aNewPaymentHEN.GetAllServiceUsedInHall();
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
                    aServicesGroupHallEN.DisplayMoneyTax = aNewPaymentHEN.GetMoneyTax(this.GetTotalMoneyServiceGroupHallBeforeTax(item), 10);
                    aServicesGroupHallEN.ServiceGroupName = aServiceGroupsBO.Sel_ByID(item).Name;
                    aListServicesGroupHallEN.Add(aServicesGroupHallEN);
                }

                //danh sach hoi truong
                this.DetailReportHall.DataSource = aNewPaymentHEN.aListBookingHallUsed;
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
                lblSumMoneyHallsBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentHEN.GetOnlyMoneyHallsBeforeTax()));
                //tong tien hoi truong sau thue
                lblSumMoneyHallsAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentHEN.GetOnlyMoneyHalls()));

                //tong tien dich vu hoi truong truoc thue
                lblSumMoneyServiceHallsBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentHEN.GetTotalMoneyServiceUsedInHallsBeforeTax()));
                //tong tien dich vu hoi truong sau thue
                lblSumMoneyServiceHallsAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentHEN.GetTotalMoneyServiceUsedInHalls()));


                //Tong tien hoa don can thanh toan
                decimal? beforTax = Convert.ToDecimal(this.aNewPaymentHEN.GetMoneyHallsBeforeTax());
                decimal? afterTax = Convert.ToDecimal(this.aNewPaymentHEN.GetMoneyHalls());
                decimal? bookingMoney = Convert.ToDecimal(this.aNewPaymentHEN.BookingHMoney);


                //tong tien thanh toan truoc thue
                lblTotalMoneyBeforeTax.Text = String.Format("{0:0,0}", beforTax);
                //tien thue
                lblTotalMoneyTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentHEN.GetMoneyTax(beforTax, 10)));
                //tong tien thanh toan sau thue
                lblTotalMoneyAfterTax.Text = String.Format("{0:0,0}", afterTax);
                //So tien ung truoc
                lblBookingMoney.Text = String.Format("{0:0,0}", bookingMoney);
                //so tien con lai can thanh toan
                lblTotalMoney.Text = String.Format("{0:0,0}", afterTax - bookingMoney);
                string TotalMoney_BookingHString = UppercaseFirst(Library.StringUtility.ConvertDecimalToString(Convert.ToDecimal(afterTax - bookingMoney)));

                lblTotalMoneyString.Text = "(" + TotalMoney_BookingHString + ")";
                #endregion
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        public frmRpt_PaymentBookingHs(NewPaymentEN aNewPaymentEN)
        {
            InitializeComponent();
            this.aNewPaymentEN = aNewPaymentEN;
            try
            {
                //------------------------------- Hoi truong ---------------------

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

                #region Truyền thông tin hội trường
                aListServiceUsedHall = this.aNewPaymentEN.GetAllServiceUsedInHall();
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
                lblSumMoneyHallsBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetOnlyMoneyHallsBeforeTax()));
                //tong tien hoi truong sau thue
                lblSumMoneyHallsAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetOnlyMoneyHalls()));

                //tong tien dich vu hoi truong truoc thue
                lblSumMoneyServiceHallsBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyServiceUsedInHallsBeforeTax()));
                //tong tien dich vu hoi truong sau thue
                lblSumMoneyServiceHallsAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyServiceUsedInHalls()));
                     

                //Tong tien hoa don can thanh toan
                decimal? beforTax =  Convert.ToDecimal(this.aNewPaymentEN.GetMoneyHallsBeforeTax());
                decimal? afterTax = Convert.ToDecimal(this.aNewPaymentEN.GetMoneyHalls()) ;
                decimal? bookingMoney = Convert.ToDecimal(this.aNewPaymentEN.BookingHMoney);

                
                //tong tien thanh toan truoc thue
                lblTotalMoneyBeforeTax.Text = String.Format("{0:0,0}", beforTax);
                //tien thue
                lblTotalMoneyTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetMoneyTax(beforTax, 10)));
                //tong tien thanh toan sau thue
                lblTotalMoneyAfterTax.Text = String.Format("{0:0,0}", afterTax);
                //So tien ung truoc
                lblBookingMoney.Text = String.Format("{0:0,0}", bookingMoney);
                //so tien con lai can thanh toan
                lblTotalMoney.Text = String.Format("{0:0,0}", afterTax - bookingMoney);
                string TotalMoney_BookingHString = UppercaseFirst(Library.StringUtility.ConvertDecimalToString(Convert.ToDecimal(afterTax - bookingMoney)));

                lblTotalMoneyString.Text = "(" + TotalMoney_BookingHString + ")";
                #endregion
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            else
            {
                return char.ToUpper(s[0]) + s.Substring(1);
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
