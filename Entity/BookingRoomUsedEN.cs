using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace Entity
{
   public class BookingRoomUsedEN : BookingRoomsEN
    {
       public List<ServiceUsedEN> ListServiceUsed = new List<ServiceUsedEN>();
       public Nullable<int> IndexSubPayment { get; set; }
       public List<Customers> ListCustomer = new List<Customers>();


       public bool IsCheckInEarly { get; set; }
       public bool IsCheckOutLate { get; set; }
       
       public decimal? TotalMoney { get{return this.GetTotalMoneyRoom();}}


       public bool IsPaid { get { return this.IsPaidRoom(); } }
 
       public decimal? GetOnlyMoneyRoom()
       {
           double? AddTimeStart;
           if (this.AddTimeStart == null)
           {
               AddTimeStart = 0;
           }
           else
           {
               AddTimeStart = this.AddTimeStart;
           }
           double? AddTimeEnd;
           if (this.AddTimeEnd == null)
           {
               AddTimeEnd = 0;
           }
           else
           {
               AddTimeEnd = this.AddTimeEnd;
           }
           decimal? TimeUsed;
           if (this.TimeInUse == null)
           {
               TimeUsed = 0;
           }
           else
           {
               TimeUsed = this.TimeInUse;
           }
           double? Tax;
           if (this.PercentTax == null)
           {
               Tax = 0;
           }
           else
           {
               Tax = this.PercentTax;
           }
           decimal? RoomCost;
           if (this.Cost == null)
           {
               RoomCost = this.CostRef_Rooms;
           }
           else
           {
               RoomCost = this.Cost;
           }
           decimal? Sum = 0;
           // Tinh ca di som ve muon
           
           if (this.Type == 3) 
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) + Convert.ToDecimal(AddTimeStart + AddTimeEnd))) * (1 + (Convert.ToDecimal(Tax) / 100));
           }
           
           else if (this.Type == 2)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) + Convert.ToDecimal(AddTimeStart ))) * (1 + (Convert.ToDecimal(Tax) / 100));
           }
           
           else if (this.Type == 1)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) + Convert.ToDecimal(AddTimeEnd))) * (1 + (Convert.ToDecimal(Tax) / 100));
           }
           
           else if (this.Type == 0)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) )) * (1 + (Convert.ToDecimal(Tax) / 100));
           }

           return Sum;
       }

       public decimal? GetOnlyMoneyRoomBeforeTax()
       {
           double? AddTimeStart;
           if (this.AddTimeStart == null)
           {
               AddTimeStart = 0;
           }
           else
           {
               AddTimeStart = this.AddTimeStart;
           }
           double? AddTimeEnd;
           if (this.AddTimeEnd == null)
           {
               AddTimeEnd = 0;
           }
           else
           {
               AddTimeEnd = this.AddTimeEnd;
           }
           decimal? TimeUsed;
           if (this.TimeInUse == null)
           {
               TimeUsed = 0;
           }
           else
           {
               TimeUsed = this.TimeInUse;
           }          
           decimal? RoomCost;
           if (this.Cost == null)
           {
               RoomCost = this.CostRef_Rooms;
           }
           else
           {
               RoomCost = this.Cost;
           }

           decimal? Sum = 0;
           if (this.Type == 3)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) + Convert.ToDecimal(AddTimeStart + AddTimeEnd))) ;
           }

           else if (this.Type == 2)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) + Convert.ToDecimal(AddTimeStart))) ;
           }

           else if (this.Type == 1)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60) + Convert.ToDecimal(AddTimeEnd))) ;
           }

           else if (this.Type == 0)
           {
               Sum = (RoomCost * Convert.ToDecimal(TimeUsed / (24 * 60))) ;
           }

           return Sum;
       }

       public decimal? GetMoneyListServiceUsed()
       {
           decimal? MoneyListServiceUsed = 0;
           foreach (ServiceUsedEN item in this.ListServiceUsed)
           {
               MoneyListServiceUsed = MoneyListServiceUsed + item.GetMoneyService();               
           }
           return MoneyListServiceUsed;
       }

       public decimal? GetMoneyListServiceUsedBeforeTax()
       {
           decimal? MoneyListServiceUsedBeforeTax = 0;
           foreach (ServiceUsedEN item in this.ListServiceUsed)
           {
               MoneyListServiceUsedBeforeTax = MoneyListServiceUsedBeforeTax + item.GetMoneyServiceBeforeTax();
           }
           return MoneyListServiceUsedBeforeTax;
       }
       public decimal? GetTotalMoneyRoom()
       {
           decimal? MoneyRoom = this.GetMoneyListServiceUsed() + this.GetOnlyMoneyRoom();
           return MoneyRoom;
       }
      
       public decimal? GetMoneyRoomBeforeTax()
       {
           decimal? MoneyRoomBeforeTax = this.GetMoneyListServiceUsedBeforeTax() + this.GetOnlyMoneyRoomBeforeTax();
           return MoneyRoomBeforeTax;
       }
       public List<ServiceUsedEN> GetListServiceUsedByStatusPay(int StatusPay)
       {
           List<ServiceUsedEN> aListServiceUsed = this.ListServiceUsed.Where(a => a.StatusPay == StatusPay).ToList();
           return aListServiceUsed;
       }
       
       public void SetCostServiceUsed(int IDBookingRoomService, decimal Cost)
       {
           this.ListServiceUsed.Where(a => a.IDBookingService == IDBookingRoomService).ToList()[0].Cost = Cost;
       }
       
       public void SetQuantityServiceUsed(int IDBookingRoomService, double Quantity)
       {
           this.ListServiceUsed.Where(a => a.IDBookingService == IDBookingRoomService).ToList()[0].Quantity = Quantity;
       }

       public bool IsPaidRoom()
       {
           if (this.Status == 8)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public void ChangeTaxService(int IDBookingRoomService, double Tax)
       {
           this.ListServiceUsed.Where(a => a.IDBookingService == IDBookingRoomService).ToList()[0].Tax = Tax; 
       }
       public decimal? GetMoneyListServiceUsedByIDGroupService(int IDGroupService)
       {
           List<ServiceUsedEN> aListTemp = this.ListServiceUsed.Where(a => a.IDServiceGroup == IDGroupService).ToList();
           decimal? MoneyListServiceUsed = 0;
           foreach (ServiceUsedEN item in aListTemp)
           {
               MoneyListServiceUsed = MoneyListServiceUsed + item.GetMoneyService();
           }
           return MoneyListServiceUsed;

       }
       public decimal? GetMoneyListServiceUsedNotPaid()
       {
           List<ServiceUsedEN> aListTemp= this.ListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
           decimal? MoneyListServiceUsed = 0;
           foreach (ServiceUsedEN item in aListTemp)
           {
               MoneyListServiceUsed = MoneyListServiceUsed + item.GetMoneyService();
           }
           return MoneyListServiceUsed;
       }
       public decimal? GetMoneyListServiceUsedNotPaidBeforeTax()
       {
           List<ServiceUsedEN> aListTemp = this.ListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
           decimal? MoneyListServiceUsedBeforeTax = 0;
           foreach (ServiceUsedEN item in aListTemp)
           {
               MoneyListServiceUsedBeforeTax = MoneyListServiceUsedBeforeTax + item.GetMoneyServiceBeforeTax();
           }
           return MoneyListServiceUsedBeforeTax;
       }
       public int SetBookingRoomType(bool IsCheckInEarly, bool IsCheckOutLate)
       {
           //int Type = -1;
           if (IsCheckInEarly == true && IsCheckOutLate == true)
           {
               this.Type = 3;
               
           }
           else if (IsCheckInEarly == true && IsCheckOutLate == false)
           {
               this.Type = 1;
           }
           else if (IsCheckInEarly == false && IsCheckOutLate == true)
           {
               this.Type = 2;
           }
           else if (IsCheckInEarly == false && IsCheckOutLate == false)
           {
               this.Type = 0;
           }
           return this.Type.GetValueOrDefault(0);
       }

       public int Save()
       {
           try
           {
               DatabaseDA aDatabaseDA = new DatabaseDA();
               BookingRooms aTemp = aDatabaseDA.BookingRooms.Where(a => a.ID == this.ID).ToList()[0];
               aTemp.ID = this.ID;
               aTemp.IDBookingR = this.IDBookingR;
               aTemp.CodeRoom = this.CodeRoom;
               aTemp.Cost = this.Cost;
               aTemp.PercentTax = this.PercentTax;
               aTemp.CostRef_Rooms = this.CostRef_Rooms;
               aTemp.Note = this.Note;
               aTemp.CheckInPlan = this.CheckInPlan;
               aTemp.CheckInActual = this.CheckInActual;
               aTemp.CheckOutPlan = this.CheckOutPlan;
               aTemp.CheckOutActual = this.CheckOutActual;
               aTemp.BookingStatus = this.BookingStatus;
               aTemp.Status = this.Status;
               aTemp.StartTime = this.StartTime;
               aTemp.EndTime = this.EndTime;
               aTemp.IsAllDayEvent = this.IsAllDayEvent;
               aTemp.Color = this.Color;
               aTemp.IsRecurring = this.IsRecurring;
               aTemp.IsEditable = this.IsEditable;
               aTemp.AdditionalColumn1 = this.AdditionalColumn1;
               aTemp.CostPendingRoom = this.CostPendingRoom;
               aTemp.TimeInUse = this.TimeInUse;
               aTemp.AddTimeStart = this.AddTimeStart;
               aTemp.AddTimeEnd = this.AddTimeEnd;
               
               aTemp.Type = this.Type;
               //aTemp.Type = this.SetBookingRoomType(this.IsCheckInEarly, this.IsCheckOutLate);

               aTemp.Disable = this.Disable;
               aTemp.IndexSubPayment = this.IndexSubPayment;
               aTemp.AcceptDate = this.AcceptDate;
               aTemp.InvoiceDate = this.InvoiceDate;
               aTemp.InvoiceNumber = this.InvoiceNumber; 

               foreach (ServiceUsedEN item in this.ListServiceUsed)
               {
                   item.Save(1);
               }
               aTemp.PriceType = this.PriceType;
               aDatabaseDA.BookingRooms.AddOrUpdate(aTemp);
               aDatabaseDA.SaveChanges();

               return 0;
           }
           catch (Exception e)
           {
               return 1;
               //throw new Exception("Lỗi khi insert...");

           }
           
       }
       
       public void DeleteServiceUsed(int IDBookingRoomService )
       {
             DatabaseDA aDatabaseDA = new DatabaseDA();
             BookingRooms_Services aBookingRooms_Services = aDatabaseDA.BookingRooms_Services.Where(a => a.ID == IDBookingRoomService).ToList()[0];
             if (aBookingRooms_Services != null)
             {
                 aDatabaseDA.BookingRooms_Services.Remove(aBookingRooms_Services);
                 aDatabaseDA.SaveChanges();
             }
       }
       public void SetValue(BookingRooms aBookingRooms)
       {
           this.ID = aBookingRooms.ID;
           this.IDBookingR = aBookingRooms.IDBookingR;
           this.CodeRoom = aBookingRooms.CodeRoom;          
           this.PercentTax = aBookingRooms.PercentTax;
           this.CostRef_Rooms = aBookingRooms.CostRef_Rooms;
           this.Note = aBookingRooms.Note;
           this.CheckInPlan = aBookingRooms.CheckInPlan;
           this.CheckInActual = aBookingRooms.CheckInActual;
           this.CheckOutPlan = aBookingRooms.CheckOutPlan;
           this.CheckOutActual = aBookingRooms.CheckOutActual;
           this.BookingStatus = aBookingRooms.BookingStatus;
           this.Status = aBookingRooms.Status;
           this.StartTime = aBookingRooms.StartTime;
           this.EndTime = aBookingRooms.EndTime;
           this.IsAllDayEvent = aBookingRooms.IsAllDayEvent;
           this.Color = aBookingRooms.Color;
           this.IsRecurring = aBookingRooms.IsRecurring;
           this.IsEditable = aBookingRooms.IsEditable;
           this.AdditionalColumn1 = aBookingRooms.AdditionalColumn1;
           this.CostPendingRoom = aBookingRooms.CostPendingRoom;
           this.PriceType = aBookingRooms.PriceType;
           this.IndexSubPayment = aBookingRooms.IndexSubPayment;
           this.AcceptDate = aBookingRooms.AcceptDate;
           this.InvoiceDate = aBookingRooms.InvoiceDate;
           this.InvoiceNumber = aBookingRooms.InvoiceNumber;
           this.Type = aBookingRooms.Type;
           if (aBookingRooms.Type == 0)
           {
               this.IsCheckInEarly = false;
               this.IsCheckOutLate = false;
           }
           else if (aBookingRooms.Type == 1)
           {
               this.IsCheckInEarly = true;
               this.IsCheckOutLate = false;
           }
           else if (aBookingRooms.Type == 2)
           {
               this.IsCheckInEarly = false;
               this.IsCheckOutLate = true;
           }
           else if (aBookingRooms.Type == 3)
           {
               this.IsCheckInEarly = true;
               this.IsCheckOutLate = true;
           }
          
       }
       public void ChangeIndexSubPaymentService(int IDBookingRoomService, int Index)
       {
           this.ListServiceUsed.Where(a => a.IDBookingService == IDBookingRoomService).ToList()[0].IndexSubPayment = Index;


       }

    }
}
