using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Entity
{
   public class HallsEN : Halls
    {
        public string TypeDisplay { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<int> TableOrPerson { get; set; }
        public string DisplayTableOrPerson { get; set; }
        public int IDBookingHall { get; set; }


        public int IDBookingH { get; set; }
        public string CodeHall { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> PercentTax { get; set; }
        public Nullable<decimal> CostRef_Halls { get; set; }
        public decimal? TotalMoney { get; set; }

        public Nullable<int> IndexSubHalls { get; set; }
       
       public void SetValue(Halls aHalls)
        {
            this.Code = aHalls.Code;
            this.CostRef = aHalls.CostRef;
            this.CostUnit = aHalls.CostUnit;
            this.Disable = aHalls.Disable;
            this.ID = aHalls.ID;
            this.IDLang = aHalls.IDLang;
            this.Image = aHalls.Image;
            this.Info = aHalls.Info;
            this.Intro = aHalls.Intro;
            this.NumTableMax = aHalls.NumTableMax;
            this.NumTableStandard = aHalls.NumTableStandard;
            this.Sku = aHalls.Sku;
            this.Type = aHalls.Type;
            this.Status = aHalls.Status;

        }

       public decimal? TotalCost
       {
           get
           {
               decimal? cost = 0;

               if (this.Cost == null)
               {
                   cost = this.CostRef;
               }
               else
               {
                   cost = this.Cost;
               }

               return (cost + cost * Convert.ToDecimal(this.PercentTax) / 100);

           }
       }

       public decimal? TotalCostBeforeTax
       {
           get
           {
               decimal? cost = 0;

               if (this.Cost == null)
               {
                   cost = this.CostRef;
               }
               else
               {
                   cost = this.Cost;
               }

               return cost;

           }
       }
    }
}
