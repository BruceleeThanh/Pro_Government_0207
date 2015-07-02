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
using Library;


namespace RoomManager
{
    public partial class frmRpt_SplitPayment_BookingRs : XtraReport
    {
        private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        List<ServiceGroupEN> aListServicesGroupEN = new List<ServiceGroupEN>();
        List<ServiceUsedEN> aListServiceUsed = new List<ServiceUsedEN>();
        List<int> aListIDServicesGroup = new List<int>();


        private int IndexSub = 0;
        public frmRpt_SplitPayment_BookingRs(NewPaymentEN aNewPaymentEN,int IndexSub)
        {
            InitializeComponent();
            this.aNewPaymentEN = aNewPaymentEN;
            this.IndexSub = IndexSub;
            try
            {
                lblNumberVote.Text = Convert.ToString(this.aNewPaymentEN.IDBookingR);
                lblIIDBookingR.Text = Convert.ToString(this.aNewPaymentEN.IDBookingR);
                lblNameCustomer.Text = aNewPaymentEN.NameCustomer;
                lblGroup.Text = aNewPaymentEN.NameCustomerGroup;
                lblCompany.Text =aNewPaymentEN.NameCompany;
                lblTaxNumberCode.Text =aNewPaymentEN.TaxNumberCodeCompany;

                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

                //------------- Phong ------------------------
                List<BookingRoomUsedEN> aListBookingRoomUsedEN = new List<BookingRoomUsedEN>();
                aListBookingRoomUsedEN = aNewPaymentEN.aListBookingRoomUsed.Where(r => r.IndexSubPayment == this.IndexSub).OrderBy(r => r.RoomSku).ToList();


                aListServiceUsed = aNewPaymentEN.GetAllServiceUsedInRoom().Where(r => r.IndexSubPayment == this.IndexSub).OrderBy(r => r.Sku).ToList();
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
                
                decimal? sumMoneyRoomBeforeTax = aListBookingRoomUsedEN.Sum(r => r.GetOnlyMoneyRoomBeforeTax());
                decimal? SumMoneyTaxRoom = aListBookingRoomUsedEN.Sum(r => r.GetOnlyMoneyRoom());
                decimal? sumMoneyRoomAfterTax = aListBookingRoomUsedEN.Sum(r => r.GetOnlyMoneyRoom());


                decimal? sumMoneyServiceRoomBeforeTax = aListServicesGroupEN.Sum(s => s.TotalMoneyBeforeTax);
                decimal? sumMoneyTaxServices = aListServicesGroupEN.Sum(s => s.DisplayMoneyTax);
                decimal? sumMoneyServiceRoomAfterTax = aListServicesGroupEN.Sum(s => s.TotalMoneyAfterTax);



                decimal? BookingMoneyR = 0;         

                //danh sach phong
                this.DetailReport.DataSource = aListBookingRoomUsedEN;
                colSkuRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "RoomSku");
                colCheckIn.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckInActual", "{0:dd-MM-yyyy HH:mm}");
                colCheckOut.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckOutActual", "{0:dd-MM-yyyy HH:mm}");
                colBookingRoomCost.DataBindings.Add("Text", this.DetailReport.DataSource, "Cost", "{0:0,0.##}");
                colDateInUse.DataBindings.Add("Text", this.DetailReport.DataSource, "DateUsed", "{0:0,0.##}");
                colMoneyRoomBeforeTax.DataBindings.Add("Text", this.DetailReport.DataSource, "MoneyRoomBeforeTax", "{0:0,0}");
                colPercentTaxRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "DisplayMoneyTaxRoom", "{0:0,0}");
                colPaymentMoneyaRoom.DataBindings.Add("Text", this.DetailReport.DataSource, "MoneyRoom", "{0:0,0}");

                //tong tien phong truoc thue
                lblSumMoneyRoomsBeforeTax.Text = String.Format("{0:0,0}", sumMoneyRoomBeforeTax);
                //Tien thue phong 
                lblSumMoneyRoomTax.Text = String.Format("{0:0,0}", SumMoneyTaxRoom);
                //tong tien phong sau thue
                lblSumMoneyRoomsAfterTax.Text = String.Format("{0:0,0}", sumMoneyRoomAfterTax);

                //danh sach dich vu
                this.DetailReport2.DataSource = aListServicesGroupEN;
                colNamService.DataBindings.Add("Text", this.DetailReport2.DataSource, "ServiceGroupName");
                colTotalMoneyBeforeTax.DataBindings.Add("Text", this.DetailReport2.DataSource, "TotalMoneyBeforeTax", "{0:0,0}");
                colPercentTaxService.DataBindings.Add("Text", this.DetailReport2.DataSource, "DisplayMoneyTax", "{0:0,0}");
                colTotalMoneyServiceAfterTax.DataBindings.Add("Text", this.DetailReport2.DataSource, "TotalMoneyAfterTax", "{0:0,0}");

                //tong tien dich vu truoc thue
                lblSumMoneyService_BookingRBeforeTax.Text = String.Format("{0:0,0}", sumMoneyServiceRoomBeforeTax);
                //Tien thue dich vu
                lblSumMoneyServiceTax.Text = String.Format("{0:0,0}", sumMoneyTaxServices);
                //tong tien dich vu sau thue
                lblSumMoneyService_BookingRAfterTax.Text = String.Format("{0:0,0}", sumMoneyServiceRoomAfterTax);


                //tong tien thanh toan truoc thue
                lblTotalMoneyBookingRBeforeTax.Text = String.Format("{0:0,0}", (sumMoneyRoomBeforeTax + sumMoneyServiceRoomBeforeTax));
                //Tong tien thue
                lblTotalMoneyTax.Text = String.Format("{0:0,0}", (SumMoneyTaxRoom + sumMoneyTaxServices));
                //tong tien thanh toan sau thue
                lblTotalMoneyBookingRAfterTax.Text = String.Format("{0:0,0}", (sumMoneyRoomAfterTax + sumMoneyServiceRoomAfterTax));
                //So tien ung truoc
                lblBookingMoney_BookingR.Text = String.Format("{0:0,0}", BookingMoneyR);
                //so tien con lai can thanh toan
                lblTotalMoney_BookingR.Text = String.Format("{0:0,0}", ((sumMoneyRoomAfterTax + sumMoneyServiceRoomAfterTax) - BookingMoneyR));


                string TotalMoney_BookingRString = UppercaseFirst(StringUtility.ConvertDecimalToString(Convert.ToDecimal((sumMoneyRoomAfterTax + sumMoneyServiceRoomAfterTax) - BookingMoneyR)));
                lblTotalMoney_BookingRString.Text = "(" + TotalMoney_BookingRString + ")";



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
    }
}
