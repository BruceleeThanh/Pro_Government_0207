using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public  class BookingHEN : BookingHs
    {
        public string CustomerTypeDisplay { get; set; }
        public string TypeDisplay { get; set; }
        public string StatusPayDisplay { get; set; }
        public string StatusDisplay { get; set; }

        public void SetValue(BookingHs aBookingHs)
        {
            this.ID = aBookingHs.ID;
            this.CreatedDate = aBookingHs.CreatedDate;
            this.CustomerType = aBookingHs.CustomerType;
            this.BookingType = aBookingHs.BookingType;
            this.Note = aBookingHs.Note;
            this.IDGuest = aBookingHs.IDGuest;
            this.PayMenthod = aBookingHs.PayMenthod;
            this.StatusPay = aBookingHs.StatusPay;
            this.BookingMoney = aBookingHs.BookingMoney;
            this.ExchangeRate = aBookingHs.ExchangeRate;
            this.Status = aBookingHs.Status;
            this.Type = aBookingHs.Type;
            this.Disable = aBookingHs.Disable;
            this.Level = aBookingHs.Level;
            this.Subject = aBookingHs.Subject;
            this.Description = aBookingHs.Description;
            this.IDCustomer = aBookingHs.IDCustomer;
            this.IDCustomerGroup = aBookingHs.IDCustomerGroup;
            this.IDSystemUser = aBookingHs.IDSystemUser;
        }
    }
    
}
