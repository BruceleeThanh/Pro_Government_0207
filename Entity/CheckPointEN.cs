using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Entity
{
   public class CheckPointEN : CheckPoints
    {
        public string TypeDisplay { get; set; }
        public void SetValue ( CheckPoints aChekPoint)
        {
            this.ID = aChekPoint.ID;
            this.From = aChekPoint.From;
            this.To = aChekPoint.To;
            this.Type = aChekPoint.Type;
            this.Status = aChekPoint.Status;
            this.AddTime = aChekPoint.AddTime;
            this.Disable = aChekPoint.Disable;
        }

    }
}
