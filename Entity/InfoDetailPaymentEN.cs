using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class InfoDetailPaymentEN
    {
        public BookingRooms aBookingRooms = new BookingRooms();
        public Nullable<int> IndexSubRooms { get; set; }
        public string Sku { get; set; }
        public double? DateInUse = 0;
        public DateTime CheckOut = new DateTime();
        public List<Customers> aListCustomer = new List<Customers>();
        public List<ServicesEN> aListService = new List<ServicesEN>();
    }
}
