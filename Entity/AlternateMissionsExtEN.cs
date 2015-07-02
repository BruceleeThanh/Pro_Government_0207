using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class AlternateMissionsExtEN : AlternateMissions
    {
        //public AlternateMissionsExtEN(string Username, string Name, string Country, DateTime? CreatedDate, DateTime? DecisionDate, string DecisionLevel, string Description, bool? Disable, DateTime? FromDate, int IDSystemUser)
        //{
        //    this.Username = Username;
        //    this.Name = Name;
        //    this.Country = Country;
        //    this.CreatedDate = CreatedDate;
        //    this.DecisionDate = DecisionDate;
        //    this.DecisionLevel = DecisionLevel;
        //    this.Description = Description;
        //    this.Disable = Disable;
        //    this.FromDate = FromDate;
        //    this.IDSystemUser = IDSystemUser;

          
        //}
        public string Username { set; get; }
        public string Name { set; get; }
    }
}
