using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /* LinhTN - Đối tượng dùng cho hàm ReceptionTaskBO.GetEfficiencyRoom */
    public class EfficiencyEN
    {
        public string CodeRoom { get; set; }
        public string Sku { get; set; }
        public double Efficiency { get; set; }
    }
}
