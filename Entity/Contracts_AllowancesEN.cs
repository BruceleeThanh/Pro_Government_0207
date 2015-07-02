using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class Contracts_AllowancesEN
    {
        public Nullable<decimal> RealSalaryPlus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ApplyDate { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<bool> Disable { get; set; }
        public List<AllowancesEN> aListAllowances = new List<AllowancesEN>();
     
    }
}
