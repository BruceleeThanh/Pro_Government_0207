using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace Entity
{
    public class BookingHallUsedEN :BookingHallsEN
    {
        public List<MenusEN> aListMenuEN = new List<MenusEN>();
        public List<ServiceUsedEN> aListServiceUsed = new List<ServiceUsedEN>();

        public decimal? TotalMoney { get { return this.GetTotalMoneyHall(); } }


        public bool IsPaid { get { return this.IsPaidHall(); } }


        public decimal? GetOnlyMoneyHall()
        {
            
            double? Tax;
            if (this.PercentTax == null)
            {
                Tax = 0;
            }
            else
            {
                Tax = this.PercentTax;
            }
            decimal? HallCost;
            if (this.Cost == null)
            {
                HallCost = this.CostRef_Halls;
            }
            else
            {
                HallCost = this.Cost;
            }
            decimal? Sum = HallCost * (1 + (Convert.ToDecimal(Tax) / 100));
            return Sum;
        }
        public decimal? GetOnlyMoneyHallBeforeTax()
        {           
            decimal? HallCost;
            if (this.Cost == null)
            {
                HallCost = this.CostRef_Halls;
            }
            else
            {
                HallCost = this.Cost;
            }
            decimal? Sum = HallCost;
            return Sum;
        }
        public decimal? GetMoneyListServiceUsed()
        {
            decimal? MoneyListServiceUsed = 0;
            foreach (ServiceUsedEN item in this.aListServiceUsed)
            {
                MoneyListServiceUsed = MoneyListServiceUsed + item.GetMoneyService();
            }
            return MoneyListServiceUsed;
        }
        public decimal? GetMoneyListServiceUsedBeforeTax()
        {
            decimal? MoneyListServiceUsedBeforeTax = 0;
            foreach (ServiceUsedEN item in this.aListServiceUsed)
            {
                MoneyListServiceUsedBeforeTax = MoneyListServiceUsedBeforeTax + item.GetMoneyServiceBeforeTax();
            }
            return MoneyListServiceUsedBeforeTax;
        }
        public decimal? GetTotalMoneyHall()
        {
            decimal? MoneyHall = this.GetMoneyListServiceUsed() + this.GetOnlyMoneyHall();
            return MoneyHall;
        }

        public decimal? GetMoneyHallBeforeTax()
        {
            decimal? MoneyHallBeforeTax = this.GetMoneyListServiceUsedBeforeTax() + this.GetOnlyMoneyHallBeforeTax();
            return MoneyHallBeforeTax;
        }
        public void SetCostServiceUsed(int IDBookingHallService, decimal Cost)
        {
            if(this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList().Count > 0)
            {
            this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList()[0].Cost = Cost;
            }
        }
        public void SetQuantityServiceUsed(int IDBookingHallService, double Quantity)
        {
            if (this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList().Count > 0)
            {
                this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList()[0].Quantity = Quantity;
            }
        }
        public bool IsPaidHall()
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
        public void ChangeTaxService(int IDBookingHallService, double Tax)
        {
            if (this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList().Count > 0)
            {
                this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList()[0].Tax = Tax;
            }
        }
        public decimal? GetMoneyListServiceUsedByIDGroupService(int IDGroupService)
        {
            List<ServiceUsedEN> aListTemp = this.aListServiceUsed.Where(a => a.IDServiceGroup == IDGroupService).ToList();
            decimal? MoneyListServiceUsed = 0;
            foreach (ServiceUsedEN item in aListTemp)
            {
                MoneyListServiceUsed = MoneyListServiceUsed + item.GetMoneyService();
            }
            return MoneyListServiceUsed;

        }
        public decimal? GetMoneyListServiceUsedNotPaid()
        {
            List<ServiceUsedEN> aListTemp = this.aListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
            decimal? MoneyListServiceUsed = 0;
            foreach (ServiceUsedEN item in aListTemp)
            {
                MoneyListServiceUsed = MoneyListServiceUsed + item.GetMoneyService();
            }
            return MoneyListServiceUsed;
        }
        public decimal? GetMoneyListServiceUsedNotPaidBeforeTax()
        {
            List<ServiceUsedEN> aListTemp = this.aListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
            decimal? MoneyListServiceUsedBeforeTax = 0;
            foreach (ServiceUsedEN item in aListTemp)
            {
                MoneyListServiceUsedBeforeTax = MoneyListServiceUsedBeforeTax + item.GetMoneyServiceBeforeTax();
            }
            return MoneyListServiceUsedBeforeTax;
        }
        public void DeleteServiceUsed(int IDBookingHallService)
        {
            DatabaseDA aDatabaseDA = new DatabaseDA();
            BookingHalls_Services aBookingHalls_Services = aDatabaseDA.BookingHalls_Services.Where(a => a.ID == IDBookingHallService).ToList()[0];
            if (aBookingHalls_Services != null)
            {
                aDatabaseDA.BookingHalls_Services.Remove(aBookingHalls_Services);
                aDatabaseDA.SaveChanges();
            }
        }
        public void Save()
        {
            try
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                BookingHalls aTemp = aDatabaseDA.BookingHalls.Where(a => a.ID == this.ID).ToList()[0];
                if (aTemp != null)
                {
                    aTemp.ID = this.ID;
                    aTemp.CodeHall = this.CodeHall;
                    aTemp.Cost = this.Cost;
                    aTemp.PercentTax = this.PercentTax;
                    aTemp.CostRef_Halls = this.CostRef_Halls;
                    aTemp.Date = this.Date;
                    aTemp.LunarDate = this.LunarDate;
                    aTemp.BookingStatus = this.BookingStatus;
                    aTemp.Unit = this.Unit;
                    aTemp.TableOrPerson = this.TableOrPerson;
                    aTemp.Note = this.Note;
                    aTemp.Status = this.Status;
                    aTemp.Location = this.Location;
                    aTemp.StartTime = this.StartTime;
                    aTemp.EndTime = this.EndTime;
                    aTemp.IsAllDayEvent = this.IsAllDayEvent;
                    aTemp.Color = this.Color;
                    aTemp.IsRecurring = this.IsRecurring;
                    aTemp.IsEditable = this.IsEditable;
                    aTemp.AdditionalColumn1 = this.AdditionalColumn1;
                    aTemp.IDBookingH = this.IDBookingH;
                    aTemp.IndexSubPayment = this.IndexSubPayment;
                    aTemp.AcceptDate = this.AcceptDate;
                    aTemp.InvoiceDate = this.InvoiceDate ;
                    aTemp.InvoiceNumber = this.InvoiceNumber; 

                    foreach (ServiceUsedEN item in this.aListServiceUsed)
                    {
                        item.Save(2);
                    }
                    aDatabaseDA.BookingHalls.AddOrUpdate(aTemp);
                    aDatabaseDA.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BookingHallUsedEN.Save :" + ex.Message.ToString()));
            }
        }
        public void SetValue(BookingHalls aTemp)
        {
            this.ID = aTemp.ID;
            this.CodeHall = aTemp.CodeHall;
            this.Cost = aTemp.Cost;
            this.PercentTax = aTemp.PercentTax;
            this.CostRef_Halls = aTemp.CostRef_Halls;
            this.Date = aTemp.Date;
            this.LunarDate = aTemp.LunarDate;
            this.BookingStatus = aTemp.BookingStatus;
            this.Unit = aTemp.Unit;
            this.TableOrPerson = aTemp.TableOrPerson;
            this.Note = aTemp.Note;
            this.Status = aTemp.Status;
            this.Location = aTemp.Location;
            this.StartTime = aTemp.StartTime;
            this.EndTime = aTemp.EndTime;
            this.IsAllDayEvent = aTemp.IsAllDayEvent;
            this.Color = aTemp.Color;
            this.IsRecurring = aTemp.IsRecurring;
            this.IsEditable = aTemp.IsEditable;
            this.AdditionalColumn1 = aTemp.AdditionalColumn1;
            this.IDBookingH = aTemp.IDBookingH;
            this.IndexSubPayment = aTemp.IndexSubPayment;
            this.AcceptDate = aTemp.AcceptDate;
            this.InvoiceDate = aTemp.InvoiceDate;
            this.InvoiceNumber = aTemp.InvoiceNumber;
            //this.TotalMoney = this.GetTotalMoneyHall();
            //this.MoneyHallBeforeTax = this.GetOnlyMoneyHallBeforeTax();
            //this.MoneyHall = this.GetOnlyMoneyHall();
        }
        public void ChangeIndexSubPaymentService(int IDBookingHallService, int Index)
        {
            this.aListServiceUsed.Where(a => a.IDBookingService == IDBookingHallService).ToList()[0].IndexSubPayment = Index;

        }
       



    }
}
