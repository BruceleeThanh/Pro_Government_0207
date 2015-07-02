using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class CalculatorSalaryEN : CalculatorSalaries
    {
        public string SystemUser { get; set; }
        public void SetValue(CalculatorSalaries aCalculatorSalaries)
        {
            this.ID = aCalculatorSalaries.ID;
            this.SkuTableSalary = aCalculatorSalaries.SkuTableSalary;
            this.Coefficent = aCalculatorSalaries.Coefficent;
            this.StartDate = aCalculatorSalaries.StartDate;
            this.EndDate = aCalculatorSalaries.EndDate;
            this.Status = aCalculatorSalaries.Status;
            this.Type = aCalculatorSalaries.Type;
            this.Disable = aCalculatorSalaries.Disable;
            this.IDSystemUser = aCalculatorSalaries.IDSystemUser;
            
        }
    }
}
