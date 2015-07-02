using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;



namespace Entity
{
    public class ServiceUsedEN
    {
        public int IDBookingService { get; set; }
        public int IDServiceGroup { get; set; }
        public string ServiceGroupName { get; set; } 
        public int IDService { get; set; }
        public string NameService { get; set; }
        public DateTime? DateUsed { get; set; }
        public double? Quantity { get; set; }
        public string Unit { get; set; }
        public decimal? Cost { get; set; }
        public decimal? CostRef_Service { get; set; }
        public double? Tax { get; set; }
        public int? StatusPay { get; set; }
        public string DisplayStatusPay { get; set; }
        public Nullable<int> IndexSubPayment { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public string Sku { get; set; }

        // Lỗi số lượng nhập được số âm
        public decimal? TotalMoney { 
            //get { return this.GetMoneyService(); } 
            get {
                if (this.Quantity >= 1) {
                    return this.GetMoneyService();
                }
                else {
                    return 0;
                }
            }
        }
        public decimal? TotalMoneyBeforeTax { 
            //get { return this.GetMoneyServiceBeforeTax(); } 
            get {
                if (this.Quantity >= 1) {
                    return this.GetMoneyServiceBeforeTax();
                }
                else {
                    return 0;
                }
            }
        }
        public decimal? MoneyTax { 
            //get { return this.TotalMoney - this.TotalMoneyBeforeTax; } 
            get {
                if (this.Quantity >= 1) {
                    return this.TotalMoney - this.TotalMoneyBeforeTax;
                }
                else {
                    return 0;
                }
            }
        }

        public bool IsPaid { get; set; }



        public decimal? GetMoneyService()
        {
            double? Quantity;
            if (this.Quantity == null)
            {
                Quantity = 0;
            }
            else
            {
                Quantity = this.Quantity;
            }
            double? Tax;
            if (this.Tax == null)
            {
               Tax = 0;
            }
            else
            {
                Tax = this.Tax;
            }
            decimal? ServiceCost;
            if (this.Cost == null)
            {
                ServiceCost = this.CostRef_Service;
            }
            else
            {
                ServiceCost = this.Cost;
            }
                       
            decimal? Sum = (ServiceCost * Convert.ToDecimal(Quantity)) * (1 + (Convert.ToDecimal(Tax) / 100));
            return Sum;
        }
        public decimal? GetMoneyServiceBeforeTax()
        {
            double? Quantity;
            if (this.Quantity == null)
            {
                Quantity = 0;
            }
            else
            {
                Quantity = this.Quantity;
            }
           
            decimal? ServiceCost;
            if (this.Cost == null)
            {
                ServiceCost = this.CostRef_Service;
            }
            else
            {
                ServiceCost = this.Cost;
            }

            decimal? Sum = ServiceCost * Convert.ToDecimal(Quantity);
            return Sum;
        }
        public bool IsPaidService()
        {
            if (this.StatusPay == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Save(int ServiceType)
        {
            try
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (ServiceType == 1)
                {

                   
                    if (aDatabaseDA.BookingRooms_Services.Where(b => b.ID == this.IDBookingService).ToList().Count > 0 )
                    {
                        BookingRooms_Services aTemp = aDatabaseDA.BookingRooms_Services.Where(b => b.ID == this.IDBookingService).ToList()[0];
                        aTemp.Cost = this.Cost;
                        aTemp.CostRef_Services = this.CostRef_Service;
                        aTemp.Date = this.DateUsed;
                        aTemp.PercentTax = this.Tax;
                        aTemp.Quantity = this.Quantity;
                        aTemp.Status = this.StatusPay;
                        aTemp.ID = this.IDBookingService;
                        aTemp.IndexSubPayment = this.IndexSubPayment;
                        aTemp.AcceptDate = this.AcceptDate;
                        aTemp.InvoiceDate = this.InvoiceDate;
                        aTemp.InvoiceNumber = this.InvoiceNumber;
                        aDatabaseDA.BookingRooms_Services.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                }
                else if (ServiceType == 2)
                {
                    if (aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.IDBookingService).ToList().Count > 0)
                    {
                        BookingHalls_Services aTemp = aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.IDBookingService).ToList()[0];
                        aTemp.Cost = this.Cost;
                        aTemp.CostRef_Services = this.CostRef_Service;
                        aTemp.Date = this.DateUsed;
                        aTemp.PercentTax = this.Tax;
                        aTemp.Quantity = this.Quantity;
                        aTemp.Status = this.StatusPay;
                        aTemp.ID = this.IDBookingService;
                        aTemp.IndexSubPayment = this.IndexSubPayment;
                        aTemp.AcceptDate = this.AcceptDate;
                        aTemp.InvoiceDate = this.InvoiceDate;
                        aTemp.InvoiceNumber = this.InvoiceNumber;
                        aDatabaseDA.BookingHalls_Services.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServiceUsedEN.Save :" + ex.Message.ToString()));
            }
        }



       
    }
}
