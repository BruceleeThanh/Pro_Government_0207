using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Entity
{
   public class NewBookingHEN : BookingHs
    {
       public List<NewBookingHallEN> aListBookingHallUsed = new List<NewBookingHallEN>();
        public string PhoneNumber { get; set; }

    }
}
