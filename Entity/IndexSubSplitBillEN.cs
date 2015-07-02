using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IndexSubSplitBillEN
    {
        public int ID { get; set; }
        public int IndexSub { get; set; }
        public Nullable<decimal> SubBookingMoney { get; set; }
        public Nullable<int> SubStatus { get; set; }
    }
}
