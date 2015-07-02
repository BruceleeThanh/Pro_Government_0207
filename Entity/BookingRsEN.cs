using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class BookingRsEN : vw__PaymentInfo__BookingRs_BookingRooms_Customers
    {
        public string CustomerTypeDisplay { get; set; }
        public string StatusDisplay { get; set; }
        public void SetValue(vw__PaymentInfo__BookingRs_BookingRooms_Customers item)
        {
            this.BookingRooms_CheckInActual = item.BookingRooms_CheckInActual;
            this.BookingRooms_CheckInPlan = item.BookingRooms_CheckInPlan;
            this.BookingRooms_CheckOutActual = item.BookingRooms_CheckOutActual;
            this.BookingRooms_CheckOutPlan = item.BookingRooms_CheckOutPlan;
            this.BookingRs_CreatedDate = item.BookingRs_CreatedDate;
            this.CustomerGroups_Name = item.CustomerGroups_Name;
            this.Customers_Name = item.Customers_Name;
            this.BookingRs_Status = item.BookingRs_Status;
            this.Rooms_Sku = item.Rooms_Sku;
            this.BookingRs_ID = item.BookingRs_ID;
            this.BookingRs_Subject = item.BookingRs_Subject;
            this.BookingRooms_ID = item.BookingRooms_ID;
            this.CustomerGroups_ID = item.CustomerGroups_ID;
            this.CustomerGroups_IDCompany = item.CustomerGroups_IDCompany;
            this.Customers_ID = item.Customers_ID;
         
        }
    }
}
