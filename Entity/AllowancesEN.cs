using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class AllowancesEN:Allowances
    {
        public List<Contracts> aListContracts = new List<Contracts>();
    }
}
