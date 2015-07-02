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
    public partial class frmRpt_PersonalPayment : DevExpress.XtraReports.UI.XtraReport
    {
        public frmRpt_PersonalPayment(List<RptPaymentStyle1_ForPrint> aListData, string CompanyName, string Address, string NameCustomerGroup, string InvoiceNumber
            , DateTime FirstDate, DateTime LastDate, decimal? BookingHMoney, decimal? BookingRMoney,int IDBookingR)
        {
            InitializeComponent();
            //Load dữ liệu
             BookingRoomsBO aBookingRoomBO = new BookingRoomsBO();
                        CustomersBO aCustomersBO = new CustomersBO();
            RoomsBO aRoomsBO = new RoomsBO();

            string RoomSku = "";
            string CustomerNames = "";
              List<BookingRooms> aListBookingRooms = aBookingRoomBO.Select_ByIDBookingRs(IDBookingR);
              if (aListBookingRooms.Count > 0)
              {
                  BookingRoomUsedEN aBookingRoomUsedEN;

                  foreach (BookingRooms item in aListBookingRooms)
                  {
                      aBookingRoomUsedEN = new BookingRoomUsedEN();
                      aBookingRoomUsedEN.SetValue(item);
                      aBookingRoomUsedEN.ListCustomer = aCustomersBO.SelectListCustomer_ByIDBookingRoom(item.ID);
                      Rooms aRooms = aRoomsBO.Select_ByCodeRoom(item.CodeRoom, 1);
                      if (aRooms != null)
                      {
                          aBookingRoomUsedEN.RoomSku = aRooms.Sku;
                      }
                      else
                      {
                          aBookingRoomUsedEN.RoomSku = string.Empty;
                      }
                      if (RoomSku == "")
                      {
                          RoomSku = aBookingRoomUsedEN.RoomSku;
                      }
                      else
                      {
                          RoomSku = RoomSku + " + " + aBookingRoomUsedEN.RoomSku;
                      }
                      foreach (Customers aItem in aBookingRoomUsedEN.ListCustomer)
                      {
                          if (CustomerNames == "")
                          {
                              CustomerNames = aItem.Name;
                          }
                          else
                          {
                              CustomerNames = CustomerNames + " + " + aItem.Name;
                          }
                      }
                  }
                  
              }
              decimal MealCharge = 0;
              decimal DrinkCharge = 0;
              decimal    RoomCharge= 0; 
               decimal   RoomServiceCharge= 0;
               decimal   Tel= 0;
              decimal Laundry = 0;
              decimal    OtherServiceCharge = 0;
              decimal TotalServiceMoney = 0;
              decimal TotalMoneyBeforeTax = 0;
              foreach (RptPaymentStyle1_ForPrint aItem in aListData)
              {
                  MealCharge = MealCharge + aItem.ServiceGroup8_Fee;
                  DrinkCharge = DrinkCharge + aItem.ServiceGroup7_Fee;
                  RoomCharge = RoomCharge + aItem.Room_Fee;
                  RoomServiceCharge = RoomServiceCharge + aItem.ServiceGroup5_Fee;
                  Tel = Tel + aItem.ServiceGroup2_Fee;
                  Laundry = Laundry + aItem.ServiceGroup3_Fee;
                  OtherServiceCharge = OtherServiceCharge + aItem.ServiceGroup4_Fee + aItem.ServiceGroup5_Fee + aItem.ServiceGroup9_Fee;
                  TotalServiceMoney = TotalServiceMoney + aItem.TotalServiceMoney;
                  TotalMoneyBeforeTax = TotalMoneyBeforeTax + aItem.TotalMoney;
              }
           
            //Hiển thị dữ liệu
              BookingRs aBookingRs = new BookingRs();
              aBookingRs = (new BookingRsBO()).Select_ByID(IDBookingR);

              lblIDBookingR.Text = IDBookingR.ToString();
              lblInvoiceNumber.Text = aBookingRs.InvoiceNumber;
              lblInvoiceDate.Text = aBookingRs.InvoiceDate.GetValueOrDefault().Date.ToShortDateString();
              lbAcceptDate.Text = aBookingRs.AcceptDate.GetValueOrDefault().Date.ToShortDateString();

             

              lblCheckIn.Text = FirstDate.ToString("dd/MM/yyyy");
              lblCheckOut.Text = LastDate.ToString("dd/MM/yyyy");
              lblCustomerName.Text = CustomerNames;
              lblRoomSku.Text = RoomSku;

              lblMealChargeVN.Text = MealCharge.ToString("0,0");
              lblDrinkChargeVN.Text = DrinkCharge.ToString("0,0");
              lblRoomChargeVN.Text = RoomCharge.ToString("0,0");
              lblRoomServiceVN.Text = RoomServiceCharge.ToString("0,0");
              lblTelVN.Text = Tel.ToString("0,0");
              lblLaundryVN.Text = Laundry.ToString("0,0");
              lblOtherServiceVN.Text = OtherServiceCharge.ToString("0,0");

              lblServiceChargeVN.Text = TotalServiceMoney.ToString("0,0");
              lblTotalBTVN.Text = TotalMoneyBeforeTax.ToString("0,0");
              lblTaxVN.Text = (TotalMoneyBeforeTax * 10 / 100).ToString("0,0");
              lblMoneyAfterTaxVN.Text = (TotalMoneyBeforeTax * 110 / 100).ToString("0,0");
              lblBookingMoneyVN.Text = Convert.ToDecimal(BookingHMoney + BookingHMoney).ToString("0,0");
              lblTotalMoneyVN.Text = ((TotalMoneyBeforeTax * 110 / 100) - Convert.ToDecimal(BookingHMoney + BookingHMoney)).ToString("0,0");
              string TotalMoney_String = UppercaseFirst(StringUtility.ConvertDecimalToString((TotalMoneyBeforeTax * 110 / 100) - Convert.ToDecimal(BookingHMoney + BookingHMoney)));
              lblConvertToString.Text = TotalMoney_String;

              int day = DateTime.Now.Day;
              int month = DateTime.Now.Month;
              int year = DateTime.Now.Year;
              lblDayMonthYear.Text = "Hà nội , ngày " + day.ToString() + " tháng " + month.ToString() + " năm " + year.ToString();

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
