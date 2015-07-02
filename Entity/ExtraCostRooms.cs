using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ExtraCostRooms
    {
        public int ID { get; set; }
        public string Sku { set; get; }
        public decimal ExtraValue { get; set; }
        public int NumberPepole { get; set; }
        public int CustomerType { set; get; }
        public string DisplayCustomerType { set; get; }
        public string PriceType { set; get; }

    }
}
