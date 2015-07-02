using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class BookingHallDetailEN : BookingHallsEN
    {
        public int IDMenu { get; set; }
        public string NameMenu { get; set; }
        public string NameCustomer { get; set; }
        public string NameCustomerGroup { get; set; }
        public List<Foods> aListFoods = new List<Foods>();
        public List<ServicesHallsEN> aListServicesHallsEN = new List<ServicesHallsEN>();
    }
}
