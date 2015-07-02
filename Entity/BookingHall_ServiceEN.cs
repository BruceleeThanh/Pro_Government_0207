using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class BookingHall_ServiceEN : BookingHalls_Services
    {
        public string Service_Name { get; set; }
        public string Service_Unit { get; set; }

        // Lỗi số lượng nhập được số âm
        public decimal? Sum { 
            //get { return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) * (decimal)(this.PercentTax.GetValueOrDefault(0) / 100 + 1); } 
            get {
                if (this.Quantity < 1) {
                    DatabaseDA aDatabaseDA = new DatabaseDA();
                    if (aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.ID).ToList().Count > 0) {
                        this.Quantity = aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.ID).ToList()[0].Quantity;
                    }
                    else {
                        this.Quantity = 1;
                    }
                }
                return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) * (decimal)(this.PercentTax.GetValueOrDefault(0) / 100 + 1);
            }
        }
        public decimal? SumBeforeTax { 
            //get { return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) ; } 
            get {
                if (this.Quantity < 1) {
                    DatabaseDA aDatabaseDA = new DatabaseDA();
                    if (aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.ID).ToList().Count > 0) {
                        this.Quantity = aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.ID).ToList()[0].Quantity;
                    }
                    else {
                        this.Quantity = 1;
                    }
                }
                return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0));
            }
        }
        public decimal? SumTax { 
            //get { return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) * (decimal)(this.PercentTax.GetValueOrDefault(0) / 100); } 
            get {
                if (this.Quantity < 1) {
                    DatabaseDA aDatabaseDA = new DatabaseDA();
                    if (aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.ID).ToList().Count > 0) {
                        this.Quantity = aDatabaseDA.BookingHalls_Services.Where(b => b.ID == this.ID).ToList()[0].Quantity;
                    }
                    else {
                        this.Quantity = 1;
                    }
                }
                return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) * (decimal)(this.PercentTax.GetValueOrDefault(0) / 100);
            }
        }
    }
}
