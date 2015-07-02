using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Entity;
using System.Collections.Generic;

namespace RoomManager
{
    public partial class frmRpt_Revenues : DevExpress.XtraReports.UI.XtraReport
    {
        public frmRpt_Revenues(List<AllBookingEN> aListAllBookingEN, DateTime From,DateTime To,
            Nullable<decimal> SumServiceHalls1_NotTax, Nullable<decimal> SumServiceHalls2_NotTax, Nullable<decimal> SumServiceHalls3_NotTax,
            Nullable<decimal> SumServiceRooms1_NotTax, Nullable<decimal> SumServiceRooms2_NotTax, Nullable<decimal> SumServiceRooms3_NotTax)
        {
            InitializeComponent();
            lblDateNow.Text = DateTime.Now.Day.ToString();
            lblMonthNow.Text = DateTime.Now.Month.ToString();
            lblYearNow.Text = DateTime.Now.Year.ToString();
            lblFrom.Text = From.ToShortDateString();
            lblTo.Text = To.ToShortDateString();
            // Load data tờ thứ 1
            DetailReport.DataSource = aListAllBookingEN;
            cellID.DataBindings.Add("Text", this.DetailReport.DataSource, "ID");
            cellDatePay.DataBindings.Add("Text", this.DetailReport.DataSource, "DatePay","{0:dd/MM}");
            cellInvoiceNumber.DataBindings.Add("Text", this.DetailReport.DataSource, "InvoiceNumber");
            cellInvoiceDate.DataBindings.Add("Text", this.DetailReport.DataSource, "InvoiceDate");
            cellStatusPay.DataBindings.Add("Text", this.DetailReport.DataSource, "StatusPayDisplay");
            cellSubject.DataBindings.Add("Text", this.DetailReport.DataSource, "Subject");
            cellTotalMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "TotalMoney", "{0:#,#}");
            cellTotalMoneyBeforeTax.DataBindings.Add("Text", this.DetailReport.DataSource, "TotalMoneyBeforeTax","{0:#,#}");
            cellTax.DataBindings.Add("Text", this.DetailReport.DataSource, "Tax", "{0:#,#}");
            cellRoomsInvoiceNotTax.DataBindings.Add("Text", this.DetailReport.DataSource, "RoomsInvoiceNotTax", "{0:#,#}");
            cellHallsInvoiceNotTax.DataBindings.Add("Text", this.DetailReport.DataSource, "HallsInvoiceNotTax", "{0:#,#}");
            //Load data tính tổng
            cellSumTotalMoney.DataBindings.Add("Text", this.DetailReport.DataSource, "TotalMoney");           
            cellSumTotalMoneyBeforeTax.DataBindings.Add("Text", this.DetailReport.DataSource, "TotalMoneyBeforeTax");
            cellSumTax.DataBindings.Add("Text", this.DetailReport.DataSource, "Tax");
            cellSumRoomsInvoiceNotTax.DataBindings.Add("Text", this.DetailReport.DataSource, "RoomsInvoiceNotTax");
            cellSumHallsInvoiceNotTax.DataBindings.Add("Text", this.DetailReport.DataSource, "HallsInvoiceNotTax");

            // Load data tờ thứ 1
            DetailReport1.DataSource = aListAllBookingEN;
            cellServiceHalls1_NotTax.DataBindings.Add("Text", this.DetailReport1.DataSource, "ServiceHalls1_NotTax", "{0:#,#}");
            cellServiceHalls2_NotTax.DataBindings.Add("Text", this.DetailReport1.DataSource, "ServiceHalls2_NotTax", "{0:#,#}");
            cellServiceHalls3_NotTax.DataBindings.Add("Text", this.DetailReport1.DataSource, "ServiceHalls3_NotTax", "{0:#,#}");
            cellServiceRooms1_NotTax.DataBindings.Add("Text", this.DetailReport1.DataSource, "ServiceRooms1_NotTax", "{0:#,#}");
            cellServiceRooms2_NotTax.DataBindings.Add("Text", this.DetailReport1.DataSource, "ServiceRooms2_NotTax", "{0:#,#}");
            cellServiceRooms3_NotTax.DataBindings.Add("Text", this.DetailReport1.DataSource, "ServiceRooms3_NotTax", "{0:#,#}");
         
            //Load data tính tổng
            lblSumServiceHalls1_NotTax.Text = Convert.ToDecimal(SumServiceHalls1_NotTax).ToString("#,#");
            lblSumServiceHalls2_NotTax.Text = Convert.ToDecimal(SumServiceHalls2_NotTax).ToString("#,#");
            lblSumServiceRooms1_NotTax.Text = Convert.ToDecimal(SumServiceRooms1_NotTax).ToString("#,#");
            lblSumServiceRooms2_NotTax.Text = Convert.ToDecimal(SumServiceRooms2_NotTax).ToString("#,#");
            lblSumServiceRooms3_NotTax.Text = Convert.ToDecimal(SumServiceRooms3_NotTax).ToString("#,#");
            c.Text = Convert.ToDecimal(SumServiceHalls3_NotTax).ToString("#,#");
        }

    }
}
