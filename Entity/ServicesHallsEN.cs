using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class ServicesHallsEN : BookingHalls_Services
    {
       
        public string CodeHall { get; set; }
        public string SkuHall { get; set; }
        public string NameService { get; set; }
        public Nullable<int> IndexSubServices { get; set; }
        public int IDBookingHallService { get; set; }
        public decimal? Total
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
                if (this.Cost == null || this.Cost == 0)
                {
                    ServiceCost = this.CostRef_Services;
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
                if (this.Cost == null || this.Cost == 0)
                {
                    ServiceCost = this.CostRef_Services;
                }
                else
                {
                    ServiceCost = this.Cost;
                }
                return (ServiceCost * Convert.ToDecimal(Quantity));

            }
        }
    }
}
