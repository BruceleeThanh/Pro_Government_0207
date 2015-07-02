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
using Library;
using System.Globalization;


namespace RoomManager
{
    public partial class frmRpt_GroupPayment_Rs : DevExpress.XtraReports.UI.XtraReport
    {
        decimal TotalServiceMoney, TotalMoneyBeforeTax = 0;
        List<RptPaymentStyle1_ForPrint> aListData = null;
        public frmRpt_GroupPayment_Rs(List<RptPaymentStyle1_ForPrint> aListData,string CompanyName, string Address, string NameCustomerGroup,string InvoiceNumber
            , DateTime FirstDate, DateTime LastDate, decimal? BookingHMoney, decimal? BookingRMoney, int IDBookingR)
        {
            InitializeComponent();

            this.aListData = aListData;
            foreach (RptPaymentStyle1_ForPrint aItem in aListData)
            {
                TotalServiceMoney = TotalServiceMoney + aItem.TotalServiceMoney;
                TotalMoneyBeforeTax = TotalMoneyBeforeTax + aItem.TotalMoney;
                aItem.Room_Fee = aItem.Room_Fee + aItem.Hall_Fee;  // Gộp 2 cột
            }
            //Truyền dữ liệu cho Detail
            lblCompanyName.Text = CompanyName;
            lblAddress.Text = Address;
            lblCustomerGroupName.Text = NameCustomerGroup;
   

            lblCheckIn.Text = FirstDate.ToString("dd-MM-yyyy");
            lblCheckOut.Text = LastDate.ToString("dd-MM-yyyy");

            BookingRs aBookingRs = new BookingRs();
            aBookingRs = (new BookingRsBO()).Select_ByID(IDBookingR);

            lblIDBookingR.Text = IDBookingR.ToString();
            lblInvoiceNumber.Text = aBookingRs.InvoiceNumber;
            lblInvoiceDate.Text = aBookingRs.InvoiceDate.GetValueOrDefault().Date.ToShortDateString();
            lbAcceptDate.Text = aBookingRs.AcceptDate.GetValueOrDefault().Date.ToShortDateString();



            this.DetailReport.DataSource = this.aListData;
            colDate.DataBindings.Add("Text", this.DetailReport.DataSource, "Date", "{0:dd-MM}");
            colDescription.DataBindings.Add("Text", this.DetailReport.DataSource, "Note");
            colNumberCus.DataBindings.Add("Text", this.DetailReport.DataSource, "CountCustomerInGroup");
            colMoneyRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "Room_Fee", "{0:0,0}");
            colTotalARoom.DataBindings.Add("Text", this.DetailReport.DataSource, "TotalMoney", "{0:0,0}");
           // colHallMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "Hall_Fee", "{0:0,0}");
            colMealMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "MealMoney", "{0:0,0}");
            colDrinkMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "DrinkMoney", "{0:0,0}");
            colRoomServiceMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "RoomServiceMoney", "{0:0,0}");
            colOtherMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "OtherMoney", "{0:0,0}");



            colMoneyService.Text = TotalServiceMoney.ToString("0,0");
            colMoneyBeforeTax.Text = TotalMoneyBeforeTax.ToString("0,0");
            colMoneyTax.Text = (TotalMoneyBeforeTax * 10 / 100).ToString("0,0");
            colMoneyAfterTax.Text = (TotalMoneyBeforeTax * 110 / 100).ToString("0,0");
            colBookingMoney.Text = Convert.ToDecimal(BookingHMoney + BookingHMoney).ToString("0,0");
            colTotalMoneyPay.Text = ((TotalMoneyBeforeTax * 110 / 100) - Convert.ToDecimal(BookingHMoney + BookingHMoney)).ToString("0,0");
            string TotalMoney_String = UppercaseFirst(StringUtility.ConvertDecimalToString((TotalMoneyBeforeTax * 110 / 100) - Convert.ToDecimal(BookingHMoney + BookingHMoney)));
            lblConvertToString.Text = TotalMoney_String;

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();
            
            //--------------Tính tổng---------------------------------
            XRSummary aXRSummaryMoney = new XRSummary();
            aXRSummaryMoney.Func = SummaryFunc.Sum;
            aXRSummaryMoney.Running = SummaryRunning.Group;
            aXRSummaryMoney.IgnoreNullValues = true;
            aXRSummaryMoney.FormatString = "{0:0,0}";
            XRBinding aXRBindingMoney = new XRBinding("Text", this.DetailReport.DataSource, "TotalMoney", "{0:0,0}");
            XRBinding[] listXRBindingMoney = new XRBinding[] { aXRBindingMoney };
            colSumTotalMoney.DataBindings.AddRange(listXRBindingMoney);
            colSumTotalMoney.Summary = aXRSummaryMoney;

            XRSummary aXRSumDrinkMoney = new XRSummary();
            aXRSumDrinkMoney.Func = SummaryFunc.Sum;
            aXRSumDrinkMoney.Running = SummaryRunning.Group;
            aXRSumDrinkMoney.IgnoreNullValues = true;
            aXRSumDrinkMoney.FormatString = "{0:0,0}";
            XRBinding aXRBinding = new XRBinding("Text", this.DetailReport.DataSource, "DrinkMoney", "{0:0,0}");
            XRBinding[] aList_aXRBinding = new XRBinding[] { aXRBinding };
            colSumDrinkMoney.DataBindings.AddRange(aList_aXRBinding);
            colSumDrinkMoney.Summary = aXRSumDrinkMoney;

            //XRSummary aXRSumHallMoney = new XRSummary();
            //aXRSumHallMoney.Func = SummaryFunc.Sum;
            //aXRSumHallMoney.Running = SummaryRunning.Group;
            //aXRSumHallMoney.IgnoreNullValues = true;
            //aXRSumHallMoney.FormatString = "{0:0,0}";
            //XRBinding aXRBinding1 = new XRBinding("Text", this.DetailReport.DataSource, "Hall_Fee", "{0:0,0}");
            //XRBinding[] aList_aXRBinding1 = new XRBinding[] { aXRBinding1 };
            //colSumHallMoney.DataBindings.AddRange(aList_aXRBinding1);
            //colSumHallMoney.Summary = aXRSumHallMoney;

            XRSummary aXRSumMealMoney = new XRSummary();
            aXRSumMealMoney.Func = SummaryFunc.Sum;
            aXRSumMealMoney.Running = SummaryRunning.Group;
            aXRSumMealMoney.IgnoreNullValues = true;
            aXRSumMealMoney.FormatString = "{0:0,0}";
            XRBinding aXRBinding2 = new XRBinding("Text", this.DetailReport.DataSource, "MealMoney", "{0:0,0}");
            XRBinding[] aList_aXRBinding2 = new XRBinding[] { aXRBinding2 };
            colSumMealMoney.DataBindings.AddRange(aList_aXRBinding2);
            colSumMealMoney.Summary = aXRSumMealMoney;

            XRSummary aXRSumMoneyRoom = new XRSummary();
            aXRSumMoneyRoom.Func = SummaryFunc.Sum;
            aXRSumMoneyRoom.Running = SummaryRunning.Group;
            aXRSumMoneyRoom.IgnoreNullValues = true;
            aXRSumMoneyRoom.FormatString = "{0:0,0}";
            XRBinding aXRBinding3 = new XRBinding("Text", this.DetailReport.DataSource, "Room_Fee", "{0:0,0}");
            XRBinding[] aList_aXRBinding3 = new XRBinding[] { aXRBinding3 };
            colSumMoneyRoom.DataBindings.AddRange(aList_aXRBinding3);
            colSumMoneyRoom.Summary = aXRSumMoneyRoom;

          


            XRSummary aXRSumOtherMoney = new XRSummary();
            aXRSumOtherMoney.Func = SummaryFunc.Sum;
            aXRSumOtherMoney.Running = SummaryRunning.Group;
            aXRSumOtherMoney.IgnoreNullValues = true;
            aXRSumOtherMoney.FormatString = "{0:0,0}";
            XRBinding aXRBinding4 = new XRBinding("Text", this.DetailReport.DataSource, "OtherMoney", "{0:0,0}");
            XRBinding[] aList_aXRBinding4 = new XRBinding[] { aXRBinding4 };
            colSumOtherMoney.DataBindings.AddRange(aList_aXRBinding4);
            colSumOtherMoney.Summary = aXRSumOtherMoney;


            XRSummary aXRSumRoomServiceMoney = new XRSummary();
            aXRSumRoomServiceMoney.Func = SummaryFunc.Sum;
            aXRSumRoomServiceMoney.Running = SummaryRunning.Group;
            aXRSumRoomServiceMoney.IgnoreNullValues = true;
            aXRSumRoomServiceMoney.FormatString = "{0:0,0}";
            XRBinding aXRBinding5 = new XRBinding("Text", this.DetailReport.DataSource, "RoomServiceMoney", "{0:0,0}");
            XRBinding[] aList_aXRBinding5 = new XRBinding[] { aXRBinding5 };
            colSumRoomServiceMoney.DataBindings.AddRange(aList_aXRBinding5);
            colSumRoomServiceMoney.Summary = aXRSumRoomServiceMoney;



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
    }
}
