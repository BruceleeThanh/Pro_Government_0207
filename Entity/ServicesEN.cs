using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServicesEN
    {
        public int BookingRooms_Services_ID { get; set; }
        public int IDBookingRoomService { get; set; }
        public int IDBookingRoom { get; set; }
        public string CodeRoom { get; set; }
        public int IDService { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public double? Quantity { get; set; }
        public decimal? Cost { get; set; }
        public decimal? CostRef_Service { get; set; }
        public double? PercentTax { get; set; }
        public int IDServiceGroup { get; set; }
        public string ServiceGroupName { get; set; }

        public Nullable<int> IndexSubPayment { get; set; }
        
        public decimal? TotalCost
        {

            get
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
                double? PercentTax;
                if (this.PercentTax == null)
                {
                    PercentTax = 0;
                }
                else
                {
                    PercentTax = this.PercentTax;
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

                decimal? NotTax = ServiceCost * Convert.ToDecimal(Quantity);
                decimal? Tax = NotTax * Convert.ToDecimal(PercentTax) / 100;
                decimal? Sum = NotTax + Tax;
                return Sum;

            }
        }

        public decimal? TotalBeforeTax
        {
            get
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
                double? PercentTax;
                if (this.PercentTax == null)
                {
                    PercentTax = 0;
                }
                else
                {
                    PercentTax = this.PercentTax;
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
        }

        public string Sku { get; set; }
    }
}
