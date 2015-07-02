using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class RoomsEN : Rooms
    {
        public int IDBookingRooms { get; set; }

        public int IDBookingR { get; set; }

        public decimal? TotalMoney { get; set; }

        public string TypeDisplay { get; set; }


        public Nullable<decimal> Cost { get; set; }

        public Nullable<double> PercentTax { get; set; }

        public System.DateTime CheckInActual { get; set; }

        public System.DateTime CheckOutActual { get; set; }

        public Nullable<double> CostPendingRoom { get; set; }

        public Nullable<decimal> TimeInUse { get; set; }

        public Nullable<int> IndexSubPayment { get; set; }


        public Nullable<int> BookingRooms_Status { get; set; }

        public decimal? TotalCost
        {
            get
            {
                decimal? ret = 0;
                decimal? cost = 0;

                if (this.Cost == null)
                {
                    cost = this.CostRef;
                }
                else
                {
                    cost = this.Cost;
                }

                if (this.BookingRooms_Status == 3) //3:da checkIn
                {
                    decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse);
                    decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.PercentTax) / 100;
                    ret = ret + NotTax + Tax;
                }
                else if (this.BookingRooms_Status == 5) //5: pending
                {
                    decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.CostPendingRoom) / 100;
                    decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.CostPendingRoom) / 100 * Convert.ToDecimal(this.PercentTax) / 100;
                    ret = ret + NotTax + Tax;
                }
                else if (this.BookingRooms_Status == 7) //7: da checkOut nhung chua thanh toan
                {
                    decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse);
                    decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.PercentTax) / 100;
                    ret = ret + NotTax + Tax;
                }
                else if (this.BookingRooms_Status == 8) //7: da thanh toan
                {
                    decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse);
                    decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.PercentTax) / 100;
                    ret = ret + NotTax + Tax;
                }


                return ret;

            }
        }

        public decimal? TotalCostBeforeTax
        {
            get
            {
                decimal? ret = 0;
                decimal? cost = 0;

                if (this.Cost == null)
                {
                    cost = this.CostRef;
                }
                else
                {
                    cost = this.Cost;
                }
                if (this.BookingRooms_Status == 3) //3:da checkIn
                {
                    ret = cost * Convert.ToDecimal(this.TimeInUse);
                }
                else if (this.BookingRooms_Status == 5) //5: pending
                {
                    ret = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.CostPendingRoom) / 100;

                }
                else if (this.BookingRooms_Status == 7) //7: da checkOut nhung chua thanh toan
                {
                    ret = cost * Convert.ToDecimal(this.TimeInUse);
                }
                else if (this.BookingRooms_Status == 8) //7: da thanh toan
                {
                    ret = cost * Convert.ToDecimal(this.TimeInUse);
                }
                return ret;

            }
        }
    }
}
