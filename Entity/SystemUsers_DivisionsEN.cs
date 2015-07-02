using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class SystemUsers_DivisionsEN
    {
        public DateTime AvaiableDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public bool Disable { get; set; }
        public List<DivisionsEN> aListDivisionsEN = new List<DivisionsEN>();
        

    }
}
