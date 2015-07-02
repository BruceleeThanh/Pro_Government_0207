using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    /* LinhTN - Đối tượng dùng cho hàm ReceptionTaskBO.GetEfficiencyRoom */
    public class RevenueEN 
    {
        public string CodeRoom { get; set; }
        public string Sku { get; set; }
        public double Revenue { get; set; }
    }
}
