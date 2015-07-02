using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class InfoSystemUserLiftSalaryEN : SystemUsers
    {
        public string SkuTableSalary { get; set; }
        public Nullable<double> Coefficent { get; set; }
        public Nullable<decimal> SalaryNet { get; set; }
        public Nullable<decimal> SalaryCross { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string DisplayGender { get; set; }
    }
}
