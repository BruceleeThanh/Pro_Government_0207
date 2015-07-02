using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class BookingRStatusPayViewEN
    {
        public string NameCompany { get; set; }
        public string BookingRStatusPayDisplay { get; set; }
        public string CustomerTypeDisplay { get; set; }

        public int IDBookingR { get; set; }
        public string Subject { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<int> IDCustomer { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<int> IDCustomerGroup { get; set; }
        public string CustomerGroups_Name { get; set; }
        public Nullable<int> StatusPay { get; set; }      
        public Nullable<decimal> BookingMoney { get; set; }
        public int IDBookingRoom { get; set; }
        public string Sku { get; set; }
        public Nullable<decimal>CostRef_Rooms { get; set; }
        public Nullable<int> BookingStatus { get; set; }


        public Nullable<int> BookingRs_Status { get; set; }
        public Nullable<int> IDBookingH { get; set; }
        public Nullable<int> BookingHs_Status { get; set; }
        public Nullable<int> BookingHs_StatusPay { get; set; }
        public Nullable<int> BookingHs_Type { get; set; }
        public Nullable<bool> BookingHs_Disable { get; set; }
        public string BookingHs_Subject { get; set; }

        public Nullable<DateTime> CheckInActual { get; set; }
        public Nullable<DateTime> CheckOut { get; set; }
        public string BookingRooms_CodeRoom { get; set; }
        public Nullable<int> BookingRooms_Status { get; set; }
        public string BookingRoomStatusPayDisplay { get; set; }


    }


}


