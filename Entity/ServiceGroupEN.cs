using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServiceGroupEN
    {
        public int IDServiceGroup { get; set; }
        public string Sku { get; set; }
        public string ServiceGroupName { get; set; }
        //Hiennv 04/11/2014 dung de hien thi tien thue
        public decimal? DisplayMoneyTax { get; set; }
        public decimal? TotalMoneyBeforeTax { get; set; }
        public decimal? TotalMoneyAfterTax { get; set; }

    }
}
