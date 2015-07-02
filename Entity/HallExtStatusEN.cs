using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
   public class HallExtStatusEN : sp_HallExt_GetCurrentStatusHalls_ByIDHall_ByTime_Result
    {
       public int HallStatus;

      
       public HallExtStatusEN()
       {
         
           this.HallStatus = 0;
           this.Code = "0";

           this.ID = 0;

           this.CostRef = 0;
           this.Sku = "000";
           this.Note = "";
           this.Type = 0;
           this.BookingHalls_ID = 0;
           this.BookingHs_BookingMoney = 0;
           this.BookingHs_CustomerType = 0;
           this.BookingHs_ID = 0;
           this.BookingHs_Subject = "";
           this.Date = DateTime.Parse("01/01/1900");
           this.LunarDate = DateTime.Parse("01/01/1900");
           this.StartTime = TimeSpan.Parse("00:00:00");
           this.EndTime = TimeSpan.Parse("23:59:59");
           this.Color = true;
           this.Companies_Name = "";
           this.CostRef = 0;
           this.CustomerGroups_Name = "";
           this.Customers_Address = "";
           this.Customers_Name = "";
           this.Customers_Nationality = "";
           this.Customers_Tel = "";
           this.Location = "";
           this.NumTableMax = 0;
           this.NumTableStandard = 0;
           this.Unit = 0;
           this.TableOrPerson = 1; // 1:Table ; 2: Person 
       }

    }
}
