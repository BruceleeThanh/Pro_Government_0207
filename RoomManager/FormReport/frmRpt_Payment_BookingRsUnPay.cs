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

    public partial class frmRpt_Payment_BookingRsUnPay : XtraReport
    {
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        List<ServiceGroupEN> aListServicesGroupEN = new List<ServiceGroupEN>();
        List<ServiceUsedEN> aListServiceUsed = new List<ServiceUsedEN>();
        List<int> aListIDServicesGroup = new List<int>();

        public frmRpt_Payment_BookingRsUnPay(NewPaymentEN aNewPaymentEN)
        {
            InitializeComponent();
            this.aNewPaymentEN = aNewPaymentEN;

            try
            {
                //------------- Phong ------------------------

                lblNumberVote.Text = Convert.ToString(this.aNewPaymentEN.IDBookingR);
                lblIDBookingR.Text = Convert.ToString(this.aNewPaymentEN.IDBookingR);
                lblNameCustomer.Text = this.aNewPaymentEN.NameCustomer;
                lblGroup.Text = this.aNewPaymentEN.NameCustomerGroup;
                lblCompany.Text = this.aNewPaymentEN.NameCompany;
                lblTaxNumberCode.Text = this.aNewPaymentEN.TaxNumberCodeCompany;

                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

                aListServiceUsed = this.aNewPaymentEN.GetAllServiceUsedInRoom();
                //Lấy List< IDServiceGroup>
                List<int> aTemp = new List<int>();
                int IDServiceGroup;
                foreach (ServiceUsedEN item in aListServiceUsed)
                {
                    IDServiceGroup = new int();


                    IDServiceGroup = item.IDServiceGroup;
                    aTemp.Add(IDServiceGroup);
                }
                aListIDServicesGroup = aTemp.Distinct().ToList();



                ServiceGroupEN aServicesGroupEN;
                ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();


                foreach (int item in aListIDServicesGroup)
                {
                    aServicesGroupEN = new ServiceGroupEN();
                    aServicesGroupEN.IDServiceGroup = item;


                    aServicesGroupEN.TotalMoneyBeforeTax = this.GetTotalMoneyServiceGroupBeforeTax(item);
                    aServicesGroupEN.DisplayMoneyTax = aNewPaymentEN.GetMoneyTax(this.GetTotalMoneyServiceGroupBeforeTax(item), 10);
                    aServicesGroupEN.TotalMoneyAfterTax = this.GetTotalMoneyServiceGroupAfterTax(item);
                    aServicesGroupEN.ServiceGroupName = aServiceGroupsBO.Sel_ByID(item).Name;


                    aListServicesGroupEN.Add(aServicesGroupEN);
                }

                //danh sach phong
                this.DetailReport.DataSource = aNewPaymentEN.aListBookingRoomUsed;


                colSkuRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "RoomSku");
                colCheckIn.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckInActual", "{0:dd-MM-yyyy HH:mm}");
                if (aNewPaymentEN.Status_BookingR == 8 || aNewPaymentEN.Status_BookingR == 7)
                {
                    colCheckOut.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckOutActual", "{0:dd-MM-yyyy HH:mm}");
                }
                else
                {
                    colCheckOut.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckOutPlan", "{0:dd-MM-yyyy HH:mm}");

                }
                colBookingRoomCost.DataBindings.Add("Text", this.DetailReport.DataSource, "Cost", "{0:0,0.##}");
                colDateInUse.DataBindings.Add("Text", this.DetailReport.DataSource, "DateUsed", "{0:0,0.##}");
                colMoneyRoomBeforeTax.DataBindings.Add("Text", this.DetailReport.DataSource, "MoneyRoomBeforeTax", "{0:0,0}");
                colPercentTaxRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "DisplayMoneyTaxRoom", "{0:0,0}");
                colPaymentMoneyaRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "MoneyRoom", "{0:0,0}");

                ////tong tien phong truoc thue
                //lblSumMoneyRoomsBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetMoneyRoomsBeforeTax()));
                ////Tong tien thue
                //lblSumMoneyRoomTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetMoneyTax(this.aNewPaymentEN.GetMoneyRoomsBeforeTax(), 10)));
                ////tong tien phong sau thue
                //lblSumMoneyRoomsAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetMoneyRooms()));


                XRSummary aXRSummaryMoneyRoomBeforeTax = new XRSummary();
                aXRSummaryMoneyRoomBeforeTax.Func = SummaryFunc.Sum;
                aXRSummaryMoneyRoomBeforeTax.Running = SummaryRunning.Group;
                aXRSummaryMoneyRoomBeforeTax.IgnoreNullValues = true;
                aXRSummaryMoneyRoomBeforeTax.FormatString = "{0:0,0}";
                XRBinding aXRBindingMoneyRoomBeforeTax = new XRBinding("Text", this.DetailReport.DataSource, "MoneyRoomBeforeTax", "{0:0,0}");
                XRBinding[] listXRBindingMoneyRoomBeforeTax = new XRBinding[] { aXRBindingMoneyRoomBeforeTax };
                lblSumMoneyRoomsBeforeTax.DataBindings.AddRange(listXRBindingMoneyRoomBeforeTax);
                lblSumMoneyRoomsBeforeTax.Summary = aXRSummaryMoneyRoomBeforeTax;


                XRSummary aXRSummaryDisplayMoneyTaxRoom = new XRSummary();
                aXRSummaryDisplayMoneyTaxRoom.Func = SummaryFunc.Sum;
                aXRSummaryDisplayMoneyTaxRoom.Running = SummaryRunning.Group;
                aXRSummaryDisplayMoneyTaxRoom.IgnoreNullValues = true;
                aXRSummaryDisplayMoneyTaxRoom.FormatString = "{0:0,0}";
                XRBinding aXRBindingDisplayMoneyTaxRoom = new XRBinding("Text", this.DetailReport.DataSource, "DisplayMoneyTaxRoom", "{0:0,0}");
                XRBinding[] listXRBindingDisplayMoneyTaxRoom = new XRBinding[] { aXRBindingDisplayMoneyTaxRoom };
                lblSumMoneyRoomTax.DataBindings.AddRange(listXRBindingDisplayMoneyTaxRoom);
                lblSumMoneyRoomTax.Summary = aXRSummaryDisplayMoneyTaxRoom;


                XRSummary aXRSummaryMoneyRoom = new XRSummary();
                aXRSummaryMoneyRoom.Func = SummaryFunc.Sum;
                aXRSummaryMoneyRoom.Running = SummaryRunning.Group;
                aXRSummaryMoneyRoom.IgnoreNullValues = true;
                aXRSummaryMoneyRoom.FormatString = "{0:0,0}";
                XRBinding aXRBindingMoneyRoom = new XRBinding("Text", this.DetailReport.DataSource, "MoneyRoom", "{0:0,0}");
                XRBinding[] listXRBindingMoneyRoom = new XRBinding[] { aXRBindingMoneyRoom };
                lblSumMoneyRoomsAfterTax.DataBindings.AddRange(listXRBindingMoneyRoom);
                lblSumMoneyRoomsAfterTax.Summary = aXRSummaryMoneyRoom;




                //danh sach dich vu
                this.DetailReport2.DataSource = aListServicesGroupEN;
                colNamService.DataBindings.Add("Text", this.DetailReport2.DataSource, "ServiceGroupName");
                colTotalMoneyBeforeTax.DataBindings.Add("Text", this.DetailReport2.DataSource, "TotalMoneyBeforeTax", "{0:0,0}");
                colPercentTaxService.DataBindings.Add("Text", this.DetailReport2.DataSource, "DisplayMoneyTax", "{0:0,0}");
                colTotalMoneyServiceAfterTax.DataBindings.Add("Text", this.DetailReport2.DataSource, "TotalMoneyAfterTax", "{0:0,0}");

                ////tong tien dich vu truoc thue
                //lblSumMoneyService_BookingRBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyServiceUsedInRoomsBeforeTax()));
                ////Tong so tien thue
                //lblSumMoneyServiceTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetMoneyTax(this.aNewPaymentEN.GetTotalMoneyServiceUsedInRoomsBeforeTax(), 10)));
                ////tong tien dich vu sau thue
                //lblSumMoneyService_BookingRAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyServiceUsedInRooms()));

                XRSummary aXRSummaryTotalMoneyBeforeTax = new XRSummary();
                aXRSummaryTotalMoneyBeforeTax.Func = SummaryFunc.Sum;
                aXRSummaryTotalMoneyBeforeTax.Running = SummaryRunning.Group;
                aXRSummaryTotalMoneyBeforeTax.IgnoreNullValues = true;
                aXRSummaryTotalMoneyBeforeTax.FormatString = "{0:0,0}";
                lblSumMoneyService_BookingRBeforeTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReport2.DataSource, "TotalMoneyBeforeTax", "{0:0,0}") });
                lblSumMoneyService_BookingRBeforeTax.Summary = aXRSummaryTotalMoneyBeforeTax;

                XRSummary aXRSummaryDisplayMoneyTax = new XRSummary();
                aXRSummaryDisplayMoneyTax.Func = SummaryFunc.Sum;
                aXRSummaryDisplayMoneyTax.Running = SummaryRunning.Group;
                aXRSummaryDisplayMoneyTax.IgnoreNullValues = true;
                aXRSummaryDisplayMoneyTax.FormatString = "{0:0,0}";
                lblSumMoneyServiceTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReport2.DataSource, "DisplayMoneyTax", "{0:0,0}") });
                lblSumMoneyServiceTax.Summary = aXRSummaryDisplayMoneyTax;

                XRSummary aXRSummaryTotalMoneyAfterTax = new XRSummary();
                aXRSummaryTotalMoneyAfterTax.Func = SummaryFunc.Sum;
                aXRSummaryTotalMoneyAfterTax.Running = SummaryRunning.Group;
                aXRSummaryTotalMoneyAfterTax.IgnoreNullValues = true;
                aXRSummaryTotalMoneyAfterTax.FormatString = "{0:0,0}";
                lblSumMoneyService_BookingRAfterTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReport2.DataSource, "TotalMoneyAfterTax", "{0:0,0}") });
                lblSumMoneyService_BookingRAfterTax.Summary = aXRSummaryTotalMoneyAfterTax;

                //tong tien thanh toan truoc thue
                lblTotalMoneyBookingRBeforeTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyBeforeTax()));
                //tien thue
                lblTotalMoneyTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetMoneyTax(Convert.ToDecimal(this.aNewPaymentEN.GetMoneyRoomsBeforeTax()) + Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyServiceUsedInRoomsBeforeTax()), 10)));
                //tong tien thanh toan sau thue
                lblTotalMoneyBookingRAfterTax.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoney()));
                //So tien ung truoc
                lblBookingMoney_BookingR.Text = String.Format("{0:0,0}", Convert.ToDecimal(this.aNewPaymentEN.BookingRMoney));
                //so tien con lai can thanh toan
                lblTotalMoney_BookingR.Text = String.Format("{0:0,0}", (Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoney()) - Convert.ToDecimal(this.aNewPaymentEN.BookingRMoney)));
                string TotalMoney_BookingRString = UppercaseFirst(StringUtility.ConvertDecimalToString((Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoney()) - Convert.ToDecimal(this.aNewPaymentEN.BookingRMoney))));

                lblTotalMoney_BookingRString.Text = "(" + TotalMoney_BookingRString + ")";

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public decimal? GetTotalMoneyServiceGroupBeforeTax(int IDServiceGroup)
        {
            decimal? TotalMoneyServiceGroupBeforeTax = 0;
            List<ServiceUsedEN> aTemp = aListServiceUsed.Where(a => a.IDServiceGroup == IDServiceGroup).ToList();
            foreach (ServiceUsedEN item in aTemp)
            {
                decimal? cost = item.GetMoneyServiceBeforeTax();
                TotalMoneyServiceGroupBeforeTax = TotalMoneyServiceGroupBeforeTax + cost;
            }
            return TotalMoneyServiceGroupBeforeTax;
        }
        public decimal? GetTotalMoneyServiceGroupAfterTax(int IDServiceGroup)
        {
            decimal? TotalMoneyServiceGroupAfterTax = 0;
            List<ServiceUsedEN> aTemp = aListServiceUsed.Where(a => a.IDServiceGroup == IDServiceGroup).ToList();
            foreach (ServiceUsedEN item in aTemp)
            {
                decimal? cost = item.GetMoneyService();
                TotalMoneyServiceGroupAfterTax = TotalMoneyServiceGroupAfterTax + cost;
            }
            return TotalMoneyServiceGroupAfterTax;
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
