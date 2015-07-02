using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class BookingHallsEN : BookingHalls
    {
       
        public Nullable<int> CustomerType { get; set; }
        public string DisplayCustomerType { get; set; }    
        public string NameGuest { get; set; }     
        public Nullable<int> BookingTypeBookingH { get; set; }
        public string DisplayBookingType { get; set; }
        public Nullable<int> StatusPayBookingH { get; set; }        
        public Nullable<int> LevelBookingH { get; set; }
        public string DisplayLevel { get; set; }
        public string HallSku { get; set; }
        public Nullable<int> HallType { get; set; }
        public string DisplayHallType { get; set; }
        public string HasMenu { get; set; }
        public string DisplayTableOrPerson { get; set; }
        
    }
}
