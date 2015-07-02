using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class RoomServiceInfoEN
    {
         
        public int IDBookingRs { get; set; }
        public int IDBookingRooms { get; set; }

        public string Sku { get; set; }
        public string CodeRoom { get; set; }

        public int IDService { get; set; }
        public string ServiceName { get; set; }
        public Double? Quantity { get; set; }
        public string Unit { get; set; }
        public Decimal? CostRef { get; set; }
        public Decimal? Cost { get; set; }
        public Double? PercentTax { get; set; }
        public DateTime? Date { get; set; }
        public int IDServiceGroup { get; set; }
        public int ID { get; set; }
        public Nullable<int> Status { get; set; }

    }
}
