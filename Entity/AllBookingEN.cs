using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class AllBookingEN : sp_BookingExt_GetAllBooking_Result
    {
       public Nullable<decimal> TotalMoney { get; set; }
       public Nullable<decimal> TotalMoneyBeforeTax { get; set; }
       public Nullable<decimal> Tax { get; set; }
      
       public string StatusPayDisplay { get; set; }

        public void SetValue(sp_BookingExt_GetAllBooking_Result asp_BookingExt_GetAllBooking_Result)
        {
            this.ID = asp_BookingExt_GetAllBooking_Result.ID;
            this.InvoiceNumber	=	asp_BookingExt_GetAllBooking_Result.InvoiceNumber;
            this.DatePay = asp_BookingExt_GetAllBooking_Result.DatePay.GetValueOrDefault().Date;
                this.InvoiceDate	=	asp_BookingExt_GetAllBooking_Result.InvoiceDate.GetValueOrDefault().Date;
                this.Subject	=	asp_BookingExt_GetAllBooking_Result.Subject;
                this.StatusPay	=	asp_BookingExt_GetAllBooking_Result.StatusPay;
                this.PayMenthod	=	asp_BookingExt_GetAllBooking_Result.PayMenthod;
                this.Companies_Name	=	asp_BookingExt_GetAllBooking_Result.Companies_Name;
                this.CustomerGroups_Name	=	asp_BookingExt_GetAllBooking_Result.CustomerGroups_Name;
                this.Customers_Name	=	asp_BookingExt_GetAllBooking_Result.Customers_Name;
                this.Customers_Type	=	asp_BookingExt_GetAllBooking_Result.Customers_Type;
                this.RoomsInvoiceNotTax = asp_BookingExt_GetAllBooking_Result.RoomsInvoiceNotTax.GetValueOrDefault(0);
                this.RoomsInvoiceTax = asp_BookingExt_GetAllBooking_Result.RoomsInvoiceTax.GetValueOrDefault(0);
                this.ServiceRooms1_NotTax	=	asp_BookingExt_GetAllBooking_Result.ServiceRooms1_NotTax.GetValueOrDefault(0);
                this.ServiceRooms1_Tax	=	asp_BookingExt_GetAllBooking_Result.ServiceRooms1_Tax.GetValueOrDefault(0);
                this.ServiceRooms2_NotTax	=	asp_BookingExt_GetAllBooking_Result.ServiceRooms2_NotTax.GetValueOrDefault(0);
                this.ServiceRooms2_Tax	=	asp_BookingExt_GetAllBooking_Result.ServiceRooms2_Tax.GetValueOrDefault(0);
                this.ServiceRooms3_NotTax	=	asp_BookingExt_GetAllBooking_Result.ServiceRooms3_NotTax.GetValueOrDefault(0);
                this.ServiceRooms3_Tax	=	asp_BookingExt_GetAllBooking_Result.ServiceRooms3_Tax.GetValueOrDefault(0);
                this.HallsInvoiceNotTax	=	asp_BookingExt_GetAllBooking_Result.HallsInvoiceNotTax.GetValueOrDefault(0);
                this.HallsInvoiceTax	=	asp_BookingExt_GetAllBooking_Result.HallsInvoiceTax.GetValueOrDefault(0);
                this.ServiceHalls1_NotTax	=	asp_BookingExt_GetAllBooking_Result.ServiceHalls1_NotTax.GetValueOrDefault(0);
                this.ServiceHalls1_Tax	=	asp_BookingExt_GetAllBooking_Result.ServiceHalls1_Tax.GetValueOrDefault(0);
                this.ServiceHalls2_NotTax	=	asp_BookingExt_GetAllBooking_Result.ServiceHalls2_NotTax.GetValueOrDefault(0);
                this.ServiceHalls2_Tax	=	asp_BookingExt_GetAllBooking_Result.ServiceHalls2_Tax.GetValueOrDefault(0);
                this.ServiceHalls3_NotTax	=	asp_BookingExt_GetAllBooking_Result.ServiceHalls3_NotTax.GetValueOrDefault(0);
                this.ServiceHalls3_Tax	=	asp_BookingExt_GetAllBooking_Result.ServiceHalls3_Tax.GetValueOrDefault(0);

        }

            
    }
}
