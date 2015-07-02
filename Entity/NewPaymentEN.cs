using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;


namespace Entity
{
   public class NewPaymentEN
    {
       public int? IDBookingH { get; set; }
       public int? IDBookingR { get; set; }
       public List<BookingHallUsedEN> aListBookingHallUsed = new List<BookingHallUsedEN>();
       public List<BookingRoomUsedEN> aListBookingRoomUsed = new List<BookingRoomUsedEN>();
       public Nullable<DateTime> CreatedDate_BookingR { get; set; }
       public Nullable<DateTime> CreatedDate_BookingH { get; set; }
       public int? CustomerType { get; set; }
       public int? PayMenthodR { get; set; }
       public int? PayMenthodH { get; set; }

       public int? StatusPay { get; set; }
       public decimal? BookingHMoney { get; set; }
       public decimal? BookingRMoney { get; set; }
       public int? Status_BookingR { get; set; }
       public int? Status_BookingH { get; set; }
       public int? IDCustomer { get; set; }
       public string NameCustomer { get; set; }
       public int? IDSystemUser { get; set; }
       public string NameSystemUser { get; set; }
       public int? IDCustomerGroup { get; set; }
       public string NameCustomerGroup { get; set; }
       public int? IDCompany { get; set; }      
       public string NameCompany { get; set; }
       public string TaxNumberCodeCompany { get; set; }
       public string AddressCompany { get; set; }
       public string InvoiceNumber { get; set; }
       public DateTime? AcceptDate { get; set; }      

       public List<int> ListIndex = new List<int>();
       public Nullable<DateTime> InvoiceDate { get; set; } // ngay tren hoa don do, ngay chot doanh thu

       public decimal? GetMoneyRooms()
       {
           decimal? MoneyRooms = 0;
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               MoneyRooms = MoneyRooms + item.GetTotalMoneyRoom();
           }
           return MoneyRooms;
       }
       public decimal? GetMoneyHalls()
       {
           decimal? MoneyHalls = 0;
           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               MoneyHalls = MoneyHalls + item.GetTotalMoneyHall();
           }
           return MoneyHalls;
       }
       public int GetNumberCustomerInRoom(int IDBookingRoom)
       {
           List<BookingRoomUsedEN> aList = this.aListBookingRoomUsed.Where(p => p.ID == IDBookingRoom).ToList();
           if (aList.Count > 0)
           {
               return this.aListBookingRoomUsed.Where(p => p.ID == IDBookingRoom).ToList()[0].ListCustomer.Count;
           }
           else
           {
               return 0;
           }
       }


       //Hiennv  03/11/2014
       public decimal? GetMoneyTax(decimal? TotalMoney , decimal? PercentTax)
       {
           return(TotalMoney * PercentTax) / 100;
       }


       public decimal? GetMoneyRoomsBeforeTax()
       {
           decimal? MoneyRoomsBeforeTax = 0;
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               MoneyRoomsBeforeTax = MoneyRoomsBeforeTax + item.GetMoneyRoomBeforeTax();
           }
           return MoneyRoomsBeforeTax;
       }
       public decimal? GetMoneyHallsBeforeTax()
       {
           decimal? MoneyHallsBeforeTax = 0;
           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               MoneyHallsBeforeTax = MoneyHallsBeforeTax + item.GetMoneyHallBeforeTax();
           }
           return MoneyHallsBeforeTax;
       }
       public decimal? GetOnlyMoneyRooms()
       {
           decimal? MoneyRooms = 0;
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               MoneyRooms = MoneyRooms + item.GetOnlyMoneyRoom();
           }
           return MoneyRooms;
       }
       public decimal? GetOnlyMoneyRoomsBeforeTax()
       {
           decimal? MoneyRooms = 0;
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               MoneyRooms = MoneyRooms + item.GetOnlyMoneyRoomBeforeTax();
           }
           return MoneyRooms;
       }
       public decimal? GetOnlyMoneyHalls()
       {
           decimal? MoneyHalls = 0;
           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               MoneyHalls = MoneyHalls + item.GetOnlyMoneyHall();
           }
           return MoneyHalls;
       }
       public decimal? GetOnlyMoneyHallsBeforeTax()
       {
           decimal? MoneyHalls = 0;
           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               MoneyHalls = MoneyHalls + item.GetOnlyMoneyHallBeforeTax();
           }
           return MoneyHalls;
       }
       public decimal? GetTotalMoney()
       {
           if (this.GetMoneyHalls() != 0)
           {
               decimal? TotalMoney = this.GetMoneyHalls() + this.GetMoneyRooms();
               return TotalMoney;
           }
           else
           {
               return this.GetMoneyRooms();
           }
       }
       public decimal? GetTotalMoneyBeforeTax()
       {
           if (this.GetMoneyHallsBeforeTax() != 0)
           {
               decimal? TotalMoneyBeforeTax = this.GetMoneyHallsBeforeTax() + this.GetMoneyRoomsBeforeTax();
               return TotalMoneyBeforeTax;
           }
           else
           {
               return this.GetMoneyRoomsBeforeTax();
           }
       }
       public decimal? GetOnlyMoneyRoom(int IDBookingRoom)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               return this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetOnlyMoneyRoom();
           }
           return 0;
       }
       public decimal? GetMoneyAHall(int IDBookingHall)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               return this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].GetOnlyMoneyHall();
           }
           return 0;
       }
       public void PaymentRoom()
       {
           if (this.IDBookingH != null)
           {
               foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
               {

                   foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                   {
                       item1.StatusPay = 8;
                   }
                   item.Status = 8;
                   item.CheckOutActual = DateTime.Now;
                   item.Save();
               }
           }
           else
           {
               DatabaseDA aDatabaseDA = new DatabaseDA();             
               if (aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList().Count > 0)
               {
                   BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList()[0];
                   aTemp.DatePay = DateTime.Now;
                   aTemp.Status = 8;
                   aTemp.InvoiceDate = this.InvoiceDate;
                   aTemp.InvoiceNumber = this.InvoiceNumber;
                   aTemp.BookingMoney = this.BookingRMoney;
                   aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                   aDatabaseDA.SaveChanges();
                   foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
                   {

                       foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                       {
                           item1.StatusPay = 8;
                       }
                       item.Status = 8;
                       item.CheckOutActual = DateTime.Now;
                       item.Save();
                   }
               }             

           }
              
           
       }
       public void PaymentHall()
       {
           DatabaseDA aDatabaseDA = new DatabaseDA();
           if (aDatabaseDA.BookingHs.Where(a => a.ID == IDBookingH).ToList().Count > 0)
           {
               BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == IDBookingH).ToList()[0];
               aTemp.CreatedDate = this.CreatedDate_BookingH;
               aTemp.Status = 8;
               aTemp.BookingMoney = this.BookingHMoney;
               aTemp.InvoiceDate = this.InvoiceDate;
               aTemp.InvoiceNumber = this.InvoiceNumber;
               aTemp.DatePay = DateTime.Now;
               aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
               aDatabaseDA.SaveChanges();
               foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
               {

                   foreach (ServiceUsedEN item1 in item.aListServiceUsed)
                   {
                       item1.StatusPay = 8;
                   }
                   item.Status = 8;
                   item.Save();
               }
           }
        
       }
       public void PaymentTotal()
       {
           if (this.aListBookingHallUsed.Count > 0)
           {
               this.PaymentHall();
               DatabaseDA aDatabaseDA = new DatabaseDA();
               if (aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList().Count > 0)
               {
                   BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList()[0];
                   aTemp.DatePay = DateTime.Now;
                   aTemp.Status = 8;
                   aTemp.InvoiceDate = this.InvoiceDate;
                   aTemp.InvoiceNumber = this.InvoiceNumber;
                   aTemp.BookingMoney = this.BookingRMoney;
                   aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                   aDatabaseDA.SaveChanges();
                   foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
                   {

                       foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                       {
                           item1.StatusPay = 8;
                       }
                       item.Status = 8;
                       item.CheckOutActual = DateTime.Now;
                       item.Save();
                   }
               }
           }
           else
           {
               DatabaseDA aDatabaseDA = new DatabaseDA();
               if (aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList().Count > 0)
               {
                   BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList()[0];
                   aTemp.DatePay = DateTime.Now;
                   aTemp.Status = 8;
                   aTemp.InvoiceDate = this.InvoiceDate;
                   aTemp.InvoiceNumber = this.InvoiceNumber;
                   aTemp.BookingMoney = this.BookingRMoney;
                   aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                   aDatabaseDA.SaveChanges();
                   foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
                   {

                       foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                       {
                           item1.StatusPay = 8;
                       }
                       item.Status = 8;
                       item.CheckOutActual = DateTime.Now;
                       item.Save();
                   }
               }
           }
       }
       public void ChangeCostRefRoom(int IDBookingRoom, decimal CostRef)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {

               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].CostRef_Rooms = CostRef;
           }

       }
       public void ChangeCostRoom(int IDBookingRoom, decimal Cost)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].Cost = Cost;
              // this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TotalMoney = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetTotalMoneyRoom();
           }
          
       }
       public void ChangeCostHall(int IDBookingHall, decimal Cost)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].Cost = Cost;
           }
       }
       public void ChangeCheckInActual(int IDBookingRoom, DateTime CheckInActual)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].CheckInActual = CheckInActual;
           }
       }
       public void ChangeCheckInPlan(int IDBookingRoom, DateTime CheckInPlan)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].CheckInPlan = CheckInPlan;
           }
       }
       public void ChangeCheckOutActual(int IDBookingRoom, DateTime CheckOutActual)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].CheckOutActual = CheckOutActual;
           }
       }
       public void ChangeCheckOutPlan(int IDBookingRoom, DateTime CheckOutPlan)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].CheckOutPlan = CheckOutPlan;
           }
       }
       public void ChangeTimeInUsed(int IDBookingRoom, decimal TimeUsed)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TimeInUse = TimeUsed;
               //this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TotalMoney = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetTotalMoneyRoom();
           }
       }
       public void ChangeCostServiceUsedInRoom(int IDBookingRoom, int IDBookingRoomService, decimal Cost)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].SetCostServiceUsed(IDBookingRoomService, Cost);
              // this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TotalMoney = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetTotalMoneyRoom();

           }
       }
       public void ChangeQuantityServiceUsedInRoom(int IDBookingRoom, int IDBookingRoomService, double Quantity)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].SetQuantityServiceUsed(IDBookingRoomService, Quantity);
              // this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TotalMoney = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetTotalMoneyRoom();

           }
       }
       public void SetCheckInEarly(int IDBookingRoom,bool CheckInEarly)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].IsCheckInEarly = CheckInEarly;
           }
       }
       public void SetCheckOutLate(int IDBookingRoom, bool CheckOutLate)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].IsCheckOutLate = CheckOutLate;
           }
       }
       public void ChangeTaxServiceInRoom(int IDBookingRoom, int IDBookingRoomService, double Tax)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].ChangeTaxService(IDBookingRoomService, Tax);
              // this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TotalMoney = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetTotalMoneyRoom();

           }
       }
       public void ChangePercentTaxRoom(int IDBookingRoom, double Tax)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].PercentTax = Tax;
              // this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].TotalMoney = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].GetTotalMoneyRoom();

           }
       }
       public void ChangePercentTaxHall(int IDBookingHall, double Tax)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].PercentTax = Tax;
           }
       }
       public void ChangeTaxServiceInHall(int IDBookingHall, int IDBookingHallService, double Tax)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].ChangeTaxService(IDBookingHallService, Tax);
              
           }
       }
       public void ChangeCostServiceUsedInHall(int IDBookingHall, int IDBookingHallService, decimal Cost)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].SetCostServiceUsed(IDBookingHallService, Cost);
           }
       }
       public void ChangeQuantityServiceUsedInHall(int IDBookingHall, int IDBookingHallService, double Quantity)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].SetQuantityServiceUsed(IDBookingHallService, Quantity);
               
           }
       }
       public List<ServiceUsedEN> GetListServiceUsedPaidInRoom(int IDBookingRoom)
       {
           BookingRoomUsedEN aTemp = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0];
           return aTemp.ListServiceUsed.Where(a => a.IsPaidService() == true).ToList();
       }
       public List<ServiceUsedEN> GetListServiceUsedUnPaidInRoom(int IDBookingRoom)
       {
           BookingRoomUsedEN aTemp = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0];
           return aTemp.ListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
       }
       public List<ServiceUsedEN> GetListServiceUsedPaidInHall(int IDBookingHall)
       {
           BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
           return aTemp.aListServiceUsed.Where(a => a.IsPaidService() == true).ToList();
       }
       public List<ServiceUsedEN> GetListServiceUsedUnPaidInHall(int IDBookingHall)
       {
           BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
           return aTemp.aListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
       }
       public decimal? GetTotalMoneyServiceUsedInRooms()
       {
           decimal? TotalMoneyService = 0;
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               TotalMoneyService = TotalMoneyService + item.GetMoneyListServiceUsed();           
           }
           return TotalMoneyService;
       }
       public decimal? GetTotalMoneyServiceUsedInRoomsBeforeTax()
       {
           decimal? TotalMoneyService = 0;
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               TotalMoneyService = TotalMoneyService + item.GetMoneyListServiceUsedBeforeTax();
           }
           return TotalMoneyService;
       }
       public decimal? GetTotalMoneyServiceUsedInHalls()
       {
           decimal? TotalMoneyService = 0;
           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               TotalMoneyService = TotalMoneyService + item.GetMoneyListServiceUsed();
           }
           return TotalMoneyService;
       }
       public decimal? GetTotalMoneyServiceUsedInHallsBeforeTax()
       {
           decimal? TotalMoneyService = 0;
           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               TotalMoneyService = TotalMoneyService + item.GetMoneyListServiceUsedBeforeTax();
           }
           return TotalMoneyService;
       }
       public decimal? GetMoneyListServiceUsedInARoom(int IDBookingRoom)
       {
           BookingRoomUsedEN aTemp = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0];
           return aTemp.GetMoneyListServiceUsed();
       }
       public decimal? GetMoneyListServiceUsedInARoomBeforeTax(int IDBookingRoom)
       {
           BookingRoomUsedEN aTemp = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0];
           return aTemp.GetMoneyListServiceUsedBeforeTax();
       }
       public decimal? GetMoneyListServiceUsedInAHall(int IDBookingHall)
       {
           BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
           return aTemp.GetMoneyListServiceUsed();
       }
       public decimal? GetMoneyListServiceUsedInAHallBeforeTax(int IDBookingHall)
       {
           BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
           return aTemp.GetMoneyListServiceUsedBeforeTax();
       }
       public List<ServiceUsedEN> GetListServiceUsedInRoom(int IDBookingRoom)
       {
           BookingRoomUsedEN aTemp = this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0];
           return aTemp.ListServiceUsed;
       }
       public List<ServiceUsedEN> GetListServiceUsedInHall(int IDBookingHall)
       {
           BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
           return aTemp.aListServiceUsed;
       }
  
      
       public List<ServiceUsedEN> GetAllServiceUsedInRoom()
       {
           List<ServiceUsedEN> aListServiceUsed = new List<ServiceUsedEN>();
           
           foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
           {
               foreach (ServiceUsedEN item1 in item.ListServiceUsed)
               {
                   aListServiceUsed.Add(item1);
               }
           }
           return aListServiceUsed;
       }

       public List<ServiceUsedEN> GetAllServiceUsedInHall()
       {
           List<ServiceUsedEN> aListServiceUsed = new List<ServiceUsedEN>();

           foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
           {
               foreach (ServiceUsedEN item1 in item.aListServiceUsed)
               {
                   aListServiceUsed.Add(item1);
               }
           }
           return aListServiceUsed;
       }
       public void Save()
       {
           try
           {
               
               DatabaseDA aDatabaseDA = new DatabaseDA();
               if (IDBookingR != null)
               {
                   BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == IDBookingR).ToList()[0];
                   if (aTemp != null)
                   {
                       aTemp.CreatedDate = this.CreatedDate_BookingR;
                       aTemp.ID = Convert.ToInt32(this.IDBookingR);
                       aTemp.Status = this.Status_BookingR;                      
                       aTemp.InvoiceNumber = this.InvoiceNumber;
                       aTemp.AcceptDate = this.AcceptDate.GetValueOrDefault(Convert.ToDateTime("01/01/1900"));
                       aTemp.InvoiceDate = this.InvoiceDate.GetValueOrDefault(Convert.ToDateTime("01/01/1900"));                      
                       aTemp.BookingMoney = this.BookingRMoney;
                       aTemp.PayMenthod = this.PayMenthodR;

                       aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                       aDatabaseDA.SaveChanges();
                   }
                   foreach (BookingRoomUsedEN item in this.aListBookingRoomUsed)
                   {
                       item.Save();
                   }
               }
               if (IDBookingH != null)
               {

                   BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == IDBookingH).ToList()[0];
                   if (aTemp != null)
                   {
                       aTemp.CreatedDate = this.CreatedDate_BookingH;
                       aTemp.ID = Convert.ToInt32(this.IDBookingH);
                       aTemp.Status = this.Status_BookingH;
                       aTemp.BookingMoney = this.BookingHMoney;
                       aTemp.InvoiceNumber = this.InvoiceNumber;
                       aTemp.AcceptDate = this.AcceptDate;
                       aTemp.InvoiceDate = this.InvoiceDate;
                       aTemp.PayMenthod = this.PayMenthodH;
                       aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
                       aDatabaseDA.SaveChanges();
                   }
                   foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
                   {
                       item.Save();
                   }
               }
               // Luu thong tin cong ty
               Companies aCompany = aDatabaseDA.Companies.Where(a => a.ID == this.IDCompany).ToList()[0];
               aCompany.TaxNumberCode = this.TaxNumberCodeCompany;
               aCompany.Address = this.AddressCompany;
               aCompany.ID = Convert.ToInt32(this.IDCompany);
               aDatabaseDA.Companies.AddOrUpdate(aCompany);
               aDatabaseDA.SaveChanges();
               // Luu thong tin bookingRoom + Hall
             
          
           }
           catch (Exception ex)
           {
               throw new Exception(string.Format("BookingRoomUsedEN.Save :" + ex.Message.ToString()));
           }
       }

       public void ChangeIndexSubPaymentServiceRoom(int IDBookingRoom, int IDBookingRoomService, int Index)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].ChangeIndexSubPaymentService(IDBookingRoomService, Index);

           }
       }
       public void ChangeIndexSubPaymentServiceHall(int IDBookingHall, int IDBookingHallService, int Index)
       {
           if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
           {
               this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].ChangeIndexSubPaymentService(IDBookingHallService, Index);

           }
       }
       public void ChangeInvoiceDate(DateTime InvoiceDate)
       {
           this.InvoiceDate = InvoiceDate;
           if (this.aListBookingRoomUsed.Count > 0)
           {
               foreach (BookingRoomUsedEN aBookingRoom in this.aListBookingRoomUsed)
               {
                   if (aBookingRoom.IndexSubPayment == null)
                   {
                       aBookingRoom.InvoiceDate = InvoiceDate;
                   }
                   if (aBookingRoom.ListServiceUsed.Count > 0)
                   {
                       foreach (ServiceUsedEN aTemp in aBookingRoom.ListServiceUsed)
                       {
                           if (aTemp.IndexSubPayment == null)
                           {
                               aTemp.InvoiceDate = InvoiceDate;
                           }
                       }
                   }

               }
           }
           if (this.aListBookingHallUsed.Count > 0)
           {
               foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
               {
                   if (aBookingHall.IndexSubPayment == null)
                   {
                       aBookingHall.InvoiceDate = InvoiceDate;
                   }
                   if (aBookingHall.aListServiceUsed.Count > 0)
                   {
                       foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                       {
                           if (aTemp.IndexSubPayment == null)
                           {
                               aTemp.InvoiceDate = InvoiceDate;
                           }
                       }
                   }
               }
           }
       }
       public void ChangeInvoiceNumber(string InvoiNumber)
       {
           this.InvoiceNumber = InvoiNumber;
           if (this.aListBookingRoomUsed.Count > 0)
           {
               foreach (BookingRoomUsedEN aBookingRoom in this.aListBookingRoomUsed)
               {
                   if (aBookingRoom.IndexSubPayment == null)
                   {
                       aBookingRoom.InvoiceNumber = InvoiNumber;
                   }
                   if (aBookingRoom.ListServiceUsed.Count > 0)
                   {
                       foreach (ServiceUsedEN aTemp in aBookingRoom.ListServiceUsed)
                       {
                           if (aTemp.IndexSubPayment == null)
                           {
                               aTemp.InvoiceNumber = InvoiNumber;
                           }
                       }
                   }
               }
           }
           else if (this.aListBookingHallUsed.Count > 0)
           {
               foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
               {
                   if (aBookingHall.IndexSubPayment == null)
                   {
                       aBookingHall.InvoiceNumber = InvoiNumber;
                   }
                   if (aBookingHall.aListServiceUsed.Count > 0)
                   {
                       foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                       {
                           if (aTemp.IndexSubPayment == null)
                           {
                               aTemp.InvoiceDate = InvoiceDate;
                           }
                       }
                   }
               }
           }
       }
       public void ChangeAcceptDate(DateTime AcceptDate)
       {
           this.AcceptDate = AcceptDate;
           if (this.aListBookingRoomUsed.Count > 0)
           {
               foreach (BookingRoomUsedEN aBookingRoom in this.aListBookingRoomUsed)
               {
                   if (aBookingRoom.IndexSubPayment == null)
                   {
                       aBookingRoom.AcceptDate = AcceptDate;
                   }
                   if (aBookingRoom.ListServiceUsed.Count > 0)
                   {
                       foreach (ServiceUsedEN aTemp in aBookingRoom.ListServiceUsed)
                       {
                           if (aTemp.IndexSubPayment == null)
                           {
                               aTemp.AcceptDate = AcceptDate;
                           }
                       }
                   }

               }
           }
           if (this.aListBookingHallUsed.Count > 0)
           {
               foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
               {
                   if (aBookingHall.IndexSubPayment == null)
                   {
                       aBookingHall.AcceptDate = AcceptDate;
                   }
                   if (aBookingHall.aListServiceUsed.Count > 0)
                   {
                       foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                       {
                           if (aTemp.IndexSubPayment == null)
                           {
                               aTemp.AcceptDate = AcceptDate;
                           }
                       }
                   }
               }
           }
       }
       public void ChangeTypeBookingRoom(int IDBookingRoom, int NewType)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].Type = NewType;
           }
       }
       public void ChangePriceType(int IDBookingRoom, string PriceType)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].PriceType = PriceType;

           }
       }


       //=================================
       //=========================================
       // Ngoc


       // Lay danh sach dich vu vao mot ngay nao do tu 1 danh sach dich vu nhieu ngay ban dau
       private List<ServiceUsedEN> GetListServiceInOnceDay(List<ServiceUsedEN> AllData, DateTime CheckDate)
       {
          return AllData.Where(p => p.DateUsed.GetValueOrDefault().ToShortDateString() == CheckDate.ToShortDateString()).ToList();
       }
       // Truyen vao 1 danh sach IDServiceGroup, cac dich vu se dc cong don theo danh sach IDServiceGroup nay. 
       // VD : Hien nay ke toan dang gop nhom dich vu theo may nhom sau : 
       // Phieu bao thanh toan khach doan : Tien an | Tien uong | Tien phong | Dat tai buong | Thu khac
       // Phieu bao thanh toan khach le   : Tien an | Tien uong | Tien phong | Dat tai buong | Photo | Dien thoai | Fax | Giat la | Dich vu khac 
       // Bao cao phan tich doanh thu     :

       // Tat ca cac nhom nay dc luu trong ServiceGroup, (trong do co type = 2 la cac nhom dich vu gop cho phong, type = 1 la dich vu cho tiec)
       // List IDSrerviceGroup se duoc truyen vao ham nay va gia tien se dc cong gop theo cac nhom dich vu do
       private Decimal SumEachGroupServiceFee(int IDServiceGroup, List<ServiceUsedEN> ListDataInOnceDay)
       {
               decimal SumFee = 0;

               for (int i = 0; i < ListDataInOnceDay.Count; i++)
               {
                   if (ListDataInOnceDay[i].IDServiceGroup == IDServiceGroup)
                   {
                       SumFee = SumFee + ListDataInOnceDay[i].GetMoneyServiceBeforeTax().GetValueOrDefault(0);
                   }
               }
               return SumFee;
       }

       // Ham ho tro lay noi dung cot dien giai cua bao cao
       private string GetNote(int IDServiceGroup, List<ServiceUsedEN> ListDataInOnceDay)
       {
           string Note = "" ;
           for (int i = 0; i < ListDataInOnceDay.Count; i++)
           {
               if (ListDataInOnceDay[i].IDServiceGroup == IDServiceGroup)
               {
                   if (Note == "")
                   {
                       Note = ListDataInOnceDay[i].ServiceGroupName +":";
                   }
                   Note = Note + ListDataInOnceDay[i].NameService +", ";
               }
           }
           return Note;
       }
       private int GetNumCustomerInOnceDay(DateTime CheckDate)
       {
          //// Neu phong da checkOut hoac da thanh toan thi dem so nguoi bang moc so sanh Actual
          // int Count1 = this.aListBookingRoomUsed.Where(p => p.Status >= 7).Where(p => p.CheckInActual.Date <= CheckDate.Date).Where(p => p.CheckOutActual.Date >= CheckDate.Date).ToList().Count;
          ////Neu phong con chua tra phong thi dem so nguoi bang moc so sanh Actual va Plan
          //int Count2 = this.aListBookingRoomUsed.Where(p => p.Status == 3).Where(p => p.CheckInActual.Date <= CheckDate.Date).Where(p => p.CheckOutPlan.Date >= CheckDate.Date).ToList().Count;
          //return Count1 + Count2;

           // Neu phong da checkOut hoac da thanh toan thi dem so nguoi bang moc so sanh Actual
           List<BookingRoomUsedEN> List1 = this.aListBookingRoomUsed.Where(p => p.Status >= 7).Where(p => p.CheckInActual.Date <= CheckDate.Date).Where(p => p.CheckOutActual.Date >= CheckDate.Date).ToList();
           //Neu phong con chua tra phong thi dem so nguoi bang moc so sanh Actual va Plan
           List<BookingRoomUsedEN> List2 = this.aListBookingRoomUsed.Where(p => p.Status == 3).Where(p => p.CheckInActual.Date <= CheckDate.Date).Where(p => p.CheckOutPlan.Date >= CheckDate.Date).ToList();
           List1.AddRange(List2);
           List<Customers> Tempt = new List<Customers>();
           for (int i = 0; i < List1.Count; i++)
           {
               Tempt.AddRange(List1[i].ListCustomer);
               
           }
           return Tempt.Distinct().Count();
       }

       // Tim ngay som nhat de bat dau tinh toan in bao cao
       // Khong chac ngay checkIn cua phong som nhat la ngay dau tien trong bao cao
       // vi co the ho da dat tiec va su dung hoi truong truoc khi checkIn phong dau tien
       public  DateTime GetFirstDate()
       {
           // Lay ngay checkIn som nhat
           if (this.aListBookingRoomUsed.Count > 0)
           {
               DateTime Point1 = this.aListBookingRoomUsed.Min(p => p.CheckInActual);

               // Lay ngay dat hoi truong som nhat 
               DateTime Point2 = this.aListBookingHallUsed.Min(p => p.Date).GetValueOrDefault(Point1);
               if (Point1 <= Point2)
               {
                   return Point1;
               }
               else
               {
                   return Point2;
               }
           }
           else if (this.aListBookingHallUsed.Count >0)
           {
               return this.aListBookingHallUsed.Min(p => p.Date).GetValueOrDefault();
           }
           else 
           {

               return DateTime.Now;
           }

       }
       public DateTime GetLastDate()
       {
           // Lay ngay checkIn som nhat
           DateTime Point1 = new DateTime();
           if (this.aListBookingRoomUsed.Count > 0)
           {

               if (this.Status_BookingR >= 7)
               {
                   Point1 = this.aListBookingRoomUsed.Max(p => p.CheckOutActual);
               }
               else
               {
                   Point1 = this.aListBookingRoomUsed.Max(p => p.CheckOutPlan);
               }
               // Lay ngay dat hoi truong som nhat 
               DateTime Point2 = this.aListBookingHallUsed.Max(p => p.Date).GetValueOrDefault(Point1);
               if (Point1 > Point2)
               {
                   return Point1;
               }
               else
               {
                   return Point2;
               }
           }
           else if (this.aListBookingHallUsed.Count > 0)
           {
               return this.aListBookingHallUsed.Max(p => p.Date).GetValueOrDefault();
           }
           else
           {

               return DateTime.Now;
           }
       }


       // Lay tong tien phong 1 ngay 
       private decimal GetRoomFeeInOnceDay(DateTime CheckDate)
       {

           // Neu phong da checkOut hoac da thanh toan thi dem so nguoi bang moc so sanh Actual
           // Chi lay den ngay sat ngay cuoi cung, ngay cuoi cung phai tach ra tinh rien 
           List<BookingRoomUsedEN> List1 = this.aListBookingRoomUsed.Where(p => p.Status >= 7).Where(p => p.CheckInActual.Date <= CheckDate.Date).Where(p => p.CheckOutActual.Date >= CheckDate.Date).ToList();
           //Neu phong con chua tra phong thi dem so nguoi bang moc so sanh Actual va Plan
           List<BookingRoomUsedEN> List2 = this.aListBookingRoomUsed.Where(p => p.Status == 3).Where(p => p.CheckInActual.Date <= CheckDate.Date).Where(p => p.CheckOutPlan.Date >= CheckDate.Date).ToList();
           List1.AddRange(List2);
           decimal Ret = 0;
           List1.Distinct();
           for (int i = 0; i < List1.Count; i++)
           {
               //int IsChangeRoomInDay = List1.Select(p => p.ID).Distinct().ToList().Count;
             

               //----------------- 
               // Chi co ngay dau tien va ngay cuoi cung moi tinh den di som ve muon

               BookingRoomUsedEN IsFirstDayOrLastDay = List1[i];// = List1.Where(p => p.Status == 3).Where(p => p.CheckInActual.Date == CheckDate.Date).Where(p => p.CheckOutActual.Date != CheckDate.Date).ToList();
               
               if ((IsFirstDayOrLastDay.CheckInActual.Date == CheckDate.Date) && (IsFirstDayOrLastDay.CheckOutActual.Date != CheckDate.Date)) // Tinh theo gia phong moi sang
               {

                   Ret = Ret + EstimateCostRoomInFirstDay(IsFirstDayOrLastDay);

               }
               else if ((IsFirstDayOrLastDay.CheckOutActual.Date == CheckDate.Date) && (IsFirstDayOrLastDay.CheckInActual.Date != CheckDate.Date))// Tinh theo gia phong moi sang
               {
                   Ret = Ret + EstimateCostRoomInLastDay(IsFirstDayOrLastDay);
               }
               else if ((IsFirstDayOrLastDay.CheckOutActual.Date == CheckDate.Date) && (IsFirstDayOrLastDay.CheckInActual.Date == CheckDate.Date))// Tinh theo gia phong moi sang
               {
                   Ret = Ret + List1[i].Cost.GetValueOrDefault(0);
               }
               //else if (IsFirstDayOrLastDay.Status == 3) // Tinh theo gia phong moi sang
               //{

               //    Ret = Ret + EstimateCostRoomInLastDay(IsFirstDayOrLastDay);
               //}
               else
               {
                   Ret = Ret + List1[i].Cost.GetValueOrDefault(0);
               }

               //if (IsChangeRoomInDay > 1)  // Chuyen sang phong khac hoac dung them phong khac trong cung 1 ngay
               //{
               //    if (IsFirstDay.CheckInActual.Date == CheckDate.Date ) // Tinh theo gia phong moi sang
               //    {
                       
               //            Ret = Ret + EstimateCostRoomInOnceDay(IsFirstDay.Type.GetValueOrDefault(0), IsFirstDay.Status.GetValueOrDefault(0), IsFirstDay.AddTimeStart.GetValueOrDefault(0), IsFirstDay.AddTimeEnd.GetValueOrDefault(0), IsFirstDay.Cost.GetValueOrDefault(0));
                       
               //    }
               //        // phong cu khong tinh tien, tinh theo gia phong moi sang
               //    else 
               //    {
               //        Ret = Ret + 0;
               //    }
               //}
               //else // Thuan tuy chuyen thu phong no sang phong kia
               //{
               //    if (IsFirstDay.CheckInActual.Date == CheckDate.Date) // Tinh theo gia phong moi sang
               //    {

               //        Ret = Ret + EstimateCostRoomInOnceDay(IsFirstDay.Type.GetValueOrDefault(0), IsFirstDay.Status.GetValueOrDefault(0), IsFirstDay.AddTimeStart.GetValueOrDefault(0), IsFirstDay.AddTimeEnd.GetValueOrDefault(0), IsFirstDay.Cost.GetValueOrDefault(0));

               //    }
               //    else
               //    {
               //        Ret = Ret + List1[i].Cost.GetValueOrDefault(0);
               //    }
               //}

           }
         
           return Ret;
       }
       private decimal GetHallFeeInOnceDay(DateTime CheckDate)
       {
           List<BookingHallUsedEN> List1 = this.aListBookingHallUsed.Where(p => p.Date.GetValueOrDefault().Date == CheckDate.Date).ToList();

           decimal Ret = 0;
           for (int i = 0; i < List1.Count; i++)
           {
               Ret = Ret + List1[i].Cost.GetValueOrDefault(0);
           }
           return Ret;
       }

       // tra ra 1 list cac ban ghi ve cac dich vu gop nhom trong 1 nga
       private List<RptPaymentStyle1> SumGroupServiceFeeInOnceDay(List<int> ListIDServiceGroup, List<ServiceUsedEN> ListDataInOnceDay)
       {
           // List<Decimal>

           List<RptPaymentStyle1> DataInOnceDay = new List<RptPaymentStyle1>();
           if (ListDataInOnceDay.Count > 0)
           {
               DateTime CheckDate = ListDataInOnceDay[0].DateUsed.GetValueOrDefault();

               RptPaymentStyle1 ItemSumGroupInOnceDay= new RptPaymentStyle1();
               for (int i = 0; i < ListIDServiceGroup.Count; i++)
               {
                   //------------------------------------------------------------------------------------
                   ItemSumGroupInOnceDay = new RptPaymentStyle1();
                   // Lay tong so nguoi cua doan
                   ItemSumGroupInOnceDay.CountCustomerInGroup = this.GetNumCustomerInOnceDay(CheckDate);
                   ItemSumGroupInOnceDay.Date = CheckDate.Date;

                   ItemSumGroupInOnceDay.Note = this.GetNote(ListIDServiceGroup[i], ListDataInOnceDay);
                   // Gan tong tien dich vu vao cot thu 3 tro di tuong ung trong ServiceGroup_Fee 
                   ItemSumGroupInOnceDay.ServiceGroup_Fee.Insert(i+2, this.SumEachGroupServiceFee(ListIDServiceGroup[i], ListDataInOnceDay));
                   if (ItemSumGroupInOnceDay.ServiceGroup_Fee[i + 2] > 0)
                   {
                       DataInOnceDay.Add(ItemSumGroupInOnceDay);
                   }
                  
               }
           }
           return DataInOnceDay;
       }

       public List<RptPaymentStyle1_ForDisplay> ConvertDataFor_RptPaymentStyle1(List<int> ListIDServiceGroup)
       {
           DateTime FirstDateReport = this.GetFirstDate();
           DateTime LastDateReport = this.GetLastDate();
    

           List<ServiceUsedEN> ListServiceInOnceDay = new List<ServiceUsedEN>();
           List<RptPaymentStyle1> aListRet = new List<RptPaymentStyle1>();
           List<RptPaymentStyle1_ForDisplay> aListRetView = new List<RptPaymentStyle1_ForDisplay>();

           RptPaymentStyle1 ItemSumGroupInOnceDay = new RptPaymentStyle1();

           double Loop = (LastDateReport.Date - FirstDateReport.Date).TotalDays ;
           for (double i = 0; i <= Loop; i++)
           {
               
               ItemSumGroupInOnceDay = new RptPaymentStyle1();
               // Lay tong so nguoi cua doan
               ItemSumGroupInOnceDay.CountCustomerInGroup = this.GetNumCustomerInOnceDay(FirstDateReport.AddDays(i));
               ItemSumGroupInOnceDay.Date = FirstDateReport.AddDays(i).Date;

               // tien phong

               ItemSumGroupInOnceDay.ServiceGroup_Fee.Insert(0, this.GetRoomFeeInOnceDay(FirstDateReport.AddDays(i)));
 
               ItemSumGroupInOnceDay.Note = "Tiền phòng";
               if (ItemSumGroupInOnceDay.ServiceGroup_Fee[0] > 0)
               {
                   aListRet.Insert(0, ItemSumGroupInOnceDay);
               }
               else {
                   aListRet.Insert(0, new RptPaymentStyle1());
               }


               ItemSumGroupInOnceDay = new RptPaymentStyle1();
               ItemSumGroupInOnceDay.Date = FirstDateReport.AddDays(i).Date;
               // gop cung cot so 0
               ItemSumGroupInOnceDay.ServiceGroup_Fee.Insert(1, this.GetHallFeeInOnceDay(FirstDateReport.AddDays(i)));
               ItemSumGroupInOnceDay.Note = "Tiền hội trường";
               if (ItemSumGroupInOnceDay.ServiceGroup_Fee[1] > 0)
               {
                   aListRet.Insert(1, ItemSumGroupInOnceDay);
               }
               else
               {
                   aListRet.Insert(1, new RptPaymentStyle1());
               }

               //----------------------------------------------
               // Lay danh sach dich vu phong dung trong 1 ngay
               ListServiceInOnceDay = GetListServiceInOnceDay(this.GetAllServiceUsedInRoom(), FirstDateReport.AddDays(i));

               // lay them danh sach dich vu hoi truong trong cung ngay roi noi vao list tren
               ListServiceInOnceDay.AddRange(GetListServiceInOnceDay(this.GetAllServiceUsedInHall(), FirstDateReport.AddDays(i)));
               aListRet.AddRange(SumGroupServiceFeeInOnceDay(ListIDServiceGroup, ListServiceInOnceDay));

               

           }

           // convert data sang dang phu hop de hien thi va in
           for (int ii = 0; ii < aListRet.Count; ii++)
           {
               aListRetView.Add(new RptPaymentStyle1_ForDisplay(aListRet[ii]));
           }
  
           int alist = aListRetView.RemoveAll(p => p.Date == DateTime.MinValue);
           return aListRetView;
       }

       private decimal EstimateCostRoomInFirstDay (BookingRoomUsedEN FirstDay)
       {

         
           int BookingRoom_Type =  FirstDay.Type.GetValueOrDefault(0) ;
           int BookingRoom_Status =FirstDay.Status.GetValueOrDefault(0) ;
           double AddTimeStart = FirstDay.AddTimeStart.GetValueOrDefault(0);
           double AddTimeEnd = FirstDay.AddTimeEnd.GetValueOrDefault(0) ;
           decimal Cost = FirstDay.Cost.GetValueOrDefault(0);



           if ((BookingRoom_Type == 0) && (BookingRoom_Type == 1))// Khong tinh checkInsom 
           {
               return Cost * (decimal)0.5;
           }
           else //if ((BookingRoom_Type == 2) && (BookingRoom_Type == 3))// Khong tinh checkInsom 
           {
               return Cost * ((decimal)0.5 + (decimal)AddTimeStart);
           }
         
       }
       private decimal EstimateCostRoomInLastDay (BookingRoomUsedEN LastDay) {


           int BookingRoom_Type = LastDay.Type.GetValueOrDefault(0);
           int BookingRoom_Status = LastDay.Status.GetValueOrDefault(0);
           double AddTimeStart = LastDay.AddTimeStart.GetValueOrDefault(0);
           double AddTimeEnd = LastDay.AddTimeEnd.GetValueOrDefault(0);
           decimal Cost = LastDay.Cost.GetValueOrDefault(0);



           if ((BookingRoom_Type == 0) && (BookingRoom_Type == 2))// Khong tinh checkInsom 
           {
               return Cost * (decimal)0.5;
           }
           else //if ((BookingRoom_Type == 1) && (BookingRoom_Type == 3))// Khong tinh checkInsom 
           {
               return Cost * ((decimal)0.5 + (decimal)AddTimeEnd);
           }

         
       }
       private decimal EstimateCostRoomInUse (BookingRoomUsedEN RoomInUse) {


           //int BookingRoom_Type = RoomInUse.Type.GetValueOrDefault(0);
           //int BookingRoom_Status = RoomInUse.Status.GetValueOrDefault(0);
           //double AddTimeStart = RoomInUse.AddTimeStart.GetValueOrDefault(0);
           //double AddTimeEnd = RoomInUse.AddTimeEnd.GetValueOrDefault(0);
           //decimal Cost = RoomInUse.Cost.GetValueOrDefault(0);



           //if ((BookingRoom_Type == 0) && (BookingRoom_Type == 2))// Khong tinh checkInsom 
           //{
           //    return Cost * (decimal)0.5;
           //}
           //if ((BookingRoom_Type == 1) && (BookingRoom_Type == 3))// Khong tinh checkInsom 
           //{
           //    return Cost * ((decimal)0.5 + (decimal)AddTimeEnd);
           //}

           //else return Cost;

           return 0;
       }
       public int GetTypeBookingRoom(int IDBookingRoom)
       {
           try
           {
               return this.aListBookingRoomUsed.Where(p => p.ID == IDBookingRoom).ToList()[0].Type.GetValueOrDefault(0);
           }
           catch
           {
               return 0;
           }
       }
       public void SetPriceType(int IDBookingRoom, string NewPriceType)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].PriceType = NewPriceType;
           }
       }
       public string GetPriceType(int IDBookingRoom)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               return this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].PriceType ;
           }
           return "";

       }
       public decimal? GetCostRoom(int IDBookingRoom)
       {
           if (this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
           {
               return this.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0].Cost;
           }
           return null;
       }
    }

}
