using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class InfoDetailPaymentHallsEN
    {
        public BookingHalls aBookingHalls = new BookingHalls();
        public string Sku { get; set; }
        public Nullable<int> IndexSubHalls { get; set; }
        public MenusEN aMenusEN = new MenusEN();
        public List<ServicesHallsEN> aListServicesHallsEN = new List<ServicesHallsEN>();
    }
}
