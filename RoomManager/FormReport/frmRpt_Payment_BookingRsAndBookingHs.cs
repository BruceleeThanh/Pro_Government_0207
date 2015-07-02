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
    public partial class frmRpt_Payment_BookingRsAndBookingHs : XtraReport
    {
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        List<ServiceGroupEN> aListServicesGroupRoomEN = new List<ServiceGroupEN>();
        List<ServiceGroupEN> aListServicesGroupHallEN = new List<ServiceGroupEN>();

        List<ServiceUsedEN> aListServiceUsedRoom = new List<ServiceUsedEN>();
        List<ServiceUsedEN> aListServiceUsedHall = new List<ServiceUsedEN>();

        List<int> aListIDServicesGroupRoom = new List<int>();
        List<int> aListIDServicesGroupHall = new List<int>();

        public frmRpt_Payment_BookingRsAndBookingHs(NewPaymentEN aNewPaymentEN)
        {
            InitializeComponent();
            this.aNewPaymentEN = aNewPaymentEN;
            try
            {


                lblNumberVote.Text = Convert.ToString(this.aNewPaymentEN.IDBookingR);
                lblIIDBookingR.Text = Convert.ToString(this.aNewPaymentEN.IDBookingR);
                lblNameCustomer.Text = this.aNewPaymentEN.NameCustomer;
                lblGroup.Text = this.aNewPaymentEN.NameCustomerGroup;
                lblCompany.Text = this.aNewPaymentEN.NameCompany;
                lblTaxNumberCode.Text = this.aNewPaymentEN.TaxNumberCodeCompany;

                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

                #region Phòng

                aListServiceUsedRoom = this.aNewPaymentEN.GetAllServiceUsedInRoom();
                //Lấy List< IDServiceGroup>
                List<int> aTemp = new List<int>();
                int IDServiceGroup;
                foreach (ServiceUsedEN item in aListServiceUsedRoom)
                {
                    IDServiceGroup = new int();
                    IDServiceGroup = item.IDServiceGroup;
                    aTemp.Add(IDServiceGroup);
                }
                aListIDServicesGroupRoom = aTemp.Distinct().ToList();


                ServiceGroupEN aServicesGroupEN;
                ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();

                foreach (int item in aListIDServicesGroupRoom)
                {
                    aServicesGroupEN = new ServiceGroupEN();
                    aServicesGroupEN.IDServiceGroup = item;
                    aServicesGroupEN.TotalMoneyBeforeTax = this.GetTotalMoneyServiceGroupRoomBeforeTax(item);
                    aServicesGroupEN.TotalMoneyAfterTax = this.GetTotalMoneyServiceGroupRoomAfterTax(item);
                    aServicesGroupEN.DisplayMoneyTax = aNewPaymentEN.GetMoneyTax(this.GetTotalMoneyServiceGroupRoomBeforeTax(item), 10);
                    aServicesGroupEN.ServiceGroupName = aServiceGroupsBO.Sel_ByID(item).Name;
                    aListServicesGroupRoomEN.Add(aServicesGroupEN);
                }

                //danh sach phong
                this.DetailReport.DataSource = aNewPaymentEN.aListBookingRoomUsed;


                colSkuRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "RoomSku");
                colCheckIn.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckInActual", "{0:dd-MM-yyyy HH:mm}");
                colCheckOut.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckOutActual", "{0:dd-MM-yyyy HH:mm}");
                colBookingRoomCost.DataBindings.Add("Text", this.DetailReport.DataSource, "Cost", "{0:0,0}");
                colDateInUse.DataBindings.Add("Text", this.DetailReport.DataSource, "DateUsed", "{0:0,0}");
                colMoneyRoomBeforeTax.DataBindings.Add("Text", this.DetailReport.DataSource, "MoneyRoomBeforeTax", "{0:0,0}");
                colPercentTaxRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "DisplayMoneyTaxRoom", "{0:0,0}");
                colPaymentMoneyRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "MoneyRoom", "{0:0,0}");

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
                XRBinding aXRBindingDisplayMoneyTaxRoom = new XRBinding("Text", this.DetailReport.DataSource, "DisplayMoneyTaxRoom", "{0:0,0})");
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
                this.DetailReport2.DataSource = aListServicesGroupRoomEN;
                colNamServiceRoom.DataBindings.Add("Text", this.DetailReport2.DataSource, "ServiceGroupName");
                colTotalMoneyServiceRoomBeforeTax.DataBindings.Add("Text", this.DetailReport2.DataSource, "TotalMoneyBeforeTax", "{0:0,0}");
                colPercentTaxServiceRoom.DataBindings.Add("Text", this.DetailReport2.DataSource, "DisplayMoneyTax", "{0:0,0}");
                colTotalMoneyServiceRoomAfterTax.DataBindings.Add("Text", this.DetailReport2.DataSource, "TotalMoneyAfterTax", "{0:0,0}");

                XRSummary aXRSummaryTotalMoneyBeforeTax = new XRSummary();
                aXRSummaryTotalMoneyBeforeTax.Func = SummaryFunc.Sum;
                aXRSummaryTotalMoneyBeforeTax.Running = SummaryRunning.Group;
                aXRSummaryTotalMoneyBeforeTax.IgnoreNullValues = true;
                aXRSummaryTotalMoneyBeforeTax.FormatString = "{0:0,0}";
                lblSumMoneyServiceRoomsBeforeTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReport2.DataSource, "TotalMoneyBeforeTax", "{0:0,0}") });
                lblSumMoneyServiceRoomsBeforeTax.Summary = aXRSummaryTotalMoneyBeforeTax;

                XRSummary aXRSummaryDisplayMoneyTax = new XRSummary();
                aXRSummaryDisplayMoneyTax.Func = SummaryFunc.Sum;
                aXRSummaryDisplayMoneyTax.Running = SummaryRunning.Group;
                aXRSummaryDisplayMoneyTax.IgnoreNullValues = true;
                aXRSummaryDisplayMoneyTax.FormatString = "{0:0,0}";
                lblSumMoneyServiceRoomsTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReport2.DataSource, "DisplayMoneyTax", "{0:0,0}") });
                lblSumMoneyServiceRoomsTax.Summary = aXRSummaryDisplayMoneyTax;

                XRSummary aXRSummaryTotalMoneyAfterTax = new XRSummary();
                aXRSummaryTotalMoneyAfterTax.Func = SummaryFunc.Sum;
                aXRSummaryTotalMoneyAfterTax.Running = SummaryRunning.Group;
                aXRSummaryTotalMoneyAfterTax.IgnoreNullValues = true;
                aXRSummaryTotalMoneyAfterTax.FormatString = "{0:0,0}";
                lblSumMoneyServiceRoomsAfterTax.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", this.DetailReport2.DataSource, "TotalMoneyAfterTax", "{0:0,0}") });
                lblSumMoneyServiceRoomsAfterTax.Summary = aXRSummaryTotalMoneyAfterTax;               
               

                #endregion
                #region Hội trường
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
                decimal? beforTax = Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoneyBeforeTax());
                decimal? afterTax = Convert.ToDecimal(this.aNewPaymentEN.GetTotalMoney());
                decimal? bookingMoney = Convert.ToDecimal(this.aNewPaymentEN.BookingHMoney) + Convert.ToDecimal(this.aNewPaymentEN.BookingRMoney);
                              
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
                string TotalMoney_BookingRString = UppercaseFirst(StringUtility.ConvertDecimalToString(Convert.ToDecimal(afterTax - bookingMoney)));

                lblTotalMoneyString.Text = "(" + TotalMoney_BookingRString + ")";
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
        public decimal? GetTotalMoneyServiceGroupRoomBeforeTax(int IDServiceGroup)
        {
            decimal? TotalMoneyServiceGroupBeforeTax = 0;
            List<ServiceUsedEN> aTemp = aListServiceUsedRoom.Where(a => a.IDServiceGroup == IDServiceGroup).ToList();
            foreach (ServiceUsedEN item in aTemp)
            {
                decimal? cost = item.GetMoneyServiceBeforeTax();
                TotalMoneyServiceGroupBeforeTax = TotalMoneyServiceGroupBeforeTax + cost;
            }
            return TotalMoneyServiceGroupBeforeTax;
        }
        public decimal? GetTotalMoneyServiceGroupRoomAfterTax(int IDServiceGroup)
        {
            decimal? TotalMoneyServiceGroupAfterTax = 0;
            List<ServiceUsedEN> aTemp = aListServiceUsedRoom.Where(a => a.IDServiceGroup == IDServiceGroup).ToList();
            foreach (ServiceUsedEN item in aTemp)
            {
                decimal? cost = item.GetMoneyService();
                TotalMoneyServiceGroupAfterTax = TotalMoneyServiceGroupAfterTax + cost;
            }
            return TotalMoneyServiceGroupAfterTax;
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
